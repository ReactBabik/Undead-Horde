using UnityEngine;

public class MoveByTouch : MonoBehaviour
{
    public float movementSpeed = 3f;

    private bool isTouching = false;
    private Vector2 touchStartPosition;
    private Vector2 touchCurrentPosition;

    void Start()
    {
        
    }

   void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
                isTouching = true;
                touchStartPosition = touch.position;
                touchCurrentPosition = touch.position;
            }
            else if (touch.phase == TouchPhase.Moved)
            {
                touchCurrentPosition = touch.position;
            }
            else if (touch.phase == TouchPhase.Ended || touch.phase == TouchPhase.Canceled)
            {
                isTouching = false;
            }
        }

        // Move the character based on touch movement
        if (isTouching)
        {
            Vector2 touchDelta = touchCurrentPosition - touchStartPosition;
            Vector3 moveDirection = new Vector3(touchDelta.x, 0f, touchDelta.y);
            moveDirection.Normalize();
            transform.Translate(moveDirection * movementSpeed * Time.deltaTime);
        }
    }
    
    // Start is called before the first frame update
   
}
