using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Windows.Speech;

public class PlayerCommandVoice : MonoBehaviour
{
	[SerializeField] private CapsuleCollider capsuleCollider;
	[SerializeField] private Rigidbody rigidbodyPlayer;
	
	
	KeywordRecognizer keywordRecognizer;
	Dictionary<string, Action> wordToAction;
	void Start()
	{
		wordToAction = new Dictionary<string, Action>();
		wordToAction.Add("azul",Azul);
		wordToAction.Add("rojo",Rojo);
		wordToAction.Add("verde",Verde);
		wordToAction.Add("arriba",Arriba);
		wordToAction.Add("abajo",Abajo);
		
		keywordRecognizer= new KeywordRecognizer(wordToAction.Keys.ToArray());
		keywordRecognizer.OnPhraseRecognized += WordRecongnized;
		keywordRecognizer.Start();
	}

	private void WordRecongnized(PhraseRecognizedEventArgs word)
	{
		Debug.Log(word.text);
		wordToAction[word.text].Invoke();
	}

	private void Abajo()
	{
		transform.Translate(Vector3.down);
	}

	private void Arriba()
	{
		// transform.Translate(Vector3.up);
		rigidbodyPlayer.AddForce(Vector3.up  * 10f,ForceMode.Impulse);
	}

	private void Verde()
	{
		GetComponent<Renderer>().material.SetColor("_Color",Color.green);
	}

	private void Rojo()
	{
		GetComponent<Renderer>().material.SetColor("_Color",Color.red);
	}

	private void Azul()
	{
		GetComponent<Renderer>().material.SetColor("_Color",Color.blue);
	}

	// Update is called once per frame
	void Update()
	{
	
	}
}
