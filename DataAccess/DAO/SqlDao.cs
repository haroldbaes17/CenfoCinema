﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.DAO
{
    /*
     * Clase u objeto que se encarga de la comunicación con la base de datos SQL.
     * Solo ejecuta Store Procedures
     * 
     * Esta clase implementa el Patron del Singleton 
     * para asegurar la existencia de una única instancia de este objeto
     * 
     */
    public class SqlDao
    {
        // Paso 1: Crear una instancia privada de la misma clase
        private static SqlDao _instance;

        private string _connectionString;

        // Paso 2: Redefinir el constructor default y convertirlo en privado
        private SqlDao()
        {
            _connectionString = string.Empty;
        }

        // Paso 3: Definir el metodo que expone la instancia
        public static SqlDao GetInstance()
        {
            if (_instance == null)
            {
                _instance = new SqlDao();
            } 
            return _instance;
        }

        // Metodo para la ejecucion de Store Procedures sin retorno
        public void ExecuteProcedure(SqlOperation operation)
        {
            // Conectarse a la base de datos
            // Ejecutar el Store Procedure
        }

        //Metodo para la ejecucion de Store Procedures con retorno de data
        public List<Dictionary<string, object>> ExecuteQueryProcedure(SqlOperation operation)
        {
            // Conectarse a la base de datos
            // Ejecutar el Store Procedure
            // Capturar el resultado
            // Convertirlo en DTO

            var list = new List<Dictionary<string, object>>();

            return list;
        }
    }
}
