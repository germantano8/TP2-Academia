﻿using System;
using System.Windows.Forms;
using Business.Entities;
using Business.Logic;

namespace UI.Desktop
{
    public partial class Planes : ApplicationForm
    {
        public Planes()
        {
            InitializeComponent();
            dgvPlanes.AutoGenerateColumns = false;
        }

        public void Listar()
        {
            try
            {
                this.dgvPlanes.DataSource = new PlanLogic().GetAll();
                //dgvUsuarios.DataSource = ul.GetAll().FindAll(u => u.State != BusinessEntity.States.Deleted);
            }
            catch (Exception)
            {
                Notificar("Error", "Error al recuperar los datos del usuario",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Planes_Load(object sender, EventArgs e)
        {
            this.Listar();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            this.Listar();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tsbNuevo_Click(object sender, EventArgs e)
        {
            PlanDesktop formPlan = new PlanDesktop(ApplicationForm.ModoForm.Alta);
            formPlan.ShowDialog();
            this.Listar();
        }

        private void tsbEditar_Click(object sender, EventArgs e)
        {
            if (!isRowSelected(dgvPlanes)) return;
            openUserForm(ApplicationForm.ModoForm.Modificacion);
        }

        private void tsbEliminar_Click(object sender, EventArgs e)
        {
            if (!isRowSelected(dgvPlanes)) return;
            openUserForm(ApplicationForm.ModoForm.Baja);
        }

        private void openUserForm(ApplicationForm.ModoForm modo)
        {
            int ID = ((Plan)this.dgvPlanes.SelectedRows[0].DataBoundItem).ID;
            PlanDesktop formPlan = new PlanDesktop(ID, modo);
            formPlan.ShowDialog();
            this.Listar();
        }
    }
}
