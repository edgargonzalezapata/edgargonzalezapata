using SIMPLEAPI_Demo.Controller;
using ChileSystems.DTE.Engine.Enum;
using SIMPLEAPI_Demo.Clases;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;
using System.Data;

namespace SIMPLEAPI_Demo.Vista
{
    public partial class generarDTE_NCE : Form
    {
        encabezadoBoletaController objencabezadoBoletaController = new encabezadoBoletaController();
        Handler handler = new Handler();
        List<ItemBoleta> items;
        decimal total;

        public string sql;
        public OleDbDataAdapter objadapter;
        public DataSet objdataset;

        ItemBoletaController ItemBoletaController = new ItemBoletaController();
        public generarDTE_NCE()
        {
            InitializeComponent();
            items = new List<ItemBoleta>();
        }



        private void kryptonButton1_Click(object sender, EventArgs e)
        {
            DateTime inicio = txtInicio.Value.Date;
            DateTime termino = txtTermino.Value.Date;

            // TODO: esta línea de código carga datos en la tabla 'ventasFandaDataSet.caja' Puede moverla o quitarla según sea necesario.
            this.nCTableAdapter.Fill(this.ventasFandaDataSet.NC, inicio, termino);

            double neto = 0;
            double iva = 0;
            double bruto = 0;


            foreach (DataGridViewRow row in grilla1.Rows)
            {

                neto += Convert.ToDouble(row.Cells[4].Value);
                iva += Convert.ToDouble(row.Cells[5].Value);
                bruto += Convert.ToDouble(row.Cells[6].Value);

            }


            lbNeto.Text = neto.ToString("N");
            lbIVA.Text = iva.ToString("N");
            lbBruto.Text = bruto.ToString("N");
        }

        private void kryptonButton2_Click(object sender, EventArgs e)
        {
            int folio;
            int fk_venta;
            int docRef;

            DateTime FechaEmision;

            foreach (DataGridViewRow row in grilla1.Rows)
            {

                fk_venta = Convert.ToInt32(row.Cells[0].Value);
                FechaEmision = Convert.ToDateTime(row.Cells[1].Value);
                folio = Convert.ToInt32(row.Cells[2].Value);
                docRef = Convert.ToInt32(row.Cells[6].Value);

                GetItem(ref fk_venta);


                var dte = handler.GenerateDTEsibb(ChileSystems.DTE.Engine.Enum.TipoDTE.DTEType.NotaCreditoElectronica, FechaEmision, (int)folio);
                handler.GenerateDetails(dte, items);
                string casoPrueba = "CASO-" + folio.ToString("N0");
                handler.Referencias(dte, TipoReferencia.TipoReferenciaEnum.SetPruebas, TipoDTE.TipoReferencia.NotaCreditoElectronica, FechaEmision, docRef, casoPrueba);
                var path = handler.TimbrarYFirmarXMLDTE(dte, "out\\temp\\", "out\\caf\\", out string messageOut);

                handler.Validate(path, SIMPLE_API.Security.Firma.Firma.TipoXML.DTE, ChileSystems.DTE.Engine.XML.Schemas.DTE);
                items.Clear();
                Console.WriteLine("Total : " + total);

            }
        }

        public bool GetItem(ref int fk_venta)
        {
            variablesGlobales objvariablesGlobales = new variablesGlobales();
            try
            {
                if (objvariablesGlobales.ConectaBase())
                {
                    sql = "select p.Descripción,d.cantidad , '1' as Afecto, d.valor , round(d.valor * d.cantidad,0) as Total from d_nce as d inner join lista_costo as p on d.fk_prod = p.id where d.fk_venta = " + fk_venta + "";
                    objadapter = new OleDbDataAdapter(sql, objvariablesGlobales.Conecta);
                    objdataset = new DataSet();
                    objadapter.Fill(objdataset);


                    String nombre;

                    Console.WriteLine("idVenta: " + fk_venta);
                    foreach (DataRow dr in objdataset.Tables[0].Rows)
                    {
                        ItemBoleta item = new ItemBoleta();

                        // item.Nombre = dr[0].ToString();
                        nombre = dr[0].ToString();
                        if (nombre.Length > 20)
                        {
                            item.Nombre = nombre.Substring(0, 20);
                        }
                        else
                        {
                            item.Nombre = dr[0].ToString();
                        }
                        item.Cantidad = Convert.ToDecimal(dr[1].ToString());
                        item.Afecto = true;
                        item.Precio = (int)dr[3];
                        items.Add(item);


                        Console.WriteLine(item.Nombre + "  cantidad : " + item.Cantidad + "  precio : " + item.Precio);
                        total = total + (decimal)item.Cantidad * (int)item.Precio;


                    }
                    return true;
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
                return false;
            }
            return false;
        }

        private void generarDTE_NCE_Load(object sender, EventArgs e)
        {
            grilla1.AutoGenerateColumns = false;
            handler.configuracion = new Configuracion();
            handler.configuracion.LeerArchivo();
        }
    }
}
