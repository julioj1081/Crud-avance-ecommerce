-- --------------------------------------------------------
-- Host:                         localhost\MSSQLSERVER01
-- Versión del servidor:         Microsoft SQL Server 2019 (RTM-GDR) (KB4517790) - 15.0.2070.41
-- SO del servidor:              Windows 10 Pro 10.0 <X64> (Build 19042: )
-- HeidiSQL Versión:             11.1.0.6116
-- --------------------------------------------------------

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET NAMES  */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;


-- Volcando estructura de base de datos para JFernandezEcommerce
CREATE DATABASE IF NOT EXISTS "JFernandezEcommerce";
USE "JFernandezEcommerce";

-- Volcando estructura para procedimiento JFernandezEcommerce.AddArea
DELIMITER //
create procedure AddArea
@NombreA varchar(50)
as
insert into JFernandezArea values (@NombreA)
//
DELIMITER ;

-- Volcando estructura para procedimiento JFernandezEcommerce.AddCliente
DELIMITER //
create procedure AddCliente
@NombreC varchar(50),
@Rfc varchar(50)
as 
Insert into JFernandezCliente values(@NombreC, @Rfc)
//
DELIMITER ;

-- Volcando estructura para procedimiento JFernandezEcommerce.AddDepartamento
DELIMITER //
create procedure AddDepartamento
@NombreD varchar(50),
@IdArea int
as
insert into JFernandezDepartamento values (@NombreD, @IdArea)
//
DELIMITER ;

-- Volcando estructura para procedimiento JFernandezEcommerce.AddMetodoPago
DELIMITER //
create procedure AddMetodoPago
@Metodo varchar(50)
as 
Insert into JFernandezMetodoPago values(@Metodo)
//
DELIMITER ;

-- Volcando estructura para procedimiento JFernandezEcommerce.AddProducto
DELIMITER //
create procedure AddProducto
@Nombre varchar(50),
@Descripcion varchar(50),
@Precio decimal,
@IdDepartamento int,
@IdProveedor int,
@Image varbinary(MAX)
as
insert into JFernandezProductos 
values (@Nombre, @Descripcion, @Precio, @IdDepartamento, @IdProveedor, @Image)
//
DELIMITER ;

-- Volcando estructura para procedimiento JFernandezEcommerce.AddProductoSucursal
DELIMITER //
create procedure AddProductoSucursal
@IdProducto int,
@IdSucursal int
as
insert into JFernandezProductoSucursal 
values (@IdProducto, @IdSucursal)
//
DELIMITER ;

-- Volcando estructura para procedimiento JFernandezEcommerce.AddProveedor
DELIMITER //
create procedure AddProveedor
@NombreProveedor varchar(50),
@Telefono varchar(10)
as
insert into JFernandezProveedor values (@NombreProveedor, @Telefono)
//
DELIMITER ;

-- Volcando estructura para procedimiento JFernandezEcommerce.AddSucursal
DELIMITER //
create procedure AddSucursal
@NombreS varchar(50)
as
insert into JFernandezSucursal 
values (@NombreS)
//
DELIMITER ;

-- Volcando estructura para procedimiento JFernandezEcommerce.AddVenta
DELIMITER //
create procedure AddVenta
@IdCliente int,
@Total float,
@IdMetodoPago int,
@Fecha date
as
Insert Into JFernandezVenta values(@IdCliente, @Total, @IdMetodoPago, @Fecha)
//
DELIMITER ;

-- Volcando estructura para procedimiento JFernandezEcommerce.AddVentaProducto
DELIMITER //
Create procedure AddVentaProducto
@IdVenta int,
@IdProductoSucursal int,
@Cantidad int,
@IdProducto int
as
Insert Into JFernandezVentaProducto VALUES(@IdVenta, @IdProductoSucursal, @Cantidad, @IdProducto)
//
DELIMITER ;

-- Volcando estructura para procedimiento JFernandezEcommerce.DeleteArea
DELIMITER //
create procedure DeleteArea
@IdArea int
as
Delete from JFernandezArea Where IdArea = @IdArea
//
DELIMITER ;

-- Volcando estructura para procedimiento JFernandezEcommerce.DeleteCliente
DELIMITER //
create procedure DeleteCliente
@IdCliente int
as
Delete from JFernandezCliente WHERE IdCliente = @IdCliente
//
DELIMITER ;

-- Volcando estructura para procedimiento JFernandezEcommerce.DeleteDepartamento
DELIMITER //
create procedure DeleteDepartamento
@IdDepartamento int
as Delete from JFernandezDepartamento WHERE IdDepartamento = @IdDepartamento
//
DELIMITER ;

-- Volcando estructura para procedimiento JFernandezEcommerce.DeleteMetodoPago
DELIMITER //
create procedure DeleteMetodoPago
@IdMetodoPago int
as
Delete from JFernandezMetodoPago WHERE IdMetodoPago = @IdMetodoPago
//
DELIMITER ;

-- Volcando estructura para procedimiento JFernandezEcommerce.DeleteProducto
DELIMITER //
create procedure DeleteProducto
@IdProducto int
as
Delete from JFernandezProductos Where IdProducto = @IdProducto
//
DELIMITER ;

-- Volcando estructura para procedimiento JFernandezEcommerce.DeleteProductoSucursal
DELIMITER //
create procedure DeleteProductoSucursal
@IdProductoSucursal int
as
Delete from JFernandezProductoSucursal Where IdProductoSucursal = @IdProductoSucursal
//
DELIMITER ;

-- Volcando estructura para procedimiento JFernandezEcommerce.DeleteProveedor
DELIMITER //
create procedure DeleteProveedor
@IdProveedor int
as
Delete from JFernandezProveedor Where IdProveedor = @IdProveedor
//
DELIMITER ;

