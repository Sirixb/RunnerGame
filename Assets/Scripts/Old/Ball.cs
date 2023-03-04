using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Ball : MonoBehaviour
{
    [SerializeField] private float gravity= 9.8f;
    [SerializeField] private Rigidbody rigidbodyBall;

    public delegate void DestroyBall();
    public static event DestroyBall OnDestroyBall;
    private void Start()
    {
        Stats.gravity = gravity;
    }
    private void Update()
    {
        Vector3 acelerationGravity = Vector3.down * gravity * Time.deltaTime;
        rigidbodyBall.velocity += acelerationGravity;
    }

    private void OnCollisionEnter(Collision collision)
    {
            if (OnDestroyBall != null)
                OnDestroyBall();

        Destroy(gameObject, 1f);
    }
}
