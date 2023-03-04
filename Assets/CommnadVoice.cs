using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Windows.Speech;

public class CommnadVoice : MonoBehaviour
{
	public KeywordRecognizer keywordRecognizer;
	public ConfidenceLevel confidenceLevel = ConfidenceLevel.Low;
	Dictionary<string, Action> wordToAction;
	
	public static Action OnUp;
	public static Action OnDown;
		
	private void Awake()
	{
		DontDestroyOnLoad(this);
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
		wordToAction.Add("saltar", Arriba);
		wordToAction.Add("deslizar", Abajo);
		wordToAction.Add("up", Arriba);
		wordToAction.Add("down", Abajo);
		wordToAction.Add("jump", Arriba);
		wordToAction.Add("slide", Abajo);
		keywordRecognizer = new KeywordRecognizer(wordToAction.Keys.ToArray(),confidenceLevel);
		keywordRecognizer.OnPhraseRecognized += WordRecongnized;
	}
	
	private void WordRecongnized(PhraseRecognizedEventArgs word)
	{
		Debug.Log(word.text);
		wordToAction[word.text].Invoke();
	}
	
	public void Arriba()
	{
		if(OnUp != null)
			OnUp();
	}
	
	public void Abajo()
	{
		if(OnDown != null)
			OnDown();
	}


}
