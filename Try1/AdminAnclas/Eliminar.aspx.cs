using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AdminAnclas_Eliminar : System.Web.UI.Page
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
                if (anclaId == 2)
                {

                }
            }
            gvAnclas.GridLines = GridLines.None;
            gvAnclas.DataSource = tblAnclas;
            gvAnclas.DataBind();
        }
    }

    protected void Modify_Click(object sender, EventArgs e)
    {
        
    }
    protected void gvAnclas_SelectedIndexChanged(object sender, EventArgs e)
    {
        int index = gvAnclas.SelectedIndex;
        string titleN = ((LinkButton)gvAnclas.Rows[index].Cells[1].Controls[0]).Text;
        string descN = ((LinkButton)gvAnclas.Rows[index].Cells[2].Controls[0]).Text;
        string idTipoN = ((LinkButton)gvAnclas.Rows[index].Cells[4].Controls[0]).Text;
        string idAnclaN = ((LinkButton)gvAnclas.Rows[index].Cells[0].Controls[0]).Text;
        string pathN = ((LinkButton)gvAnclas.Rows[index].Cells[5].Controls[0]).Text;
        string[] tokens = pathN.Split('/');
        cAnclas obj = new cAnclas((int)Session["idUser"], Convert.ToInt32(idAnclaN), titleN, descN, pathN, Convert.ToInt32(idTipoN), 1);
        obj.GuardaAncla();
    }

}