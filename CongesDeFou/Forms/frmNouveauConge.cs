using GestionConges.Entities;
using System;
using System.Windows.Forms;

namespace GestionConges.Forms
{
    public partial class frmNouveauConge : Form
    {
        public Conge Conge { get; private set; }

        public frmNouveauConge()
        {
            InitializeComponent();
            dtpDebut.Value = DateTime.Today;
            dtpFin.Value = DateTime.Today.AddDays(1);
        }

        private void btnValider_Click(object sender, EventArgs e)
        {
            if (dtpDebut.Value.Date > dtpFin.Value.Date)
            {
                MessageBox.Show("La date de début doit être antérieure ou égale à la date de fin.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (numPraticienId.Value <= 0)
            {
                MessageBox.Show("Veuillez entrer un ID utilisateur valide.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Conge = new Conge
            {
                IdUtilisateur = (int)numPraticienId.Value,
                DateDebut = dtpDebut.Value.Date,
                DateFin = dtpFin.Value.Date,
                Motif = txtMotif.Text.Trim(),
                EtatConge = "Attente"
            };

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnAnnuler_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}