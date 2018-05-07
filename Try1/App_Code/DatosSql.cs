using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
//using System.Data.Sql;
using System.Data.SqlClient;

/// <summary>
/// Descripción breve de cDatosSql
/// </summary>
public class DatosSql
{
    String _cadenaConex = "";
    SqlConnection _conectarBD = new SqlConnection();

    public DatosSql()
    {
        this._cadenaConex = System.Configuration.ConfigurationManager.AppSettings["CADENA_CONEXION_SQL"].ToString();
        this._conectarBD.ConnectionString = this._cadenaConex;
    }

    public DatosSql(String cadenaConex)
    {
        this._cadenaConex = cadenaConex;
        this._conectarBD.ConnectionString = this._cadenaConex;
    }

    public void Ejecutar(String StoredProcedure, params Object[] parametros)
    {
        SqlCommand sql = new SqlCommand(StoredProcedure + " " + cargaParametros(parametros), this._conectarBD);
        sql.CommandTimeout = 6000;
        this._conectarBD.Open();
        sql.ExecuteNonQuery();

        if (this._conectarBD.State == ConnectionState.Open)
        {
            this._conectarBD.Close();
        }
    }
    public void EjecutarCargaMasiva(String StoredProcedure, params Object[] parametros)
    {
        SqlCommand sql = new SqlCommand(StoredProcedure + " " + cargaParametrosCM(parametros), this._conectarBD);
        if (this._conectarBD.State != ConnectionState.Open)
        {
            this._conectarBD.Open();
        }

        sql.ExecuteNonQuery();

        if (this._conectarBD.State == ConnectionState.Open)
        {
            this._conectarBD.Close();
        }
    }

    public DataTable TraerDataTable(String StoredProcedure, params Object[] parametros)
    {
        DataTable tblResultado = new DataTable();
        if (parametros != null)
        {
            SqlDataAdapter da = new SqlDataAdapter(StoredProcedure + cargaParametros(parametros), this._conectarBD);
            da.Fill(tblResultado);
        }

        if (this._conectarBD.State == ConnectionState.Open)
        {
            this._conectarBD.Close();
        }

        return tblResultado;
    }

    private String cargaParametros(params Object[] parametros)
    {
        String salida = " ";
        foreach (Object parametro in parametros)
        {
            String par = parametro.ToString().Replace("'", "");
            salida += "'" + par + "',";
        }

        salida = salida.Substring(0, salida.Length - 1);
        return salida;
    }
    private String cargaParametrosCM(params Object[] parametros)
    {
        String salida = " ";

        foreach (Object parametro in parametros)
        {
            String par = parametro.ToString();
            salida += "'" + par + "'   ";
        }

        salida = salida.Substring(0, salida.Length - 1);
        return salida;
    }
}
