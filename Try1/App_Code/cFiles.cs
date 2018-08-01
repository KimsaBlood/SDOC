using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

/// <summary>
/// Descripción breve de cFiles
/// </summary>
public class cFiles
{
    private int _IdFile;
    private int _IdTipo;
    private string _Ruta;
    private string _Title;
    private string _Desc;
   
    //Constructor vacío
    public cFiles()
    {
        //
        // TODO: Agregar aquí la lógica del constructor
        //
    }

    //Constructor con parámetros
    public cFiles(int idFile, int idTipo, string ruta, string title, string desc)
    {
        this.IdFile = idFile;
        this.IdTipo = idTipo;
        this.Ruta = ruta;
        this.Title = title;
        this.Desc = desc;
    }

    //Metodo Mostrar
    public DataTable GetAudios()
    {
        DatosSql sql = new DatosSql();
        DataTable tbl = sql.TraerDataTable("spGet_Audios");

        return tbl;
    }

    /*Métodos Getters & Setters */
    public int IdFile
    {
        get{return _IdFile;}
        set{_IdFile = value;}
    }

    public int IdTipo
    {
        get{ return _IdTipo;}
        set{ _IdTipo = value;}
    }

    public string Ruta
    {
        get{ return _Ruta;}
        set{ _Ruta = value;}
    }

    public string Title
    {
        get{ return _Title;}
        set{ _Title = value;}
    }

    public string Desc
    {
        get{ return _Desc;}
        set{ _Desc = value;}
    }
}