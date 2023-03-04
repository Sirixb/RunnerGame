using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stats 
{
    public static float velocidadInicial;
    public static float anguloinicial; 
    public static float distanciaDigitada=10f;
    public static float distanciaRecorrida;
    public static float tolerance;
    private static float margenMaximo;
    private static float margenMinimo;
    public static float gravity;

    public static void CalculateDistance()
    {
        anguloinicial *= Mathf.Deg2Rad;
        distanciaRecorrida = Mathf.Sin(2 * anguloinicial) * Mathf.Pow(velocidadInicial, 2) / gravity;
    }

    public static bool WinOrLose()
    {
        margenMaximo = distanciaDigitada + tolerance;
        margenMinimo = distanciaDigitada - tolerance;

        if (distanciaRecorrida >= margenMinimo && distanciaRecorrida <= margenMaximo)
            return true;
        else
            return false;
    }
}
