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

-- Volcando estructura para tabla JFernandezEcommerce.JFernandezArea
CREATE TABLE IF NOT EXISTS "JFernandezArea" (
	"IdArea" INT NOT NULL,
	"NombreA" VARCHAR(50) NULL DEFAULT NULL COLLATE 'Modern_Spanish_CI_AS',
	PRIMARY KEY ("IdArea")
);

-- Volcando datos para la tabla JFernandezEcommerce.JFernandezArea: 8 rows
/*!40000 ALTER TABLE "JFernandezArea" DISABLE KEYS */;
REPLACE INTO "JFernandezArea" ("IdArea", "NombreA") VALUES
	(1, 'Frutas y verduras'),
	(2, 'Muebles'),
	(3, 'Ferreteria'),
	(4, 'Papeleria'),
	(5, 'Jugeteria'),
	(6, 'Hojar'),
	(7, 'Decoracion'),
	(8, 'Accesorios de autos');
/*!40000 ALTER TABLE "JFernandezArea" ENABLE KEYS */;

-- Volcando estructura para tabla JFernandezEcommerce.JFernandezCliente
CREATE TABLE IF NOT EXISTS "JFernandezCliente" (
	"IdCliente" INT NOT NULL,
	"NombreC" VARCHAR(50) NULL DEFAULT NULL COLLATE 'Modern_Spanish_CI_AS',
	"Rfc" VARCHAR(50) NULL DEFAULT NULL COLLATE 'Modern_Spanish_CI_AS',
	PRIMARY KEY ("IdCliente")
);

-- Volcando datos para la tabla JFernandezEcommerce.JFernandezCliente: 3 rows
/*!40000 ALTER TABLE "JFernandezCliente" DISABLE KEYS */;
REPLACE INTO "JFernandezCliente" ("IdCliente", "NombreC", "Rfc") VALUES
	(1, 'Cliente 1', '1'),
	(2, 'Cliente 2', 'frc2'),
	(3, 'Cliente 3', 'FRC 123');
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

-- Volcando datos para la tabla JFernandezEcommerce.JFernandezDepartamento: 8 rows
/*!40000 ALTER TABLE "JFernandezDepartamento" DISABLE KEYS */;
REPLACE INTO "JFernandezDepartamento" ("IdDepartamento", "NombreD", "IdArea") VALUES
	(1, 'Departamento de comida', 1),
	(2, 'Departamento de muebles', 2),
	(3, 'Departamento de Ferreteria', 3),
	(4, 'Departamento de Papeleria', 4),
	(5, 'Departamento de Jugueteria', 5),
	(6, 'Departamento de Hogar', 6),
	(7, 'Departamento de decoracion', 7),
	(8, 'Departamento de herramientas', 8);
/*!40000 ALTER TABLE "JFernandezDepartamento" ENABLE KEYS */;

-- Volcando estructura para tabla JFernandezEcommerce.JFernandezMetodoPago
CREATE TABLE IF NOT EXISTS "JFernandezMetodoPago" (
	"IdMetodoPago" INT NOT NULL,
	"Metodo" VARCHAR(50) NULL DEFAULT NULL COLLATE 'Modern_Spanish_CI_AS',
	PRIMARY KEY ("IdMetodoPago")
);

-- Volcando datos para la tabla JFernandezEcommerce.JFernandezMetodoPago: 3 rows
/*!40000 ALTER TABLE "JFernandezMetodoPago" DISABLE KEYS */;
REPLACE INTO "JFernandezMetodoPago" ("IdMetodoPago", "Metodo") VALUES
	(1, 'Pago credito'),
	(2, 'Pago tarjeta'),
	(3, 'Pago monetario');
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

