using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Descripción breve de PesosSin
/// </summary>
public class PesosSin
{
    int noCapas;
    double[][,] pesos;

    public PesosSin(int noCapas)
    {
        pesos = new double[noCapas][,];
    }

    public void writeFilePesos()
    {

    }

    public void setPesos(int capaActiva, double[,] pesos)
    {
        this.pesos[capaActiva] = pesos;
    }
}