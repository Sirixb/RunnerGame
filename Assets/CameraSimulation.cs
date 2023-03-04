using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSimulation : MonoBehaviour
{
    private void Start()
    {
        ZooMin();
    }
    public void ZoomMax()
    {
        transform.position = new Vector3(5f, 2.5f, -10);
    }
    public void ZooMin()
    {
        transform.position = new Vector3(79f, 15.8f, -100);
    }
}
