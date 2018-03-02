using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace XMLConfigCreator.CustomExceptions.ValidationModels
{
    interface IExceptionForm
    {
        List<ValidationExceptionObject> oVal { get; set; }
        void LoadDataGridView(DataGridView dgv);
        void DisposeDataGridView(DataGridView dgv);
    }
}
