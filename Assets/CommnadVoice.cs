using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Windows.Speech;

public class CommnadVoice : MonoBehaviour
{
	KeywordRecognizer keywordRecognizer;
	Dictionary<string, Action> wordToAction;
	
	public static Action OnUp;
	public static Action OnDown;
	public static PlayerCommandVoice instance;
	// static PlayerCommandVoice Instance
	// {
	// 	get
	// 	{
	// 		if(instance == null)
	// 		{
	// 			Debug.LogError("The player commnad voice is null");
	// 		}
			
	// 		return instance;
	// 	}
	// }
	
	private void Awake()
	{
		// if(instance == null)
		// {
		// 	instance = this;
		// 	ConfigkeywordRecognizer();
		// }else
		// {
		// 	Destroy(instance);
		// }
		ConfigkeywordRecognizer();
	}
	void Start()
	{
		keywordRecognizer.Start();
	}

	private void ConfigkeywordRecognizer()
	{
		Debug.Log("Instancia de voz");
		wordToAction = new Dictionary<string, Action>();
		wordToAction.Add("arriba", Arriba);
		wordToAction.Add("abajo", Abajo);
		keywordRecognizer = new KeywordRecognizer(wordToAction.Keys.ToArray());
		keywordRecognizer.OnPhraseRecognized += WordRecongnized;
		
	}
	private void WordRecongnized(PhraseRecognizedEventArgs word)
	{
		Debug.Log(word.text);
		wordToAction[word.text].Invoke();
	}
	
	private void Abajo()
	{
		if(OnDown != null)
			OnDown();
	}

	private void Arriba()
	{
		if(OnUp != null)
			OnUp();
	}

}
