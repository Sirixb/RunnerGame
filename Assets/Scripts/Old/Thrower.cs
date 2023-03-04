using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Thrower : MonoBehaviour
{
    [RangeAttribute(0f,35f)]
    [SerializeField] private float velocidadInicial;
    [RangeAttribute(0f, 90f)]
    [SerializeField] private float anguloVelocidadInicial;

    [SerializeField] private GameObject ball;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip audioClip;
    private Quaternion quaternion;


#if UNITY_EDITOR
    void Update()
    {
        Stats.velocidadInicial = velocidadInicial;
        Stats.anguloinicial = anguloVelocidadInicial;
        SetAngle();

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Shoot();
        }
    }
#endif

    public void SetAngle()
    {
        quaternion = Quaternion.AngleAxis(anguloVelocidadInicial, Vector3.forward);
        transform.rotation = quaternion;
    }
    
    public void Shoot()
    {
        GameObject ballInstance= Instantiate(ball, transform.position, Quaternion.identity);
        Rigidbody rigidbody= ballInstance.GetComponent<Rigidbody>();
        var rotatedVector = quaternion * Vector3.right;
        rigidbody.velocity = rotatedVector * velocidadInicial;
        if (!audioSource.isPlaying)
            audioSource.PlayOneShot(audioClip,0.5f);
    }

    public void SetInitialVelocity()
    {
        velocidadInicial = Stats.velocidadInicial;
    }
    public void SetInitialAngle()
    {
        anguloVelocidadInicial = Stats.anguloinicial;
    }
}
