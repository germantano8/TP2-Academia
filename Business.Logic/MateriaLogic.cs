﻿using System.Collections.Generic;
using Business.Entities;
using Data.Database;


namespace Business.Logic
{
    public class MateriaLogic : BusinessLogic
    {
        public MateriaAdapter MateriaData { get; set; }

        public MateriaLogic()
        {
            MateriaData = new MateriaAdapter();
        }

        public List<Materia> GetAll()
        {
            return MateriaData.GetAll();
        }

        public Materia GetOne(int id)
        {
            return MateriaData.GetOne(id);
        }

        public void Save(Materia materia)
        {
            MateriaData.Save(materia);
        }
    }
}
