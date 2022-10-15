using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CAJA
{
    public partial class ReciboViewer : Form
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public ReciboViewer()
        {
            InitializeComponent();
        }

        private void reportViewer1_Load(object sender, EventArgs e)
        {
            //var adapter = new SomeTableAdapter();
            //var tbl = adapter.SomeStoredProcedure(parameterA, parameterB);

            //var dataSource = new ReportDataSource("[Database instance name]", (DataTable)tbl);

            //this.reportViewer1.LocalReport.DataSources.Clear();
            //this.reportViewer1.LocalReport.DataSources.Add(dataSource);
            //this.reportViewer1.RefreshReport();
        }

        private void Form1_Load(object sender, EventArgs e)
        {


            this.reportViewer1.RefreshReport();
        }

        private void reportesToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void productosToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
