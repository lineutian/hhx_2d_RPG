using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class xuetiao : MonoBehaviour
{//单例模式
    public static xuetiao hphr { get; private set; }
    void Start()
    {
        hphr =this;
    }
    public Image xue;
    public Image xue_1;
    [SerializeField] private float xue_time_1;//serializefield 可以在外部通过面板改变private变量
    public float xue_chazhi;
    public TextMeshProUGUI xueliang;
    public void updatehp(int currnhp,int maxhpp)
    {
        xue.fillAmount = (float)currnhp / (float)maxhpp;
        xue_chazhi = (xue_1.fillAmount - xue.fillAmount);
        xueliang.text = currnhp + "/" + maxhpp;
    }
    private void Update()
    {
        if (xue_1.fillAmount > xue.fillAmount)//血条缓冲效果
        {
            xue_1.fillAmount -= (float)xue_chazhi/ xue_time_1;
        }
        else
        {
            xue_1.fillAmount = xue.fillAmount;
        }
    }
    public void update(int maxhpp)
    {
        xueliang.text = (int)(maxhpp*xue.fillAmount) + "/" + (int)maxhpp;
    }
}
