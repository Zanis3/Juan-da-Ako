using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonController : MonoBehaviour
{
    private SpriteRenderer theSR;
    public Sprite defaultImg;
    public Sprite pressedImg;
    public KeyCode keyToPress;
    private Camera cam;
    void Start()
    {
        theSR = GetComponent<SpriteRenderer>();
        cam = Camera.main;
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
            Collider2D hit = Physics2D.OverlapPoint(mousePos);
            theSR.sprite = pressedImg;
        }
        if (Input.GetMouseButtonUp(0))
        {
            theSR.sprite = defaultImg;
        }
    }
}
