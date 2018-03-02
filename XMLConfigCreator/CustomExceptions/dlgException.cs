using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using XMLConfigCreator.CustomExceptions.ValidationModels;

namespace XMLConfigCreator.CustomExceptions
{
    public partial class DlgException : Form, IExceptionForm
    {
        public List<ValidationExceptionObject> oVal { get; set; }

        public DlgException()
        {
            InitializeComponent();
            oVal = new List<ValidationExceptionObject>();

            Load += delegate(object sender, EventArgs args)
            {
                LoadDataGridView(dgvValidationException);
            };

            FormClosing += delegate(object sender, FormClosingEventArgs args)
            {
                DisposeDataGridView(dgvValidationException);
            };
        }

        public void LoadDataGridView(DataGridView dgv)
        {
            if (oVal.Count > 0)
            {
                dgv.DataSource = oVal;
            }
        }

        public void DisposeDataGridView(DataGridView dgv)
        {
            if (dgv.DataSource != null)
            {
                dgv.Dispose();
            }
        }
    }
}
