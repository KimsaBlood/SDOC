using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AdminAnclas_Registrar : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        cAnclas obj = new cAnclas();
        DataTable tblAnclas= obj.TraeTipo();
        if (tblAnclas.Rows.Count > 0)
        {
                for (int i = 0; i < tblAnclas.Rows.Count; i++)
                {
                    tipo.Items.Add(new ListItem(tblAnclas.Rows[i]["tipoAncla"].ToString(), tblAnclas.Rows[i]["idTipoAncla"].ToString()));
                }
        }
        else
        {
            String script = "$.confirm({title: 'Genial!',    content: 'Tus datos han sido modificados',theme: 'material',buttons: {ok:{ btnClass: 'btn btn-info',action: function(){ }   }}}); ";
            ScriptManager.RegisterStartupScript(this, GetType(),
                      "ServerControlScript", script, true);
        }
    }

    protected void tipo_SelectedIndexChanged(object sender, EventArgs e)
    {
        String val = tipo.SelectedValue;
        if (val == "2" || val == "3" || val == "6")
        {
            file.Visible = true;
            lblFile.Visible = true;
        }
        else
        {
            file.Visible = false;
            lblFile.Visible = false;
        }
    }

    protected void Register_Click(object sender, EventArgs e)
    {
        String myPath="";
        String val = tipo.SelectedValue;
        if (val == "2")//sonidos
        {
            myPath = "Files/sounds/" + file.FileName;
            file.SaveAs(System.AppDomain.CurrentDomain.BaseDirectory + myPath);
        }
        else if (val == "3")
        {
            myPath =  "Files/images/" + file.FileName;
            file.SaveAs(System.AppDomain.CurrentDomain.BaseDirectory + myPath);
        }
        else if (val == "6")
        {
            myPath = "Files/videos/" + file.FileName;
            file.SaveAs(System.AppDomain.CurrentDomain.BaseDirectory + myPath);
        }
        cAnclas obj = new cAnclas((int)Session["idUser"], 0, title.Text, desc.Text,myPath, Convert.ToInt32(tipo.SelectedValue), 0);
        obj.GuardaAncla();
    }
}