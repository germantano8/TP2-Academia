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
    
    public partial class modulos_usuarios
    {
        public int id_modulo_usuario { get; set; }
        public int id_modulo { get; set; }
        public int id_usuario { get; set; }
        public Nullable<bool> alta { get; set; }
        public Nullable<bool> baja { get; set; }
        public Nullable<bool> modificacion { get; set; }
        public Nullable<bool> consulta { get; set; }
    
        public virtual modulos modulos { get; set; }
        public virtual usuarios usuarios { get; set; }
    }
}
