# Prueba tecnica - MonoLegal BackEnd
[![N|Solid](https://cldup.com/dTxpPi9lDf.thumb.png)](https://nodesource.com/products/nsolid)

[![Build Status](https://travis-ci.org/joemccann/dillinger.svg?branch=master)](https://travis-ci.org/joemccann/dillinger)

# Configurar MongoDB
Una vez descargue el codigo, debe modificar el archivo que esta en la ruta:
```sh
MonoLegalBackEnd\MonoLegal.Persistence\Implementations\InvoiceRepository.cs
```
Debe modificar la linea 17, la cual es la cadena de conexión
```sh
_client = new MongoClient("mongodb://127.0.0.1:27017");
```
Debe modificar la linea 18, la cual es el nombre de la base de datos de MongoDb
```sh
_db = _client.GetDatabase("monolegal-invoice");
```
En la ruta: **MonoLegalBackEnd\MonoLegal.Core\Templates\MongoDB** dejo 2 archivos json, 

* El archivo de nombre **InsertInvoicesMongoDB.json** este contiene informacipón de 3 facturas, inserte esos registros por medio de **Robo 3T**, la colleción debe llamarse **Invoice**
<div>
    <p style = 'text-align:center;'>
        <img src="https://res.cloudinary.com/dcbxpunq6/image/upload/v1647132053/InvoiceRoboT3_i79hsa.png" alt="JuveYell">
    </p>
</div>

* El archivo de nombre **InsertTemplateMongoDB.json** este contiene informacipón de 2 plantillas, inserte esos registros por medio de **Robo 3T**, la colleción debe llamarse **Template**
<div>
    <p style = 'text-align:center;'>
        <img src="https://res.cloudinary.com/dcbxpunq6/image/upload/v1647132281/TemplateRoboT3_pflx1e.png" alt="JuveYell">
    </p>
</div>

# Configurar Envio de Correo
Para realizar el envio de correo se realizo la configuración del siguiente correo: **Notification.test.2022@gmail.com**, si usted desea cambiar dicho remitente, modifique el archivo **appsettings.Development.json** que se encuentra en proyecto **MonoLegal.Api**
<div>
    <p style = 'text-align:center;'>
        <img src="https://res.cloudinary.com/dcbxpunq6/image/upload/v1647132524/AppSettingsDev_x5mfbf.png" alt="JuveYell">
    </p>
</div>

# Ejecute el proyecto
Una vez finalice los pasos antetiores ejecute el proyecto, este le abrira la siguiente Url **http://localhost:9105/swagger**, una vez abra swagger, usted podra consumir la api expuesta.
<div>
    <p style = 'text-align:center;'>
        <img src="https://res.cloudinary.com/dcbxpunq6/image/upload/v1647132671/Swagger_dd0t9i.png" alt="JuveYell">
    </p>
</div>

# Postman
Adjunto documentición en postman, una vez descargue este archivo podra ejecutar desde postman el consumo a la api, tambien en contrara en la sección de test, un par de test unitarios realizados en postman

<div>
    <p style = 'text-align:center;'>
        <img src="https://res.cloudinary.com/dcbxpunq6/image/upload/v1647135940/UnitTestPostman_u6tprm.png" alt="JuveYell">
    </p>
</div>

* Descargar colleción: https://drive.google.com/file/d/1xTww_PiyEm7D8EvXeFPxYWglOT1MwplQ/view?usp=sharing
* Ver documentación: https://documenter.getpostman.com/view/5922585/UVsJvS3a