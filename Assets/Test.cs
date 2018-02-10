using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour {

	void Start () {
        //VectorMaths.RotateVertexAroundAxis(60, new Vector3(1,0,0), new Vector3(250,12,18));
        Quat test = new Quat(-0.338738f, new Vector3(0.8816453f,0.2938818f,0.1469409f)) * new Quat(0, new Vector3(1,0,0));
        Debug.Log("Q*");
        Debug.Log(test.w);
        Debug.Log(test.x);
        Debug.Log(test.y);
        Debug.Log(test.z);
    }
}
