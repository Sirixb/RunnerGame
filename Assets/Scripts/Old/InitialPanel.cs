using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEditor;

public class InitialPanel : MonoBehaviour
{
    [SerializeField] private GameObject initialPanel;
    [SerializeField] private Button iniciarSimulacion;
    [SerializeField] private Thrower Thrower;
    [SerializeField] private TMP_InputField[] tMP_InputFields;
    
    private bool show = false;

    [SerializeField] private Rect window = new Rect(20, 20, 120, 50);
    [SerializeField] private Rect label= new Rect(25, 25, 100, 30);
    [SerializeField] private Rect button = new Rect(10, 20, 100, 20);


    public void VerificarCampoVacio()
    {
        foreach (var inputField in tMP_InputFields)
        {
            bool isEmptys = string.IsNullOrEmpty(inputField.text);
            if (isEmptys)
            {
                Open();
                return;
            }
        }
        initialPanel.SetActive(false);
        Invoke("StartSimulation", 3.0f);
    }

    public void StartSimulation()
    {
        Thrower.Shoot();
    }
    public void Open()
    {
        show = true;
    }

    public void Close()
    {
        show = false;
    }

    public void DesactivarBoton()
    {
        iniciarSimulacion.interactable = false;
    }   
    
    void OnGUI()
    {
        if (show)
        {
            GUI.color = Color.yellow;
            //window = new Rect(Screen.width / 2 - 100, Screen.height / 2 - 340, 263, 78);
            window = GUI.Window(0, window, DoMyWindow, "Aviso"); 
        }
    }

    void DoMyWindow(int windowID)
    {
        GUI.Label(label, "Por favor rellene todos los campos");
        if (GUI.Button(button, "Ok"))
        {
            Close();
        }
        GUI.DragWindow(new Rect(0, 0, 10000, 10000));
    }
}
