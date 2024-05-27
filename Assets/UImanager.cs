using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UImanager : MonoBehaviour
{
    private void Awake()
    {
        float p1 = (float)Screen.width / 1280f;
        float p2 = (float)Screen.height / 720f;
        float p = p1 < p2 ? p1 : p2;
        transform.localScale = Vector3.one * p;
    }
}
