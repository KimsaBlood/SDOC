using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NeuroSky.ThinkGear;
using System.IO;
using System.Security.Permissions;

public partial class Monitoreo_Monitoreo : System.Web.UI.Page
{

    static Connector connector = new Connector();
    static byte poorSig;

    protected void Page_Load(object sender, EventArgs e)
    {
        //aqui ya usas la magia de la pagina con las onda
    }

    void Conectar()
    {
    
        // Initialize a new Connector and add event handlers
        connector.DeviceConnected += new EventHandler(OnDeviceConnected);
        connector.DeviceConnectFail += new EventHandler(OnDeviceFail);
        connector.DeviceValidating += new EventHandler(OnDeviceValidating);

        // Scan for devices across COM ports
        // The COM port named will be the first COM port that is checked.
        connector.ConnectScan("COM40");

        // Blink detection needs to be manually turned on
        connector.setBlinkDetectionEnabled(true);
        //Thread.Sleep(450000);

        //System.Console.WriteLine("Goodbye.");
        //connector.Close();
        //Environment.Exit(0);
    }

 

    protected void Button2_Click(object sender, EventArgs e)
    {
        
    }

    // Called when a device is connected 

    static void OnDeviceConnected(object sender, EventArgs e)
    {

        Connector.DeviceEventArgs de = (Connector.DeviceEventArgs)e;
        String ruta_archivo = System.AppDomain.CurrentDomain.BaseDirectory + "\\ondas.txt";
        StreamWriter escritura = File.AppendText(ruta_archivo);
        escritura.Write("Device found on: ");
        Console.WriteLine("Device found on: " + de.Device.PortName);
        de.Device.DataReceived += new EventHandler(OnDataReceived);
        escritura.Close();

    }




    // Called when scanning fails

    static void OnDeviceFail(object sender, EventArgs e)
    {
        String ruta_archivo = System.AppDomain.CurrentDomain.BaseDirectory + "\\ondas.txt";
        StreamWriter escritura= File.AppendText(ruta_archivo);
        Console.WriteLine("No devices found! :(");
        escritura.Write("No devices found! :(");
        escritura.Close();
    }



    // Called when each port is being validated

    static void OnDeviceValidating(object sender, EventArgs e)
    {

        Console.WriteLine("Validating: ");

    }

    // Called when data is received from a device

    static void OnDataReceived(object sender, EventArgs e)
    {

        //Device d = (Device)sender;

        Device.DataEventArgs de = (Device.DataEventArgs)e;
        DataRow[] tempDataRowArray = de.DataRowArray;

        TGParser tgParser = new TGParser();
        tgParser.Read(de.DataRowArray);



        /* Loops through the newly parsed data of the connected headset*/
        // The comments below indicate and can be used to print out the different data outputs. 

        for (int i = 0; i < tgParser.ParsedData.Length; i++)
        {
            //escirtura.WriteLine(i);
            if (tgParser.ParsedData[i].ContainsKey("Raw"))
            {

                //Console.WriteLine("Raw Value:" + tgParser.ParsedData[i]["Raw"]);

            }

            if (tgParser.ParsedData[i].ContainsKey("PoorSignal"))
            {

                //The following line prints the Time associated with the parsed data
                //Console.WriteLine("Time:" + tgParser.ParsedData[i]["Time"]);

                //A Poor Signal value of 0 indicates that your headset is fitting properly
                //Console.WriteLine("Poor Signal:" + tgParser.ParsedData[i]["PoorSignal"]);
                String ruta_archivo = System.AppDomain.CurrentDomain.BaseDirectory + "\\ondas.txt";
                StreamWriter escirtura = File.AppendText(ruta_archivo);
                escirtura.WriteLine("Poor Signal:" + tgParser.ParsedData[i]["PoorSignal"]);
                poorSig = (byte)tgParser.ParsedData[i]["PoorSignal"];
                escirtura.Close();
            }


            if (tgParser.ParsedData[i].ContainsKey("Attention"))
            {
                StreamWriter escirtura = File.AppendText(System.AppDomain.CurrentDomain.BaseDirectory + "ejemplo.txt");
                //Console.WriteLine("Att Value:" + tgParser.ParsedData[i]["Attention"]);
                escirtura.WriteLine("Att Value:" + tgParser.ParsedData[i]["Attention"]);
                escirtura.Close();
            }


            if (tgParser.ParsedData[i].ContainsKey("Meditation"))
            {
                StreamWriter escirtura = File.AppendText(System.AppDomain.CurrentDomain.BaseDirectory + "ejemplo.txt");
                Console.WriteLine("Med Value:" + tgParser.ParsedData[i]["Meditation"]);
                escirtura.WriteLine("Med Value:" + tgParser.ParsedData[i]["Meditation"]);
                escirtura.Close();
                //escirtura.WriteLine("Med Value:" + tgParser.ParsedData[i]["Meditation"]);
            }


            if (tgParser.ParsedData[i].ContainsKey("EegPowerDelta"))
            {

                String ruta_archivo = System.AppDomain.CurrentDomain.BaseDirectory + "\\ondas.txt";
               
                StreamWriter escirtura = File.AppendText(ruta_archivo);
                Console.WriteLine("Delta: " + tgParser.ParsedData[i]["EegPowerDelta"]);
                escirtura.WriteLine();
                escirtura.Close();
                //escirtura.WriteLine("Delta: " + tgParser.ParsedData[i]["EegPowerDelta"]);
            }

            if (tgParser.ParsedData[i].ContainsKey("BlinkStrength"))
            {
                StreamWriter escirtura = File.AppendText(System.AppDomain.CurrentDomain.BaseDirectory + "ejemplo.txt");
                //escirtura.WriteLine("Eyeblink " + tgParser.ParsedData[i]["BlinkStrength"]);
                Console.WriteLine("Eyeblink " + tgParser.ParsedData[i]["BlinkStrength"]);
                escirtura.Close();
            }

        }
        //escirtura.Close();
    }
    /*protected void Page_Load(object sender, EventArgs e)
    {
    }*/


    protected void Button1_Click1(object sender, EventArgs e)
    {
        String ruta_archivo = System.AppDomain.CurrentDomain.BaseDirectory + "\\ondas.txt";
        try
        {
            StreamWriter escritor = new StreamWriter(ruta_archivo);
            escritor.Write("hola");
            escritor.Close();
        }
        catch (Exception ex)
        {

        }
        
        TextBox1.Text = "" + ruta_archivo;
        Conectar();
    }



    protected void Button1_Click(object sender, EventArgs e)
    {
        connector.Close();
    }
}