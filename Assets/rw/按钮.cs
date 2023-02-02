using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class 按钮 : MonoBehaviour
{
    [SerializeField]
    private Button button;
    [SerializeField]
    private Text text;
    [SerializeField]
    private GameObject index;

    private void indexUI()
    {
        index.SetActive(true);
        text.text = transform.GetChild(2).GetComponent<Text>().text;
    }
    private void Start()
    {
        index.SetActive(false);
        button.onClick.AddListener(indexUI);
    }
}
