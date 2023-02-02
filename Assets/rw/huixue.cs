using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class huixue : MonoBehaviour
    {
    public Button button_startgame;
    private NewBehaviourScript ss;
    public GameObject showDamgeUI;
    
    // Start is called before the first frame update
    public void Startgame()
    {
        ss = GameObject.FindGameObjectWithTag("Player").GetComponent<NewBehaviourScript>();
        ss.changHP(ss.MYmaxHP);
        DamageNum damageNum=ShadowPool.Instance.GetFormPool(0).GetComponent<DamageNum>();
        damageNum.GetTransform(ss.transform.position);
        damageNum.ShowUIDamage(ss.MYmaxHP);
    }
    private void Start()
    {
        button_startgame.onClick.AddListener(Startgame);
    }

}
