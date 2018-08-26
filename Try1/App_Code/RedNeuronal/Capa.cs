using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Descripción breve de Capa
/// </summary>
public class Capa
{
    int noNeuronas;
    int function;
    double[,] vIn;
    double[,] vOut;
    double[,] pesosSin;
    double[] bias;
    double error;
    Random rnd;

    public Capa(int noNeuronas, double[,] vIn)
    {
        setNoNeuronas(noNeuronas);
        setVIn(vIn);
        this.bias = SetBias();
        this.pesosSin = SetPesos();

    }

    public Capa(int noNeuronas)
    {
        setNoNeuronas(noNeuronas);

    }

    public void setFunction(int function)
    {
        this.function = function;
    }

    public void setError(double error)
    {
        this.error = error;
    }

    private double[] SetBias()
    {
        double[] biasAux = new double[noNeuronas];
        for (int i = 0; i < noNeuronas; i++)
        {
            rnd = new Random();
            biasAux[i] = Convert.ToDouble(rnd.Next(-1, 2));
        }
        return biasAux;
    }

    private double[,] SetPesos()
    {
        rnd = new Random();
        double[,] pesosAux = new double[noNeuronas, this.vIn.GetLength(0)];
        for (int i = 0; i < noNeuronas; i++)
        {
            for (int j = 0; j < this.vIn.GetLength(0); j++)
            {
                pesosAux[i, j] = rnd.NextDouble() * (1 - (-1)) + (-1);
            }
        }
        return pesosAux;
    }

    public void setNoNeuronas(int noNeuronas)
    {
        this.noNeuronas = noNeuronas;
    }

    public void setVIn(double[,] vIn)
    {
        this.vIn = vIn;
    }

    public double[,] getPesos()
    {
        return this.pesosSin;
    }

    public double[,] getVOut()
    {
        return this.vOut;
    }

    public double[] getBias()
    {
        return bias;
    }

    public double[,] propForward()
    {
        vOut = new double[pesosSin.GetLength(0), vIn.GetLength(1)];
        double[,] vOutAux = new double[pesosSin.GetLength(0), vIn.GetLength(1)];
        if (function == 1)
        {
            vOutAux = Logsig();
        }
        vOut = vOutAux;
        return vOutAux;
    }

    public void actPesos(double[,] newP)
    {
        pesosSin = newP;
    }

    private double[,] Logsig()
    {
        double[,] aAux = new double[pesosSin.GetLength(0), vIn.GetLength(1)];
        double[,] a = new double[pesosSin.GetLength(0), vIn.GetLength(1)];
        for (int i = 0; i < pesosSin.GetLength(0); i++)
        {
            for (int j = 0; j < vIn.GetLength(1); j++)
            {

                a = multMatrix(pesosSin, vIn);

            }
        }
        for (int i = 0; i < aAux.GetLength(0); i++)
        {
            for (int j = 0; j < aAux.GetLength(1); j++)
            {
                double b = (-1) * (bias[i] + a[i, j]);
                aAux[i, j] = (1 / (1 + Math.Exp(b)));
            }
        }
        return aAux;
    }

    private double[,] multMatrix(double[,] a, double[,] b)
    {
        double[,] c = new double[a.GetLength(0), b.GetLength(1)];
        for (int i = 0; i < c.GetLength(0); i++)
        {
            for (int j = 0; j < c.GetLength(1); j++)
            {
                for (int k = 0; k < a.GetLength(1); k++)
                {
                    c[i, j] += ((a[i, k]) * (b[k, j]));
                }
            }
        }
        return c;
    }

    private void propBack()
    {

    }
}