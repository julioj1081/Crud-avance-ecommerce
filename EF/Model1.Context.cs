﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class JFernandezEcommerceEntities : DbContext
    {
        public JFernandezEcommerceEntities()
            : base("name=JFernandezEcommerceEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<JFernandezArea> JFernandezArea { get; set; }
        public virtual DbSet<JFernandezCliente> JFernandezCliente { get; set; }
        public virtual DbSet<JFernandezDepartamento> JFernandezDepartamento { get; set; }
        public virtual DbSet<JFernandezMetodoPago> JFernandezMetodoPago { get; set; }
        public virtual DbSet<JFernandezProductos> JFernandezProductos { get; set; }
        public virtual DbSet<JFernandezProductoSucursal> JFernandezProductoSucursal { get; set; }
        public virtual DbSet<JFernandezProveedor> JFernandezProveedor { get; set; }
        public virtual DbSet<JFernandezSucursal> JFernandezSucursal { get; set; }
        public virtual DbSet<JFernandezVenta> JFernandezVenta { get; set; }
        public virtual DbSet<JFernandezVentaProducto> JFernandezVentaProducto { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
    
        public virtual ObjectResult<GetAllDepartamento_Result> GetAllDepartamento()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<GetAllDepartamento_Result>("GetAllDepartamento");
        }
    
        public virtual int AddDepartamento(string nombreD, Nullable<int> idArea)
        {
            var nombreDParameter = nombreD != null ?
                new ObjectParameter("NombreD", nombreD) :
                new ObjectParameter("NombreD", typeof(string));
    
            var idAreaParameter = idArea.HasValue ?
                new ObjectParameter("IdArea", idArea) :
                new ObjectParameter("IdArea", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("AddDepartamento", nombreDParameter, idAreaParameter);
        }
    
        public virtual int DeleteDepartamento(Nullable<int> idDepartamento)
        {
            var idDepartamentoParameter = idDepartamento.HasValue ?
                new ObjectParameter("IdDepartamento", idDepartamento) :
                new ObjectParameter("IdDepartamento", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("DeleteDepartamento", idDepartamentoParameter);
        }
    
        public virtual ObjectResult<GetByIdEF_Result> GetByIdEF(Nullable<int> idDepartamento)
        {
            var idDepartamentoParameter = idDepartamento.HasValue ?
                new ObjectParameter("IdDepartamento", idDepartamento) :
                new ObjectParameter("IdDepartamento", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<GetByIdEF_Result>("GetByIdEF", idDepartamentoParameter);
        }
    
        public virtual int UpdateDepartamento(string nombreD, Nullable<int> idArea, Nullable<int> idDepartamento)
        {
            var nombreDParameter = nombreD != null ?
                new ObjectParameter("NombreD", nombreD) :
                new ObjectParameter("NombreD", typeof(string));
    
            var idAreaParameter = idArea.HasValue ?
                new ObjectParameter("IdArea", idArea) :
                new ObjectParameter("IdArea", typeof(int));
    
            var idDepartamentoParameter = idDepartamento.HasValue ?
                new ObjectParameter("IdDepartamento", idDepartamento) :
                new ObjectParameter("IdDepartamento", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("UpdateDepartamento", nombreDParameter, idAreaParameter, idDepartamentoParameter);
        }
    
        public virtual int AddArea(string nombreA)
        {
            var nombreAParameter = nombreA != null ?
                new ObjectParameter("NombreA", nombreA) :
                new ObjectParameter("NombreA", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("AddArea", nombreAParameter);
        }
    
        public virtual int AddProducto(string nombre, string descripcion, Nullable<decimal> precio, Nullable<int> idDepartamento, Nullable<int> idProveedor, byte[] image)
        {
            var nombreParameter = nombre != null ?
                new ObjectParameter("Nombre", nombre) :
                new ObjectParameter("Nombre", typeof(string));
    
            var descripcionParameter = descripcion != null ?
                new ObjectParameter("Descripcion", descripcion) :
                new ObjectParameter("Descripcion", typeof(string));
    
            var precioParameter = precio.HasValue ?
                new ObjectParameter("Precio", precio) :
                new ObjectParameter("Precio", typeof(decimal));
    
            var idDepartamentoParameter = idDepartamento.HasValue ?
                new ObjectParameter("IdDepartamento", idDepartamento) :
                new ObjectParameter("IdDepartamento", typeof(int));
    
            var idProveedorParameter = idProveedor.HasValue ?
                new ObjectParameter("IdProveedor", idProveedor) :
                new ObjectParameter("IdProveedor", typeof(int));
    
            var imageParameter = image != null ?
                new ObjectParameter("Image", image) :
                new ObjectParameter("Image", typeof(byte[]));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("AddProducto", nombreParameter, descripcionParameter, precioParameter, idDepartamentoParameter, idProveedorParameter, imageParameter);
        }
    
        public virtual int AddProductoSucursal(Nullable<int> idProducto, Nullable<int> idSucursal)
        {
            var idProductoParameter = idProducto.HasValue ?
                new ObjectParameter("IdProducto", idProducto) :
                new ObjectParameter("IdProducto", typeof(int));
    
            var idSucursalParameter = idSucursal.HasValue ?
                new ObjectParameter("IdSucursal", idSucursal) :
                new ObjectParameter("IdSucursal", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("AddProductoSucursal", idProductoParameter, idSucursalParameter);
        }
    
        public virtual int AddProveedor(string nombreProveedor, string telefono)
        {
            var nombreProveedorParameter = nombreProveedor != null ?
                new ObjectParameter("NombreProveedor", nombreProveedor) :
                new ObjectParameter("NombreProveedor", typeof(string));
    
            var telefonoParameter = telefono != null ?
                new ObjectParameter("Telefono", telefono) :
                new ObjectParameter("Telefono", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("AddProveedor", nombreProveedorParameter, telefonoParameter);
        }
    
        public virtual int AddSucursal(string nombreS)
        {
            var nombreSParameter = nombreS != null ?
                new ObjectParameter("NombreS", nombreS) :
                new ObjectParameter("NombreS", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("AddSucursal", nombreSParameter);
        }
    
        public virtual int DeleteArea(Nullable<int> idArea)
        {
            var idAreaParameter = idArea.HasValue ?
                new ObjectParameter("IdArea", idArea) :
                new ObjectParameter("IdArea", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("DeleteArea", idAreaParameter);
        }
    
        public virtual int DeleteProducto(Nullable<int> idProducto)
        {
            var idProductoParameter = idProducto.HasValue ?
                new ObjectParameter("IdProducto", idProducto) :
                new ObjectParameter("IdProducto", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("DeleteProducto", idProductoParameter);
        }
    
        public virtual int DeleteProductoSucursal(Nullable<int> idProductoSucursal)
        {
            var idProductoSucursalParameter = idProductoSucursal.HasValue ?
                new ObjectParameter("IdProductoSucursal", idProductoSucursal) :
                new ObjectParameter("IdProductoSucursal", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("DeleteProductoSucursal", idProductoSucursalParameter);
        }
    
        public virtual int DeleteProveedor(Nullable<int> idProveedor)
        {
            var idProveedorParameter = idProveedor.HasValue ?
                new ObjectParameter("IdProveedor", idProveedor) :
                new ObjectParameter("IdProveedor", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("DeleteProveedor", idProveedorParameter);
        }
    
        public virtual int DeleteSucursal(Nullable<int> idSucursal)
        {
            var idSucursalParameter = idSucursal.HasValue ?
                new ObjectParameter("IdSucursal", idSucursal) :
                new ObjectParameter("IdSucursal", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("DeleteSucursal", idSucursalParameter);
        }
    
        public virtual ObjectResult<GetAllArea_Result> GetAllArea()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<GetAllArea_Result>("GetAllArea");
        }
    
        public virtual ObjectResult<GetAllProducto_Result> GetAllProducto()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<GetAllProducto_Result>("GetAllProducto");
        }
    
        public virtual ObjectResult<GetAllProductoSucursal_Result> GetAllProductoSucursal()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<GetAllProductoSucursal_Result>("GetAllProductoSucursal");
        }
    
        public virtual ObjectResult<GetAllProveedor_Result> GetAllProveedor()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<GetAllProveedor_Result>("GetAllProveedor");
        }
    
        public virtual ObjectResult<GetAllSucursal_Result> GetAllSucursal()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<GetAllSucursal_Result>("GetAllSucursal");
        }
    
        public virtual int sp_alterdiagram(string diagramname, Nullable<int> owner_id, Nullable<int> version, byte[] definition)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            var versionParameter = version.HasValue ?
                new ObjectParameter("version", version) :
                new ObjectParameter("version", typeof(int));
    
            var definitionParameter = definition != null ?
                new ObjectParameter("definition", definition) :
                new ObjectParameter("definition", typeof(byte[]));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_alterdiagram", diagramnameParameter, owner_idParameter, versionParameter, definitionParameter);
        }
    
        public virtual int sp_creatediagram(string diagramname, Nullable<int> owner_id, Nullable<int> version, byte[] definition)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            var versionParameter = version.HasValue ?
                new ObjectParameter("version", version) :
                new ObjectParameter("version", typeof(int));
    
            var definitionParameter = definition != null ?
                new ObjectParameter("definition", definition) :
                new ObjectParameter("definition", typeof(byte[]));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_creatediagram", diagramnameParameter, owner_idParameter, versionParameter, definitionParameter);
        }
    
        public virtual int sp_dropdiagram(string diagramname, Nullable<int> owner_id)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_dropdiagram", diagramnameParameter, owner_idParameter);
        }
    
        public virtual ObjectResult<sp_helpdiagramdefinition_Result> sp_helpdiagramdefinition(string diagramname, Nullable<int> owner_id)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_helpdiagramdefinition_Result>("sp_helpdiagramdefinition", diagramnameParameter, owner_idParameter);
        }
    
        public virtual ObjectResult<sp_helpdiagrams_Result> sp_helpdiagrams(string diagramname, Nullable<int> owner_id)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_helpdiagrams_Result>("sp_helpdiagrams", diagramnameParameter, owner_idParameter);
        }
    
        public virtual int sp_renamediagram(string diagramname, Nullable<int> owner_id, string new_diagramname)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            var new_diagramnameParameter = new_diagramname != null ?
                new ObjectParameter("new_diagramname", new_diagramname) :
                new ObjectParameter("new_diagramname", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_renamediagram", diagramnameParameter, owner_idParameter, new_diagramnameParameter);
        }
    
        public virtual int sp_upgraddiagrams()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_upgraddiagrams");
        }
    
        public virtual int UpdateArea(string nombreA, Nullable<int> idArea)
        {
            var nombreAParameter = nombreA != null ?
                new ObjectParameter("NombreA", nombreA) :
                new ObjectParameter("NombreA", typeof(string));
    
            var idAreaParameter = idArea.HasValue ?
                new ObjectParameter("IdArea", idArea) :
                new ObjectParameter("IdArea", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("UpdateArea", nombreAParameter, idAreaParameter);
        }
    
        public virtual int UpdateProducto(string nombre, string descripcion, Nullable<decimal> precio, Nullable<int> idDepartamento, Nullable<int> idProveedor, byte[] image, Nullable<int> idProducto)
        {
            var nombreParameter = nombre != null ?
                new ObjectParameter("Nombre", nombre) :
                new ObjectParameter("Nombre", typeof(string));
    
            var descripcionParameter = descripcion != null ?
                new ObjectParameter("Descripcion", descripcion) :
                new ObjectParameter("Descripcion", typeof(string));
    
            var precioParameter = precio.HasValue ?
                new ObjectParameter("Precio", precio) :
                new ObjectParameter("Precio", typeof(decimal));
    
            var idDepartamentoParameter = idDepartamento.HasValue ?
                new ObjectParameter("IdDepartamento", idDepartamento) :
                new ObjectParameter("IdDepartamento", typeof(int));
    
            var idProveedorParameter = idProveedor.HasValue ?
                new ObjectParameter("IdProveedor", idProveedor) :
                new ObjectParameter("IdProveedor", typeof(int));
    
            var imageParameter = image != null ?
                new ObjectParameter("Image", image) :
                new ObjectParameter("Image", typeof(byte[]));
    
            var idProductoParameter = idProducto.HasValue ?
                new ObjectParameter("IdProducto", idProducto) :
                new ObjectParameter("IdProducto", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("UpdateProducto", nombreParameter, descripcionParameter, precioParameter, idDepartamentoParameter, idProveedorParameter, imageParameter, idProductoParameter);
        }
    
        public virtual int UpdateProductoSucursal(Nullable<int> idProducto, Nullable<int> idSucursal, Nullable<int> idProductoSucursal)
        {
            var idProductoParameter = idProducto.HasValue ?
                new ObjectParameter("IdProducto", idProducto) :
                new ObjectParameter("IdProducto", typeof(int));
    
            var idSucursalParameter = idSucursal.HasValue ?
                new ObjectParameter("IdSucursal", idSucursal) :
                new ObjectParameter("IdSucursal", typeof(int));
    
            var idProductoSucursalParameter = idProductoSucursal.HasValue ?
                new ObjectParameter("IdProductoSucursal", idProductoSucursal) :
                new ObjectParameter("IdProductoSucursal", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("UpdateProductoSucursal", idProductoParameter, idSucursalParameter, idProductoSucursalParameter);
        }
    
        public virtual int UpdateProveedor(string nombreProveedor, string telefono, Nullable<int> idProveedor)
        {
            var nombreProveedorParameter = nombreProveedor != null ?
                new ObjectParameter("NombreProveedor", nombreProveedor) :
                new ObjectParameter("NombreProveedor", typeof(string));
    
            var telefonoParameter = telefono != null ?
                new ObjectParameter("Telefono", telefono) :
                new ObjectParameter("Telefono", typeof(string));
    
            var idProveedorParameter = idProveedor.HasValue ?
                new ObjectParameter("IdProveedor", idProveedor) :
                new ObjectParameter("IdProveedor", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("UpdateProveedor", nombreProveedorParameter, telefonoParameter, idProveedorParameter);
        }
    
        public virtual int UpdateSucursal(string nombreS, Nullable<int> idSucursal)
        {
            var nombreSParameter = nombreS != null ?
                new ObjectParameter("NombreS", nombreS) :
                new ObjectParameter("NombreS", typeof(string));
    
            var idSucursalParameter = idSucursal.HasValue ?
                new ObjectParameter("IdSucursal", idSucursal) :
                new ObjectParameter("IdSucursal", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("UpdateSucursal", nombreSParameter, idSucursalParameter);
        }
    
        public virtual ObjectResult<GetAllDepartamento1_Result> GetAllDepartamento1()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<GetAllDepartamento1_Result>("GetAllDepartamento1");
        }
    
        public virtual int AddCliente(string nombreC, string rfc)
        {
            var nombreCParameter = nombreC != null ?
                new ObjectParameter("NombreC", nombreC) :
                new ObjectParameter("NombreC", typeof(string));
    
            var rfcParameter = rfc != null ?
                new ObjectParameter("Rfc", rfc) :
                new ObjectParameter("Rfc", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("AddCliente", nombreCParameter, rfcParameter);
        }
    
        public virtual int AddMetodoPago(string metodo)
        {
            var metodoParameter = metodo != null ?
                new ObjectParameter("Metodo", metodo) :
                new ObjectParameter("Metodo", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("AddMetodoPago", metodoParameter);
        }
    
        public virtual int DeleteCliente(Nullable<int> idCliente)
        {
            var idClienteParameter = idCliente.HasValue ?
                new ObjectParameter("IdCliente", idCliente) :
                new ObjectParameter("IdCliente", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("DeleteCliente", idClienteParameter);
        }
    
        public virtual int DeleteMetodoPago(Nullable<int> idMetodoPago)
        {
            var idMetodoPagoParameter = idMetodoPago.HasValue ?
                new ObjectParameter("IdMetodoPago", idMetodoPago) :
                new ObjectParameter("IdMetodoPago", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("DeleteMetodoPago", idMetodoPagoParameter);
        }
    
        public virtual ObjectResult<GetAllCliente_Result> GetAllCliente()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<GetAllCliente_Result>("GetAllCliente");
        }
    
        public virtual ObjectResult<GetAllDepartamentos_Result> GetAllDepartamentos()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<GetAllDepartamentos_Result>("GetAllDepartamentos");
        }
    
        public virtual ObjectResult<GetAllMetodoPago_Result> GetAllMetodoPago()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<GetAllMetodoPago_Result>("GetAllMetodoPago");
        }
    
        public virtual int UpdateCliente(string nombreC, string rfc, Nullable<int> idCliente)
        {
            var nombreCParameter = nombreC != null ?
                new ObjectParameter("NombreC", nombreC) :
                new ObjectParameter("NombreC", typeof(string));
    
            var rfcParameter = rfc != null ?
                new ObjectParameter("Rfc", rfc) :
                new ObjectParameter("Rfc", typeof(string));
    
            var idClienteParameter = idCliente.HasValue ?
                new ObjectParameter("IdCliente", idCliente) :
                new ObjectParameter("IdCliente", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("UpdateCliente", nombreCParameter, rfcParameter, idClienteParameter);
        }
    
        public virtual int UpdateMetodoPago(string metodo, Nullable<int> idMetodoProducto)
        {
            var metodoParameter = metodo != null ?
                new ObjectParameter("Metodo", metodo) :
                new ObjectParameter("Metodo", typeof(string));
    
            var idMetodoProductoParameter = idMetodoProducto.HasValue ?
                new ObjectParameter("IdMetodoProducto", idMetodoProducto) :
                new ObjectParameter("IdMetodoProducto", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("UpdateMetodoPago", metodoParameter, idMetodoProductoParameter);
        }
    }
}