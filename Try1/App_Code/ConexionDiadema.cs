using NeuroSky.ThinkGear;
using NeuroSky.ThinkGear.Algorithms;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.ServiceModel.Web;
using System.Text;
using System.Threading;

[ServiceContract(Namespace = "")]
[AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]

public class ConexionDiadema
{
    //public Diadema conDiadema = new Diadema();
    static Connector connector = new Connector();
    static byte PoorSig;
    static Connector.DeviceEventArgs De = null;
    static int numS = 0;

    [OperationContract]
    public string GuardarDatos()
    {
        De.Device.DataReceived += new EventHandler(OnDataReceived);
        return "Guardando";
    }

    [OperationContract]
    public string ConectarDiadema()
    {
        String ruta_archivo = System.AppDomain.CurrentDomain.BaseDirectory + "ondas.txt";
        StreamWriter archO = new StreamWriter(ruta_archivo);
        archO.Close();
        StreamWriter dispositivo = new StreamWriter(System.AppDomain.CurrentDomain.BaseDirectory + "dispositivo.txt");
        dispositivo.Close();

        connector = new Connector();
        // Initialize a new Connector and add event handlers
        connector.DeviceConnected += new EventHandler(OnDeviceConnected);
        connector.DeviceConnectFail += new EventHandler(OnDeviceFail);
        connector.DeviceValidating += new EventHandler(OnDeviceValidating);

        // Scan for devices across COM ports
        // The COM port named will be the first COM port that is checked.
        connector.ConnectScan("COM40");

        // Blink detection needs to be manually turned on
        //connector.setBlinkDetectionEnabled(true);
      
        //System.Console.WriteLine("Goodbye.");
        //connector.Close();
        //Environment.Exit(0);
        // conDiadema.Conectar();
        //connector = conDiadema.connector;
        //_De = conDiadema._De;
        //Thread.Sleep(000);
        //Thread.Sleep(20000);
        bool bandera = true;
        string dispositivoF = "";
        while (bandera)
        {
            try
            {
                StreamReader diadema = new StreamReader(System.AppDomain.CurrentDomain.BaseDirectory + "dispositivo.txt");
                string sLine = "";
                ArrayList arrText = new ArrayList();
                while (sLine != null)
                {
                    sLine = diadema.ReadLine();
                    if (sLine != null)
                        arrText.Add(sLine);
                }
                diadema.Close();
                if (arrText[0].ToString() == "Device found on")
                {
                    bandera = false;
                    dispositivoF = arrText[0].ToString();
                }
                else if (arrText[0].ToString() == "No devices found")
                {
                    bandera = false;
                    dispositivoF = arrText[0].ToString();
                }
                    
            }
            catch (Exception e)
            {

            }
        }

        if (dispositivoF == "Device found on")
            return "success";
        else
            return "Conexion fallida";
       
    }

