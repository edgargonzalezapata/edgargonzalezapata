using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;
using System.Data;
using System.Data.SqlClient;

using System.Windows.Forms;

namespace SIMPLEAPI_Demo.Controller
{
    internal class ItemBoletaController
    {

        public string sql;
        public OleDbDataAdapter objadapter;
        public DataSet objdataset;
        List<ItemBoleta> items;


        public ItemBoletaController()
        {
            items = new List<ItemBoleta>();
        }

        public bool GetItem(ref int fk_venta)
        {
            variablesGlobales objvariablesGlobales = new variablesGlobales();
            try
            {
                if (objvariablesGlobales.ConectaBase())
                {
                    sql = "select p.Descripción,d.cantidad , '1' as Afecto, d.valor , round(d.valor * d.cantidad,0) as Total from d_venta as d inner join lista_costo as p on d.fk_prod = p.id where d.fk_venta = " + fk_venta + "";
                    objadapter = new OleDbDataAdapter(sql, objvariablesGlobales.Conecta);
                    objdataset = new DataSet();
                    objadapter.Fill(objdataset);

                    ItemBoleta item = new ItemBoleta();

                    foreach (DataRow dr in objdataset.Tables[0].Rows)
                    {


                        item.Nombre = dr[0].ToString();
                        item.Cantidad = Convert.ToDecimal(dr[1].ToString());
                        item.Afecto = true;
                        item.Precio = (int)dr[3];
                        items.Add(item);


                        Console.WriteLine(items);
                        return true;

                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
                return false;
            }
            return false;
        }
    }



}