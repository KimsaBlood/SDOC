using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Register : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void Regis_Click(object sender, EventArgs e)
    {
        if (userPass.Text == userPassConf.Text)
        {
            cUsuarios obj = new cUsuarios(0, name.Text, lastName.Text, sureName.Text, email.Text, userName.Text, userPass.Text, "", 0);
            String mensaje = obj.GuardaUsuario();
            if (mensaje == "Usuario Registrado Correctamente")
            {
                Response.Redirect("Default.aspx");
            }
            else if (mensaje == "Usuario Registrado Anteriormente")
            {
                String script = "$.confirm({title: 'Error!',    content: 'Usuario registrado anteriormente',theme: 'material',buttons: {ok:{ btnClass: 'btn btn-info',action: function(){ }   }}}); ";
                ScriptManager.RegisterStartupScript(this, GetType(),
                          "ServerControlScript", script, true);
            }
        }
        else
        {
            String script = "$.confirm({title: 'Error!',    content: 'Las contraseñas no coinciden',theme: 'material',buttons: {ok:{ btnClass: 'btn btn-info',action: function(){ }   }}}); ";
            ScriptManager.RegisterStartupScript(this, GetType(),
                      "ServerControlScript", script, true);
        }
    }
}