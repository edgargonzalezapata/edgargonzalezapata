using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Data;

namespace SIMPLEAPI_Demo.Controller
{
    internal class encabezadoBoletaController
    {
        public string sql;
        public OleDbDataAdapter objadapter;
        public DataSet objdataset;
        private int idDte;
        private DateTime fechaEmision;
        private string codigoLocal;
        private string direccion;
        private string comuna;
        private string ciudad;
        variablesGlobales objvariablesGlobales = new variablesGlobales();
     

        public DataSet GetBoletas(ref DateTime inicio, ref DateTime termino )
        {
            variablesGlobales objvariablesGlobales = new variablesGlobales();
            try
            {
                if (objvariablesGlobales.ConectaBase())
                {
                    sql = "select v.fecha   ,v.id, v.id_dte as Folio,l.nombre , sum(round((cantidad * d.valor)/1.19, 0)) as Neto ,sum(round(cantidad * d.valor, 0) - round((cantidad * d.valor)/1.19, 0)) as IVA, sum(round(cantidad * d.valor, 0)) as Total from venta as v inner join d_venta as d on v.id = d.fk_venta inner join local as l on d.fk_local = l.id where v.fecha between '" + inicio + "' and '" + termino + "' group by v.fecha, v.id, v.id_dte, l.nombre order by v.id_dte asc";
                    objadapter = new OleDbDataAdapter(sql, objvariablesGlobales.Conecta);
                    objdataset = new DataSet();
                    objadapter.Fill(objdataset);

                    
                    return objdataset;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Error : " + e.ToString());
                return objdataset;
            }
            return objdataset;
        }

    }

}
