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

    public bool IsBossFight { get => _isBossFight; set => _isBossFight = value; }

    private bool _isBossFight = false;

    void FixedUpdate()
    {
        if (IsBossFight) return;
        transform.position = Vector3.Lerp(transform.position, DesiredPosition, 5f * Time.deltaTime);
    }

    public void SetBossFightPosition(Vector3 position)
    {
        _isBossFight = true;
        transform.position = position;
    }
}
