using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class triggerObscunringitem : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        cebiwujianbian cebiwujianbian = collision.gameObject.GetComponent<cebiwujianbian>();
        if (cebiwujianbian)
        {
            cebiwujianbian.fadeOut();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        cebiwujianbian cebiwujianbian = collision.gameObject.GetComponent<cebiwujianbian>();
        if (cebiwujianbian)
        {
            cebiwujianbian.fadeIn();
        }
    }
}
