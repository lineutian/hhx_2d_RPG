using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DamageNum : MonoBehaviour
{
    public Text damageText;
    public float lifeTimer;
    public float upSpeed;
    public float bigSpeed;
    void OnEnable()
    {
        //transform.GetComponent<Animator>().enabled = true;
        StartCoroutine(Timer());
        transform.localScale = new Vector3(0.01f, 0.01f, 0.01f);
        damageText.color = Color.red;//初始化
    }
    void Update()
    {
        transform.position += new Vector3(0, upSpeed * Time.deltaTime, 0);
        transform.localScale *= bigSpeed;
    }
    IEnumerator Timer() {
            yield return new WaitForSeconds(lifeTimer);
            ShadowPool.Instance.ReturnPool(gameObject,0);
    }

    public void ShowUIDamage(float _amout,HurtType hurtType)
    {
        switch (hurtType)
            {
                case HurtType.AD:
                    damageText.color = Color.red;
                    break;
                case HurtType.AP:
                    damageText.color = new Color(138/225f,43/225f,226/225f);
                    break;
                case HurtType.Cure:
                    if (_amout>=0)
                    {
                        damageText.color = Color.green;
                    }
                    else
                    {
                        damageText.color = new Color(118/255f, 128/255f, 105 / 255f);
                    }
                    break;
                case HurtType.Shield:
                    damageText.color = new Color(192/255f, 192/255f, 192/255f);
                    break;
                case HurtType.TrueDamage:
                    damageText.color = new Color(202/255f, 235/255f, 206/255f);
                    break;
            }
        damageText.text = Mathf.Abs(_amout).ToString();
    }
    public void ShowUIDamage(float _amout)
    {
        if (_amout > 0)
        {
            //transform.GetComponent<Animator>().enabled = false;
            damageText.color =Color.green;
        }
        damageText.text = Mathf.Abs(_amout).ToString();
    }

    public void GetTransform(Vector3 orth)
    {
        transform.position = orth;
    }
}
