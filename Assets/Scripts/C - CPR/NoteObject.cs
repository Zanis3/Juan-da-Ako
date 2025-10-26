using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteObject : MonoBehaviour
{
    public bool canBePressed;
    void Start()
    {
        
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (canBePressed)
            {
                gameObject.SetActive(false);
            }
        }
    }
    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag == "Activater")
        {
            canBePressed = true;
        }
    }
    void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.tag == "Activater")
        {
            canBePressed = false;
        }
    }
}
