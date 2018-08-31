using System;
using System.Collections.Generic;
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



    public RedNeuronal()
    {
        noNeuronas[0] = 2;
        noNeuronas[1] = 3;
        noNeuronas[2] = 2;
        function[0] = 1;
        function[1] = 1;
        function[2] = 1;
   
        target[0, 0] = 1;
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
        obj.TrainRNA();
        return "Se entrenó correctamente";
    }

    [OperationContract]
    public void Clasificar()
    {

    }
    // Agregue aquí más operaciones y márquelas con [OperationContract]
}
