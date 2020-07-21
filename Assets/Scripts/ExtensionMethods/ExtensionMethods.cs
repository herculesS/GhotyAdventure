using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public static class ExtensionMethods
{
    public static Vector2 DirectionTowards(this Vector2 a, Vector2 b)
    {
        return (b - a).normalized;
    }

    public static Vector2 DirectionTowards(this Vector3 a, Vector2 b)
    {
        return (b - (Vector2)a).normalized;
    }

    public static float DistanceTo(this Vector2 a, Vector2 b)
    {
        return (b - a).magnitude;
    }
    public static float DistanceTo(this Vector3 a, Vector2 b)
    {
        return (b - (Vector2)a).magnitude;
    }




    public static Vector2 Rotate(this Vector2 v, float degrees)
    {
        float sin = Mathf.Sin(degrees * Mathf.Deg2Rad);
        float cos = Mathf.Cos(degrees * Mathf.Deg2Rad);

        float tx = v.x;
        float ty = v.y;
        v.x = (cos * tx) - (sin * ty);
        v.y = (sin * tx) + (cos * ty);
        return v;
    }

}
