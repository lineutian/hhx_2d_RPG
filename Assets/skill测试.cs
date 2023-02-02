using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class skill测试 : MonoBehaviour
{
    public skill skill;
    public Text text;
    private void Update()
    {
        text.text = skill.DescribeIndex;
    }
}
