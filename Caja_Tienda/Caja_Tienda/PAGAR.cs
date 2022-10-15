using Caja_Tienda.DataSet1TableAdapters;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Caja_Tienda
{
    public partial class PAGAR : Form
    {
        public PAGAR()
        {
            InitializeComponent();
        }

        private void label6_Click(object sender, EventArgs e)
        {
           
        }

        private void PAGAR_Load(object sender, EventArgs e)
        {
            FacturaPTableAdapter adapter = new FacturaPTableAdapter();
            label6.Visible = true;
            label6.Text= Convert.ToString(adapter.GetData().Sum(c => c.Total));
        }

        private void label2_Click(object sender, EventArgs e)
        {
            if (listBox1.Text == "TARJETA DE DEBITO/CREDITO")
                label2.Visible = false;
            else
                label2.Visible = true;
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox1.Text == "TARJETA DE DEBITO/CREDITO")
                label2.Visible = false;
            else
                label2.Visible = true;
        }

        private void label4_Click(object sender, EventArgs e)
        {
            if (listBox1.Text == "TARJETA DE DEBITO/CREDITO")
                label4.Visible = false;
            else
                label4.Visible = true;

            if(label4.Visible == true)

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

            if (listBox1.Text == "TARJETA DE DEBITO/CREDITO")
                textBox1.Visible = false;
            else
                textBox1.Visible = true;

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("SE HA PAGADO");
           
            Close();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            if (listBox1.Text == "TARJETA DE DEBITO/CREDITO")
                label3.Visible = false;
            else
                label3.Visible = true;
        }
    }
}
