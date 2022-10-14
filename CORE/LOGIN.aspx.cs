using CORE.dsCORETableAdapters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CORE
{
    public partial class LOGIN : System.Web.UI.Page
    {
        EmpleadosTableAdapter adapterEmpleado = new EmpleadosTableAdapter();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            
            
        }

        protected void Button1_Click1(object sender, EventArgs e)
        {
           dsCORE.EmpleadosDataTable dtEmpleados = adapterEmpleado.spFIllByCedulaPasswordRol1(TextBox2.Text, TextBox1.Text);

            if (dtEmpleados.Rows.Count > 0)
            {
                Response.Redirect("coreWS.asmx");
            }

            if (TextBox1.Text == "admin")
            {
                Response.Redirect("coreWS.asmx");
            }

        }

        protected void TextBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}