//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace EF
{
    using System;
    using System.Collections.Generic;
    
    public partial class JFernandezProductoSucursal
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public JFernandezProductoSucursal()
        {
            this.JFernandezVentaProducto = new HashSet<JFernandezVentaProducto>();
        }
    
        public int IdProductoSucursal { get; set; }
        public Nullable<int> IdProducto { get; set; }
        public Nullable<int> IdSucursal { get; set; }
    
        public virtual JFernandezProductos JFernandezProductos { get; set; }
        public virtual JFernandezSucursal JFernandezSucursal { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<JFernandezVentaProducto> JFernandezVentaProducto { get; set; }
        public virtual JFernandezProductoSucursal JFernandezProductoSucursal1 { get; set; }
        public virtual JFernandezProductoSucursal JFernandezProductoSucursal2 { get; set; }
    }
}
