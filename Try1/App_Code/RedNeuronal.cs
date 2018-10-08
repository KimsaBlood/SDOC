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

[ServiceContract(Namespace = "")]
[AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
public class RedNeuronal
{

    // Para usar HTTP GET, agregue el atributo [WebGet]. (El valor predeterminado de ResponseFormat es WebMessageFormat.Json)
    // Para crear una operación que devuelva XML,
    //     agregue [WebGet(ResponseFormat=WebMessageFormat.Xml)]
    //     e incluya la siguiente línea en el cuerpo de la operación:
    //         WebOperationContext.Current.OutgoingResponse.ContentType = "text/xml";

    int[] noNeuronas = new int[3];
    int[] function = new int[3];
    double[,] capaIn = new double[3, 1];
    double[,] target = new double[2, 1];
    cAnclas n = new cAnclas();

    //tansig en capas intermedias para que converga mas rapido
    public RedNeuronal()
    {
        noNeuronas[0] = 2;
        noNeuronas[1] = 3;
        noNeuronas[2] = 2;
        function[0] = 1;
        function[1] = 1;
        function[2] = 1;
   
        target[0, 0] = 1;//estres 10, 01 no estres
        target[1, 0] = 0;
    }

    [OperationContract]
    public void DoWork()
    {
        // Agregue aquí la implementación de la operación
        return;
    }

    [OperationContract]
    public void setDatos()
    {
        // Agregue aquí la implementación de la operación
        return;
    }

    [OperationContract]
    public string EntrenarRedNeuronal()
    {
        EntrenaRedNeuronal obj = new EntrenaRedNeuronal(1, noNeuronas, function, capaIn, target, 0.02);
        //obj.TrainRNA();
        double[,] values = Leer();
        for (int i = 0; i < values.GetLength(1); i++)
        {
            capaIn = AssingValues(values, i);
            obj.setCapaIn(capaIn);
            obj.TrainRNA();
            target[0, 0] = 0;
            target[1, 0] = 1;
        }

        capaIn = AssingValues(values, 0);
        obj.setCapaIn(capaIn);
        obj.What();
        return "Se entrenó correctamente";
    }

    [OperationContract]
    public void Clasificar()
    {

    }

    public double[,] AssingValues(double[,] val, int index)
    {
        double[,] valAux = new double[9, 1];
        for (int i = 0; i < val.GetLength(0); i++)
        {
            valAux[i, 0] = val[i, index];
        }
        return valAux;
    }

    public double[,] Leer()
    {
        StreamReader objReader = new StreamReader(System.AppDomain.CurrentDomain.BaseDirectory + "ondas.txt");
        string sLine = "";
        ArrayList arrText = new ArrayList();
        double[,] values;

        int total = 0;
        int count, ii;
        while (sLine != null)
        {
            sLine = objReader.ReadLine();
            if (sLine != null)
            {
                arrText.Add(sLine);

                if (Int32.TryParse(sLine, out count) == true)
                {
                    total++;
                }
            }
        }
        objReader.Close();
        values = new double[9, total];
        int i = 0;
        foreach (string sOutput in arrText)
        {
            if (Int32.TryParse(sOutput, out  ii))
            {
                i = Int32.Parse(sOutput) - 1;
            }
            values = GetValues(values, sOutput, i);

        }
        return values;
    }

    public double[,] GetValues(double[,] values, string sOutput, int index)
    {
        if (sOutput.IndexOf("Poor Signal: ") != -1)
        {
            values[0, index] = double.Parse(sOutput.Substring(sOutput.IndexOf(": ") + 2));
        }
        else if (sOutput.IndexOf("Delta: ") != -1)
        {
            values[1, index] = double.Parse(sOutput.Substring(sOutput.IndexOf(": ") + 2));
        }
        else if (sOutput.IndexOf("Theta: ") != -1)
        {
            values[2, index] = double.Parse(sOutput.Substring(sOutput.IndexOf(": ") + 2));
        }
        else if (sOutput.IndexOf("Alpha1: ") != -1)
        {
            values[3, index] = double.Parse(sOutput.Substring(sOutput.IndexOf(": ") + 2));
        }
        else if (sOutput.IndexOf("Alpha2: ") != -1)
        {
            values[4, index] = double.Parse(sOutput.Substring(sOutput.IndexOf(": ") + 2));
        }
        else if (sOutput.IndexOf("Beta1: ") != -1)
        {
            values[5, index] = double.Parse(sOutput.Substring(sOutput.IndexOf(": ") + 2));
        }
        else if (sOutput.IndexOf("Beta2: ") != -1)
        {
            values[6, index] = double.Parse(sOutput.Substring(sOutput.IndexOf(": ") + 2));
        }
        else if (sOutput.IndexOf("Gamma1: ") != -1)
        {
            values[7, index] = double.Parse(sOutput.Substring(sOutput.IndexOf(": ") + 2));
        }
        else if (sOutput.IndexOf("Gamma2: ") != -1)
        {
            values[8, index] = double.Parse(sOutput.Substring(sOutput.IndexOf(": ") + 2));
        }
        return values;
    }
    public void printOut(double[,] x)
    {
        for (int i = 0; i < x.GetLength(0); i++)
        {
            for (int j = 0; j < x.GetLength(1); j++)
            {
                Console.WriteLine(x[i, j]);
            }
        }
    }
    // Agregue aquí más operaciones y márquelas con [OperationContract]
}
