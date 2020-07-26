using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
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

    public static float Rotation(this Vector2 vector)
    {

        return Mathf.Atan2(vector.y, vector.x) * Mathf.Rad2Deg;

    }

    public static void Hide(this CanvasGroup group)
    {
        group.alpha = 0f;
        group.interactable = false;
        group.blocksRaycasts = false;
    }
    public static void Show(this CanvasGroup group)
    {
        group.alpha = 1f;
        group.interactable = true;
        group.blocksRaycasts = true;
    }

    public static bool IsHidden(this CanvasGroup group)
    {
        return group.alpha < 1f &&
        !group.interactable &&
        !group.blocksRaycasts;
    }
}
