using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NeuroSky.ThinkGear;
using System.IO;
using System.Security.Permissions;
using System.Threading;

public partial class Monitoreo_Monitoreo : System.Web.UI.Page
{

    static Connector connector = new Connector();
    static byte poorSig;
    StreamWriter ondasA;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["idUser"] == null)
        {
            Response.Redirect(Request.ApplicationPath + "Default.aspx");
        }
        else
        {
            cFiles obj = new cFiles();
            System.Data.DataTable tblAudios = obj.GetAudios();

            if (tblAudios.Rows.Count > 0)
            {
                for (int i = 0; i < tblAudios.Rows.Count; i++)
                    tblAudios.Rows[i]["ruta"] = "<audio name='audios_estresantes' controls  src='" + tblAudios.Rows[i]["ruta"].ToString() + "' type='audio/mp3'></audio>";
            }
            else
            {

            }
            gvMetAlm.GridLines = GridLines.None;
            gvMetAlm.DataSource = tblAudios;
            gvMetAlm.DataBind();
        }
        //aqui ya usas la magia de la pagina con las onda
    }

    protected void Button1_Click1(object sender, EventArgs e)
    {
        String ruta_archivo = System.AppDomain.CurrentDomain.BaseDirectory + "ondas.txt";
        try
        {
            StreamWriter escritor = new StreamWriter(ruta_archivo);
            escritor.Write("hola");
            escritor.Close();
        }
        catch (Exception ex)
        {

        }

        //TextBox1.Text = "" + ruta_archivo;
    }


    protected void Button1_Click(object sender, EventArgs e)
    {

    }

    protected void Button1_Click2(object sender, EventArgs e)
    {
        Thread.Sleep(20000);
    }
}