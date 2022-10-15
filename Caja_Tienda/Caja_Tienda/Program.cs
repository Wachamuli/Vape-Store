using Caja_Tienda.DataSet1TableAdapters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Caja_Tienda
{
    static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            LOGINTableAdapter adapter = new LOGINTableAdapter();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Class1 class1 = new Class1();
            Login login = new Login();
            do
            {
                Application.Run(new Login());
                foreach (var item in adapter.GetData().Where(c=> c.Id == 1))
                {
                    R = item.R;
                }
               
            } while (R == false);
            if (R == true)
                Application.Exit();

            Application.Run(new Inicio());
        }
        static bool R = true;
    }
}
