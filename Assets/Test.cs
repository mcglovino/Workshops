using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour {

	void Start () {
        //VectorMaths.RotateVertexAroundAxis(60, new Vector3(1,0,0), new Vector3(250,12,18));

        //Quat test = new Quat(-0.07215064f, 6.227821f, -16.5f, -25.26345f) * new Quat(-0.5f, -0, 0.7071067f, -0.5f);
        VectorMaths.CrossProduct(new Vector3(6.227821f, -16.5f, -25.26345f), new Vector3(0, 0.7071067f, -0.5f));

        //VectorMaths.Dot(new Vector2(263, 32), new Vector2(84,13));

        /*Quat test = new Quat(70, new Vector3(1, 0, 0));
        Debug.Log(test.w);
        Debug.Log(test.x);
        Debug.Log(test.y);
        Debug.Log(test.z);*/


        //VectorMaths.RotateByQuat(new Vector3(23, 10, 18), new Quat(-0.5f, 0, -0.7071067f, 0.5f));
    }
}
