using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoundToScreen : MonoBehaviour
{
    private Vector2 screenBounds;
    void Start()
    {
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
    }
    void LateUpdate()
    {
        Vector3 viewPos = transform.position;
        viewPos.y = Mathf.Clamp(viewPos.y, -screenBounds.y, screenBounds.y);
        transform.position = viewPos;
    }
}
