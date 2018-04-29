using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuatRotate : MonoBehaviour {

    Vector3[] ModelSpaceVertices;
    MeshFilter MF;

    public Quat rotateQuat = new Quat(180, new Vector3(1, 0, 0));


    void Start()
    {
        MF = GetComponent<MeshFilter>();

        ModelSpaceVertices = MF.mesh.vertices;
    }

    // Update is called once per frame
    void Update () {
        rotateQuat.w += Time.deltaTime;

        Vector3[] TransformedVertices = new Vector3[ModelSpaceVertices.Length];

        for (int i = 0; i < TransformedVertices.Length; i++)
        {
            //TransformedVertices[i] = M * ModelSpaceVertices[i];
            TransformedVertices[i] = rotateQuat.QuatToMatrix() * ModelSpaceVertices[i];
            //TransformedVertices[i] = translateMatrix * TransformedVertices[i];
        }

        MF.mesh.vertices = TransformedVertices;

        MF.mesh.RecalculateNormals();
        MF.mesh.RecalculateBounds();

        //transform.position = VectorMaths.RotateByQuat(new Vector3(1,2,3), rotateQuat);

        /*Vector3 A = new Vector3(1, 2, 3);

        Quat C = new Quat(A);
        Quat newC = rotateQuat * C * rotateQuat.Inverse();
        Vector3 D = newC.GetAxis();

        transform.position = D;*/
    }
}
