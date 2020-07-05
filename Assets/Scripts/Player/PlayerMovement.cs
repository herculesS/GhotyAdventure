using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


public class PlayerMovement : MonoBehaviour
{

    [SerializeField]
    float moveSpeed = 10f;
    private Rigidbody2D rb;
    Touch touch;
    Vector3 touchPosition, whereToMove;
    bool isMoving = false;
    float previousDistanceToTouchPos, currentDistanceToTouchPos;
    PlayerFSM playerFSM;
    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        playerFSM = GetComponent<PlayerFSM>();
    }

    // Update is called once per frame
    void Update()
    {
        if(IsPointerOverGameObject()) {
            return;
        }
        if (isMoving)
            currentDistanceToTouchPos = (touchPosition - transform.position).magnitude;

        if (Input.touchCount > 0)
        {

            touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
                previousDistanceToTouchPos = 0;
                currentDistanceToTouchPos = 0;
                isMoving = true;
                touchPosition = Camera.main.ScreenToWorldPoint(touch.position);
                touchPosition.z = 0;
                whereToMove = (touchPosition - transform.position).normalized;
                rb.velocity = new Vector2(whereToMove.x * moveSpeed, whereToMove.y * moveSpeed);
            }
        }
        else if (Input.GetMouseButtonDown(0))
        {
            previousDistanceToTouchPos = 0;
            currentDistanceToTouchPos = 0;
            isMoving = true;
            touchPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            touchPosition.z = 0;
            whereToMove = (touchPosition - transform.position).normalized;
            rb.velocity = new Vector2(whereToMove.x * moveSpeed, whereToMove.y * moveSpeed);
        }

        if (currentDistanceToTouchPos > previousDistanceToTouchPos)
        {
            isMoving = false;
            rb.velocity = Vector2.zero;
        }

        if (isMoving)
            previousDistanceToTouchPos = (touchPosition - transform.position).magnitude;

        SetMovementFlags();

    }
    public static bool IsPointerOverGameObject()
    {
        //check mouse
        if (EventSystem.current.IsPointerOverGameObject())
            return true;

        //check touch
        if (Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Began)
        {
            if (EventSystem.current.IsPointerOverGameObject(Input.touches[0].fingerId))
                return true;
        }

        return false;
    }
    private void SetMovementFlags()
    {
        if (rb.velocity.x > 0f)
        {
            playerFSM.MovRight = true;
            playerFSM.MovLeft = false;
        }
        else if (rb.velocity.x < 0f)
        {
            playerFSM.MovRight = false;
            playerFSM.MovLeft = true;
        }

        if (rb.velocity.y > 0f)
        {
            playerFSM.MovUp = true;
            playerFSM.MovDown = false;
        }
        else if (rb.velocity.y < 0f)
        {
            playerFSM.MovUp = false;
            playerFSM.MovDown = true;

        }

        if (rb.velocity == Vector2.zero)
        {
            playerFSM.MovRight = false;
            playerFSM.MovLeft = false;
            playerFSM.MovUp = false;
            playerFSM.MovDown = false;
        }
    }
}
