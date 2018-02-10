using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quat {

    public float w, x, y, z;
    public Vector3 v;

    public Quat(float Angle, Vector3 Axis)
    {
        float halfAngle = Angle / 2;
        w = Mathf.Cos(halfAngle);
        x = Axis.x * Mathf.Sin(halfAngle);
        y = Axis.y * Mathf.Sin(halfAngle);
        z = Axis.z * Mathf.Sin(halfAngle);
        v = new Vector3(x,y,z);
    }

    public static Quat operator*(Quat lhs, Quat rhs)
    {
        Quat rv = new Quat(0,new Vector3(0,0,0));
        rv.w = (lhs.w * rhs.w) - (VectorMaths.Dot(lhs.v, rhs.v));
        rv.v = ((lhs.w * rhs.v) + (rhs.w * lhs.v) + (VectorMaths.CrossProduct(rhs.v, lhs.v)));
        rv.x = rv.v.x;
        rv.y = rv.v.y;
        rv.z = rv.v.z;
        return rv;
    }
}
