﻿using Business.Entities;
using Business.Logic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UI.Desktop
{
    public partial class Personas : ApplicationForm
    {
        public Personas()
        {
            InitializeComponent();
            dgvPersonas.AutoGenerateColumns = false;
        }

        private void Personas_Load(object sender, EventArgs e)
        {
            this.Listar();
        }

        private void tsbAgregarP_Click(object sender, EventArgs e)
        {
            PersonaDesktop formPersona = new PersonaDesktop(ApplicationForm.ModoForm.Alta);
            formPersona.ShowDialog();
            this.Listar();
        }

        private void tsbEditarP_Click(object sender, EventArgs e)
        {
            if (!isRowSelected(dgvPersonas)) return;
            openForm(ApplicationForm.ModoForm.Modificacion);
        }

        private void tsbEliminarP_Click(object sender, EventArgs e)
        {
            if (!isRowSelected(dgvPersonas)) return;
            openForm(ApplicationForm.ModoForm.Baja);
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            this.Listar();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void openForm(ApplicationForm.ModoForm modo)
        {
            int ID = ((Persona)this.dgvPersonas.SelectedRows[0].DataBoundItem).ID;
            var formPersona = new PersonaDesktop(ID, modo);
            formPersona.ShowDialog();
            this.Listar();
        }

        public void Listar()
        {
            try
            {
                this.dgvPersonas.DataSource = new PersonaLogic().GetAll();
            }
            catch (Exception)
            {
                Notificar("Error", "Error al recuperar los datos del usuario",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}