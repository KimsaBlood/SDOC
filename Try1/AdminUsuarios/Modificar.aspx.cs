using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Modificar : System.Web.UI.Page
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
            name.Text = obj.name;
            lastName.Text = obj.lastName;
            sureName.Text = obj.sureName;
            email.Text = obj.email;
            userName.Text = obj.userName;
        }
    }
    protected void Modify_Click(object sender,EventArgs e)
    {
        photo.SaveAs(System.AppDomain.CurrentDomain.BaseDirectory + userName.Text.Trim());
        cUsuarios obj = new cUsuarios((int)Session["idUser"], name.Text.Trim(), lastName.Text.Trim(), sureName.Text.Trim(), email.Text.Trim(), userName.Text.Trim(), userPass.Text.Trim(), "images/Profiles/" + photo.FileName.Trim(), 2);
        if (userPass.Text == userPassConf.Text)
        {
            String msj=obj.GuardaUsuario();
            if(msj =="Datos de Usuario Modificados")
            {
                String script = "$.confirm({title: 'Genial!',    content: 'Tus datos han sido modificados',theme: 'material',buttons: {ok:{ btnClass: 'btn btn-info',action: function(){ }   }}}); ";
                ScriptManager.RegisterStartupScript(this, GetType(),
                          "ServerControlScript", script, true);
            }
        }
       // 
    }
    
}