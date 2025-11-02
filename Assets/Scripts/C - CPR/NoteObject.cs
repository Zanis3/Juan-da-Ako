using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteObject : MonoBehaviour
{
    public bool canBePressed;
    private bool wasHit = false;
    public GameObject normEffect, goodEffect, perfectEffect, missEffect;
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (canBePressed && !wasHit)
            {
                wasHit = true;
                gameObject.SetActive(false);
                //CprManager.instance.NoteHit();
                if (Mathf.Abs(transform.position.x) > 1f)
                {
                    CprManager.instance.NormalHit();
                    Instantiate(normEffect, transform.position, normEffect.transform.rotation);
                }
                else if (Mathf.Abs(transform.position.x) > 0.25f)
                {
                    CprManager.instance.GoodHit();
                    Instantiate(goodEffect, transform.position, goodEffect.transform.rotation);
                }
                else
                {
                    CprManager.instance.PerfectHit();
                    Instantiate(perfectEffect, transform.position, perfectEffect.transform.rotation);
                }
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
            if (!wasHit)
            {
                CprManager.instance.NoteMiss();
                Instantiate(missEffect, transform.position, missEffect.transform.rotation);
            }
        }
    }
}
