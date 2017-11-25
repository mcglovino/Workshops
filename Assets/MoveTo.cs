using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTo : MonoBehaviour {

    GameObject other;
    float theDot;
    Vector3 Direction;

    Vector3 targetPosition;

    public void Start()
    {
        other = GameObject.FindGameObjectWithTag("Evader");
    }
	void Update () {
        Direction = VectorMaths.Normalized(VectorMaths.Sub(other.transform.position, transform.position));

        //theDot = VectorMaths.Dot(Direction, other.GetComponent<Movement>().Direction);

        //if (theDot > 0.2f)
        //{
        transform.position = VectorMaths.Add(transform.position, Direction/3 );
        //}
    }
}
