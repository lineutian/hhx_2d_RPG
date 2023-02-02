using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cebiwujianbian : MonoBehaviour
{
    private SpriteRenderer SpriteRenderer_cebiwu;
    private void Awake()
    {
        SpriteRenderer_cebiwu = gameObject.GetComponent<SpriteRenderer>();
    }
    public void fadeOut()
    {
        StartCoroutine(fadeOutRouting());
    }
    public void fadeIn()
    {
        StartCoroutine(fadeInRouting());
    }
    private IEnumerator fadeOutRouting() 
    {
        float currentAlpha = SpriteRenderer_cebiwu.color.a;
        float distance = currentAlpha - setting.tarAlpha;

        while (currentAlpha - setting.tarAlpha > 0.01f)
        {
            currentAlpha = currentAlpha - distance / setting.fadeOutSeconds * Time.deltaTime;
            SpriteRenderer_cebiwu.color = new Color(1f, 1f, 1f, currentAlpha);
            yield return null;
        }
        SpriteRenderer_cebiwu.color = new Color(1f, 1f, 1f, setting.tarAlpha);
    }
    private IEnumerator fadeInRouting()
    {
        float currentAlpha = SpriteRenderer_cebiwu.color.a;
        float distance =1- currentAlpha;
        while (1 - currentAlpha > 0.01f)
        {
            currentAlpha = currentAlpha + distance / setting.fadeInSeconds * Time.deltaTime;
            SpriteRenderer_cebiwu.color = new Color(1f, 1f, 1f, currentAlpha);
            yield return null;  
        }
        SpriteRenderer_cebiwu.color = new Color(1f, 1f, 1f, 1f);
    }
}
