//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Data.Database
{
    using System;
    using System.Collections.Generic;
    
    public partial class alumnos_inscripciones
    {
        public int id_inscripcion { get; set; }
        public int id_alumno { get; set; }
        public int id_curso { get; set; }
        public string condicion { get; set; }
        public Nullable<int> nota { get; set; }
    
        public virtual cursos cursos { get; set; }
        public virtual personas personas { get; set; }
    }
}
