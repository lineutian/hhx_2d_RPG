using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class 属性测试 : MonoBehaviour
{
    public int i;
    public int i1 { get; private set; }
    public int i2 { get =>i3; }//只读，指向i3
    public int i3 { get; set; }

    private void Update()
    {

        if (Input.GetKeyDown(KeyCode.Tab))
        {
            i3 = 100;
            i = 100;
            i1 = 100;
            Debug.Log(i2 + i + i1 + i3);
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            i3 = 200;
            i = 200;
            i1 = 200;
            Debug.Log(i2 + i + i1 + i3);
        }
    }
}