-- Volcando estructura para procedimiento JFernandezEcommerce.DeleteSucursal
DELIMITER //
create procedure DeleteSucursal
@IdSucursal int
as
Delete from JFernandezSucursal Where IdSucursal = @IdSucursal
//
DELIMITER ;

-- Volcando estructura para procedimiento JFernandezEcommerce.DeleteVenta
DELIMITER //
create procedure DeleteVenta
@IdVenta int
as
Delete from JFernandezVenta Where IdVenta = @IdVenta
//
DELIMITER ;

-- Volcando estructura para función JFernandezEcommerce.fn_diagramobjects
DELIMITER //

	CREATE FUNCTION dbo.fn_diagramobjects() 
	RETURNS int
	WITH EXECUTE AS N'dbo'
	AS
	BEGIN
		declare @id_upgraddiagrams		int
		declare @id_sysdiagrams			int
		declare @id_helpdiagrams		int
		declare @id_helpdiagramdefinition	int
		declare @id_creatediagram	int
		declare @id_renamediagram	int
		declare @id_alterdiagram 	int 
		declare @id_dropdiagram		int
		declare @InstalledObjects	int

		select @InstalledObjects = 0

		select 	@id_upgraddiagrams = object_id(N'dbo.sp_upgraddiagrams'),
			@id_sysdiagrams = object_id(N'dbo.sysdiagrams'),
			@id_helpdiagrams = object_id(N'dbo.sp_helpdiagrams'),
			@id_helpdiagramdefinition = object_id(N'dbo.sp_helpdiagramdefinition'),
			@id_creatediagram = object_id(N'dbo.sp_creatediagram'),
			@id_renamediagram = object_id(N'dbo.sp_renamediagram'),
			@id_alterdiagram = object_id(N'dbo.sp_alterdiagram'), 
			@id_dropdiagram = object_id(N'dbo.sp_dropdiagram')

		if @id_upgraddiagrams is not null
			select @InstalledObjects = @InstalledObjects + 1
		if @id_sysdiagrams is not null
			select @InstalledObjects = @InstalledObjects + 2
		if @id_helpdiagrams is not null
			select @InstalledObjects = @InstalledObjects + 4
		if @id_helpdiagramdefinition is not null
			select @InstalledObjects = @InstalledObjects + 8
		if @id_creatediagram is not null
			select @InstalledObjects = @InstalledObjects + 16
		if @id_renamediagram is not null
			select @InstalledObjects = @InstalledObjects + 32
		if @id_alterdiagram  is not null
			select @InstalledObjects = @InstalledObjects + 64
		if @id_dropdiagram is not null
			select @InstalledObjects = @InstalledObjects + 128
		
		return @InstalledObjects 
	END
	//
DELIMITER ;

-- Volcando estructura para procedimiento JFernandezEcommerce.GetAllArea
DELIMITER //
create procedure GetAllArea
as
select * from JFernandezArea
//
DELIMITER ;

-- Volcando estructura para procedimiento JFernandezEcommerce.GetAllCliente
DELIMITER //
create procedure GetAllCliente
as
select * from JFernandezCliente
//
DELIMITER ;

-- Volcando estructura para procedimiento JFernandezEcommerce.GetAllDepartamento
DELIMITER //
CREATE PROCEDURE GetAllDepartamento
as
Select IdDepartamento, NombreD,  NombreA from JFernandezDepartamento
Left join JFernandezArea
ON JFernandezDepartamento.IdArea = JFernandezArea.IdArea//
DELIMITER ;

-- Volcando estructura para procedimiento JFernandezEcommerce.GetAllDepartamentos
DELIMITER //

CREATE PROCEDURE GetAllDepartamentos
as
select * from JFernandezDepartamento
//
DELIMITER ;

-- Volcando estructura para procedimiento JFernandezEcommerce.GetAllMetodoPago
DELIMITER //
create procedure GetAllMetodoPago
as
SELECT * FROM JFernandezMetodoPago
//
DELIMITER ;

-- Volcando estructura para procedimiento JFernandezEcommerce.GetAllProducto
DELIMITER //
CREATE procedure [dbo].[GetAllProducto]
as
SELECT  IdProducto, Nombre as 'Productos', Descripcion, Precio, NombreD AS 'Departamento', NombreProveedor as 'Provedor', Image
from JFernandezProductos 
INNER JOIN JFernandezDepartamento
on JFernandezProductos.IdDepartamento=JFernandezDepartamento.IdDepartamento
INNER JOIN JFernandezProveedor
on JFernandezProductos.IdProveedor=JFernandezProveedor.IdProveedor//
DELIMITER ;

-- Volcando estructura para procedimiento JFernandezEcommerce.GetAllProductoSucursal
DELIMITER //
CREATE procedure [dbo].[GetAllProductoSucursal]
as
SELECT IdProductoSucursal, Nombre, NombreS FROM JFernandezProductoSucursal
Left join JFernandezProductos 
ON JFernandezProductoSucursal.IdProducto = JFernandezProductos.IdProducto
Left join JFernandezSucursal 
ON JFernandezProductoSucursal.IdSucursal = JFernandezSucursal.IdSucursal//
DELIMITER ;

-- Volcando estructura para procedimiento JFernandezEcommerce.GetAllProveedor
DELIMITER //
create procedure GetAllProveedor
as
select * from JFernandezProveedor
//
DELIMITER ;

-- Volcando estructura para procedimiento JFernandezEcommerce.GetAllSucursal
DELIMITER //
create procedure GetAllSucursal
as
select * from JFernandezSucursal
//
DELIMITER ;

-- Volcando estructura para procedimiento JFernandezEcommerce.GetAllVenta
DELIMITER //
create procedure GetAllVenta
as
SELECT IdVenta, NombreC, Total, Metodo, Fecha FROM JFernandezVenta
LEFT JOIN JFernandezCliente
ON JFernandezVenta.IdCliente = JFernandezCliente.IdCliente
LEFT JOIN JFernandezMetodoPago
ON JFernandezVenta.IdMetodoPago = JFernandezMetodoPago.IdMetodoPago
//
DELIMITER ;

