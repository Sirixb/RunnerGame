using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;


public class PlayerCommandVoice : MonoBehaviour
{
	[SerializeField] private CapsuleCollider capsuleCollider;
	[SerializeField] private Rigidbody rigidbodyPlayer;
	[SerializeField] private Animator animator;
	
	[SerializeField] private float speed= 5;
	[SerializeField] private float hight= 1;
	[SerializeField] private float speedHight = 2;
	private float tempo;
	
	static readonly string animatorSpeed = "Speed";
	static readonly string animatorSlide = "Slide";
	static readonly string animatorJump = "Jump";
	
	private void Start()
	{
		animator.SetFloat(animatorSpeed,speed);
	}

	void Update() => Movement();

	private void Movement() => transform.Translate(Vector3.forward * Time.deltaTime * speed, Space.World);

	public void OnAccion(InputValue value)
	{
		Vector3 newVector= new Vector3(0f,.3f,0f);
		
		
		Debug.Log("Accion presionada");
	}
	
	public void Arriba()
	{
		Jump();
		StartCoroutine(JumpPhysics());
		Debug.Log("arribas llamado");
	}
	
	public void Jump() => animator.SetTrigger(animatorJump);
	IEnumerator JumpPhysics()
	{
		do
		{
			tempo+=.2f;
			transform.transform.position = (new Vector3(transform.position.x, Mathf.PingPong((tempo * hight) * speedHight, 5), transform.position.z));
			yield return null;
			
		}while(transform.position.y >= .1);
		
		tempo= 0f;
		yield return null;
	}
	public void Abajo()
	{
		Debug.Log("abajo llamado");
		Slide();
		transform.position = new Vector3(transform.position.x,0,transform.position.z);
	}

	public void Slide() => animator.SetTrigger(animatorSlide);
	
	public void ContractCollider()
	{
		
		capsuleCollider.center = new Vector3(0f,.3f,0f);
		capsuleCollider.height=.6f;
		Debug.Log("Collider contraido llamado");
		
	}
	public void ExpandCollider()
	{
		capsuleCollider.center = new Vector3(0f,.9f,0f);
		capsuleCollider.height= 1.8f;
		Debug.Log("Collider expandido llamado");
		
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
