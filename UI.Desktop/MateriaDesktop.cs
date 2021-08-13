﻿using System;
using System.Collections.Generic;
using Business.Logic;
using Business.Entities;
using System.Windows.Forms;

namespace UI.Desktop
{
    public partial class MateriaDesktop : ApplicationForm
    {
        private Materia MateriaActual { get; set; }
        public MateriaDesktop()
        {
            InitializeComponent();
            cbxPlan.DataSource = new PlanLogic().GetAll();
        }

        public MateriaDesktop(ModoForm modo) : this()
        {
            this.Modo = modo;
        }

        public MateriaDesktop(int ID, ModoForm modo) : this(modo)
        {
            MateriaActual = new MateriaLogic().GetOne(ID);
            MapearDeDatos();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (Validar())
            {
                GuardarCambios();
                Close();
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        public override void MapearDeDatos()
        {
            txtID.Text = MateriaActual.ID.ToString();
            txtDescripcion.Text = MateriaActual.Descripcion;
            txtHsSemanales.Text = MateriaActual.HorasSemanales.ToString();
            txtHsTotales.Text = MateriaActual.HorasTotales.ToString();
            cbxPlan.SelectedValue = MateriaActual.MiPlan.ID;

            if (Modo == ModoForm.Consulta)
            {
                btnAceptar.Text = "Aceptar";
            }
            else if (Modo == ModoForm.Alta || Modo == ModoForm.Modificacion)
            {
                btnAceptar.Text = "Guardar";
            }
            else if (Modo == ModoForm.Baja)
            {
                btnAceptar.Text = "Eliminar";
            }
        }

        public override void MapearADatos()
        {
            if (Modo == ModoForm.Alta)
            {
                MateriaActual = new Materia { State = BusinessEntity.States.New };
            }
            if (Modo == ModoForm.Alta || Modo == ModoForm.Modificacion)
            {
                if (Modo == ModoForm.Modificacion)
                {
                    MateriaActual.State = BusinessEntity.States.Modified;
                }
                MateriaActual.Descripcion = txtDescripcion.Text;
                MateriaActual.HorasSemanales = int.Parse(txtHsSemanales.Text);
                MateriaActual.HorasTotales = int.Parse(txtHsTotales.Text);
                MateriaActual.MiPlan = new PlanLogic().GetOne((int)cbxPlan.SelectedValue);
            }
            else if (Modo == ModoForm.Baja)
            {
                MateriaActual.State = BusinessEntity.States.Deleted;
            }
            else if (Modo == ModoForm.Consulta)
            {
                MateriaActual.State = BusinessEntity.States.Unmodified;
            }
        }

        public override void GuardarCambios()
        {
            MapearADatos();
            new MateriaLogic().Save(MateriaActual);
        }

        public override bool Validar()
        {
            if (!Validaciones.FormularioCompleto
                (new List<string> {txtDescripcion.Text, txtHsSemanales.Text, txtHsTotales.Text}))
            {
                Notificar("Informacion invalida", "Complete los campos para continuar.",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (cbxPlan.SelectedValue == null)
            {
                Notificar("Informacion invalida", "Porfavor seleccione una especialidad valida.",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                return true;
            }
            return false;
        }
    }
}