-- Volcando estructura para procedimiento JFernandezEcommerce.GetAllVentaProducto
DELIMITER //
CREATE procedure [dbo].[GetAllVentaProducto]
as
SELECT IdVentaProducto, IdCliente, NombreS AS 'Nombre Sucursal', Cantidad, Nombre AS 'Nombre del producto'FROM JFernandezVentaProducto
INNER JOIN JFernandezVenta
ON JFernandezVentaProducto.IdVenta = JFernandezVenta.IdVenta 
INNER JOIN JFernandezSucursal
ON JFernandezVentaProducto.IdProductoSucursal = JFernandezSucursal.IdSucursal 
Inner JOIN JFernandezProductos
ON JFernandezVentaProducto.IdProducto = JFernandezProductos.IdProducto 

//
DELIMITER ;

-- Volcando estructura para procedimiento JFernandezEcommerce.GetByIdEF_Cliente
DELIMITER //
Create Procedure GetByIdEF_Cliente
@IdCliente int
as
select * from JFernandezCliente WHERE IdCliente = @IdCliente
//
DELIMITER ;

-- Volcando estructura para procedimiento JFernandezEcommerce.GetByIdEF_Departamento
DELIMITER //
create procedure GetByIdEF
@IdDepartamento int
as select * from JFernandezDepartamento WHERE IdDepartamento = @IdDepartamento
//
DELIMITER ;

-- Volcando estructura para procedimiento JFernandezEcommerce.GetByIdEF_Producto
DELIMITER //
Create Procedure GetByIdEF_Producto
@IdProducto int
as
select * from JFernandezProductos WHERE IdProducto = @IdProducto
//
DELIMITER ;

-- Volcando estructura para tabla JFernandezEcommerce.JFernandezArea
CREATE TABLE IF NOT EXISTS "JFernandezArea" (
	"IdArea" INT NOT NULL,
	"NombreA" VARCHAR(50) NULL DEFAULT NULL COLLATE 'Modern_Spanish_CI_AS',
	PRIMARY KEY ("IdArea")
);

-- Volcando datos para la tabla JFernandezEcommerce.JFernandezArea: -1 rows
/*!40000 ALTER TABLE "JFernandezArea" DISABLE KEYS */;
REPLACE INTO "JFernandezArea" ("IdArea", "NombreA") VALUES
	(1, 'Frutas y verduras'),
	(2, 'Muebles'),
	(3, 'Ferreteria'),
	(4, 'Papeleria'),
	(5, 'Jugeteria'),
	(6, 'Hojar'),
	(7, 'Decoracion'),
	(8, 'Accesorios de autos'),
	(1005, 'Devoluciones'),
	(1007, 'Electronicos');
/*!40000 ALTER TABLE "JFernandezArea" ENABLE KEYS */;

-- Volcando estructura para tabla JFernandezEcommerce.JFernandezCliente
CREATE TABLE IF NOT EXISTS "JFernandezCliente" (
	"IdCliente" INT NOT NULL,
	"NombreC" VARCHAR(50) NULL DEFAULT NULL COLLATE 'Modern_Spanish_CI_AS',
	"Rfc" VARCHAR(50) NULL DEFAULT NULL COLLATE 'Modern_Spanish_CI_AS',
	PRIMARY KEY ("IdCliente")
);

-- Volcando datos para la tabla JFernandezEcommerce.JFernandezCliente: -1 rows
/*!40000 ALTER TABLE "JFernandezCliente" DISABLE KEYS */;
REPLACE INTO "JFernandezCliente" ("IdCliente", "NombreC", "Rfc") VALUES
	(1, 'gabriel flores', 'rflsa123'),
	(3, 'juanito', 'FRC 123'),
	(5, 'alejandro', 'alefg');
/*!40000 ALTER TABLE "JFernandezCliente" ENABLE KEYS */;

-- Volcando estructura para tabla JFernandezEcommerce.JFernandezDepartamento
CREATE TABLE IF NOT EXISTS "JFernandezDepartamento" (
	"IdDepartamento" INT NOT NULL,
	"NombreD" VARCHAR(50) NULL DEFAULT NULL COLLATE 'Modern_Spanish_CI_AS',
	"IdArea" INT NULL DEFAULT NULL,
	PRIMARY KEY ("IdDepartamento"),
	FOREIGN KEY INDEX "FK_JFernandezDepartamento_JFernandezArea" ("IdArea"),
	CONSTRAINT "FK_JFernandezDepartamento_JFernandezArea" FOREIGN KEY ("IdArea") REFERENCES "JFernandezArea" ("IdArea") ON UPDATE NO_ACTION ON DELETE NO_ACTION
);

-- Volcando datos para la tabla JFernandezEcommerce.JFernandezDepartamento: -1 rows
/*!40000 ALTER TABLE "JFernandezDepartamento" DISABLE KEYS */;
REPLACE INTO "JFernandezDepartamento" ("IdDepartamento", "NombreD", "IdArea") VALUES
	(1, 'Departamento de frutitas', 4),
	(2, 'Departamento de muebles', 2),
	(3, 'Departamento de Ferreteria', 3),
	(4, 'Departamento de Papeleria', 7),
	(5, 'Departamento de Jugueteria', 5),
	(6, 'Departamento de Hogar', 6),
	(7, 'Departamento de decoracion', 7),
	(8, 'Departamento de herramientas', 8),
	(14, 'departamento de frutas y verduras', 1),
	(20, 'muebles rincon', 2),
	(26, 'Departamento de WCF', 3),
	(31, 'Departamento wcf', 3),
	(32, 'Departamento WCF', 4),
	(33, 'Departamento de ventas', 5),
	(35, 'prueba limipeza', 7);
