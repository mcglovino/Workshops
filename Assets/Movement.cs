using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {

    public Vector3 Direction;
    Vector3 targetPosition;

    MeshFilter MF;

    Vector3[] ModelSpaceVertices;
    Vector3[] TransformedVertices;
    float yawAngle = 0.0f;

    void Start()
    {
        MF = GetComponent<MeshFilter>();
        ModelSpaceVertices = MF.mesh.vertices;

        TransformedVertices = new Vector3[ModelSpaceVertices.Length];
    }

    void Update () {
        yawAngle += Time.deltaTime;

        Matrix4x4 rotMatrix = new Matrix4x4();
        rotMatrix.SetColumn(0, new Vector3(Mathf.Cos(yawAngle), 0, -Mathf.Sin(yawAngle)));
        rotMatrix.SetColumn(1, new Vector3(0, 1, 0));
        rotMatrix.SetColumn(2, new Vector3(Mathf.Sin(yawAngle), 0, Mathf.Cos(yawAngle)));
        rotMatrix.SetColumn(3, Vector3.zero);

        for (int i = 0; i < TransformedVertices.Length; i++)
        {
            TransformedVertices[i] = rotMatrix * ModelSpaceVertices[i];
        }

        MF.mesh.vertices = TransformedVertices;


        Plane plane = new Plane(Vector3.up, transform.position);
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        float point = 0f;
        if (plane.Raycast(ray, out point))
        {
            targetPosition = ray.GetPoint(point);
        }
        Direction = VectorMaths.Normalized(VectorMaths.Sub(targetPosition, transform.position));


        transform.position = VectorMaths.Add(transform.position, Direction / 2);
    }
}
