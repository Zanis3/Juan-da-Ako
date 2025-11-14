using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeLineDashPlayer : MonoBehaviour
{
    public float lerpSpeed = 5f;
    private Rigidbody2D rb;
    private int currentLane = 1;
    private float[] laneYs = {-3f, -1.5f, 0f};
    private float targetY;
    private Vector2 startPos;
    private bool isSwiping = false;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        targetY = laneYs[currentLane];
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            startPos = Input.mousePosition;
            isSwiping = true;
        }
        if (Input.GetMouseButtonUp(0) && isSwiping)
        {
            Vector2 endPos = Input.mousePosition;
            float swipeDistance = endPos.y - startPos.y;
            if (Mathf.Abs(swipeDistance) > 50f)
            {
                if (swipeDistance > 0 && currentLane < 2) 
                {
                    currentLane++;
                }
                else if (swipeDistance < 0 && currentLane > 0)
                {
                    currentLane--;
                }
                targetY = laneYs[currentLane];
            }
            isSwiping = false;
        }
    }
    void FixedUpdate()
    {
        Vector2 currentPos = rb.position;
        float newY = Mathf.Lerp(currentPos.y, targetY, lerpSpeed * Time.fixedDeltaTime);
        rb.MovePosition(new Vector2(currentPos.x, newY));
    }
}
