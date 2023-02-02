using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fuchuang : MonoBehaviour
{
    public GameObject an_e;
    private void Awake()
    {
        an_e.SetActive(false);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        an_e.SetActive(true);
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        an_e.SetActive(false);
    }
}
