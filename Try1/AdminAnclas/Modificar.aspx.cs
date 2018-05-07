using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AdminAnclas_Modificar : System.Web.UI.Page
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
        String myPath = path.Text;
        String val = tipo.Text;
        
        if (val == "2")//sonidos
        {
            System.IO.File.Delete(System.AppDomain.CurrentDomain.BaseDirectory + "Files/sounds/" + path.Text);
            myPath =  "Files/sounds/" + file.FileName;
            file.SaveAs(System.AppDomain.CurrentDomain.BaseDirectory + myPath);
        }
        else if (val == "3")
        {
            System.IO.File.Delete(System.AppDomain.CurrentDomain.BaseDirectory + "Files/images/" + path.Text);
            myPath =  "Files/images/" + file.FileName;
            file.SaveAs(System.AppDomain.CurrentDomain.BaseDirectory + myPath);
        }
        else if (val == "6")
        {
            System.IO.File.Delete(System.AppDomain.CurrentDomain.BaseDirectory + "Files/videos/" + path.Text);
            myPath =  "Files/videos/" + file.FileName;
            file.SaveAs(System.AppDomain.CurrentDomain.BaseDirectory + myPath);
        }
        cAnclas obj = new cAnclas((int)Session["idUser"], Convert.ToInt32(id.Text), title.Text, desc.Text, myPath, Convert.ToInt32(val), 2);
        obj.GuardaAncla();
    }

    protected void gvAnclas_SelectedIndexChanged(object sender, EventArgs e)
    {
        int index=gvAnclas.SelectedIndex;
        string titleN = ((LinkButton)gvAnclas.Rows[index].Cells[1].Controls[0]).Text;
        string descN = ((LinkButton)gvAnclas.Rows[index].Cells[2].Controls[0]).Text;
        string idTipoN = ((LinkButton)gvAnclas.Rows[index].Cells[4].Controls[0]).Text;
        string idAnclaN = ((LinkButton)gvAnclas.Rows[index].Cells[0].Controls[0]).Text;
        string pathN = ((LinkButton)gvAnclas.Rows[index].Cells[5].Controls[0]).Text;
        string[] tokens = pathN.Split('/');
        if (tokens.Length < 1)
        {
            path.Text = tokens[2];
        }
        else
        {
            path.Text = tokens[0];
        }
        title.Text = titleN;
        desc.Text = descN;
        tipo.Text = idTipoN;
        id.Text = idAnclaN;
        
        if (idTipoN == "2" || idTipoN == "3" || idTipoN == "6")
        {
            lblFile.Visible = true;
            file.Visible = true; 
        }
        MultiView1.ActiveViewIndex = 1;
    }
}