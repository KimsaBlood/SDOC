
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using NeuroSky.ThinkGear;
using NeuroSky.ThinkGear.Algorithms;

/// <summary>
/// Descripción breve de Diadema
/// </summary>
public class Diadema
{
    public Connector connector = new Connector();
    byte PoorSig;
    public Connector.DeviceEventArgs _De = new Connector.DeviceEventArgs(new Device());
    private EventArgs e;
    public object _Sender;
    public string palabra;

    public EventArgs E
    {
        get{return e;}
        set{e = value;}
    }

    public Diadema()
    {
       
    }

    public void Conectar()
    {
        palabra = "holis";
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

    public void Desconectar()
    {
        connector.Close();
    }

    // Called when a device is connected
    void OnDeviceConnected(object sender, EventArgs e)
    {
        E = e;
        Connector.DeviceEventArgs de = (Connector.DeviceEventArgs)e;
        _De = (Connector.DeviceEventArgs)e;
        Console.WriteLine("Device found on: " + de.Device.PortName);

        //de.Device.DataReceived += new EventHandler(OnDataReceived);
        String ruta_archivo = System.AppDomain.CurrentDomain.BaseDirectory + "ondas.txt";
        StreamWriter escritura = File.AppendText(ruta_archivo);
        escritura.Write("Device found on: " + de.Device.PortName);
        escritura.Close();
    }

    // Called when scanning fails
    void OnDeviceFail(object sender, EventArgs e)
    {
        Console.WriteLine("No devices found! :(");
    }

    // Called when each port is being validated
    void OnDeviceValidating(object sender, EventArgs e)
    {
        Console.WriteLine("Validating: ");
    }

    public void OnDataReceived(object sender, EventArgs e)
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
            //for (int i = 0; i < 5; i++){
            //StreamWriter escritura = new StreamWriter("C:\\Users\\gcaza\\OneDrive\\Documentos\\TT\\Prueba2\\ejemplo.txt");
            if (tgParser.ParsedData[i].ContainsKey("Raw"))
            {
                //Console.WriteLine("Raw Value:" + tgParser.ParsedData[i]["Raw"]);
            }

            if (tgParser.ParsedData[i].ContainsKey("PoorSignal"))
            {
                //The following line prints the Time associated with the parsed data
                //Console.WriteLine("Time:" + tgParser.ParsedData[i]["Time"]);

                //A Poor Signal value of 0 indicates that your headset is fitting properly
                Console.WriteLine("Poor Signal:" + tgParser.ParsedData[i]["PoorSignal"]);
                PoorSig = (byte)tgParser.ParsedData[i]["PoorSignal"];
            }


            if (tgParser.ParsedData[i].ContainsKey("Attention"))
            {
                Console.WriteLine("Att Value:" + tgParser.ParsedData[i]["Attention"]);
            }


            if (tgParser.ParsedData[i].ContainsKey("Meditation"))
            {
                Console.WriteLine("Med Value:" + tgParser.ParsedData[i]["Meditation"]);
            }


            if (tgParser.ParsedData[i].ContainsKey("EegPowerDelta"))
            {
                Console.WriteLine("Delta: " + tgParser.ParsedData[i]["EegPowerDelta"]);
            }

            if (tgParser.ParsedData[i].ContainsKey("BlinkStrength"))
            {
                Console.WriteLine("Eyeblink " + tgParser.ParsedData[i]["BlinkStrength"]);
            }
        }
    }
}