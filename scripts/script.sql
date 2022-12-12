USE [Usuario]
GO

INSERT into [dbo].[proveedor] ([proveedor], [sistema], [estatus], [fecha_alta]) VALUES ('Secretar�a Ejecutiva del Sistema Estatal 
Anticorrupci�n de Veracruz de Ignacio de la Llave', 'Sistema de los Servidores P�blicos Sancionados, 
Sistema de los Particulares Sancionados', 'Vigente', '2000-01-01')

insert into [dbo].[contrasena] ([contrasena]) values ('e9149aa7a440daa2afb538bf514b3028a1f112e6d6c56d125bbee6aa7eee9225')

insert into [dbo].[usuario] ([nombre], [apellidoUno], [apellidoDos], [correoElectronico], [telefono], [extension], 
[usuario], [proveedorDatos], [estatus], [id_perfil], [id_contrasena], [cargo], [fecha_alta]) VALUES 
('Admin', 'admin', 'admin', 
'admin@gmail.com', '2222222222', '52', 'Administrador', 1, 'Vigente', 1, 1, 'Administrador', '2000-01-01')

insert into [dbo].[contrasena] ([contrasena]) values ('d6be10ebe7cbc8643fd5f492a6090bb9aca0c9efb0b8e6ec0e15d8c7e7e0d34b')

insert into [dbo].[usuario] ([nombre], [apellidoUno], [apellidoDos], [correoElectronico], [telefono], [extension], 
[usuario], [proveedorDatos], [estatus], [id_perfil], [id_contrasena], [cargo], [fecha_alta]) VALUES 
('Prueba', 'prueba', 'prueba', 
'prueba@gmail.com', '2222222222', '52', 'Prueba', 1, 'Vigente', 2, 2, 'Capturador', '2000-01-01')

