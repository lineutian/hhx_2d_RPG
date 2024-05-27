using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class huixue : MonoBehaviour
    {
    public Button button_startgame;
    public GameObject showDamgeUI;
    
    // Start is called before the first frame update
    public void Startgame()
    {   
        HurtManager.Instance.hurt(Player.Instance.gameObject,Player.Instance.playerData.MaxHealth,HurtType.Cure);
    }
    private void Start()
    {
        button_startgame.onClick.AddListener(Startgame);
    }

}