-- Volcando datos para la tabla JFernandezEcommerce.JFernandezProductos: 9 rows
/*!40000 ALTER TABLE "JFernandezProductos" DISABLE KEYS */;
REPLACE INTO "JFernandezProductos" ("IdProducto", "Nombre", "Descripcion", "Precio", "IdDepartamento", "IdProveedor", "Image") VALUES
	(1, 'Mango', 'Furta fresca', 10, 1, 1, NULL),
	(2, 'Manzana', 'fruta fresca', 6, 1, 1, NULL),
	(3, 'Pescado', 'Pescado fresco', 45, 1, 2, NULL),
	(4, 'Res', 'carne de res', 45, 1, 1, NULL),
	(5, 'Nuez', 'especiea', 15, 1, 1, NULL),
	(6, 'Pan de nuez', 'pan con nuez', 8, 1, 1, NULL),
	(7, 'Tortillas tia rosa', 'Tortillas de arina', 24, 1, 2, NULL),
	(8, 'Crema alpura', 'Cremas', 25, 1, 1, NULL),
	(9, 'Yogurt Alpura', 'Lacteos y yogurt', 12, 1, 2, NULL);
/*!40000 ALTER TABLE "JFernandezProductos" ENABLE KEYS */;

-- Volcando estructura para tabla JFernandezEcommerce.JFernandezProductoSucursal
CREATE TABLE IF NOT EXISTS "JFernandezProductoSucursal" (
	"IdProductoSucursal" INT NOT NULL,
	"IdProducto" INT NULL DEFAULT NULL,
	"IdSucursal" INT NULL DEFAULT NULL,
	PRIMARY KEY ("IdProductoSucursal"),
	FOREIGN KEY INDEX "FK_JFernandezProductoSucursal_JFernandezProductos1" ("IdProducto"),
	FOREIGN KEY INDEX "FK_JFernandezProductoSucursal_JFernandezSucursal" ("IdSucursal"),
	CONSTRAINT "FK_JFernandezProductoSucursal_JFernandezProductos1" FOREIGN KEY ("IdProducto") REFERENCES "JFernandezProductos" ("IdProducto") ON UPDATE NO_ACTION ON DELETE NO_ACTION,
	CONSTRAINT "FK_JFernandezProductoSucursal_JFernandezSucursal" FOREIGN KEY ("IdSucursal") REFERENCES "JFernandezSucursal" ("IdSucursal") ON UPDATE NO_ACTION ON DELETE NO_ACTION
);

-- Volcando datos para la tabla JFernandezEcommerce.JFernandezProductoSucursal: 2 rows
/*!40000 ALTER TABLE "JFernandezProductoSucursal" DISABLE KEYS */;
REPLACE INTO "JFernandezProductoSucursal" ("IdProductoSucursal", "IdProducto", "IdSucursal") VALUES
	(1, 1, 2),
	(2, 5, 3);
/*!40000 ALTER TABLE "JFernandezProductoSucursal" ENABLE KEYS */;

-- Volcando estructura para tabla JFernandezEcommerce.JFernandezProveedor
CREATE TABLE IF NOT EXISTS "JFernandezProveedor" (
	"IdProveedor" INT NOT NULL,
	"NombreProvedor" VARCHAR(50) NULL DEFAULT NULL COLLATE 'Modern_Spanish_CI_AS',
	"Telefono" VARCHAR(10) NULL DEFAULT NULL COLLATE 'Modern_Spanish_CI_AS',
	PRIMARY KEY ("IdProveedor")
);

-- Volcando datos para la tabla JFernandezEcommerce.JFernandezProveedor: 2 rows
/*!40000 ALTER TABLE "JFernandezProveedor" DISABLE KEYS */;
REPLACE INTO "JFernandezProveedor" ("IdProveedor", "NombreProvedor", "Telefono") VALUES
	(1, 'Provedor 1', '1234567890'),
	(2, 'Provedor 2', '1234123412');
/*!40000 ALTER TABLE "JFernandezProveedor" ENABLE KEYS */;

