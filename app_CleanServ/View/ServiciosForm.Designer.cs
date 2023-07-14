namespace app_CleanServ.View
{
    partial class ServiciosForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblServicios = new MetroFramework.Controls.MetroLabel();
            this.dgvServicios = new System.Windows.Forms.DataGridView();
            this.metroProgressSpinner1 = new MetroFramework.Controls.MetroProgressSpinner();
            ((System.ComponentModel.ISupportInitialize)(this.dgvServicios)).BeginInit();
            this.SuspendLayout();
            // 
            // lblServicios
            // 
            this.lblServicios.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblServicios.AutoSize = true;
            this.lblServicios.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.lblServicios.FontWeight = MetroFramework.MetroLabelWeight.Bold;
            this.lblServicios.Location = new System.Drawing.Point(331, 23);
            this.lblServicios.Name = "lblServicios";
            this.lblServicios.Size = new System.Drawing.Size(88, 25);
            this.lblServicios.Style = MetroFramework.MetroColorStyle.Black;
            this.lblServicios.TabIndex = 0;
            this.lblServicios.Text = "Servicios";
            this.lblServicios.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // dgvServicios
            // 
            this.dgvServicios.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvServicios.Location = new System.Drawing.Point(12, 70);
            this.dgvServicios.Name = "dgvServicios";
            this.dgvServicios.Size = new System.Drawing.Size(755, 631);
            this.dgvServicios.TabIndex = 1;
            // 
            // metroProgressSpinner1
            // 
            this.metroProgressSpinner1.Location = new System.Drawing.Point(331, 220);
            this.metroProgressSpinner1.Maximum = 100;
            this.metroProgressSpinner1.Name = "metroProgressSpinner1";
            this.metroProgressSpinner1.Size = new System.Drawing.Size(67, 58);
            this.metroProgressSpinner1.TabIndex = 2;
            this.metroProgressSpinner1.UseSelectable = true;
            // 
            // ServiciosForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(250)))), ((int)(((byte)(245)))));
            this.ClientSize = new System.Drawing.Size(782, 739);
            this.Controls.Add(this.metroProgressSpinner1);
            this.Controls.Add(this.dgvServicios);
            this.Controls.Add(this.lblServicios);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ServiciosForm";
            this.Text = "ServiciosForm";
            this.Load += new System.EventHandler(this.ServiciosForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvServicios)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MetroFramework.Controls.MetroLabel lblServicios;
        private System.Windows.Forms.DataGridView dgvServicios;
        private MetroFramework.Controls.MetroProgressSpinner metroProgressSpinner1;
    }
}