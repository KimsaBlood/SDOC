using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Descripción breve de EntranaRedNeuronal
/// </summary>
public class EntrenaRedNeuronal
{
    public EntrenaRedNeuronal()
    {
        //
        // TODO: Agregar aquí la lógica del constructor
        //
    }

    int noCapasOc;
    double[,] vIn;
    Capa capaIn;
    Capa[] capasOc;
    Capa capaOut;
    double[,] vOut;
    double[,] vTarget;
    PesosSin pesosSin;
    double[,] bias;
    int[] function;
    int[] noNeuronas;
    private double[,] vError;
    Sensitividades[] sen;
    double alfa;

    public EntrenaRedNeuronal(int noCapasOc, int[] noNeuronas, int[] function, double[,] capaIn, double[,] vTarget, double alfa)
    {
        this.noNeuronas = noNeuronas;
        this.alfa = alfa;
        vIn = capaIn;
        this.capaIn = new Capa(noNeuronas[0], capaIn);
        this.noCapasOc = noCapasOc;
        this.capasOc = new Capa[noCapasOc];
        //this.capaIn.setError(0.0);
        this.function = function;
        this.capaIn.setFunction(function[0]);
        this.capaIn.setVIn(capaIn);
        for (int i = 0; i < noCapasOc; i++)
        {
            this.capasOc[i] = new Capa(function[i + 1]);
        }
        setVTarget(vTarget);
        sen = new Sensitividades[noCapasOc + 2];
        for (int i = 0; i < noCapasOc + 2; i++)
        {
            sen[i] = new Sensitividades();
        }
    }

    public void setCapaIn(double[,] capaIn)
    {
        this.capaIn.setVIn(capaIn);
    }

    public void setVTarget(double[,] vTarget)
    {
        this.vTarget = vTarget;
    }

    public void TrainRNA()
    {
        double[,] a1 = capaIn.propForward();
        pesosSin = new PesosSin(noCapasOc + 2);
        pesosSin.setPesos(0, capaIn.getPesos());
        for (int i = 0; i < capasOc.GetLength(0); i++)
        {
            capasOc[i] = new Capa(noNeuronas[i + 1], a1);
            capasOc[i].setFunction(function[i + 1]);
            a1 = capasOc[i].propForward();
            pesosSin.setPesos(i + 1, capasOc[i].getPesos());
        }
        capaOut = new Capa(noNeuronas[noCapasOc + 1], a1);
        capaOut.setFunction(function[noCapasOc + 1]);
        a1 = capaOut.propForward();
        pesosSin.setPesos(noCapasOc + 1, capaOut.getPesos());
        printOut(a1);
        vError = getError(a1);
        printOut(vError);
        double[,] a12 = new double[a1.GetLength(0), a1.GetLength(1)];
        for (int i = 0; i < vError.GetLength(0); i++)
        {
            for (int j = 0; j < vError.GetLength(1); j++)
            {
                a12[i, j] = (-2) * vError[i, j];
            }
        }
        for (int i = noCapasOc + 1; i >= 0; i--)
        {
            if (i == noCapasOc + 1)
            {
                sen[i].getSen(a12, a1);
            }
            else
            {
                if (i == noCapasOc)
                {
                    sen[i].getSen(capasOc[i - 1].getVOut(), capaIn.getPesos(), sen[i + 1]);
                }
                else if (i == 0)
                {
                    sen[i].getSen(capaOut.getVOut(), capaOut.getPesos(), sen[i + 1]);
                }
                else
                {
                    sen[i].getSen(capasOc[i - 1].getVOut(), capasOc[i].getPesos(), sen[i + 1]);
                }
            }
        }
        capaOut.actPesos(restaMatrix(capaOut.getPesos(), multMatrix(multMatrix2(alfa, sen[noCapasOc + 1].getThisSen()), trans(capasOc[noCapasOc - 1].getVOut()))));

        for (int i = noCapasOc - 1; i >= 0; i--)
        {
            if (i > 0)
            {
                capasOc[i].actPesos(restaMatrix(capasOc[i].getPesos(), multMatrix2(alfa, multMatrix(sen[i + 2].getThisSen(), trans(capasOc[i - 1].getVOut())))));
            }
            else
            {
                capasOc[i].actPesos(restaMatrix(capasOc[i].getPesos(), multMatrix2(alfa, multMatrix(sen[i + 2].getThisSen(), trans(capaIn.getVOut())))));
            }
        }
        capaIn.actPesos(restaMatrix(capaIn.getPesos(), multMatrix2(alfa, multMatrix(sen[0].getThisSen(), trans(vIn)))));
        int ii = 0;
        while (ii < 10000)
        {
            ii++;
            for (int i = 0; i < vError.GetLength(0); i++)
            {
                for (int j = 0; j < vError.GetLength(1); j++)
                {
                    a12[i, j] = (-2) * vError[i, j];
                }
            }
            for (int i = noCapasOc + 1; i >= 0; i--)
            {
                if (i == noCapasOc + 1)
                {
                    sen[i].getSen(a12, a1);
                }
                else
                {
                    if (i == noCapasOc)
                    {
                        sen[i].getSen(capasOc[i - 1].getVOut(), capaIn.getPesos(), sen[i + 1]);
                    }
                    else if (i == 0)
                    {
                        sen[i].getSen(capaOut.getVOut(), capaOut.getPesos(), sen[i + 1]);
                    }
                    else
                    {
                        sen[i].getSen(capasOc[i - 1].getVOut(), capasOc[i].getPesos(), sen[i + 1]);
                    }
                }
            }
            capaOut.actPesos(restaMatrix(capaOut.getPesos(), multMatrix(multMatrix2(alfa, sen[noCapasOc + 1].getThisSen()), trans(capasOc[noCapasOc - 1].getVOut()))));

            for (int i = noCapasOc - 1; i >= 0; i--)
            {
                if (i > 0)
                {
                    capasOc[i].actPesos(restaMatrix(capasOc[i].getPesos(), multMatrix2(alfa, multMatrix(sen[i + 2].getThisSen(), trans(capasOc[i - 1].getVOut())))));
                }
                else
                {
                    capasOc[i].actPesos(restaMatrix(capasOc[i].getPesos(), multMatrix2(alfa, multMatrix(sen[i + 2].getThisSen(), trans(capaIn.getVOut())))));
                }
            }
            capaIn.actPesos(restaMatrix(capaIn.getPesos(), multMatrix2(alfa, multMatrix(sen[0].getThisSen(), trans(vIn)))));
            aproxRNA();
        }

    }