/*!40000 ALTER TABLE "JFernandezDepartamento" ENABLE KEYS */;

-- Volcando estructura para tabla JFernandezEcommerce.JFernandezMetodoPago
CREATE TABLE IF NOT EXISTS "JFernandezMetodoPago" (
	"IdMetodoPago" INT NOT NULL,
	"Metodo" VARCHAR(50) NULL DEFAULT NULL COLLATE 'Modern_Spanish_CI_AS',
	PRIMARY KEY ("IdMetodoPago")
);

-- Volcando datos para la tabla JFernandezEcommerce.JFernandezMetodoPago: -1 rows
/*!40000 ALTER TABLE "JFernandezMetodoPago" DISABLE KEYS */;
REPLACE INTO "JFernandezMetodoPago" ("IdMetodoPago", "Metodo") VALUES
	(1, 'Pago credito'),
	(2, 'Pago tarjeta'),
	(3, 'Pago monetario'),
	(4, 'paypal'),
	(5, 'efectivo');
/*!40000 ALTER TABLE "JFernandezMetodoPago" ENABLE KEYS */;

-- Volcando estructura para tabla JFernandezEcommerce.JFernandezProductos
CREATE TABLE IF NOT EXISTS "JFernandezProductos" (
	"IdProducto" INT NOT NULL,
	"Nombre" VARCHAR(50) NULL DEFAULT NULL COLLATE 'Modern_Spanish_CI_AS',
	"Descripcion" VARCHAR(50) NULL DEFAULT NULL COLLATE 'Modern_Spanish_CI_AS',
	"Precio" DECIMAL(18,0) NULL DEFAULT NULL,
	"IdDepartamento" INT NULL DEFAULT NULL,
	"IdProveedor" INT NULL DEFAULT NULL,
	"Image" VARBINARY NULL DEFAULT NULL,
	PRIMARY KEY ("IdProducto"),
	FOREIGN KEY INDEX "FK_JFernandezProductos_JFernandezDepartamento" ("IdDepartamento"),
	FOREIGN KEY INDEX "FK_JFernandezProductos_JFernandezProveedor" ("IdProveedor"),
	CONSTRAINT "FK_JFernandezProductos_JFernandezDepartamento" FOREIGN KEY ("IdDepartamento") REFERENCES "JFernandezDepartamento" ("IdDepartamento") ON UPDATE NO_ACTION ON DELETE NO_ACTION,
	CONSTRAINT "FK_JFernandezProductos_JFernandezProveedor" FOREIGN KEY ("IdProveedor") REFERENCES "JFernandezProveedor" ("IdProveedor") ON UPDATE NO_ACTION ON DELETE NO_ACTION
);

-- Volcando datos para la tabla JFernandezEcommerce.JFernandezProductos: -1 rows
/*!40000 ALTER TABLE "JFernandezProductos" DISABLE KEYS */;
REPLACE INTO "JFernandezProductos" ("IdProducto", "Nombre", "Descripcion", "Precio", "IdDepartamento", "IdProveedor", "Image") VALUES
	(1, 'Mango', 'Furta fresca', 10, 1, 1, _binary 0x368762B29A2789B95E),
	(2, 'Manzana', 'fruta fresca', 6, 1, 1, NULL),
	(3, 'Pescado', 'Pescado fresco', 45, 1, 2, NULL),
	(4, 'Carne de coyote', 'carne fresca', 123, 1, 1, _binary 0x368762B29A2789B95E),
	(5, 'Nuez', 'especiea', 15, 1, 1, NULL),
	(6, 'Pan de nuez', 'pan con nuez', 8, 1, 1, NULL),
	(7, 'Tortillas tia rosa', 'Tortillas de arina', 24, 1, 3, _binary 0x368762B29A2789B95E),
	(8, 'Crema lala', 'Cremas', 25, 1, 1, _binary 0x368762B29A2789B95E),
	(9, 'Yogurt Alpura', 'Lacteos y yogurt', 15, 1, 2, _binary 0x368762B29A2789B95E),
	(1006, 'sopa maruchan', 'nissan', 12, 1, 5, _binary 0x368762B29A2789B95E);
/*!40000 ALTER TABLE "JFernandezProductos" ENABLE KEYS */;

-- Volcando estructura para tabla JFernandezEcommerce.JFernandezProductoSucursal
CREATE TABLE IF NOT EXISTS "JFernandezProductoSucursal" (
	"IdProductoSucursal" INT NOT NULL,
	"IdProducto" INT NULL DEFAULT NULL,
	"IdSucursal" INT NULL DEFAULT NULL,
	FOREIGN KEY INDEX "FK_JFernandezProductoSucursal_JFernandezSucursal1" ("IdProducto"),
	FOREIGN KEY INDEX "FK_JFernandezProductoSucursal_JFernandezProductoSucursal" ("IdProductoSucursal"),
	PRIMARY KEY ("IdProductoSucursal"),
	CONSTRAINT "FK_JFernandezProductoSucursal_JFernandezSucursal1" FOREIGN KEY ("IdProducto") REFERENCES "JFernandezProductos" ("IdProducto") ON UPDATE NO_ACTION ON DELETE NO_ACTION,
	CONSTRAINT "FK_JFernandezProductoSucursal_JFernandezProductoSucursal" FOREIGN KEY ("IdProductoSucursal") REFERENCES "JFernandezProductoSucursal" ("IdProductoSucursal") ON UPDATE NO_ACTION ON DELETE NO_ACTION
);

