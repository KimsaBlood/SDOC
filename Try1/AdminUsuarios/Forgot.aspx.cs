using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Forgot : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void Send_Click(object sender, EventArgs e)
    {;
        cUsuarios obj = new cUsuarios(txtEmail.Text);
        String msj=obj.ValidaEmail();
        Extras obj2 = new Extras();
        
        
        if (msj== "Usuario Encontrado")
        {
            Random rnd = new Random();
            String newPass = "" + rnd.Next(1, 1000000000);
            obj.userPass = newPass;
            obj.GuardarPass();
            obj2.sendMail2(txtEmail.Text, "Tu nueva contraseña es: "+ newPass, "Recuperacion de contraseña");
        }
        else if(msj== "No existe correo")
        {
            String script = "$.confirm({title: 'Error!',    content: 'No hay ninguna cuenta asociada a ese correo',theme: 'material',buttons: {ok:{ btnClass: 'btn btn-info',action: function(){ }   }}}); ";
            ScriptManager.RegisterStartupScript(this, GetType(),
                      "ServerControlScript", script, true);
        }
    }
}