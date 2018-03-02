using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Serialization;
using XMLConfigCreator.CustomExceptions;
using XMLConfigCreator.CustomExceptions.ValidationModels;
using XMLConfigCreator.Enums;
using XMLConfigCreator.Modelos;
using Button = XMLConfigCreator.Modelos.Button;

namespace XMLConfigCreator
{
    public partial class dlgMain : Form
    {

        #region Variales Globales

        private List<Button> BeforeBusquedaList = new List<Button>();
        private List<Button> AfterBusquedaList = new List<Button>();
        private List<Columna> ColumnasList = new List<Columna>();
        private Vista Vista = null;
        private Impresion Impresion = null;
        private Configuration Configuracion = null;
        private ExceptionButtons ExceptionButtons = null;

        #endregion

        public dlgMain()
        {
            InitializeComponent();
            LoadCombos();
        }

        #region Private Methods

        private bool CreateXML()
        {
            try
            {

                return true;
            }
            catch (ValidationException e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        private void AddNewRowButton(string clave, string value, DataGridView dgv, List<Modelos.Button> list)
        {
            try
            {
                if (dgv.DataSource != null)
                    dgv.DataSource = null;

                Modelos.Button b = new Modelos.Button();
                b.Clave = clave;
                b.Valor = value;
                list.Add(b);

                var bindingList = new BindingList<Modelos.Button>(list);
                var source = new BindingSource(bindingList, null);

                dgv.DataSource = source;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        #endregion

        #region Initialize

        private void LoadCombos()
        {
            cbAutoSize.Items.AddRange(CombosValues.TrueFalse.GetValues(new CombosValues.TrueFalse()).ToArray());
            cbEngine.Items.AddRange(CombosValues.Engine.GetValues(new CombosValues.Engine()).ToArray());
            cbFormatText.Items.AddRange(CombosValues.FormatText.GetValues(new CombosValues.FormatText()).ToArray());
            cbClaveAB.Items.AddRange(CombosValues.ActionButton.GetValues(new CombosValues.ActionButton()).ToArray());
            cbClaveBB.Items.AddRange(CombosValues.ActionButton.GetValues(new CombosValues.ActionButton()).ToArray());
            cbValueAB.Items.AddRange(CombosValues.TrueFalse.GetValues(new CombosValues.TrueFalse()).ToArray());
            cbValueBB.Items.AddRange(CombosValues.TrueFalse.GetValues(new CombosValues.TrueFalse()).ToArray());
        }

        #endregion

        #region Events

        private void btnAddBeforeBusqueda_Click(object sender, EventArgs e)
        {
            List<ValidationExceptionObject> oVal = new List<ValidationExceptionObject>();
            try
            {
                if (!string.IsNullOrWhiteSpace(cbClaveBB.Text) && !string.IsNullOrWhiteSpace(cbValueBB.Text))
                    AddNewRowButton(cbClaveBB.Text, cbValueBB.Text, dgvBeforeBusqueda, BeforeBusquedaList);
                else
                {
                    oVal.Add(new ValidationExceptionObject("Validación de campos (BeforeBusqueda)", "Los campos clave y valor no pueden ser vacíos"));
                    throw new ValidationException(oVal);
                }
            }
            catch (ValidationException validation)
            {
                validation.ShowMessage();
            }
        }

        private void btnAddAfterBusqueda_Click(object sender, EventArgs e)
        {
            List<ValidationExceptionObject> oVal = new List<ValidationExceptionObject>();
            try
            {
                if (!string.IsNullOrWhiteSpace(cbClaveAB.Text) && !string.IsNullOrWhiteSpace(cbValueAB.Text))
                    AddNewRowButton(cbClaveAB.Text, cbValueAB.Text, dgvAfterBusqueda, AfterBusquedaList);
                else
                {
                    oVal.Add(new ValidationExceptionObject("Validación de campos (AfterBusqueda)", "Los campos clave y valor no pueden ser vacíos"));
                    throw new ValidationException(oVal);
                }
            }
            catch (ValidationException validation)
            {
                validation.ShowMessage();
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvColumnas.DataSource != null)
                    dgvColumnas.DataSource = null;
                Columna c = new Columna();

                if (txtCampo.TextLength > 0)
                    c.Campo = txtCampo.Text;
                if (txtWidth.TextLength > 0)
                    c.Width = txtWidth.Text;
                if (cbFormatText.Text.Length > 0)
                    c.FormatText = cbFormatText.Text;
                if (txtConvertType.TextLength > 0)
                    c.ConverterType = txtConvertType.Text;
                if (txtEnumerable.TextLength > 0)
                    c.Enumerable = txtEnumerable.Text;

                ColumnasList.Add(c);

                var bindingList = new BindingList<Columna>(ColumnasList);
                var source = new BindingSource(bindingList, null);

                dgvColumnas.DataSource = source;
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
            }
        }

        private void btnCrearXml_Click(object sender, EventArgs e)
        {
            List<ValidationExceptionObject> oVal = new List<ValidationExceptionObject>();
            try
            {
                Impresion = new Impresion();
                Impresion.Caption = txtCaptionImpresion.Text;
                Impresion.Engine = cbEngine.Text;
                Impresion.TipoReport = txtTipoReport.Text;

                if (Impresion.ValidarCampos().Count > 0)
                    oVal.AddRange(Impresion.ValidarCampos());

                Vista = new Vista();
                Vista.AutoSize = cbAutoSize.Text;
                Vista.Caption = txtCaptionVista.Text;
                Vista.MDIBusqueda = txtMDIBusqueda.Text;
                Vista.MDIEdicion = txtMDIEdicion.Text;
                Vista.Recurso = txtRecurso.Text;

                if (Vista.ValidarCampos().Count > 0)
                    oVal.AddRange(Vista.ValidarCampos());
                
                Configuracion = new Configuration();
                Configuracion.Impresion = Impresion;
                Configuracion.ColumnasVisibles.Columna.AddRange(ColumnasList);
                Configuracion.Entidad = txtEntidad.Text;

                if (Configuracion.ValidarCampos().Count > 0)
                    oVal.AddRange(Configuracion.ValidarCampos());

                if (Configuracion.ColumnasVisibles.ValidarCampos().Count > 0)
                    oVal.AddRange(Configuracion.ColumnasVisibles.ValidarCampos());

                ExceptionButtons = new ExceptionButtons();
                if (AfterBusquedaList.Count > 0)
                    ExceptionButtons.AfterBusqueda.Button.AddRange(AfterBusquedaList);
                else
                    ExceptionButtons.AfterBusqueda = null;

                if (BeforeBusquedaList.Count > 0)
                    ExceptionButtons.BeforeBusqueda.Button.AddRange(BeforeBusquedaList);
                else
                    ExceptionButtons.BeforeBusqueda = null;

                if (ExceptionButtons.BeforeBusqueda == null && ExceptionButtons.AfterBusqueda == null)
                    Configuracion.ExceptionButtons = null;
                else
                    Configuracion.ExceptionButtons = ExceptionButtons;

                Configuracion.Visita = Vista;

                if (oVal.Count > 0)
                    throw new ValidationException(oVal);

                XmlSerializerNamespaces xmlNameSpace = new XmlSerializerNamespaces();
                xmlNameSpace.Add("xmlns", "http://tempuri.org/Configuration.xsd");

                StringBuilder output = new StringBuilder();
                var writer = new StringWriter(output);

                XmlSerializer serializer = new XmlSerializer(typeof(Configuration));
                serializer.Serialize(writer, Configuracion, xmlNameSpace);

                output.Replace("xmlns:xmlns", "xmlns");
                output.Replace("utf-16", "utf-8");

                File.WriteAllText(@"C:\Users\alexreyros\Desktop\myXml.xml", output.ToString(), Encoding.UTF8);
            }
            catch (ValidationException validation)
            {
                validation.ShowMessage();
            }

        }

        #endregion

        #region Test Methods

        private void TestCase()
        {
            Configuration configuration = new Configuration();

            Vista vista = new Vista();
            vista.AutoSize = "True";
            vista.Caption = "EntPeticionNotaSimpleRequest";
            vista.MDIBusqueda = "BuscaHistoricoNotasSimples";
            vista.MDIEdicion = "SinEdicion";
            vista.Recurso = "Generico_32";

            Impresion impresion = new Impresion();
            impresion.Caption = "Report_ListadoHistoricoNotaSimple_Titulo";
            impresion.TipoReport = "BusquedaHistoricoNS";
            impresion.Engine = "AR";

            ExceptionButtons exceptionButtons = new ExceptionButtons();
            exceptionButtons.BeforeBusqueda.Button.Add(new Modelos.Button() { Clave = "AccionNuevo", Valor = "false" });
            exceptionButtons.AfterBusqueda.Button.Add(new Modelos.Button() { Clave = "AccionNuevo", Valor = "false" });

            ColumnasVisibles columnasVisibles = new ColumnasVisibles();
            columnasVisibles.Columna.Add(new Columna() { Campo = "Codigo", Width = "100" });
            columnasVisibles.Columna.Add(new Columna() { Campo = "Delegacion", Width = "100", FormatText = "Enumeration", Enumerable = "Shared.Tipos.Tramitaciones.NS.TipoEstado" });
            columnasVisibles.Columna.Add(new Columna() { Campo = "FechaIncidencia", Width = "100", FormatText = "Custom", ConverterType = "DGEST.Presentation.Entities.Converters.ShortDatetimeConverter" });

            configuration.Entidad = "DGEST.Presentation.Entities.Tramitaciones.HistoricoNS";
            configuration.Visita = vista;
            configuration.Impresion = impresion;
            configuration.ExceptionButtons = exceptionButtons;
            configuration.ColumnasVisibles = columnasVisibles;

            XmlSerializerNamespaces xmlNameSpace = new XmlSerializerNamespaces();
            xmlNameSpace.Add("xmlns", "http://tempuri.org/Configuration.xsd");

            StringBuilder output = new StringBuilder();
            var writer = new StringWriter(output);

            XmlSerializer serializer = new XmlSerializer(typeof(Configuration));
            serializer.Serialize(writer, configuration, xmlNameSpace);

            File.WriteAllText(@"C:\Users\alexreyros\Desktop\myXml.xml", output.ToString(), Encoding.UTF8);

            Console.WriteLine(output.ToString());
        }


        #endregion
    }
}
