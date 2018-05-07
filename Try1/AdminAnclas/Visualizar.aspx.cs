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
            }
            gvAnclas.GridLines = GridLines.None;
            gvAnclas.DataSource = tblAnclas;
            gvAnclas.DataBind();
        }
    }
}