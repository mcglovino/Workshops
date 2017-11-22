using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {

    float speed = 0.4f;
    public Vector3 Direction;

    void Update () {

        if (Input.GetKey(KeyCode.RightArrow))
        {
            Direction = new Vector3(speed, 0, 0);
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            Direction = new Vector3(-speed, 0);
        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            Direction = new Vector3(0f, 0, speed);
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            Direction = new Vector3(0f, 0, -speed);
        }

        transform.position = VectorMaths.Add(transform.position, Direction);
    }
}
