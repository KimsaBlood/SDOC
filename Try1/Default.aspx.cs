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

    protected void btnForgot_Click1(object sender, EventArgs e)
    {
        Response.Redirect("AdminUsuarios/Forgot.aspx");
    }
    protected void btnLogin_Click1(object sender, EventArgs e)
    {
        cUsuarios obj = new cUsuarios(txtUsuario.Text, txtPsw.Text);

        String Mensaje = obj.ValidaUsr();

        if (obj.userId != 0)
        {
            Session.Add("idUser", obj.userId);
            Response.Redirect("Inicio.aspx");


        }
        else
        {
            String script = "$.confirm({title: 'Error!',    content: 'Usuario y/o contraseña incorrectos',theme: 'material',buttons: {ok:{ btnClass: 'btn btn-info',action: function(){ }   }}}); ";
            ScriptManager.RegisterStartupScript(this, GetType(),
                      "ServerControlScript", script, true);
        }
    }

    protected void btnRegis_Click1(object sender, EventArgs e)
    {     
            Response.Redirect("AdminUsuarios/Register.aspx");
    }
}