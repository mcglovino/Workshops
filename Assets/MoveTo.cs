using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTo : MonoBehaviour {

    GameObject other;
    float theDot;

    public void Start()
    {
        other = GameObject.Find("Evader");
    }
	void Update () {
        Vector3 Direction = VectorMaths.Normalized(VectorMaths.Sub(other.transform.position, transform.position));
        theDot = VectorMaths.Dot(Direction, other.GetComponent<Movement>().Direction);

        if (theDot > 0.2f)
        {
            transform.position = VectorMaths.Add(transform.position, Direction/3 );
        }
    }
}
