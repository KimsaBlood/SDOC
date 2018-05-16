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
            photo.SaveAs(System.AppDomain.CurrentDomain.BaseDirectory + userName.Text.Trim());
            if (photo.FileName.Trim().IndexOf(".jpg") > -1|| photo.FileName.Trim().IndexOf(".png") > -1|| photo.FileName.Trim().IndexOf(".gif") > -1)
            {
                cUsuarios obj = new cUsuarios(0, name.Text, lastName.Text, sureName.Text, email.Text, userName.Text, userPass.Text, "images/Profiles/" + photo.FileName.Trim(), 0);
                String mensaje = obj.GuardaUsuario();
                if (mensaje == "Usuario Registrado Correctamente")
                {
                    
                    String script = "$.confirm({title: 'Genial!',    content: 'Usuario registrado correctamente',theme: 'material',buttons: {ok:{ btnClass: 'btn btn-info',action: function(window.location.replace('"+Request.ApplicationPath+"Default.aspx');){ }   }}}); ";
                    ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScript", script, true);
                }
                else if (mensaje == "Usuario Registrado Anteriormente")
                {
                    String script = "$.confirm({title: 'Error!',    content: 'Nombre de usuario o correo registrado anteriormente',theme: 'material',buttons: {ok:{ btnClass: 'btn btn-info',action: function(){ }   }}}); ";
                    ScriptManager.RegisterStartupScript(this, GetType(),
                              "ServerControlScript", script, true);
                }
            }
            else
            {
                String script = "$.confirm({title: 'Error!',    content: 'La extensión del archivo debe ser .jpg, .png o .gif',theme: 'material',buttons: {ok:{ btnClass: 'btn btn-info',action: function(){ }   }}}); ";
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