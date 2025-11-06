using GestionConges.Data;
using Microsoft.Data.SqlClient;
using System;
using System.Windows.Forms;

namespace GestionConges.Forms
{
    public partial class frmLogin : Form
    {
        public int? UtilisateurId { get; private set; }
        public bool EstAdministrateur { get; private set; }

        public frmLogin()
        {
            InitializeComponent();
        }

        private void btnConnexion_Click(object sender, EventArgs e)
        {
            string login = txtLogin.Text.Trim();
            string mdp = txtMdp.Text;

            if (string.IsNullOrEmpty(login) || string.IsNullOrEmpty(mdp))
            {
                MessageBox.Show("Veuillez remplir tous les champs.", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using var conn = new SqlConnection(DatabaseHelper.ConnectionString);
                conn.Open();

                string query = @"
                    SELECT id, idAdmin 
                    FROM gsb_praticien_ouf_utilisateur 
                    WHERE nom = @login AND mdp = @mdp";

                using var cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@login", login);
                cmd.Parameters.AddWithValue("@mdp", mdp);

                using var reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    UtilisateurId = reader.GetInt32(0);
                    EstAdministrateur = reader.GetInt32(1) == 1;

                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Identifiants incorrects.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur de connexion : " + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAnnuler_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void chkAfficherMdp_CheckedChanged(object sender, EventArgs e)
        {
            txtMdp.UseSystemPasswordChar = !chkAfficherMdp.Checked;
        }
    }
}