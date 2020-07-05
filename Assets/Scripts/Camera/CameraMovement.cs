using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public Transform followTarget;
    public float minX, maxX;

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 desiredPos = new Vector3(Mathf.Clamp(followTarget.position.x, minX, maxX), transform.position.y, -10);

        transform.position = Vector3.Lerp(transform.position, desiredPos, 10f * Time.deltaTime);
    }
}
