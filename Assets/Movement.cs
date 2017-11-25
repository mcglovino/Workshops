using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {

    public Vector3 Direction;
    Vector3 targetPosition;

    void Update () {


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
