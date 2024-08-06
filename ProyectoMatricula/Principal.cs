﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoMatricula
{
    public partial class Principal : Form
    {
        /*
            1=Estudiante
            2=Profesor
            3=Administrativo
            4=DBA
         */
        public int tipoUsuario;
        public Principal()
        {
            InitializeComponent();
            personalizarDiseño();
            Login lg = new Login(this);

            lg.ShowDialog();
        }
        bool menuExpand = false;

        public void setMenu()
        {
            if (tipoUsuario == 1)
            {
                lblUser.Text = "UserAlumno";
                lblRol.Text = "Alumno";
                this.flDataBase.Visible = false;

                this.pnlConsultarNota.Visible = true;
                this.pnlConsultarAsis.Visible = true;
                this.pnlConsultarHorario.Visible = true;
                this.pnlRegistroAsist.Visible = false;
                this.pnlRegistrarNota.Visible = false;
                this.pnlGenerarMalla.Visible = false;
                this.pnlGenerarHorarios.Visible = false;

                this.flAcademico.Size = new System.Drawing.Size(231,132);

                this.pnlAnularMatricula.Visible = true;
                this.pnlGenerarActas.Visible = false;
                this.pnlGenerarActasNotas.Visible= false;
                this.pnlModificarNotas.Visible= false;
                this.pnlModificarAsistencia.Visible = false;
                this.pnlAsignarCupos.Visible = false;
                this.pnlAsignarProfesor.Visible = false;
                this.pnlEnrolaNuevosEs.Visible = false;
                this.flAdministrativo.Size = new System.Drawing.Size(231, 66);
            }
            if (tipoUsuario == 2)
            {
                lblUser.Text = "UserProfe";
                lblRol.Text = "Profesor";
                this.flDataBase.Visible = false;

                this.pnlConsultarNota.Visible = false;
                this.pnlConsultarAsis.Visible = false;
                this.pnlConsultarHorario.Visible = false;
                this.pnlRegistroAsist.Visible = true;
                this.pnlRegistrarNota.Visible = true;
                this.pnlGenerarMalla.Visible = false;
                this.pnlGenerarHorarios.Visible = false;

                this.flAcademico.Size = new System.Drawing.Size(231, 99);

                this.pnlAnularMatricula.Visible = false;
                this.pnlGenerarActas.Visible = true;
                this.pnlGenerarActasNotas.Visible = true;
                this.pnlModificarNotas.Visible = false;
                this.pnlModificarAsistencia.Visible = false;
                this.pnlAsignarCupos.Visible = false;
                this.pnlAsignarProfesor.Visible = false;
                this.pnlEnrolaNuevosEs.Visible = false;

                this.flAdministrativo.Size = new System.Drawing.Size(231, 99);


            }
            if (tipoUsuario == 3)
            {
                lblUser.Text = "UserAdmi";
                lblRol.Text = "Administrativo";
                this.flDataBase.Visible = false;

                this.pnlConsultarNota.Visible = false;
                this.pnlConsultarAsis.Visible = false;
                this.pnlConsultarHorario.Visible = false;
                this.pnlRegistroAsist.Visible = false;
                this.pnlRegistrarNota.Visible = false;
                this.pnlGenerarMalla.Visible = false;
                this.pnlGenerarHorarios.Visible = true;
                this.flAcademico.Size = new System.Drawing.Size(231, 66);

                this.pnlAnularMatricula.Visible = false;
                this.pnlGenerarActas.Visible = false;
                this.pnlGenerarActasNotas.Visible = false;
                this.pnlModificarNotas.Visible = true;
                this.pnlModificarAsistencia.Visible = true;
                this.pnlAsignarCupos.Visible = true;
                this.pnlAsignarProfesor.Visible = true;
                this.pnlEnrolaNuevosEs.Visible = true;

                this.flAdministrativo.Size = new System.Drawing.Size(231, 198);


            }
            if (tipoUsuario == 4)
            {
                lblUser.Text = "UserDBA";
                lblRol.Text = "DataBaseAdmin";
                this.flDataBase.Visible = true;
                this.flAcademico.Visible = false;
                this.flAdministrativo.Visible = false;
            }
            
        }

        private void personalizarDiseño()
        {
            panelSubProfesor.Visible = false;
            panelSubAlumno.Visible = false;
        }

        private void hideSubMenu()
        {
            if (panelSubProfesor.Visible == true)
                panelSubProfesor.Visible = false;
            if (panelSubAlumno.Visible == true)
                panelSubAlumno.Visible = false;
        }

        private void showSubMenu(Panel subMenu)
        {
            if (subMenu.Visible == false)
            {
                hideSubMenu();
                subMenu.Visible = true;
            }
            else
            {
                subMenu.Visible = false;
            }
        }

        private Form formularioActivo = null;
        private void abrirFormularioHijo(Form panelHijo)
        {
            if (formularioActivo != null)
                formularioActivo.Close();
            formularioActivo = panelHijo;
            panelHijo.TopLevel = false;
            panelHijo.FormBorderStyle = FormBorderStyle.None;
           panelHijo.Dock = DockStyle.Fill;
            panel3.Controls.Add(formularioActivo);
            panel3.Tag = formularioActivo;
            panelHijo.BringToFront();
            formularioActivo.Show();


        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void panel7_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button19_Click(object sender, EventArgs e)
        {
 
           abrirFormularioHijo(new Cambiar_Contraseña());
        }

        private void btnProfesor_Click(object sender, EventArgs e)
        {
            showSubMenu(panelSubProfesor);
        }

        private void btnAlumno_Click(object sender, EventArgs e)
        {
            showSubMenu(panelSubAlumno);
        }

        private void button8_Click(object sender, EventArgs e)
        {

        }

        private void btnRegistrarProfesor_Click(object sender, EventArgs e)
        {
            abrirFormularioHijo(new FrmRegistrarProfesor());
        }
    }
}
