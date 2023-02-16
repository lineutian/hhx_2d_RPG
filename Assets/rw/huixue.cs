using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class huixue : MonoBehaviour
    {
    public Button button_startgame;
    private Character ss;
    public GameObject showDamgeUI;
    
    // Start is called before the first frame update
    public void Startgame()
    {
        ss = GameObject.Find("待机1").GetComponent<Character>();
        HurtManager.Instance.hurt(ss.gameObject,ss.Data.MaxHealth,HurtType.Cure);
    }
    private void Start()
    {
        button_startgame.onClick.AddListener(Startgame);
    }

}
