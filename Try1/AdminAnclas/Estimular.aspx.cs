using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AdminAnclas_Estimular : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void Start_Click(object sender, EventArgs e)
    {
        MultiView1.ActiveViewIndex = 1;
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

    protected void gvAnclas_SelectedIndexChanged(object sender, EventArgs e)
    {
        int index = gvAnclas.SelectedIndex;
        string titleN = ((LinkButton)gvAnclas.Rows[index].Cells[1].Controls[0]).Text;
        string descN = ((LinkButton)gvAnclas.Rows[index].Cells[2].Controls[0]).Text;
        string idTipoN = ((LinkButton)gvAnclas.Rows[index].Cells[4].Controls[0]).Text;
        string idAnclaN = ((LinkButton)gvAnclas.Rows[index].Cells[0].Controls[0]).Text;
        string pathN = ((LinkButton)gvAnclas.Rows[index].Cells[5].Controls[0]).Text;
        string[] tokens = pathN.Split('/');
        if (tokens.Length > 1)
        {
            if (idTipoN == "2")
            {
                litFile.Text = "<audio controls  src='../" + pathN + "' type='audio/mp3'></audio>";
            }
            else if (idTipoN == "3")
            {
                litFile.Text = "<img src='../" + pathN + "' class='img-thumbnail' style='width:300px;'>";
            }
            else if (idTipoN == "6")
            {
                litFile.Text = "<center><video width=500 controls><source src='../" + pathN + "' type='video/mp4;codecs='avc1.42E01E, mp4a.40.2''></video></center>";

            }
        }
        else
        {

        }
        lblTitle.Text = titleN;
        lblDescrip.Text = descN;
        MultiView1.ActiveViewIndex = 2;
    }

    protected void Next1_Click(object sender, EventArgs e)
    {
        MultiView1.ActiveViewIndex = 3;
    }

    protected void Next2_Click1(object sender, EventArgs e)
    {
        MultiView1.ActiveViewIndex = 4;
    }

    protected void Finalizar_Click1(object sender, EventArgs e)
    {

    }
}