﻿using System.Collections.Generic;
using System.Linq;
using Business.Entities;

namespace Data.Database
{
    public class PlanAdapter : Adapter
    {
        public List<Plan> GetAll()
        {
            using (AcademiaEntities context = new AcademiaEntities())
            {
                List<Plan> planes = new List<Plan>();
                var lstPlanes = context.planes;
                lstPlanes?.ToList().ForEach(p => planes.Add(nuevoPlan(p)));
                return planes;
            }
        }

        private static Plan nuevoPlan(planes p)
        {
            if (p == null) return null;
            Plan plan = new Plan
            {
                ID = p.id_plan,
                Descripcion = p.desc_plan,
                MiEspecialidad = especialidadData.GetOne(p.especialidades.id_especialidad)
            };
            return plan;
        }

        public Plan GetOne(int ID)
        {
            using (var context = new AcademiaEntities())
            {
                var plan = context.planes.SingleOrDefault(p => p.id_plan == ID);
                return nuevoPlan(plan);
            }
        }

        public Plan GetOneNombreUsuario(string desc_plan)
        {
            using (var context = new AcademiaEntities())
            {
                var pln = context.planes.SingleOrDefault(p => p.desc_plan == desc_plan);
                return nuevoPlan(pln);
            }

        }

        public void Delete(int ID)
        {
            using (var context = new AcademiaEntities())
            {
                var plan = context.planes.SingleOrDefault(p => p.id_plan == ID);
                if (plan != null)
                {
                    context.planes.Remove(plan);
                    context.SaveChanges();
                }
            }
        }

        public void Save(Plan plan)
        {
            if (plan.State == BusinessEntity.States.Deleted)
            {
                this.Delete(plan.ID);
            }
            else if (plan.State == BusinessEntity.States.New)
            {
                this.Insert(plan);
            }
            else if (plan.State == BusinessEntity.States.Modified)
            {
                this.Update(plan);
            }
            plan.State = BusinessEntity.States.Unmodified;
        }

        protected void Update(Plan plan)
        {
            using (var context = new AcademiaEntities())
            {
                var pln = context.planes.SingleOrDefault(p => p.id_plan == plan.ID);
                if (pln != null)
                {
                    pln.desc_plan = plan.Descripcion;
                    pln.id_especialidad = plan.MiEspecialidad.ID;
                    context.SaveChanges();
                }
            }
        }

        protected void Insert(Plan plan)
        {
            using (var context = new AcademiaEntities())
            {
                planes pln = new planes
                {
                    id_plan = plan.ID,
                    desc_plan = plan.Descripcion,
                    id_especialidad = plan.MiEspecialidad.ID
                };
                context.planes.Add(pln);
                context.SaveChanges();
            }
        }
    }
}
