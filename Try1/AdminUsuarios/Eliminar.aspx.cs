using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Eliminar : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["idUser"] == null)
        {
            Response.Redirect("Default.aspx");
        }
        string parameter = Request["__EVENTARGUMENT"];
        if (parameter == "1")
            Delete_Click(sender, e);
    }

    protected void Delete_Click(object sender, EventArgs e)
    {
        cUsuarios obj = new cUsuarios((int)Session["idUser"]);
        obj.TraeInfoUsuario();
        obj.userOP = 1;
        obj.GuardaUsuario();
        
        String script = "$.confirm({title: 'Genial!',    content: 'Tu cuenta ha sido eliminada',theme: 'material',buttons: {ok:{ btnClass: 'btn btn-info',action: function(){ }   }}}); ";
        ScriptManager.RegisterStartupScript(this, GetType(),
                  "ServerControlScript", script, true);
        Session.Abandon();
        Response.Redirect("../Default.aspx");
    }
}