    [OperationContract]
    public string DesconectarDiadema()
    {
        StreamWriter dispositivo = new StreamWriter(System.AppDomain.CurrentDomain.BaseDirectory + "dispositivo.txt");
        dispositivo.Close();
        connector.Close();
        De = null;
        return "Desconectando";
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
        String ruta_archivo = System.AppDomain.CurrentDomain.BaseDirectory + "ondas.txt";
        StreamWriter archO = File.AppendText(ruta_archivo);
        TimeSpan stop;
        TimeSpan start = new TimeSpan(DateTime.Now.Ticks);

        for (int i = 0; i < tgParser.ParsedData.Length; i++)
        {
            
            if (tgParser.ParsedData[i].ContainsKey("PoorSignal"))
            {
                //The following line prints the Time associated with the parsed data
                //Console.WriteLine("Time:" + tgParser.ParsedData[i]["Time"]);
                //A Poor Signal value of 0 indicates that your headset is fitting properly
                numS++;               
                //Console.WriteLine("Poor Signal:" + tgParser.ParsedData[i]["PoorSignal"]);
                archO.Write(numS+":");
                archO.WriteLine(i+"Poor Signal:" + tgParser.ParsedData[i]["PoorSignal"]);
                PoorSig = (byte)tgParser.ParsedData[i]["PoorSignal"];
            }

            if (tgParser.ParsedData[i].ContainsKey("EegPowerDelta"))
            {
                archO.WriteLine(i+"Delta: " + tgParser.ParsedData[i]["EegPowerDelta"]);
                //Console.WriteLine("Delta: " + tgParser.ParsedData[i]["EegPowerDelta"]);
            }

            if (tgParser.ParsedData[i].ContainsKey("EegPowerTheta"))
            {
                archO.WriteLine(i+"Theta: " + tgParser.ParsedData[i]["EegPowerTheta"]);
                //Console.WriteLine("Theta: " + tgParser.ParsedData[i]["EegPowerTheta"]);
            }

            if (tgParser.ParsedData[i].ContainsKey("EegPowerAlpha1"))
            {
                archO.WriteLine(i+"Alpha: " + tgParser.ParsedData[i]["EegPowerAlpha1"]);
                //Console.WriteLine("Alpha1: " + tgParser.ParsedData[i]["EegPowerAlpha1"]);
            }

            if (tgParser.ParsedData[i].ContainsKey("EegPowerAlpha2"))
            {
                archO.WriteLine(i+"Alpha2: " + tgParser.ParsedData[i]["EegPowerAlpha2"]);
                //Console.WriteLine("Alpha2: " + tgParser.ParsedData[i]["EegPowerAlpha2"]);
            }

            if (tgParser.ParsedData[i].ContainsKey("EegPowerBeta1"))
            {
                archO.WriteLine(i+"Beta1: " + tgParser.ParsedData[i]["EegPowerBeta1"]);
                //Console.WriteLine("Beta1: " + tgParser.ParsedData[i]["EegPowerBeta1"]);
            }

            if (tgParser.ParsedData[i].ContainsKey("EegPowerBeta2"))
            {
                archO.WriteLine(i+"Beta2: " + tgParser.ParsedData[i]["EegPowerBeta2"]);
                //Console.WriteLine("Beta2: " + tgParser.ParsedData[i]["EegPowerBeta2"]);
            }

            if (tgParser.ParsedData[i].ContainsKey("EegPowerGamma1"))
            {
                archO.WriteLine(i+"Gamma1: " + tgParser.ParsedData[i]["EegPowerGamma1"]);
                //Console.WriteLine("Gamma1: " + tgParser.ParsedData[i]["EegPowerGamma1"]);
            }

            if (tgParser.ParsedData[i].ContainsKey("EegPowerGamma2"))
            {
                archO.WriteLine(i+"Gamma2: " + tgParser.ParsedData[i]["EegPowerGamma2"]);
                //Console.WriteLine("Gamma2: " + tgParser.ParsedData[i]["EegPowerGamma2"]);
            }
            /*if (tgParser.ParsedData[i].ContainsKey("BlinkStrength"))
            {
                archO.WriteLine("Eyeblink " + tgParser.ParsedData[i]["BlinkStrength"]);
                Console.WriteLine("Eyeblink " + tgParser.ParsedData[i]["BlinkStrength"]);
            }

            if (tgParser.ParsedData[i].ContainsKey("Raw"))
            {
                //Console.WriteLine("Raw Value:" + tgParser.ParsedData[i]["Raw"]);
            }

            if (tgParser.ParsedData[i].ContainsKey("Attention"))
            {
                archO.WriteLine("Att Value:" + tgParser.ParsedData[i]["Attention"]);
                //Console.WriteLine("Att Value:" + tgParser.ParsedData[i]["Attention"]);
            }

            if (tgParser.ParsedData[i].ContainsKey("Meditation"))
            {
                archO.WriteLine("Med Value:" + tgParser.ParsedData[i]["Meditation"]);
                //Console.WriteLine("Med Value:" + tgParser.ParsedData[i]["Meditation"]);
            }*/
        }
        stop = new TimeSpan(DateTime.Now.Ticks);
        archO.WriteLine("Time:" +(double) stop.Subtract(start).TotalMilliseconds);
        archO.Close();    
    }

    void OnDeviceConnected(object sender, EventArgs e)
    {
        Connector.DeviceEventArgs de = (Connector.DeviceEventArgs)e;
        Console.WriteLine("Device found on: " + de.Device.PortName);
        De = de;
        StreamWriter dispositivo = new StreamWriter(System.AppDomain.CurrentDomain.BaseDirectory + "dispositivo.txt");
        dispositivo.WriteLine("Device found on");
        dispositivo.Close();
        //de.Device.DataReceived += new EventHandler(OnDataReceived);
        String ruta_archivo = System.AppDomain.CurrentDomain.BaseDirectory + "datosC.txt";
        StreamWriter datosC = new StreamWriter(ruta_archivo);
        //datosC.WriteLine("Device found on");
        datosC.WriteLine(de.Device.PortName);
        datosC.WriteLine(de.Device.HeadsetID);
        datosC.Close();
        numS = 0;
    }

    // Called when scanning fails
    void OnDeviceFail(object sender, EventArgs e)
    {
        Console.WriteLine("No devices found");
        StreamWriter dispositivo = new StreamWriter(System.AppDomain.CurrentDomain.BaseDirectory + "dispositivo.txt");
        dispositivo.WriteLine("No devices found");
        dispositivo.Close();
    }

    // Called when each port is being validated
    void OnDeviceValidating(object sender, EventArgs e)
    {
        Console.WriteLine("Validating: ");
    }

    // Agregue aquí más operaciones y márquelas con [OperationContract]
}
