using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraLookAt : MonoBehaviour
{

    public GameObject LookAt;


    void Update()
    {
        transform.LookAt(LookAt.transform.position);
    }
}
