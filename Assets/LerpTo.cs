using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LerpTo : MonoBehaviour {

    public Vector3 target;

    void Start()
    {
        Vector3 target = transform.position;
    }
	
	void Update () { 
        transform.position = VectorMaths.Lerp(transform.position, target);
    }
}
