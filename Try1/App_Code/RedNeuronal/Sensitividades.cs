using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Descripción breve de Sensitividades
/// </summary>
public class Sensitividades
{
    double[,] sensitividad;
    double[,] functionD;

    public Sensitividades()
    {

    }

    public void getSen(double[,] v1, double[,] v2)
    {
        sensitividad = new double[v1.GetLength(0), v2.GetLength(1)];
        functionD = new double[v1.GetLength(0), v2.GetLength(0)];
        for (int i = 0; i < functionD.GetLength(0); i++)
        {
            for (int j = 0; j < functionD.GetLength(1); j++)
            {
                if (i == j)
                {
                    functionD[i, j] = (1 - v2[i, 0]);
                }
            }
        }
        sensitividad = multMatrix(functionD, v1);
    }

    public void getSen(double[,] v1, double[,] v2, Sensitividades v3)
    {
        sensitividad = new double[v1.GetLength(0), v1.GetLength(1)];
        functionD = new double[v1.GetLength(0), v1.GetLength(0)];
        for (int i = 0; i < functionD.GetLength(0); i++)
        {
            for (int j = 0; j < functionD.GetLength(1); j++)
            {
                if (i == j)
                {
                    functionD[i, j] = (1 - v1[i, 0]);
                }
            }
        }
        sensitividad = multMatrix(multMatrix(functionD, trans(v2)), v3.getThisSen());
    }

    public double[,] getThisSen()
    {
        return sensitividad;
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
}