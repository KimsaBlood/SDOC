using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Security.Cryptography;
using System.Data;
using System.IO;
using System.Drawing;
/// <summary>
/// Descripción breve de Extras
/// </summary>
public class Extras
{
    public Extras()
    {

    }

    MailAddress address = new MailAddress(System.Configuration.ConfigurationManager.AppSettings["mailDiadema"], "Kimsa Raven Blood", Encoding.UTF8);
    static string usrMail = System.Configuration.ConfigurationManager.AppSettings["usrMail"];
    static string pswMail = System.Configuration.ConfigurationManager.AppSettings["pswMail"];
    static int port = Convert.ToInt32(System.Configuration.ConfigurationManager.AppSettings["puertoMail"]);
    System.Net.NetworkCredential credential = new System.Net.NetworkCredential(usrMail, pswMail);
    //String ipaddress = "192.168.254.247";
    String ipaddress = System.Configuration.ConfigurationManager.AppSettings["serverMail"];

    public void GuardaExcepcion(String Texto)
    {
        DatosSql sql = new DatosSql();
        string url = HttpContext.Current.Request.Url.AbsoluteUri;
        //sql.Ejecutar("sp_GuardaExcepcion",0,Texto,url);
    }

    public void sendMail2(String correo, string body, string subject)
    {

        try
        {
            MailMessage mail = new MailMessage();
            mail.IsBodyHtml = true;
            SmtpClient SmtpServer = new SmtpClient();
            SmtpServer.Host = ipaddress;
            mail.From = address;


            mail.Subject = subject;
            mail.To.Add(correo);
            mail.CC.Add("dduran@momentum-ti.com");
            mail.Body = body;
            SmtpServer.Port = port;
            SmtpServer.Credentials = credential;
            SmtpServer.EnableSsl = false;
            SmtpServer.Send(mail);
        }

        catch (Exception ex)
        {
            GuardaExcepcion(ex.Message);

        }
    }

    public String encriptaB64(string texto)
    {
        var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(texto);
        return System.Convert.ToBase64String(plainTextBytes);
    }

    public String decriptaB64(string textoEncriptado)
    {
        var base64EncodedBytes = System.Convert.FromBase64String(textoEncriptado);
        return System.Text.Encoding.UTF8.GetString(base64EncodedBytes);
    }


    public string ConvierteMD5(string str)
    {
        MD5 md5 = MD5CryptoServiceProvider.Create();
        ASCIIEncoding encoding = new ASCIIEncoding();
        byte[] stream = null;
        StringBuilder sb = new StringBuilder();

        stream = md5.ComputeHash(encoding.GetBytes(str));
        for (int i = 0; i < stream.Length; i++)
            sb.AppendFormat("{0:x2}", stream[i]);
        return sb.ToString();
    }

}