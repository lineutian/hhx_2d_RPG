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
        transform.GetComponent<Animator>().enabled = true;
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

    public void ShowUIDamage(float _amout)
    {
        if (_amout > 0)
        {
            transform.GetComponent<Animator>().enabled = false;
            damageText.color =Color.green;
        }
        damageText.text = Mathf.Abs(_amout).ToString();
    }

    public void GetTransform(Vector3 orth)
    {
        transform.position = orth;
    }
}
