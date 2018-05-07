using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

/// <summary>
/// Descripción breve de cAnclas
/// </summary>
public class cAnclas
{
    private int _userId;
    private int _userOP;
    private int _anclaId;
    private int _tipo;
    private String _ruta;
    private String _title;
    private String _desc;


    #region Propiedades

    public int userOP
    {
        get
        {
            return this._userOP;
        }
        set
        {
            this._userOP = value;
        }
    }
    public int userId
    {
        get
        {
            return this._userId;
        }
        set
        {
            this._userId = value;
        }
    }
    public int anclaId
    {
        get
        {
            return this._anclaId;
        }
        set
        {
            this._anclaId = value;
        }
    }
    public String title
    {
        get
        {
            return this._title;
        }
        set
        {
            this._title = value;
        }
    }
    public String desc
    {
        get
        {
            return this._desc;
        }
        set
        {
            this._desc = value;
        }
    }
    public int tipo
    {
        get
        {
            return this._tipo;
        }
        set
        {
            this._tipo = value;
        }
    }
    public String ruta
    {
        get
        {
            return this._ruta;
        }
        set
        {
            this._ruta = value;
        }
    }
    #endregion

    public cAnclas()
    {
        //
        // TODO: Agregar aquí la lógica del constructor
        //
    }
    public cAnclas(int UserIDN,int AnclaIDN, String TitleN, String DescN, String RutaN, int TipoN, int userOP2)
    {
        userId = UserIDN;
        anclaId = AnclaIDN;
        title = TitleN;
        desc = DescN;
        ruta = RutaN;
        tipo = TipoN;
        userOP = userOP2;
    }

    public cAnclas(int PersonIDN,int AnclaIDN)
    {
        userId = PersonIDN;
        anclaId = AnclaIDN;
    }

    public DataTable TraeTipo()
    {

        DatosSql sql = new DatosSql();

            DataTable tblAncla = sql.TraerDataTable("BringType");

        return tblAncla;
    }
    public String GuardaAncla()
    {
        String Mensaje = "";

        DatosSql sql = new DatosSql();
        //Mensaje = ValidaFormulario(name, lastName, sureName, email, userName,userPass);
        Mensaje = "";
        if (Mensaje == "")
        {
            
            DataTable tblUsr = sql.TraerDataTable("SaveAncla", title, desc, ruta, userId, tipo, anclaId, userOP);

            if (tblUsr.Rows.Count > 0)
            {
                userId = Convert.ToInt32(tblUsr.Rows[0]["idAncla"].ToString());
                Mensaje = tblUsr.Rows[0]["msj"].ToString();
            }
        }


        return Mensaje;
    }
    public DataTable TraeInfoAnclas()
    {
        DatosSql sql = new DatosSql();
        DataTable tbl = sql.TraerDataTable("getAnclas", userId);
        return tbl;
    }
}