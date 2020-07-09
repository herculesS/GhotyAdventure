using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public Transform followTarget;
    public float minX, maxX, minY, maxY;
    private float XComp => Mathf.Clamp(followTarget.position.x, minX, maxX);
    private float YComp => Mathf.Clamp(followTarget.position.y, minY, maxY);
    private Vector3 DesiredPosition => new Vector3(XComp, YComp, -10f);

    void FixedUpdate()
    {
        transform.position = Vector3.Lerp(transform.position, DesiredPosition, 5f * Time.deltaTime);
    }
}
