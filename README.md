# sales_Data_Prediction
 Repositorio para Prueba Técnica Empresa Codifico

## Prerequisitos

Este proyecto requiere NodeJs y NPM.
[Node](http://nodejs.org/) y [NPM](https://npmjs.org/) son de sencilla instalación.
Puede verificar su version corriendo el siguiente comando

```sh
C:\Dev\.net\sales_Data_Prediction\sale_data_prediction_front>npm -v && node -v
10.8.2
v20.11.0
```

## Menú

- [Nombre Del Proyecto](#sales_Data_Prediction)
  - [Prerequisitos](#Prerequisitos)
  - [Menú](#Menú)
  - [Introducción](#Introduccion)
  - [Instalación](#Instalacion)
  - [Como se ejecuto la prueba?](#Ejecucion)
  
 ## Introduccion
Este proyecto se realiza como parte de los requisitos para acceder al cargo de Desarrollador , consta de los componentes Back y Front comunicados entre si por medio de API Rest para listar fechas de orden y posible proxima compra, ordenes de usuario , generación de Ordenes entre otros.

Se encuentra desarrollado en Angular V17 y .Net Core con consultas a base de datos mediante sentencias DML y T-SQL
 
 
 ## Instalacion
  **BEFORE YOU INSTALL:** Por favor valide los [Prerequisitos](#Prerequisitos)

Inicie clonando el proyecto en su máquina Local:

```sh
$ git clone https://github.com/Rosembergquigo/sales_Data_Prediction.git
$ cd sales_Data_Prediction
```
 
 ### Instalación Front
 Una vez en la carpeta principal ingrese a la carpeta del proyecto front sales_Data_Prediction\sale_data_prediction_front e instale las librerias npm en el proyecto, despues proceda a correr la aplicación
```sh
$ cd sale_data_prediction_front
$ npm install
$ npm run start
```

### Instalacion Back
Para ejecutar el proyecto back puede ingresar desde su equipo al proyecto con el archivo sales_data_prediction.sln en la carpeta sales_Data_Prediction\sales_data_prediction_back

## Ejecucion
Se inicion realizando la generación del Back implementando los metodos indicados bajo la siguiente estructura
- [Sales_data_prediction_back: Raiz del proyecto back)]
	- [Properties]
		- [launchSettings.Json: Configuraciones de arranque, controlador por defecto /api/employee]
	- [Controllers]
		- [CustomerController]
			- [getCustomerOrders(id)- GET : Trae la información de las ordenes por cada customer]
		- [EmployeeController]
			- [getEmployees() - GET: Trae la información de los empleados con id y Nombre completo]
		- [OrderController]
			- [getSaleDatePrediction() - GET : Trae el id y nombre de usuario relacionandola fecha de ultima compra y la posible fecha proxima de orden]
			- [CreateOrder(createOrder) - POST: Genera la nueva orden y alimenta las tablas transaccionales correspondientes]
		- [ProductController]
			- [getProducts(): Trae la información de los productos]
		- [ShipperController]
			- [getShippers(): Trae la información de los Transportadores]
	- [DAO]
		- [AplicationDBContext: Contiene los metodos de ejecución de scripts generados ]
		 -[DBController: Contiene la generación de las Sentencias DML]
			- [GetEmployees()]
			- [GetCustomerOrders(id)]
			- [getShippers()]
			- [getProducts()]
			- [getSaleDatePrediction()]
			- [createOrder(request)]
	- [Models : Contiene las clases que serán utilizadas para recibir y enviar los registros encontrados en las consultas]
	- [Services: Conecta los controladores y las consultas SQL realizando la validación de los resultados y 'mapeando' los registros con su correspondiente modelo]
	- [Startup.cs : Ejecuta las siguientes tareas: ]		
		- [inyección de los servicios para sentencias DML - TSQL]
		- [Inyección de Servicios puente controlador-dbController]
		- [Generación de políticas CORS]
		
Posteriormente se generó el componente Front con la siguiente estructura: 		
- [Sales_data_prediction_front: Raiz Proyecto Front]
	- [src]
		- [app]
			- [components]
				- [header: Adiciona el header presente en la SWA]
				- [salesdatepredictor: componente con la lógica para mostrar la tabla principal y modal con ordenes por usuario y nuevas ordenes]
			- [models : Contiene los modelos para proyectar en el formulario segun tipo de clase]
			- [services: Archivo de conexión al api back ]
 
 
