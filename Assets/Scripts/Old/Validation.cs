using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Validation : MonoBehaviour
{
    [SerializeField] private TMP_InputField InputField;
    private float result, number;

    public void ValidarDecimalesPositivos()
    {                     
        if(CanParseToFloat(InputField,1.0f,35.0f))
        {
            Stats.velocidadInicial = number;
        }         
    }

    public void ValidarAnguloConRango ()
    {
        if (CanParseToFloat(InputField,0.0f, 90.0f))
        {
            Stats.anguloinicial = number;
        }
    }
    
    public void ValidarEstimacionDistancia()
    {
        if (CanParseToFloat(InputField,10.0f, 145.0f))
        {
            Stats.distanciaDigitada = number;
        }
    }
                                                             
    public void EstablecerCampo()
    {
        if(InputField.text.Length==0)
            InputField.text = "";
        else
            InputField.text = number.ToString();
    }

    public void QuitarSignoMenos()
    {
        InputField.text = InputField.text.Replace("-", "");
    }
    
    public bool CanParseToFloat(TMP_InputField inputField, float minValue, float maxValue)
    {
        bool canParse = float.TryParse(inputField.text, out result);
        if (canParse)
        {
            number = float.Parse(InputField.text);
            number = Mathf.Clamp(number, minValue, maxValue);
        }
        return canParse;
    }
}
