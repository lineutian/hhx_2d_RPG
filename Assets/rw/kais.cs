using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class kais : MonoBehaviour
{
    public Button button_startgame;
    public void Startgame()
    {
        SceneManager.LoadScene("SampleScene");
    }
    private void Start()
    {
        button_startgame.onClick.AddListener(Startgame);
    }
}
