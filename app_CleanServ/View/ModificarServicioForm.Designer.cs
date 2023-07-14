namespace app_CleanServ.View
{
    partial class ModificarServicioForm
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
            this.lblIdServicio = new MetroFramework.Controls.MetroLabel();
            this.txtID = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.metroLabel8 = new MetroFramework.Controls.MetroLabel();
            this.txtPrecioServicio = new System.Windows.Forms.NumericUpDown();
            this.metroLabel7 = new MetroFramework.Controls.MetroLabel();
            this.txtPagoTrabajador = new System.Windows.Forms.NumericUpDown();
            this.metroLabel6 = new MetroFramework.Controls.MetroLabel();
            this.txtComision = new System.Windows.Forms.NumericUpDown();
            this.metroLabel5 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel4 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel3 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel2 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.txtNumeroHoras = new System.Windows.Forms.NumericUpDown();
            this.txtFechaServicio = new MetroFramework.Controls.MetroDateTime();
            this.cbxTrabajador = new MetroFramework.Controls.MetroComboBox();
            this.btnGuardar = new MetroFramework.Controls.MetroButton();
            this.txtHoraDeInicio = new System.Windows.Forms.DateTimePicker();
            this.txtHoraFin = new System.Windows.Forms.DateTimePicker();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtPrecioServicio)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPagoTrabajador)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtComision)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNumeroHoras)).BeginInit();
            this.SuspendLayout();
            // 
            // lblIdServicio
            // 
            this.lblIdServicio.AutoSize = true;
            this.lblIdServicio.FontWeight = MetroFramework.MetroLabelWeight.Bold;
            this.lblIdServicio.Location = new System.Drawing.Point(3, 0);
            this.lblIdServicio.Name = "lblIdServicio";
            this.lblIdServicio.Size = new System.Drawing.Size(82, 19);
            this.lblIdServicio.TabIndex = 0;
            this.lblIdServicio.Text = "ID Servicio";
            // 
            // txtID
            // 
            this.txtID.BackColor = System.Drawing.Color.White;
            this.txtID.Enabled = false;
            this.txtID.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtID.Location = new System.Drawing.Point(176, 3);
            this.txtID.Name = "txtID";
            this.txtID.ReadOnly = true;
            this.txtID.Size = new System.Drawing.Size(100, 20);
            this.txtID.TabIndex = 1;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 31.11111F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 68.88889F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 109F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Controls.Add(this.metroLabel8, 0, 8);
            this.tableLayoutPanel1.Controls.Add(this.txtPrecioServicio, 1, 7);
            this.tableLayoutPanel1.Controls.Add(this.metroLabel7, 0, 7);
            this.tableLayoutPanel1.Controls.Add(this.txtPagoTrabajador, 1, 6);
            this.tableLayoutPanel1.Controls.Add(this.metroLabel6, 0, 6);
            this.tableLayoutPanel1.Controls.Add(this.txtComision, 1, 5);
            this.tableLayoutPanel1.Controls.Add(this.metroLabel5, 0, 5);
            this.tableLayoutPanel1.Controls.Add(this.metroLabel4, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.metroLabel3, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.metroLabel2, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.lblIdServicio, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.txtID, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.metroLabel1, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.txtNumeroHoras, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.txtFechaServicio, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.cbxTrabajador, 1, 8);
            this.tableLayoutPanel1.Controls.Add(this.btnGuardar, 2, 8);
            this.tableLayoutPanel1.Controls.Add(this.txtHoraDeInicio, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.txtHoraFin, 1, 4);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(20, 60);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 9;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 36F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 52F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 59F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 49F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 41F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 33F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 24F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(659, 457);
            this.tableLayoutPanel1.TabIndex = 2;
            // 
            // metroLabel8
            // 
            this.metroLabel8.AutoSize = true;
            this.metroLabel8.FontWeight = MetroFramework.MetroLabelWeight.Bold;
            this.metroLabel8.Location = new System.Drawing.Point(3, 423);
            this.metroLabel8.Name = "metroLabel8";
            this.metroLabel8.Size = new System.Drawing.Size(83, 19);
            this.metroLabel8.TabIndex = 17;
            this.metroLabel8.Text = "Trabajador";
            // 
            // txtPrecioServicio
            // 
            this.txtPrecioServicio.DecimalPlaces = 2;
            this.txtPrecioServicio.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPrecioServicio.Location = new System.Drawing.Point(176, 385);
            this.txtPrecioServicio.Maximum = new decimal(new int[] {
            -727379969,
            232,
            0,
            0});
            this.txtPrecioServicio.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.txtPrecioServicio.Name = "txtPrecioServicio";
            this.txtPrecioServicio.Size = new System.Drawing.Size(120, 20);
            this.txtPrecioServicio.TabIndex = 16;
            this.txtPrecioServicio.ThousandsSeparator = true;
            this.txtPrecioServicio.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // metroLabel7
            // 
            this.metroLabel7.AutoSize = true;
            this.metroLabel7.FontWeight = MetroFramework.MetroLabelWeight.Bold;
            this.metroLabel7.Location = new System.Drawing.Point(3, 382);
            this.metroLabel7.Name = "metroLabel7";
            this.metroLabel7.Size = new System.Drawing.Size(111, 19);
            this.metroLabel7.TabIndex = 15;
            this.metroLabel7.Text = "Precio Servicio";
            // 
            // txtPagoTrabajador
            // 
            this.txtPagoTrabajador.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPagoTrabajador.Location = new System.Drawing.Point(176, 336);
            this.txtPagoTrabajador.Maximum = new decimal(new int[] {
            -727379969,
            232,
            0,
            0});
            this.txtPagoTrabajador.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.txtPagoTrabajador.Name = "txtPagoTrabajador";
            this.txtPagoTrabajador.Size = new System.Drawing.Size(120, 20);
            this.txtPagoTrabajador.TabIndex = 14;
            this.txtPagoTrabajador.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // metroLabel6
            // 
            this.metroLabel6.AutoSize = true;
            this.metroLabel6.FontWeight = MetroFramework.MetroLabelWeight.Bold;
            this.metroLabel6.Location = new System.Drawing.Point(3, 333);
            this.metroLabel6.Name = "metroLabel6";
            this.metroLabel6.Size = new System.Drawing.Size(134, 19);
            this.metroLabel6.TabIndex = 13;
            this.metroLabel6.Text = "Pago a Trabajador";
            // 
            // txtComision
            // 
            this.txtComision.DecimalPlaces = 2;
            this.txtComision.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtComision.Location = new System.Drawing.Point(176, 277);
            this.txtComision.Maximum = new decimal(new int[] {
            -727379969,
            232,
            0,
            0});
            this.txtComision.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.txtComision.Name = "txtComision";
            this.txtComision.Size = new System.Drawing.Size(120, 20);
            this.txtComision.TabIndex = 12;
            this.txtComision.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // metroLabel5
            // 
            this.metroLabel5.AutoSize = true;
            this.metroLabel5.FontWeight = MetroFramework.MetroLabelWeight.Bold;
            this.metroLabel5.Location = new System.Drawing.Point(3, 274);
            this.metroLabel5.Name = "metroLabel5";
            this.metroLabel5.Size = new System.Drawing.Size(132, 19);
            this.metroLabel5.TabIndex = 11;
            this.metroLabel5.Text = "Comisión Empresa";
            // 
            // metroLabel4
            // 
            this.metroLabel4.AutoSize = true;
            this.metroLabel4.FontWeight = MetroFramework.MetroLabelWeight.Bold;
            this.metroLabel4.Location = new System.Drawing.Point(3, 214);
            this.metroLabel4.Name = "metroLabel4";
            this.metroLabel4.Size = new System.Drawing.Size(66, 19);
            this.metroLabel4.TabIndex = 9;
            this.metroLabel4.Text = "Hora Fin";
            // 
            // metroLabel3
            // 
            this.metroLabel3.AutoSize = true;
            this.metroLabel3.FontWeight = MetroFramework.MetroLabelWeight.Bold;
            this.metroLabel3.Location = new System.Drawing.Point(3, 162);
            this.metroLabel3.Name = "metroLabel3";
            this.metroLabel3.Size = new System.Drawing.Size(104, 19);
            this.metroLabel3.TabIndex = 6;
            this.metroLabel3.Text = "Hora de Inicio";
            // 
            // metroLabel2
            // 
            this.metroLabel2.AutoSize = true;
            this.metroLabel2.FontWeight = MetroFramework.MetroLabelWeight.Bold;
            this.metroLabel2.Location = new System.Drawing.Point(3, 126);
            this.metroLabel2.Name = "metroLabel2";
            this.metroLabel2.Size = new System.Drawing.Size(129, 19);
            this.metroLabel2.TabIndex = 4;
            this.metroLabel2.Text = "Número de Horas";
            // 
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.FontWeight = MetroFramework.MetroLabelWeight.Bold;
            this.metroLabel1.Location = new System.Drawing.Point(3, 63);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(131, 19);
            this.metroLabel1.TabIndex = 2;
            this.metroLabel1.Text = "Fecha del Servicio";
            // 
            // txtNumeroHoras
            // 
            this.txtNumeroHoras.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNumeroHoras.Location = new System.Drawing.Point(176, 129);
            this.txtNumeroHoras.Maximum = new decimal(new int[] {
            -727379969,
            232,
            0,
            0});
            this.txtNumeroHoras.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.txtNumeroHoras.Name = "txtNumeroHoras";
            this.txtNumeroHoras.Size = new System.Drawing.Size(120, 20);
            this.txtNumeroHoras.TabIndex = 5;
            this.txtNumeroHoras.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // txtFechaServicio
            // 
            this.txtFechaServicio.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFechaServicio.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.txtFechaServicio.Location = new System.Drawing.Point(176, 66);
            this.txtFechaServicio.MinDate = new System.DateTime(1778, 7, 5, 0, 0, 0, 0);
            this.txtFechaServicio.MinimumSize = new System.Drawing.Size(0, 29);
            this.txtFechaServicio.Name = "txtFechaServicio";
            this.txtFechaServicio.Size = new System.Drawing.Size(200, 29);
            this.txtFechaServicio.TabIndex = 7;
            // 
            // cbxTrabajador
            // 
            this.cbxTrabajador.FontWeight = MetroFramework.MetroComboBoxWeight.Bold;
            this.cbxTrabajador.ForeColor = System.Drawing.SystemColors.InfoText;
            this.cbxTrabajador.FormattingEnabled = true;
            this.cbxTrabajador.ItemHeight = 23;
            this.cbxTrabajador.Location = new System.Drawing.Point(176, 426);
            this.cbxTrabajador.Name = "cbxTrabajador";
            this.cbxTrabajador.Size = new System.Drawing.Size(200, 29);
            this.cbxTrabajador.TabIndex = 18;
            this.cbxTrabajador.UseSelectable = true;
            // 
            // btnGuardar
            // 
            this.btnGuardar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(69)))), ((int)(((byte)(113)))));
            this.btnGuardar.FontSize = MetroFramework.MetroButtonSize.Medium;
            this.btnGuardar.Location = new System.Drawing.Point(561, 426);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(94, 28);
            this.btnGuardar.Style = MetroFramework.MetroColorStyle.White;
            this.btnGuardar.TabIndex = 19;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.Theme = MetroFramework.MetroThemeStyle.Light;
            this.btnGuardar.UseCustomBackColor = true;
            this.btnGuardar.UseSelectable = true;
            this.btnGuardar.UseStyleColors = true;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // txtHoraDeInicio
            // 
            this.txtHoraDeInicio.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtHoraDeInicio.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.txtHoraDeInicio.Location = new System.Drawing.Point(176, 165);
            this.txtHoraDeInicio.Name = "txtHoraDeInicio";
            this.txtHoraDeInicio.ShowUpDown = true;
            this.txtHoraDeInicio.Size = new System.Drawing.Size(219, 20);
            this.txtHoraDeInicio.TabIndex = 20;
            // 
            // txtHoraFin
            // 
            this.txtHoraFin.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtHoraFin.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.txtHoraFin.Location = new System.Drawing.Point(176, 217);
            this.txtHoraFin.Name = "txtHoraFin";
            this.txtHoraFin.ShowUpDown = true;
            this.txtHoraFin.Size = new System.Drawing.Size(219, 20);
            this.txtHoraFin.TabIndex = 21;
            // 
            // ModificarServicioForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(699, 537);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "ModificarServicioForm";
            this.Resizable = false;
            this.Text = "Modificar Servicio";
            this.Load += new System.EventHandler(this.ModificarServicioForm_Load_1);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtPrecioServicio)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPagoTrabajador)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtComision)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNumeroHoras)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private MetroFramework.Controls.MetroLabel lblIdServicio;
        private System.Windows.Forms.TextBox txtID;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private MetroFramework.Controls.MetroLabel metroLabel1;
        private MetroFramework.Controls.MetroLabel metroLabel2;
        private System.Windows.Forms.NumericUpDown txtNumeroHoras;
        private MetroFramework.Controls.MetroLabel metroLabel3;
        private MetroFramework.Controls.MetroDateTime txtFechaServicio;
        private MetroFramework.Controls.MetroLabel metroLabel4;
        private System.Windows.Forms.NumericUpDown txtComision;
        private MetroFramework.Controls.MetroLabel metroLabel5;
        private MetroFramework.Controls.MetroLabel metroLabel6;
        private System.Windows.Forms.NumericUpDown txtPagoTrabajador;
        private MetroFramework.Controls.MetroLabel metroLabel7;
        private System.Windows.Forms.NumericUpDown txtPrecioServicio;
        private MetroFramework.Controls.MetroLabel metroLabel8;
        private MetroFramework.Controls.MetroComboBox cbxTrabajador;
        private MetroFramework.Controls.MetroButton btnGuardar;
        private System.Windows.Forms.DateTimePicker txtHoraDeInicio;
        private System.Windows.Forms.DateTimePicker txtHoraFin;
    }
}