-- Volcando datos para la tabla JFernandezEcommerce.JFernandezProductoSucursal: -1 rows
/*!40000 ALTER TABLE "JFernandezProductoSucursal" DISABLE KEYS */;
REPLACE INTO "JFernandezProductoSucursal" ("IdProductoSucursal", "IdProducto", "IdSucursal") VALUES
	(1, 1, 2),
	(2, 5, 3),
	(3, 2, 3),
	(4, 2, 1),
	(5, 7, 1);
/*!40000 ALTER TABLE "JFernandezProductoSucursal" ENABLE KEYS */;

-- Volcando estructura para tabla JFernandezEcommerce.JFernandezProveedor
CREATE TABLE IF NOT EXISTS "JFernandezProveedor" (
	"IdProveedor" INT NOT NULL,
	"NombreProveedor" VARCHAR(50) NULL DEFAULT NULL COLLATE 'Modern_Spanish_CI_AS',
	"Telefono" VARCHAR(10) NULL DEFAULT NULL COLLATE 'Modern_Spanish_CI_AS',
	PRIMARY KEY ("IdProveedor")
);

-- Volcando datos para la tabla JFernandezEcommerce.JFernandezProveedor: -1 rows
/*!40000 ALTER TABLE "JFernandezProveedor" DISABLE KEYS */;
REPLACE INTO "JFernandezProveedor" ("IdProveedor", "NombreProveedor", "Telefono") VALUES
	(1, 'gabriel', '5577884455'),
	(2, 'Provedor 2', '1234123412'),
	(3, 'LUCAS', '6664852147'),
	(4, 'juanito', '1231234321'),
	(5, 'Marco', '5577885522');
/*!40000 ALTER TABLE "JFernandezProveedor" ENABLE KEYS */;

-- Volcando estructura para tabla JFernandezEcommerce.JFernandezSucursal
CREATE TABLE IF NOT EXISTS "JFernandezSucursal" (
	"IdSucursal" INT NOT NULL,
	"NombreS" VARCHAR(50) NULL DEFAULT NULL COLLATE 'Modern_Spanish_CI_AS',
	PRIMARY KEY ("IdSucursal")
);

-- Volcando datos para la tabla JFernandezEcommerce.JFernandezSucursal: -1 rows
/*!40000 ALTER TABLE "JFernandezSucursal" DISABLE KEYS */;
REPLACE INTO "JFernandezSucursal" ("IdSucursal", "NombreS") VALUES
	(1, 'sanborns'),
	(2, 'Wallmart'),
	(3, 'Aurrera'),
	(4, 'Electra'),
	(5, 'coopel');
/*!40000 ALTER TABLE "JFernandezSucursal" ENABLE KEYS */;

-- Volcando estructura para tabla JFernandezEcommerce.JFernandezVenta
CREATE TABLE IF NOT EXISTS "JFernandezVenta" (
	"IdVenta" INT NOT NULL,
	"IdCliente" INT NULL DEFAULT NULL,
	"Total" FLOAT NULL DEFAULT NULL,
	"IdMetodoPago" INT NULL DEFAULT NULL,
	"Fecha" DATE NULL DEFAULT NULL,
	PRIMARY KEY ("IdVenta"),
	FOREIGN KEY INDEX "FK_JFernandezVenta_JFernandezCliente" ("IdCliente"),
	FOREIGN KEY INDEX "FK_JFernandezVenta_JFernandezMetodoPago" ("IdMetodoPago"),
	CONSTRAINT "FK_JFernandezVenta_JFernandezCliente" FOREIGN KEY ("IdCliente") REFERENCES "JFernandezCliente" ("IdCliente") ON UPDATE NO_ACTION ON DELETE NO_ACTION,
	CONSTRAINT "FK_JFernandezVenta_JFernandezMetodoPago" FOREIGN KEY ("IdMetodoPago") REFERENCES "JFernandezMetodoPago" ("IdMetodoPago") ON UPDATE NO_ACTION ON DELETE NO_ACTION
);

-- Volcando datos para la tabla JFernandezEcommerce.JFernandezVenta: -1 rows
/*!40000 ALTER TABLE "JFernandezVenta" DISABLE KEYS */;
REPLACE INTO "JFernandezVenta" ("IdVenta", "IdCliente", "Total", "IdMetodoPago", "Fecha") VALUES
	(1, 1, 15.45, 2, '2020-12-20'),
	(5, 3, 23.3199996948242, 2, '2020-12-31'),
	(6, 5, 24.3400001525879, 2, '2020-12-30'),
	(7, 5, 2, 1, '2020-12-30'),
	(8, 1, 18.5, 2, '2021-01-04');
/*!40000 ALTER TABLE "JFernandezVenta" ENABLE KEYS */;

-- Volcando estructura para tabla JFernandezEcommerce.JFernandezVentaProducto
CREATE TABLE IF NOT EXISTS "JFernandezVentaProducto" (
	"IdVentaProducto" INT NOT NULL,
	"IdVenta" INT NULL DEFAULT NULL,
	"IdProductoSucursal" INT NULL DEFAULT NULL,
	"Cantidad" INT NULL DEFAULT NULL,
	"IdProducto" INT NULL DEFAULT NULL,
	FOREIGN KEY INDEX "FK_JFernandezVentaProducto_JFernandezVenta" ("IdVenta"),
	FOREIGN KEY INDEX "FK_JFernandezVentaProducto_JFernandezProductoSucursal" ("IdProductoSucursal"),
	FOREIGN KEY INDEX "FK_JFernandezVentaProducto_JFernandezProductos" ("IdProducto"),
	PRIMARY KEY ("IdVentaProducto"),
	CONSTRAINT "FK_JFernandezVentaProducto_JFernandezProductos" FOREIGN KEY ("IdProducto") REFERENCES "JFernandezProductos" ("IdProducto") ON UPDATE NO_ACTION ON DELETE NO_ACTION,
	CONSTRAINT "FK_JFernandezVentaProducto_JFernandezProductoSucursal" FOREIGN KEY ("IdProductoSucursal") REFERENCES "JFernandezProductoSucursal" ("IdProductoSucursal") ON UPDATE NO_ACTION ON DELETE NO_ACTION,
	CONSTRAINT "FK_JFernandezVentaProducto_JFernandezVenta" FOREIGN KEY ("IdVenta") REFERENCES "JFernandezVenta" ("IdVenta") ON UPDATE NO_ACTION ON DELETE NO_ACTION
);