    private double[,] trans(double[,] matrix)
    {
        double[,] matrixTrans = new double[matrix.GetLength(1), matrix.GetLength(0)];
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                matrixTrans[j, i] = matrix[i, j];
            }
        }
        return matrixTrans;
    }

    private double[,] getError(double[,] vOut)
    {
        double[,] error = new double[vOut.GetLength(0), vOut.GetLength(1)];
        for (int i = 0; i < error.GetLength(0); i++)
        {
            for (int j = 0; j < error.GetLength(1); j++)
            {
                error[i, j] = vTarget[i, j] - vOut[i, j];
            }
        }
        return error;
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

    private double[,] multMatrix2(double a, double[,] b)
    {
        double[,] c = new double[b.GetLength(0), b.GetLength(1)];
        for (int i = 0; i < c.GetLength(0); i++)
        {
            for (int j = 0; j < c.GetLength(1); j++)
            {
                c[i, j] = ((a) * (b[i, j]));
            }
        }
        return c;
    }

    private double[,] restaMatrix(double[,] a, double[,] b)
    {
        double[,] c = new double[b.GetLength(0), b.GetLength(1)];
        for (int i = 0; i < c.GetLength(0); i++)
        {
            for (int j = 0; j < c.GetLength(1); j++)
            {
                c[i, j] = ((a[i, j]) - (b[i, j]));
            }
        }
        return c;
    }

    private void nuevaCapa(double[,] entrada)
    {

    }

    public void aproxRNA()
    {
        double[,] a1 = capaIn.propForward();
        System.Diagnostics.Debug.WriteLine("***aproximacion*****");
        a1 = capaOut.propForward();
        printOut(a1);
        vError = getError(a1);
        System.Diagnostics.Debug.WriteLine("*****error***");

        printOut(vError);
    }

    public void printOut(double[,] x)
    {
        for (int i = 0; i < x.GetLength(0); i++)
        {
            for (int j = 0; j < x.GetLength(1); j++)
            {
                System.Diagnostics.Debug.WriteLine(x[i, j]);
            }
        }
    }
}