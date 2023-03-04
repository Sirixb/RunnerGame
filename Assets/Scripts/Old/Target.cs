using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    [SerializeField] private float toleranceError=5f;
    [SerializeField] private float heightCompensation;
    private Vector3 size;
    
    
    private void Start()
    {
        size = new Vector3(toleranceError, 0.3f, toleranceError);
        transform.localScale = size;
        Stats.tolerance = toleranceError/2;
        SetPosition();
    }

    public void SetPosition()
    {
       transform.position = new Vector3(Stats.distanciaDigitada + heightCompensation, 0f, 0f);
    }

#if UNITY_EDITOR
    void Update()
    {
        Stats.distanciaDigitada = transform.position.x - heightCompensation;
        if (Input.GetKeyDown(KeyCode.T))
        {
            SetPosition();
        }
    }
#endif

}