-- Volcando datos para la tabla JFernandezEcommerce.JFernandezVentaProducto: -1 rows
/*!40000 ALTER TABLE "JFernandezVentaProducto" DISABLE KEYS */;
REPLACE INTO "JFernandezVentaProducto" ("IdVentaProducto", "IdVenta", "IdProductoSucursal", "Cantidad", "IdProducto") VALUES
	(1, 5, 2, 2, 6),
	(2, 7, 4, 21, 9),
	(3, 6, 1, 13, 1),
	(4, 8, 3, 55, 8),
	(5, 5, 1, 666, 1),
	(6, 5, 1, 2, 9),
	(7, 5, 3, 777, 1);
/*!40000 ALTER TABLE "JFernandezVentaProducto" ENABLE KEYS */;

-- Volcando estructura para procedimiento JFernandezEcommerce.sp_alterdiagram
DELIMITER //

	CREATE PROCEDURE dbo.sp_alterdiagram
	(
		@diagramname 	sysname,
		@owner_id	int	= null,
		@version 	int,
		@definition 	varbinary(max)
	)
	WITH EXECUTE AS 'dbo'
	AS
	BEGIN
		set nocount on
	
		declare @theId 			int
		declare @retval 		int
		declare @IsDbo 			int
		
		declare @UIDFound 		int
		declare @DiagId			int
		declare @ShouldChangeUID	int
	
		if(@diagramname is null)
		begin
			RAISERROR ('Invalid ARG', 16, 1)
			return -1
		end
	
		execute as caller;
		select @theId = DATABASE_PRINCIPAL_ID();	 
		select @IsDbo = IS_MEMBER(N'db_owner'); 
		if(@owner_id is null)
			select @owner_id = @theId;
		revert;
	
		select @ShouldChangeUID = 0
		select @DiagId = diagram_id, @UIDFound = principal_id from dbo.sysdiagrams where principal_id = @owner_id and name = @diagramname 
		
		if(@DiagId IS NULL or (@IsDbo = 0 and @theId <> @UIDFound))
		begin
			RAISERROR ('Diagram does not exist or you do not have permission.', 16, 1);
			return -3
		end
	
		if(@IsDbo <> 0)
		begin
			if(@UIDFound is null or USER_NAME(@UIDFound) is null) -- invalid principal_id
			begin
				select @ShouldChangeUID = 1 ;
			end
		end

		-- update dds data			
		update dbo.sysdiagrams set definition = @definition where diagram_id = @DiagId ;

		-- change owner
		if(@ShouldChangeUID = 1)
			update dbo.sysdiagrams set principal_id = @theId where diagram_id = @DiagId ;

		-- update dds version
		if(@version is not null)
			update dbo.sysdiagrams set version = @version where diagram_id = @DiagId ;

		return 0
	END
	//
DELIMITER ;

-- Volcando estructura para procedimiento JFernandezEcommerce.sp_creatediagram
DELIMITER //

	CREATE PROCEDURE dbo.sp_creatediagram
	(
		@diagramname 	sysname,
		@owner_id		int	= null, 	
		@version 		int,
		@definition 	varbinary(max)
	)
	WITH EXECUTE AS 'dbo'
	AS
	BEGIN
		set nocount on
	
		declare @theId int
		declare @retval int
		declare @IsDbo	int
		declare @userName sysname
		if(@version is null or @diagramname is null)
		begin
			RAISERROR (N'E_INVALIDARG', 16, 1);
			return -1
		end
	
		execute as caller;
		select @theId = DATABASE_PRINCIPAL_ID(); 
		select @IsDbo = IS_MEMBER(N'db_owner');
		revert; 
		
		if @owner_id is null
		begin
			select @owner_id = @theId;
		end
		else
		begin
			if @theId <> @owner_id
			begin
				if @IsDbo = 0
				begin
					RAISERROR (N'E_INVALIDARG', 16, 1);
					return -1
				end
				select @theId = @owner_id
			end
		end
		-- next 2 line only for test, will be removed after define name unique
		if EXISTS(select diagram_id from dbo.sysdiagrams where principal_id = @theId and name = @diagramname)
		begin
			RAISERROR ('The name is already used.', 16, 1);
			return -2
		end
	
		insert into dbo.sysdiagrams(name, principal_id , version, definition)
				VALUES(@diagramname, @theId, @version, @definition) ;
		
		select @retval = @@IDENTITY 
		return @retval
	END
	//
DELIMITER ;

-- Volcando estructura para procedimiento JFernandezEcommerce.sp_dropdiagram
DELIMITER //

	CREATE PROCEDURE dbo.sp_dropdiagram
	(
		@diagramname 	sysname,
		@owner_id	int	= null
	)
	WITH EXECUTE AS 'dbo'
	AS
	BEGIN
		set nocount on
		declare @theId 			int
		declare @IsDbo 			int
		
		declare @UIDFound 		int
		declare @DiagId			int
	
		if(@diagramname is null)
		begin
			RAISERROR ('Invalid value', 16, 1);
			return -1
		end
	
		EXECUTE AS CALLER;
		select @theId = DATABASE_PRINCIPAL_ID();
		select @IsDbo = IS_MEMBER(N'db_owner'); 
		if(@owner_id is null)
			select @owner_id = @theId;
		REVERT; 
		
		select @DiagId = diagram_id, @UIDFound = principal_id from dbo.sysdiagrams where principal_id = @owner_id and name = @diagramname 
		if(@DiagId IS NULL or (@IsDbo = 0 and @UIDFound <> @theId))
		begin
			RAISERROR ('Diagram does not exist or you do not have permission.', 16, 1)
			return -3
		end
	
		delete from dbo.sysdiagrams where diagram_id = @DiagId;
	
		return 0;
	END
	//
