using System.Collections;
using UnityEngine;


public class PlayerCommandVoice : MonoBehaviour
{
	[SerializeField] private CapsuleCollider capsuleCollider;
	[SerializeField] private Rigidbody rigidbodyPlayer;
	[SerializeField] private Animator animator;
	
	
	private bool canJump = true;
	private float jump;
	[SerializeField] private float speed= 5;
	[SerializeField] private float hight= 1;
	[SerializeField] private float speedHight = 2;
	private float tempo;
	
	bool shouldContinue = false;
	static readonly string animatorSpeed = "Speed";
	
	private void Start()
	{
		animator.SetFloat(animatorSpeed,speed);
		
	}
	public void Slide()
	{
		animator.SetFloat(animatorSpeed,speed);
	}

	
	void Update()
	{
		Movement();
	}

	private void Movement()
	{
		transform.Translate(Vector3.forward * Time.deltaTime * speed, Space.World);
	}

	private void Arriba()
	{
		StartCoroutine(Jump());
	}
	
	IEnumerator Jump()
	{
		do
		{
			tempo+=.2f;
			transform.transform.position = (new Vector3(transform.position.x, Mathf.PingPong((tempo * hight) * speedHight, 5), transform.position.z));
			print ("Hello World");
			yield return null;
			
		}while(transform.position.y >= .1);
		
		tempo= 0f;
		yield return null;
	}
	
	private void Abajo()
	{
		transform.position = new Vector3(transform.position.x,0,transform.position.z);
	}
	
	IEnumerator Fall()
	{
		while (jump >= .1)
		{
			jump-= Time.deltaTime;
			transform.Translate(Vector3.down * jump);
			Debug.Log("bajando");
			yield return null;
		}
		// canJump=true;
		// transform.position= Vector3.zero;
		yield return null;
	}
	
	
	private void OnEnable()
	{
		CommnadVoice.OnUp += Arriba;
		CommnadVoice.OnDown += Abajo;
	}
	
	public void OnDisable()
	{
		CommnadVoice.OnUp -= Arriba;
		CommnadVoice.OnDown -= Abajo;
	}
}
