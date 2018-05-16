using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class MyMaster : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if(Session["idUser"] == null)
        {
            Response.Redirect(Request.ApplicationPath + "Default.aspx");
        }
    }

    protected void EstimA_Click(object sender, EventArgs e)
    {
        Response.Redirect(Request.ApplicationPath + "AdminAnclas/Estimular.aspx");

    }

    protected void Check_Click(object sender, EventArgs e)
    {
        String hola = Request.ApplicationPath;
        Response.Redirect(Request.ApplicationPath+"AdminUsuarios/Visualizar.aspx");
       
    }

    protected void Modify_Click(object sender, EventArgs e)
    {
        Response.Redirect(Request.ApplicationPath + "AdminUsuarios/Modificar.aspx");
    }
    protected void Delete_Click(object sender, EventArgs e)
    {
        Response.Redirect(Request.ApplicationPath + "AdminUsuarios/Eliminar.aspx");
    }
    protected void RegistrarA_Click(object sender, EventArgs e)
    {
        Response.Redirect(Request.ApplicationPath + "AdminAnclas/Registrar.aspx");
    }
    protected void CheckA_Click(object sender, EventArgs e)
    {
        Response.Redirect(Request.ApplicationPath + "AdminAnclas/Visualizar.aspx");
    }

    protected void ModifyA_Click(object sender, EventArgs e)
    {
        Response.Redirect(Request.ApplicationPath + "AdminAnclas/Modificar.aspx");
    }
    protected void DeleteA_Click(object sender, EventArgs e)
    {
        Response.Redirect(Request.ApplicationPath + "AdminAnclas/Eliminar.aspx");
    }
    protected void Home_Click(object sender, EventArgs e)
    {
        Response.Redirect(Request.ApplicationPath + "Inicio.aspx");
    }
    protected void Calibrar_Click(object sender, EventArgs e)
    {
        Response.Redirect(Request.ApplicationPath + "Monitoreo/Monitoreo.aspx");
    }
    protected void Close_Click(object sender, EventArgs e)
    {
        Session.Abandon();
        Response.Redirect(Request.ApplicationPath + "Default.aspx");
    }
}
