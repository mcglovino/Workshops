﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quat {

    public float w, x, y, z;
    public Vector3 v;

    public Quat(Vector3 T)
    {
        x = T.x; y = T.y; z = T.z;
        w = 0;
    }

    public Quat(float Angle, Vector3 Axis)
    {
        float halfAngle = Angle / 2;

        //if in degrees
        halfAngle = Maths.DegToRad(halfAngle);

        w = Mathf.Cos(halfAngle);
        x = Axis.x * Mathf.Sin(halfAngle);
        y = Axis.y * Mathf.Sin(halfAngle);
        z = Axis.z * Mathf.Sin(halfAngle);
        v = new Vector3(x,y,z);
    }

    public static Quat operator *(Quat lhs, Quat rhs)
    {
        Quat rv = new Quat(0, new Vector3(0, 0, 0));
        rv.w = rhs.w * lhs.w - VectorMaths.Dot(rhs.GetAxis(), lhs.GetAxis());
        rv.SetAxis((rhs.w * lhs.GetAxis()) + (lhs.w * rhs.GetAxis()) + (VectorMaths.CrossProduct(lhs.GetAxis(), rhs.GetAxis())));
        return rv;
    }

    public Quat Inverse()
    {
        Quat rv = new Quat(-GetAxis());
        rv.w = w;
        return rv;
    }

    public Vector3 GetAxis()
    {
        return new Vector3(x, y, z);
    }

    public void SetAxis(Vector3 A)
    {
        x = A.x;
        y = A.y;
        z = A.z;
    }

    public Matrix4by4 QuatToMatrix()
    {
        float wx, wy, wz, xx, yy, yz, xy, xz, zz, x2, y2, z2;
        Matrix4by4 matrix = new Matrix4by4(new Vector3(0, 0, 0), new Vector3(0, 0, 0), new Vector3(0, 0, 0), new Vector3(0, 0, 0));

        // calculate coefficients
        x2 = x + x;
        y2 = y + y;
        z2 = z + z;
        xx = x * x2; xy = x * y2; xz = x * z2;
        yy = y * y2; yz = y * z2; zz = z * z2;
        wx = w * x2; wy = w * y2; wz = w * z2;

        matrix.values[0, 0] = 1.0f - (yy + zz);
        matrix.values[1, 0] = xy - wz;
        matrix.values[2, 0] = xz + wy;
        matrix.values[3, 0] = 0.0f;

        matrix.values[0, 1] = xy + wz;
        matrix.values[1, 1] = 1.0f - (xx + zz);
        matrix.values[2, 1] = yz - wx;
        matrix.values[3, 1] = 0.0f;

        matrix.values[0, 2] = xz - wy;
        matrix.values[1, 2] = yz + wx;
        matrix.values[2, 2] = 1.0f - (xx + yy);
        matrix.values[3, 2] = 0.0f;

        matrix.values[0, 3] = 0;
        matrix.values[1, 3] = 0;
        matrix.values[2, 3] = 0;
        matrix.values[3, 3] = 1;

        return matrix;
    }
}
