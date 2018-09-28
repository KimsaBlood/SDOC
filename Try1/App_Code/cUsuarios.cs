using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text.RegularExpressions;
using System.Data;

/// <summary>
/// Summary description for cUsuarios
/// </summary>
public class cUsuarios
{

    private int _userId;
    private int _userOP;
    private String _name;
    private String _lastName;
    private String _sureName;
    private String _email;
    private String _userName;
    private String _userPass;
    private String _userPhoto;

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
    public String name
    {
        get
        {
            return this._name;
        }
        set
        {
            this._name = value;
        }
    }
    public String lastName
    {
        get
        {
            return this._lastName;
        }
        set
        {
            this._lastName = value;
        }
    }
    public String sureName
    {
        get
        {
            return this._sureName;
        }
        set
        {
            this._sureName = value;
        }
    }
    
    public String email
    {
        get
        {
            return this._email;
        }
        set
        {
            this._email = value;
        }
    }
    public String userName
    {
        get
        {
            return this._userName;
        }
        set
        {
            this._userName = value;
        }
    }
    public String userPass
    {
        get
        {
            return this._userPass;
        }
        set
        {
            this._userPass = value;
        }
    }
    public String userPhoto
    {
        get
        {
            return this._userPhoto;
        }
        set
        {
            this._userPhoto = value;
        }
    }
    #endregion


    public cUsuarios()
    {

    }


    public cUsuarios(int PersonIDN, String NombreN, String APaternoN, String ApMaternoN, String EmailN, String UsuarioN, String PasswordN, String fotoN,int userOP2)
    {
        userId = PersonIDN;
        name = NombreN;
        lastName = APaternoN;
        sureName = ApMaternoN;
        userName = UsuarioN;
        email = EmailN;
        userPass = PasswordN;
        userPhoto = fotoN;
        userOP = userOP2;
    }

    public cUsuarios(String EmailN)
    {
        email = EmailN;
    }
    public cUsuarios(int PersonIDN)
    {
        userId = PersonIDN;
    }

    public cUsuarios(String UsuarioN, String PasswordN)
    {
        userName = UsuarioN;
        userPass = PasswordN;
    }
    public String ValidaEmail()
    {
        String Mensaje = "";

        DatosSql sql = new DatosSql();

        DataTable tblUsr = sql.TraerDataTable("GetMail", email);
        if (tblUsr.Rows.Count > 0)
        {
            userId = Convert.ToInt32(tblUsr.Rows[0]["idUser"].ToString());
            Mensaje = tblUsr.Rows[0]["msj"].ToString();
        }
        return Mensaje;
    }
    public String ValidaUsr()
    {
        String Mensaje = "";

        DatosSql sql = new DatosSql();
        userPass = new Extras().ConvierteMD5(userPass);

        DataTable tblUsr = sql.TraerDataTable("GetSession", userName, userPass);

        if (tblUsr.Rows.Count > 0)
        {
            userId = Convert.ToInt32(tblUsr.Rows[0]["idUser"].ToString());
            Mensaje = tblUsr.Rows[0]["msj"].ToString();
        }

        return Mensaje;
    }


    public String GuardaUsuario()
    {
        String Mensaje = "";

        DatosSql sql = new DatosSql();
        //Mensaje = ValidaFormulario(name, lastName, sureName, email, userName,userPass);
        Mensaje = "";
        if (Mensaje == "")
        {
            if (userPass != null)
            {
                userPass = new Extras().ConvierteMD5(userPass);
            }

            DataTable tblUsr = sql.TraerDataTable("SavePerson",userId, name, lastName, sureName, email , userName , userPass,userPhoto,userOP);

            if (tblUsr.Rows.Count > 0)
            {
                userId = Convert.ToInt32(tblUsr.Rows[0]["userId"].ToString());
                Mensaje = tblUsr.Rows[0]["msj"].ToString();
            }
        }


        return Mensaje;
    }

    public String GuardarPass()
    {
        String Mensaje = "";

        DatosSql sql = new DatosSql();
        //Mensaje = ValidaFormulario(name, lastName, sureName, email, userName,userPass);
        Mensaje = "";
        if (Mensaje == "")
        {
            if (userPass != "")
            {
                userPass = new Extras().ConvierteMD5(userPass);
            }

            DataTable tblUsr = sql.TraerDataTable("SaveMail", email,userPass);

            if (tblUsr.Rows.Count > 0)
            {
                //userId = Convert.ToInt32(tblUsr.Rows[0]["userId"].ToString());
                Mensaje = tblUsr.Rows[0]["msj"].ToString();
            }
        }


        return Mensaje;
    }

    public DataTable TraeInfoUsuario()
    {
        DatosSql sql = new DatosSql();
        DataTable tbl = sql.TraerDataTable("myInfo", userId);

        if (tbl.Rows.Count > 0)
        {
            if (userId != 0)
            {
                DataRow dr = tbl.Rows[0];
                name = dr["name"].ToString();
                lastName = dr["lastName"].ToString();
                sureName = dr["sureName"].ToString();
                email = dr["email"].ToString();
                userName = dr["userName"].ToString();
                userPass = dr["userPass"].ToString();
                userPhoto = dr["userPhoto"].ToString();
            }
        }

        return tbl;
    }

    public DataTable TraeInfoUsuario(String Busqueda)
    {
        DatosSql sql = new DatosSql();
        DataTable tbl = sql.TraerDataTable("sp_SearchPerson", Busqueda);
        return tbl;
    }

   /* private String ValidaFormulario(String Nombre, String AP, String AM, String Correo, String Usr)
    {
        String Error = "";

        if (Nombre + AP + AM == "")
        {
            Error += "<li>Debe de Ingresar un Nombre al Uusario.</li>";
        }

        if (Correo == "")
        {
            Error += "<li>Debe de Ingresar un Correo al Usuario</li>";
        }
        else
        {
            String expresion;
            expresion = "\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*";
            if (Regex.IsMatch(Correo, expresion))
            {
                if (Regex.Replace(Correo, expresion, String.Empty).Length == 0)
                {

                }
                else
                {
                    Error += "<li>El formato del Correo Electronico no es valido</li>";
                }

            }
            else
            {
                Error += "<li>El formato del Correo Electronico no es valido</li>";
            }
        }

        if (Usr == "")
        {
            Error += "<li>No ha seleccionado Usuario aun</li>";
        }


        return Error;
    }*/

}