DELIMITER ;

-- Volcando estructura para procedimiento JFernandezEcommerce.sp_helpdiagramdefinition
DELIMITER //

	CREATE PROCEDURE dbo.sp_helpdiagramdefinition
	(
		@diagramname 	sysname,
		@owner_id	int	= null 		
	)
	WITH EXECUTE AS N'dbo'
	AS
	BEGIN
		set nocount on

		declare @theId 		int
		declare @IsDbo 		int
		declare @DiagId		int
		declare @UIDFound	int
	
		if(@diagramname is null)
		begin
			RAISERROR (N'E_INVALIDARG', 16, 1);
			return -1
		end
	
		execute as caller;
		select @theId = DATABASE_PRINCIPAL_ID();
		select @IsDbo = IS_MEMBER(N'db_owner');
		if(@owner_id is null)
			select @owner_id = @theId;
		revert; 
	
		select @DiagId = diagram_id, @UIDFound = principal_id from dbo.sysdiagrams where principal_id = @owner_id and name = @diagramname;
		if(@DiagId IS NULL or (@IsDbo = 0 and @UIDFound <> @theId ))
		begin
			RAISERROR ('Diagram does not exist or you do not have permission.', 16, 1);
			return -3
		end

		select version, definition FROM dbo.sysdiagrams where diagram_id = @DiagId ; 
		return 0
	END
	//
DELIMITER ;

-- Volcando estructura para procedimiento JFernandezEcommerce.sp_helpdiagrams
DELIMITER //

	CREATE PROCEDURE dbo.sp_helpdiagrams
	(
		@diagramname sysname = NULL,
		@owner_id int = NULL
	)
	WITH EXECUTE AS N'dbo'
	AS
	BEGIN
		DECLARE @user sysname
		DECLARE @dboLogin bit
		EXECUTE AS CALLER;
			SET @user = USER_NAME();
			SET @dboLogin = CONVERT(bit,IS_MEMBER('db_owner'));
		REVERT;
		SELECT
			[Database] = DB_NAME(),
			[Name] = name,
			[ID] = diagram_id,
			[Owner] = USER_NAME(principal_id),
			[OwnerID] = principal_id
		FROM
			sysdiagrams
		WHERE
			(@dboLogin = 1 OR USER_NAME(principal_id) = @user) AND
			(@diagramname IS NULL OR name = @diagramname) AND
			(@owner_id IS NULL OR principal_id = @owner_id)
		ORDER BY
			4, 5, 1
	END
	//
DELIMITER ;

-- Volcando estructura para procedimiento JFernandezEcommerce.sp_renamediagram
DELIMITER //

	CREATE PROCEDURE dbo.sp_renamediagram
	(
		@diagramname 		sysname,
		@owner_id		int	= null,
		@new_diagramname	sysname
	
	)
	WITH EXECUTE AS 'dbo'
	AS
	BEGIN
		set nocount on
		declare @theId 			int
		declare @IsDbo 			int
		
		declare @UIDFound 		int
		declare @DiagId			int
		declare @DiagIdTarg		int
		declare @u_name			sysname
		if((@diagramname is null) or (@new_diagramname is null))
		begin
			RAISERROR ('Invalid value', 16, 1);
			return -1
		end
	
		EXECUTE AS CALLER;
		select @theId = DATABASE_PRINCIPAL_ID();
		select @IsDbo = IS_MEMBER(N'db_owner'); 
		if(@owner_id is null)
			select @owner_id = @theId;
		REVERT;
	
		select @u_name = USER_NAME(@owner_id)
	
		select @DiagId = diagram_id, @UIDFound = principal_id from dbo.sysdiagrams where principal_id = @owner_id and name = @diagramname 
		if(@DiagId IS NULL or (@IsDbo = 0 and @UIDFound <> @theId))
		begin
			RAISERROR ('Diagram does not exist or you do not have permission.', 16, 1)
			return -3
		end
	
		-- if((@u_name is not null) and (@new_diagramname = @diagramname))	-- nothing will change
		--	return 0;
	
		if(@u_name is null)
			select @DiagIdTarg = diagram_id from dbo.sysdiagrams where principal_id = @theId and name = @new_diagramname
		else
			select @DiagIdTarg = diagram_id from dbo.sysdiagrams where principal_id = @owner_id and name = @new_diagramname
	
		if((@DiagIdTarg is not null) and  @DiagId <> @DiagIdTarg)
		begin
			RAISERROR ('The name is already used.', 16, 1);
			return -2
		end		
	
		if(@u_name is null)
			update dbo.sysdiagrams set [name] = @new_diagramname, principal_id = @theId where diagram_id = @DiagId
		else
			update dbo.sysdiagrams set [name] = @new_diagramname where diagram_id = @DiagId
		return 0
	END
	//
DELIMITER ;

