namespace ProyectoMatricula
{
    partial class FrmRegistrarProfesor
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
            this.lblCodigo = new System.Windows.Forms.Label();
            this.txtCedula = new System.Windows.Forms.TextBox();
            this.lblCedula = new System.Windows.Forms.Label();
            this.dtpFechaNacimiento = new System.Windows.Forms.DateTimePicker();
            this.cmbGenero = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnRegistrar = new System.Windows.Forms.Button();
            this.lblId = new System.Windows.Forms.Label();
            this.txtEspecialidad = new System.Windows.Forms.TextBox();
            this.txtTelefono = new System.Windows.Forms.TextBox();
            this.txtCorreo = new System.Windows.Forms.TextBox();
            this.txtApellido = new System.Windows.Forms.TextBox();
            this.txtDireccion = new System.Windows.Forms.TextBox();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.lblEspecialidad = new System.Windows.Forms.Label();
            this.lblTelefono = new System.Windows.Forms.Label();
            this.lblCorreo = new System.Windows.Forms.Label();
            this.lblDireccion = new System.Windows.Forms.Label();
            this.lblFechaNac = new System.Windows.Forms.Label();
            this.lblApellido = new System.Windows.Forms.Label();
            this.lblNombre = new System.Windows.Forms.Label();
            this.lblInformacion = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblCodigo
            // 
            this.lblCodigo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.lblCodigo.AutoSize = true;
            this.lblCodigo.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCodigo.ForeColor = System.Drawing.Color.DarkBlue;
            this.lblCodigo.Location = new System.Drawing.Point(846, 32);
            this.lblCodigo.Name = "lblCodigo";
            this.lblCodigo.Size = new System.Drawing.Size(47, 16);
            this.lblCodigo.TabIndex = 46;
            this.lblCodigo.Text = "_____";
            // 
            // txtCedula
            // 
            this.txtCedula.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.txtCedula.Location = new System.Drawing.Point(368, 198);
            this.txtCedula.Name = "txtCedula";
            this.txtCedula.Size = new System.Drawing.Size(540, 22);
            this.txtCedula.TabIndex = 45;
            this.txtCedula.Text = "1";
            // 
            // lblCedula
            // 
            this.lblCedula.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.lblCedula.AutoSize = true;
            this.lblCedula.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCedula.ForeColor = System.Drawing.Color.DarkBlue;
            this.lblCedula.Location = new System.Drawing.Point(114, 198);
            this.lblCedula.Name = "lblCedula";
            this.lblCedula.Size = new System.Drawing.Size(67, 16);
            this.lblCedula.TabIndex = 26;
            this.lblCedula.Text = "CÉDULA";
            // 
            // dtpFechaNacimiento
            // 
            this.dtpFechaNacimiento.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.dtpFechaNacimiento.Location = new System.Drawing.Point(368, 345);
            this.dtpFechaNacimiento.Name = "dtpFechaNacimiento";
            this.dtpFechaNacimiento.Size = new System.Drawing.Size(540, 22);
            this.dtpFechaNacimiento.TabIndex = 44;
            // 
            // cmbGenero
            // 
            this.cmbGenero.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.cmbGenero.FormattingEnabled = true;
            this.cmbGenero.Items.AddRange(new object[] {
            "Hombre",
            "Mujer"});
            this.cmbGenero.Location = new System.Drawing.Point(368, 491);
            this.cmbGenero.Name = "cmbGenero";
            this.cmbGenero.Size = new System.Drawing.Size(540, 24);
            this.cmbGenero.TabIndex = 43;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.DarkBlue;
            this.label2.Location = new System.Drawing.Point(114, 492);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 16);
            this.label2.TabIndex = 42;
            this.label2.Text = "GÉNERO";
            // 
            // btnCancelar
            // 
            this.btnCancelar.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnCancelar.Location = new System.Drawing.Point(545, 530);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(243, 41);
            this.btnCancelar.TabIndex = 41;
            this.btnCancelar.Text = "CANCELAR";
            this.btnCancelar.UseVisualStyleBackColor = true;
            // 
            // btnRegistrar
            // 
            this.btnRegistrar.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnRegistrar.Location = new System.Drawing.Point(223, 530);
            this.btnRegistrar.Name = "btnRegistrar";
            this.btnRegistrar.Size = new System.Drawing.Size(243, 41);
            this.btnRegistrar.TabIndex = 40;
            this.btnRegistrar.Text = "REGISTRAR";
            this.btnRegistrar.UseVisualStyleBackColor = true;
            // 
            // lblId
            // 
            this.lblId.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.lblId.AutoSize = true;
            this.lblId.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblId.ForeColor = System.Drawing.Color.DarkBlue;
            this.lblId.Location = new System.Drawing.Point(772, 32);
            this.lblId.Name = "lblId";
            this.lblId.Size = new System.Drawing.Size(30, 16);
            this.lblId.TabIndex = 39;
            this.lblId.Text = "ID :";
            // 
            // txtEspecialidad
            // 
            this.txtEspecialidad.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.txtEspecialidad.Location = new System.Drawing.Point(368, 296);
            this.txtEspecialidad.Name = "txtEspecialidad";
            this.txtEspecialidad.Size = new System.Drawing.Size(540, 22);
            this.txtEspecialidad.TabIndex = 38;
            this.txtEspecialidad.Text = "v";
            // 
            // txtTelefono
            // 
            this.txtTelefono.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.txtTelefono.Location = new System.Drawing.Point(368, 443);
            this.txtTelefono.Name = "txtTelefono";
            this.txtTelefono.Size = new System.Drawing.Size(540, 22);
            this.txtTelefono.TabIndex = 37;
            this.txtTelefono.Text = "1";
            // 
            // txtCorreo
            // 
            this.txtCorreo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.txtCorreo.Location = new System.Drawing.Point(368, 394);
            this.txtCorreo.Name = "txtCorreo";
            this.txtCorreo.Size = new System.Drawing.Size(540, 22);
            this.txtCorreo.TabIndex = 36;
            this.txtCorreo.Text = "@a";
            // 
            // txtApellido
            // 
            this.txtApellido.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.txtApellido.Location = new System.Drawing.Point(368, 149);
            this.txtApellido.Name = "txtApellido";
            this.txtApellido.Size = new System.Drawing.Size(540, 22);
            this.txtApellido.TabIndex = 35;
            this.txtApellido.Text = "b";
            // 
            // txtDireccion
            // 
            this.txtDireccion.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.txtDireccion.Location = new System.Drawing.Point(368, 247);
            this.txtDireccion.Name = "txtDireccion";
            this.txtDireccion.Size = new System.Drawing.Size(540, 22);
            this.txtDireccion.TabIndex = 34;
            this.txtDireccion.Text = "a";
            // 
            // txtNombre
            // 
            this.txtNombre.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.txtNombre.Location = new System.Drawing.Point(368, 100);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(540, 22);
            this.txtNombre.TabIndex = 30;
            this.txtNombre.Text = "a";
            // 
            // lblEspecialidad
            // 
            this.lblEspecialidad.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.lblEspecialidad.AutoSize = true;
            this.lblEspecialidad.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEspecialidad.ForeColor = System.Drawing.Color.DarkBlue;
            this.lblEspecialidad.Location = new System.Drawing.Point(114, 296);
            this.lblEspecialidad.Name = "lblEspecialidad";
            this.lblEspecialidad.Size = new System.Drawing.Size(119, 16);
            this.lblEspecialidad.TabIndex = 28;
            this.lblEspecialidad.Text = "ESPECIALIDAD:";
            // 
            // lblTelefono
            // 
            this.lblTelefono.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.lblTelefono.AutoSize = true;
            this.lblTelefono.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTelefono.ForeColor = System.Drawing.Color.DarkBlue;
            this.lblTelefono.Location = new System.Drawing.Point(114, 443);
            this.lblTelefono.Name = "lblTelefono";
            this.lblTelefono.Size = new System.Drawing.Size(91, 16);
            this.lblTelefono.TabIndex = 33;
            this.lblTelefono.Text = "TELÉFONO:";
            // 
            // lblCorreo
            // 
            this.lblCorreo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.lblCorreo.AutoSize = true;
            this.lblCorreo.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCorreo.ForeColor = System.Drawing.Color.DarkBlue;
            this.lblCorreo.Location = new System.Drawing.Point(114, 394);
            this.lblCorreo.Name = "lblCorreo";
            this.lblCorreo.Size = new System.Drawing.Size(185, 16);
            this.lblCorreo.TabIndex = 32;
            this.lblCorreo.Text = "CORREO ELECTRONICO:";
            // 
            // lblDireccion
            // 
            this.lblDireccion.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.lblDireccion.AutoSize = true;
            this.lblDireccion.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDireccion.ForeColor = System.Drawing.Color.DarkBlue;
            this.lblDireccion.Location = new System.Drawing.Point(114, 247);
            this.lblDireccion.Name = "lblDireccion";
            this.lblDireccion.Size = new System.Drawing.Size(89, 16);
            this.lblDireccion.TabIndex = 27;
            this.lblDireccion.Text = "DIRECCIÓN";
            // 
            // lblFechaNac
            // 
            this.lblFechaNac.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.lblFechaNac.AutoSize = true;
            this.lblFechaNac.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFechaNac.ForeColor = System.Drawing.Color.DarkBlue;
            this.lblFechaNac.Location = new System.Drawing.Point(114, 345);
            this.lblFechaNac.Name = "lblFechaNac";
            this.lblFechaNac.Size = new System.Drawing.Size(183, 16);
            this.lblFechaNac.TabIndex = 31;
            this.lblFechaNac.Text = "FECHA DE NACIMIENTO:";
            // 
            // lblApellido
            // 
            this.lblApellido.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.lblApellido.AutoSize = true;
            this.lblApellido.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblApellido.ForeColor = System.Drawing.Color.DarkBlue;
            this.lblApellido.Location = new System.Drawing.Point(114, 149);
            this.lblApellido.Name = "lblApellido";
            this.lblApellido.Size = new System.Drawing.Size(89, 16);
            this.lblApellido.TabIndex = 25;
            this.lblApellido.Text = "APELLIDOS";
            // 
            // lblNombre
            // 
            this.lblNombre.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.lblNombre.AutoSize = true;
            this.lblNombre.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNombre.ForeColor = System.Drawing.Color.DarkBlue;
            this.lblNombre.Location = new System.Drawing.Point(114, 100);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(86, 16);
            this.lblNombre.TabIndex = 29;
            this.lblNombre.Text = "NOMBRES:";
            // 
            // lblInformacion
            // 
            this.lblInformacion.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.lblInformacion.AutoSize = true;
            this.lblInformacion.Font = new System.Drawing.Font("Lucida Fax", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInformacion.Location = new System.Drawing.Point(76, 32);
            this.lblInformacion.Name = "lblInformacion";
            this.lblInformacion.Size = new System.Drawing.Size(238, 20);
            this.lblInformacion.TabIndex = 24;
            this.lblInformacion.Text = "INFORMACIÓN PROFESOR";
            // 
            // FrmRegistrarProfesor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(992, 653);
            this.Controls.Add(this.lblCodigo);
            this.Controls.Add(this.txtCedula);
            this.Controls.Add(this.lblCedula);
            this.Controls.Add(this.dtpFechaNacimiento);
            this.Controls.Add(this.cmbGenero);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnRegistrar);
            this.Controls.Add(this.lblId);
            this.Controls.Add(this.txtEspecialidad);
            this.Controls.Add(this.txtTelefono);
            this.Controls.Add(this.txtCorreo);
            this.Controls.Add(this.txtApellido);
            this.Controls.Add(this.txtDireccion);
            this.Controls.Add(this.txtNombre);
            this.Controls.Add(this.lblEspecialidad);
            this.Controls.Add(this.lblTelefono);
            this.Controls.Add(this.lblCorreo);
            this.Controls.Add(this.lblDireccion);
            this.Controls.Add(this.lblFechaNac);
            this.Controls.Add(this.lblApellido);
            this.Controls.Add(this.lblNombre);
            this.Controls.Add(this.lblInformacion);
            this.Name = "FrmRegistrarProfesor";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblCodigo;
        private System.Windows.Forms.TextBox txtCedula;
        private System.Windows.Forms.Label lblCedula;
        private System.Windows.Forms.DateTimePicker dtpFechaNacimiento;
        private System.Windows.Forms.ComboBox cmbGenero;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnRegistrar;
        private System.Windows.Forms.Label lblId;
        private System.Windows.Forms.TextBox txtEspecialidad;
        private System.Windows.Forms.TextBox txtTelefono;
        private System.Windows.Forms.TextBox txtCorreo;
        private System.Windows.Forms.TextBox txtApellido;
        private System.Windows.Forms.TextBox txtDireccion;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.Label lblEspecialidad;
        private System.Windows.Forms.Label lblTelefono;
        private System.Windows.Forms.Label lblCorreo;
        private System.Windows.Forms.Label lblDireccion;
        private System.Windows.Forms.Label lblFechaNac;
        private System.Windows.Forms.Label lblApellido;
        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.Label lblInformacion;
    }
}