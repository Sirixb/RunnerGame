using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.Events;

public class FinalPanel : MonoBehaviour
{
    [SerializeField] private GameObject finalPanel;
    [SerializeField] private TMP_Text resultadoObtenido;
    [SerializeField] private TMP_Text resultadoDigitado;
    [SerializeField] private TMP_Text mensajeFinal;

    public void Result()
    {
        finalPanel.SetActive(true);
        Stats.CalculateDistance();
        resultadoObtenido.text = Stats.distanciaRecorrida.ToString("F1");
        resultadoDigitado.text = Stats.distanciaDigitada.ToString("F1");
        mensajeFinal.text = Stats.WinOrLose() ? Win():Lose() ;
    }
    public void LoadScene()
    {
        SceneManager.LoadScene(0);
    }
    public void Exit()
    {
        Application.Quit();
        Debug.Log("Exit");
    }
    public string Win()
    {
        return "Felicidades has Ganado";
    }
    public string Lose()
    {
        return "Fallaste intentalo de nuevo";
    }
    void OnEnable()
    {
        Ball.OnDestroyBall += Result;
    }
    void OnDisable()
    {
        Ball.OnDestroyBall -= Result;
    }


}