-- Volcando estructura para procedimiento JFernandezEcommerce.sp_upgraddiagrams
DELIMITER //

	CREATE PROCEDURE dbo.sp_upgraddiagrams
	AS
	BEGIN
		IF OBJECT_ID(N'dbo.sysdiagrams') IS NOT NULL
			return 0;
	
		CREATE TABLE dbo.sysdiagrams
		(
			name sysname NOT NULL,
			principal_id int NOT NULL,	-- we may change it to varbinary(85)
			diagram_id int PRIMARY KEY IDENTITY,
			version int,
	
			definition varbinary(max)
			CONSTRAINT UK_principal_name UNIQUE
			(
				principal_id,
				name
			)
		);


		/* Add this if we need to have some form of extended properties for diagrams */
		/*
		IF OBJECT_ID(N'dbo.sysdiagram_properties') IS NULL
		BEGIN
			CREATE TABLE dbo.sysdiagram_properties
			(
				diagram_id int,
				name sysname,
				value varbinary(max) NOT NULL
			)
		END
		*/

		IF OBJECT_ID(N'dbo.dtproperties') IS NOT NULL
		begin
			insert into dbo.sysdiagrams
			(
				[name],
				[principal_id],
				[version],
				[definition]
			)
			select	 
				convert(sysname, dgnm.[uvalue]),
				DATABASE_PRINCIPAL_ID(N'dbo'),			-- will change to the sid of sa
				0,							-- zero for old format, dgdef.[version],
				dgdef.[lvalue]
			from dbo.[dtproperties] dgnm
				inner join dbo.[dtproperties] dggd on dggd.[property] = 'DtgSchemaGUID' and dggd.[objectid] = dgnm.[objectid]	
				inner join dbo.[dtproperties] dgdef on dgdef.[property] = 'DtgSchemaDATA' and dgdef.[objectid] = dgnm.[objectid]
				
			where dgnm.[property] = 'DtgSchemaNAME' and dggd.[uvalue] like N'_EA3E6268-D998-11CE-9454-00AA00A3F36E_' 
			return 2;
		end
		return 1;
	END
	//
DELIMITER ;

-- Volcando estructura para tabla JFernandezEcommerce.sysdiagrams
CREATE TABLE IF NOT EXISTS "sysdiagrams" (
	"name" NVARCHAR(128) NOT NULL COLLATE 'Modern_Spanish_CI_AS',
	"principal_id" INT NOT NULL,
	"diagram_id" INT NOT NULL,
	"version" INT NULL DEFAULT NULL,
	"definition" VARBINARY NULL DEFAULT NULL,
	PRIMARY KEY ("diagram_id"),
	UNIQUE INDEX "UK_principal_name" ("name", "principal_id")
);

-- Volcando datos para la tabla JFernandezEcommerce.sysdiagrams: -1 rows
/*!40000 ALTER TABLE "sysdiagrams" DISABLE KEYS */;
/*!40000 ALTER TABLE "sysdiagrams" ENABLE KEYS */;

-- Volcando estructura para procedimiento JFernandezEcommerce.UpdateArea
DELIMITER //
create procedure UpdateArea
@NombreA varchar(50),
@IdArea int
as
Update JFernandezArea SET NombreA = @NombreA WHERE IdArea = @IdArea
//
DELIMITER ;

-- Volcando estructura para procedimiento JFernandezEcommerce.UpdateCliente
DELIMITER //
create procedure UpdateCliente
@NombreC varchar(50),
@Rfc varchar(50),
@IdCliente int
as
Update JFernandezCliente SET NombreC = @NombreC, Rfc = @Rfc where IdCliente = @IdCliente
//
DELIMITER ;

-- Volcando estructura para procedimiento JFernandezEcommerce.UpdateDepartamento
DELIMITER //
create procedure UpdateDepartamento
@NombreD varchar(50),
@IdArea int,
@IdDepartamento int
as
Update JFernandezDepartamento
SET NombreD=@NombreD, IdArea=@IdArea WHERE IdDepartamento= @IdDepartamento
//
DELIMITER ;

-- Volcando estructura para procedimiento JFernandezEcommerce.UpdateMetodoPago
DELIMITER //
create procedure UpdateMetodoPago
@Metodo varchar(50),
@IdMetodoProducto int
as
Update JFernandezMetodoPago SET Metodo = @Metodo
WHERE IdMetodoPago = @IdMetodoProducto
//
DELIMITER ;

-- Volcando estructura para procedimiento JFernandezEcommerce.UpdateProducto
DELIMITER //
create procedure UpdateProducto
@Nombre varchar(50),
@Descripcion varchar(50),
@Precio decimal,
@IdDepartamento int,
@IdProveedor int,
@Image varbinary(max),
@IdProducto int
as
Update JFernandezProductos SET Nombre = @Nombre, Descripcion = @Descripcion, Precio = @Precio,
IdDepartamento = @IdDepartamento, IdProveedor = @IdProveedor, Image = @Image
WHERE IdProducto = @IdProducto
//
DELIMITER ;

-- Volcando estructura para procedimiento JFernandezEcommerce.UpdateProductoSucursal
DELIMITER //
create procedure UpdateProductoSucursal
@IdProducto int,
@IdSucursal int,
@IdProductoSucursal int
as
Update JFernandezProductoSucursal SET IdProducto = @IdProducto, IdSucursal = @IdSucursal 
where IdProductoSucursal = @IdProductoSucursal
//
DELIMITER ;

-- Volcando estructura para procedimiento JFernandezEcommerce.UpdateProveedor
DELIMITER //
create procedure UpdateProveedor
@NombreProveedor varchar(50),
@Telefono varchar(10),
@IdProveedor int
as
Update JFernandezProveedor SET NombreProveedor = @NombreProveedor, Telefono = @Telefono 
WHERE IdProveedor = @IdProveedor
//
DELIMITER ;

-- Volcando estructura para procedimiento JFernandezEcommerce.UpdateSucursal
DELIMITER //
create procedure UpdateSucursal
@NombreS varchar(50),
@IdSucursal int
as
Update JFernandezSucursal SET Nombres = @Nombres
WHERE IdSucursal = @IdSucursal
//
DELIMITER ;

/*!40101 SET SQL_MODE=IFNULL(@OLD_SQL_MODE, '') */;
/*!40014 SET FOREIGN_KEY_CHECKS=IF(@OLD_FOREIGN_KEY_CHECKS IS NULL, 1, @OLD_FOREIGN_KEY_CHECKS) */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;
