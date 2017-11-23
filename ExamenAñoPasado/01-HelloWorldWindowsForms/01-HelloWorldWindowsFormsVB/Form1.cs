using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _01_HelloWorldWindowsFormsVB
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
        private void btnClick_Click(object sender, EventArgs e)
        {
            string nombre = this.txtNombre.Text;
            string franja_horaria="";

            if(DateTime.Now.Hour>04 && DateTime.Now.Hour < 12)
            {
                franja_horaria = "Buenos Días";
            }   else if(DateTime.Now.Hour > 11 && DateTime.Now.Hour < 20)
                {
                  franja_horaria = "Buenas Tardes";
                }
                   else
                   {
                       franja_horaria = "Buenas Noches";
                   }                                 
            //if (nombre != null && nombre != "")
            //Equivalente
            if (!string.IsNullOrEmpty(nombre))   
            {
                MessageBox.Show("Su nombre es " + nombre, franja_horaria,
            MessageBoxButtons.OKCancel, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1,MessageBoxOptions.ServiceNotification);
            }
            else
            {
                MessageBox.Show("Su nombre es PON TU PUTO NOMBRE", "PONGA SU FUKING NOMBRE",
            MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);

            }
        }
    }
}

