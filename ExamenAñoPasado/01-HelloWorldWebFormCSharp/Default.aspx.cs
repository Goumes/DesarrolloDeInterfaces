using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{
    

    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void Enviar_Click(object sender, EventArgs e)
    {
        string nombre ="Hola "+this.Nombre.Text+". Estamos a: "+ DateTime.Today.ToString();
        DateTime calendario= this.calendario.SelectedDate;
        


        this.si.Visible = true;
        this.no.Visible = true;

        if (DateTime.Today.CompareTo(calendario)==0)
        {
            this.lblfelicidad.Text = "¿Eres Feliz a día de hoy?";
        }
        else if(DateTime.Today.CompareTo(calendario) > 0)
        {
            this.lblfelicidad.Text = "¿Eras feliz?";
        }
        else
        {
            this.lblfelicidad.Text = "¿Crees que serás feliz?";
        }

        this.labelresultado.Text = nombre;

        this.calendario.Visible = false;
        this.Nombre.Visible = false;
        this.Enviar.Visible = false;
        this.lblnombre.Visible = false;

    }

    protected void respuesta_Click(object sender, EventArgs e)
    {
        Button boton=(Button)sender;


        
        if (boton.Text=="Si")
        {
           lblrespuesta.Text = "Me suda la polla";
        }
        else
        {
            lblrespuesta.Text = "Te jodes";
        }
        
    }
}