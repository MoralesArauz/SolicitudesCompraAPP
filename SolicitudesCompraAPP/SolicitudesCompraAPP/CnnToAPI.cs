using System;
using System.Collections.Generic;
using System.Text;

namespace SolicitudesCompraAPP
{
    public static class CnnToAPI
    {

        // En esta clase estática vamos a almacenar la información de configuración de consumo
        // del API
        // En pruebas se usa una ruta distinta que en producción

        public static string ProductionRoute = "http://192.168.100.142:45455/api/";
        public static string TestingRoute = "http://192.168.100.142:45455/api/";

        // TODO: Agrega la funcionalidad para JWT el ApiKey acá es util ya que el usuario antes 
        // de registrarse podría utilizarlo, después de registrado  puede usar JWT

        public static string ApiKeyName = "ApiKey";
        public static string ApiKeyValue = "UIlReOTzkzbKkk8TaXnCkSgefdZ5ggtV";

    }
}
