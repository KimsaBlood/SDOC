using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Visualizar : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["idUser"] == null)
        {
            Response.Redirect(Request.ApplicationPath + "Default.aspx");
        }
        else
        {
            cUsuarios obj = new cUsuarios((int)Session["idUser"]);
            obj.TraeInfoUsuario();
            userPhoto.ImageUrl = "../"+obj.userPhoto;
            name.Text = obj.name;
            lastName.Text = obj.lastName;
            sureName.Text = obj.sureName;
            email.Text = obj.email;
            userName.Text = obj.userName;
        }
    }
}