using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AdminAnclas_Visualizar : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["idUser"] == null)
        {
            Response.Redirect(Request.ApplicationPath + "Default.aspx");
        }
        else
        {
            cAnclas obj = new cAnclas((int)Session["idUser"], 0);
            DataTable tblAnclas = obj.TraeInfoAnclas();
            if (tblAnclas.Rows.Count > 0)
            {
                int anclaId = Convert.ToInt32(tblAnclas.Rows[0]["idAncla"].ToString());
                
                for (int i = 0; i < tblAnclas.Rows.Count; i++)
                {
                    String idTipo = tblAnclas.Rows[i]["idTipoAncla"].ToString();
                    if (idTipo == "1")
                    {
                        tblAnclas.Rows[i]["rutaFile"] = "<audio controls  src='../" + tblAnclas.Rows[i]["rutaFile"].ToString() + "' type='audio/mp3'></audio>";
                    }
                    else if (idTipo == "3")
                    {
                        tblAnclas.Rows[i]["rutaFile"] = "<img src='../" + tblAnclas.Rows[i]["rutaFile"].ToString() + "' class='img-thumbnail' style='width:300px;'>";
                        Console.Write(tblAnclas.Rows[i]["rutaFile"].ToString());
                    }
                    else if (idTipo == "2")
                    {
                        tblAnclas.Rows[i]["rutaFile"] = "<video width=300 controls><source src='../" + tblAnclas.Rows[i]["rutaFile"].ToString() + "' type='video/mp4;codecs='avc1.42E01E, mp4a.40.2''></video>";
                    }
                }
            }
            gvAnclas.GridLines = GridLines.None;
            gvAnclas.DataSource = tblAnclas;
            gvAnclas.DataBind();
        }
    }
}