namespace GestionConges.Forms
{
    partial class frmGestionConges
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.dgvConges = new System.Windows.Forms.DataGridView();
            this.btnAjouter = new System.Windows.Forms.Button();
            this.btnAccepter = new System.Windows.Forms.Button();
            this.btnRefuser = new System.Windows.Forms.Button();
            this.btnAnnuler = new System.Windows.Forms.Button();
            this.btnActualiser = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.dgvConges)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvConges
            // 
            this.dgvConges.AllowUserToAddRows = false;
            this.dgvConges.AllowUserToDeleteRows = false;
            this.dgvConges.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvConges.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvConges.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvConges.Location = new System.Drawing.Point(0, 60);
            this.dgvConges.Name = "dgvConges";
            this.dgvConges.ReadOnly = true;
            this.dgvConges.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvConges.Size = new System.Drawing.Size(800, 390);
            this.dgvConges.TabIndex = 0;
            // 
            // btnAjouter
            // 
            this.btnAjouter.Location = new System.Drawing.Point(12, 12);
            this.btnAjouter.Name = "btnAjouter";
            this.btnAjouter.Size = new System.Drawing.Size(100, 36);
            this.btnAjouter.TabIndex = 1;
            this.btnAjouter.Text = "Ajouter";
            this.btnAjouter.UseVisualStyleBackColor = true;
            this.btnAjouter.Click += new System.EventHandler(this.btnAjouter_Click);
            // 
            // btnAccepter
            // 
            this.btnAccepter.Location = new System.Drawing.Point(118, 12);
            this.btnAccepter.Name = "btnAccepter";
            this.btnAccepter.Size = new System.Drawing.Size(90, 36);
            this.btnAccepter.TabIndex = 2;
            this.btnAccepter.Text = "Accepter";
            this.btnAccepter.UseVisualStyleBackColor = true;
            this.btnAccepter.Click += new System.EventHandler(this.btnAccepter_Click);
            // 
            // btnRefuser
            // 
            this.btnRefuser.Location = new System.Drawing.Point(214, 12);
            this.btnRefuser.Name = "btnRefuser";
            this.btnRefuser.Size = new System.Drawing.Size(90, 36);
            this.btnRefuser.TabIndex = 3;
            this.btnRefuser.Text = "Refuser";
            this.btnRefuser.UseVisualStyleBackColor = true;
            this.btnRefuser.Click += new System.EventHandler(this.btnRefuser_Click);
            // 
            // btnAnnuler
            // 
            this.btnAnnuler.Location = new System.Drawing.Point(310, 12);
            this.btnAnnuler.Name = "btnAnnuler";
            this.btnAnnuler.Size = new System.Drawing.Size(90, 36);
            this.btnAnnuler.TabIndex = 4;
            this.btnAnnuler.Text = "Annuler";
            this.btnAnnuler.UseVisualStyleBackColor = true;
            this.btnAnnuler.Click += new System.EventHandler(this.btnAnnuler_Click);
            // 
            // btnActualiser
            // 
            this.btnActualiser.Location = new System.Drawing.Point(688, 12);
            this.btnActualiser.Name = "btnActualiser";
            this.btnActualiser.Size = new System.Drawing.Size(100, 36);
            this.btnActualiser.TabIndex = 5;
            this.btnActualiser.Text = "Actualiser";
            this.btnActualiser.UseVisualStyleBackColor = true;
            this.btnActualiser.Click += new System.EventHandler(this.btnActualiser_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnActualiser);
            this.panel1.Controls.Add(this.btnAnnuler);
            this.panel1.Controls.Add(this.btnRefuser);
            this.panel1.Controls.Add(this.btnAccepter);
            this.panel1.Controls.Add(this.btnAjouter);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(800, 60);
            this.panel1.TabIndex = 6;
            // 
            // frmGestionConges
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dgvConges);
            this.Controls.Add(this.panel1);
            this.Name = "frmGestionConges";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Gestion des Congés - GSB Praticien";
            ((System.ComponentModel.ISupportInitialize)(this.dgvConges)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.DataGridView dgvConges;
        private System.Windows.Forms.Button btnAjouter;
        private System.Windows.Forms.Button btnAccepter;
        private System.Windows.Forms.Button btnRefuser;
        private System.Windows.Forms.Button btnAnnuler;
        private System.Windows.Forms.Button btnActualiser;
        private System.Windows.Forms.Panel panel1;
    }
}