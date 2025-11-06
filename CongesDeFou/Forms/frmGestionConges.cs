using GestionConges.Entities;
using GestionConges.IServices;
using GestionConges.Services;
using GestionConges.Data;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace GestionConges.Forms
{
    public partial class frmGestionConges : Form
    {
        private readonly ICongeService _congeService;
        private List<Conge> _conges;
        public int? UtilisateurId { get; set; }
        public bool EstAdministrateur { get; set; } = false;
        public frmGestionConges()
        {
            InitializeComponent();
            _congeService = new CongeService(DatabaseHelper.ConnectionString);
            if (!EstAdministrateur)
            {
                btnAccepter.Enabled = false;
                btnRefuser.Enabled = false;

                btnAnnuler.Enabled = false;
                btnAjouter.Enabled = true;
            }
            ChargerConges();
        }

        private void ChargerConges()
        {
            try
            {
                _conges = UtilisateurId.HasValue && !EstAdministrateur
                    ? _congeService.GetCongesByPraticien(UtilisateurId.Value)
                    : _congeService.GetAllConges();

                dgvConges.DataSource = null;
                dgvConges.DataSource = _conges;
                ConfigurerColonnes();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur : " + ex.Message);
            }
        }

        private void ConfigurerColonnes()
        {
            if (dgvConges.Columns["Id"] != null)
                dgvConges.Columns["Id"].HeaderText = "ID";

            if (dgvConges.Columns["IdUtilisateur"] != null)
                dgvConges.Columns["IdUtilisateur"].HeaderText = "ID Utilisateur";

            if (dgvConges.Columns["DateDebut"] != null)
            {
                dgvConges.Columns["DateDebut"].HeaderText = "Début";
                dgvConges.Columns["DateDebut"].DefaultCellStyle.Format = "dd/MM/yyyy";
            }

            if (dgvConges.Columns["DateFin"] != null)
            {
                dgvConges.Columns["DateFin"].HeaderText = "Fin";
                dgvConges.Columns["DateFin"].DefaultCellStyle.Format = "dd/MM/yyyy";
            }

            if (dgvConges.Columns["EtatConge"] != null)
                dgvConges.Columns["EtatConge"].HeaderText = "État";

            if (dgvConges.Columns["Motif"] != null)
                dgvConges.Columns["Motif"].Visible = false;
        }

        private void btnAjouter_Click(object sender, EventArgs e)
        {
            using var frm = new frmNouveauConge();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                if (_congeService.AjouterConge(frm.Conge))
                {
                    MessageBox.Show("Congé ajouté avec succès.", "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ChargerConges();
                }
            }
        }

        private void btnAccepter_Click(object sender, EventArgs e) => MettreAJourEtat("Accepté");
        private void btnRefuser_Click(object sender, EventArgs e) => MettreAJourEtat("Refusé");
        private void btnAnnuler_Click(object sender, EventArgs e) => MettreAJourEtat("Annulé");

        private void MettreAJourEtat(string etat)
        {
            if (dgvConges.SelectedRows.Count == 0)
            {
                MessageBox.Show("Veuillez sélectionner un congé.", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int id = (int)dgvConges.SelectedRows[0].Cells["Id"].Value;
            bool success = false;

            switch (etat)
            {
                case "Accepté": success = _congeService.AccepterConge(id); break;
                case "Refusé": success = _congeService.RefuserConge(id); break;
                case "Annulé": success = _congeService.AnnulerConge(id); break;
            }

            if (success)
            {
                MessageBox.Show($"Congé {etat.ToLower()}.", "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ChargerConges();
            }
            else
            {
                MessageBox.Show("Échec de la mise à jour.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnActualiser_Click(object sender, EventArgs e) => ChargerConges();
    }
}