-- Volcando estructura para tabla JFernandezEcommerce.JFernandezSucursal
CREATE TABLE IF NOT EXISTS "JFernandezSucursal" (
	"IdSucursal" INT NOT NULL,
	"NombreS" VARCHAR(50) NULL DEFAULT NULL COLLATE 'Modern_Spanish_CI_AS',
	PRIMARY KEY ("IdSucursal")
);

-- Volcando datos para la tabla JFernandezEcommerce.JFernandezSucursal: 3 rows
/*!40000 ALTER TABLE "JFernandezSucursal" DISABLE KEYS */;
REPLACE INTO "JFernandezSucursal" ("IdSucursal", "NombreS") VALUES
	(1, 'sanborns'),
	(2, 'Wallmart'),
	(3, 'Aurrera');
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

-- Volcando datos para la tabla JFernandezEcommerce.JFernandezVenta: 2 rows
/*!40000 ALTER TABLE "JFernandezVenta" DISABLE KEYS */;
REPLACE INTO "JFernandezVenta" ("IdVenta", "IdCliente", "Total", "IdMetodoPago", "Fecha") VALUES
	(1, 1, 15.45, 2, '2020-12-20'),
	(2, 3, 14.87, 1, '2020-12-20');
/*!40000 ALTER TABLE "JFernandezVenta" ENABLE KEYS */;

-- Volcando estructura para tabla JFernandezEcommerce.JFernandezVentaProducto
CREATE TABLE IF NOT EXISTS "JFernandezVentaProducto" (
	"IdVentaProducto" INT NOT NULL,
	"IdVenta" INT NULL DEFAULT NULL,
	"IdProductoSucursal" INT NULL DEFAULT NULL,
	"Cantidad" INT NULL DEFAULT NULL,
	"IdProducto" INT NULL DEFAULT NULL,
	PRIMARY KEY ("IdVentaProducto"),
	FOREIGN KEY INDEX "FK_JFernandezVentaProducto_JFernandezVenta1" ("IdVenta"),
	FOREIGN KEY INDEX "FK_JFernandezVentaProducto_JFernandezProductoSucursal" ("IdProductoSucursal"),
	FOREIGN KEY INDEX "FK_JFernandezVentaProducto_JFernandezProductos" ("IdProducto"),
	CONSTRAINT "FK_JFernandezVentaProducto_JFernandezProductos" FOREIGN KEY ("IdProducto") REFERENCES "JFernandezProductos" ("IdProducto") ON UPDATE NO_ACTION ON DELETE NO_ACTION,
	CONSTRAINT "FK_JFernandezVentaProducto_JFernandezProductoSucursal" FOREIGN KEY ("IdProductoSucursal") REFERENCES "JFernandezProductoSucursal" ("IdProductoSucursal") ON UPDATE NO_ACTION ON DELETE NO_ACTION,
	CONSTRAINT "FK_JFernandezVentaProducto_JFernandezVenta1" FOREIGN KEY ("IdVenta") REFERENCES "JFernandezVenta" ("IdVenta") ON UPDATE NO_ACTION ON DELETE NO_ACTION
);

-- Volcando datos para la tabla JFernandezEcommerce.JFernandezVentaProducto: 1 rows
/*!40000 ALTER TABLE "JFernandezVentaProducto" DISABLE KEYS */;
REPLACE INTO "JFernandezVentaProducto" ("IdVentaProducto", "IdVenta", "IdProductoSucursal", "Cantidad", "IdProducto") VALUES
	(1, 1, 2, 2, 1);
/*!40000 ALTER TABLE "JFernandezVentaProducto" ENABLE KEYS */;

/*!40101 SET SQL_MODE=IFNULL(@OLD_SQL_MODE, '') */;
/*!40014 SET FOREIGN_KEY_CHECKS=IF(@OLD_FOREIGN_KEY_CHECKS IS NULL, 1, @OLD_FOREIGN_KEY_CHECKS) */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;
