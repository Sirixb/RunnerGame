using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace MainMenuInnovati{
public class MainMenu : MonoBehaviour
{

	public void LoadScene(int number)
	{
		SceneManager.LoadScene(number);
	}
	
	public void ExitGame()
	{
		Application.Quit();
		Debug.Log("Exit");
	}
}
};