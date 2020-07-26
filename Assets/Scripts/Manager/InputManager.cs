
using UnityEngine;
using UnityEngine.EventSystems;

public class InputManager : MonoBehaviour
{
    private static Vector3 getTouchPosition()
    {
        if (!TouchHappened()) return Vector3.zero;
        Vector3 touchPosition = Vector3.zero;

        Touch touch = Input.GetTouch(0);
        touchPosition = Camera.main.ScreenToWorldPoint(touch.position);
        touchPosition.z = 0;

        return touchPosition;
    }

    private static Vector3 getLeftMouseClickPosition()
    {
        if (!LeftMouseButtonPressed()) return Vector3.zero;
        Vector3 touchPosition = Vector3.zero;
        touchPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        touchPosition.z = 0;
        return touchPosition;
    }

    private static bool LeftMouseButtonPressed()
    {
        if (!Input.GetMouseButtonDown(0))
        {
            return false;
        }
        return true;
    }

    private static bool TouchHappened()
    {
        if (Input.touchCount == 0) return false;
        Touch touch = Input.GetTouch(0);
        if (touch.phase != TouchPhase.Began) return false;
        return true;
    }
    public static bool PointerInputHappened()
    {
        if (IsPointerOverGameObject() || (!TouchHappened() && !LeftMouseButtonPressed()))
        {
            return false;
        }
        return true;
    }

    public static Vector3 GetPointerPosition()
    {
        if (TouchHappened()) return getTouchPosition();
        if (LeftMouseButtonPressed()) return getLeftMouseClickPosition();
        return Vector3.zero;
    }
    public static bool IsPointerOverGameObject()
    {
        if (EventSystem.current.IsPointerOverGameObject())
            return true;

        if (Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Began)
        {
            if (EventSystem.current.IsPointerOverGameObject(Input.touches[0].fingerId))
                return true;
        }

        return false;
    }

    public static bool IsFireKeyPressed()
    {
        return Input.GetKeyDown("space");
    }

    public static bool IsEscapeKeyPressed()
    {
        return Input.GetKeyDown(KeyCode.Escape);
    }


}



