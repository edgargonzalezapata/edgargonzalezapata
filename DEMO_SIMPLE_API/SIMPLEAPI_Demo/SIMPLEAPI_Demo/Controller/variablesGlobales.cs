using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;

namespace SIMPLEAPI_Demo.Controller
{
    public  class variablesGlobales
    {
        public  OleDbConnection Conecta;
        public  string conexion_string;

        public Boolean ConectaBase() {
            Conecta = new OleDbConnection("Provider=SQLOLEDB;Data Source=tcp:sibb.database.windows.net,1433;Initial Catalog=VentasFanda;Persist Security Info=True;User ID=egonzalez;Password=Fbb7346La;language=spanish");
            conexion_string = "Data Source=tcp:sibb.database.windows.net,1433;Initial Catalog=VentasFanda;Persist Security Info=True;User ID=egonzalez;Password=Fbb7346La;language=spanish";
            //conexion_string = "Data Source=.\\SQLEXPRESS;Initial Catalog=EasyMarket;Persist Security Info=True;User ID=sa;Password=Fbb7346La;language=spanish";
            //Conecta = new OleDbConnection("Provider=SQLOLEDB;Data Source=.\\SQLEXPRESS;Initial Catalog=EasyMarket;Persist Security Info=True;User ID=sa;Password=Fbb7346La;language=spanish");

            return true;
        }
       

    }
}
