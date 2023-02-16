using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static LanguageController;
public class equipUI : Singleton<equipUI>
{
    public Transform 鞋子;
    public Transform 衣服;
    public Transform 武器;
    public Transform 裤子;
    public Transform 帽子;
    public Transform 内裤;
    public GameObject slotpef;

    public void equipUIUPdate()
    {
        foreach (var equip in GlobalController.Instance.Data.Equiptory)
        {
            RefreshhUI(equipController.Instance.GetEquipFormID(equip.Value));
        }
    }

    public void RefreshhUI(equip equip) //ui更新
    {
        Color ItemColor=new Color();
        Transform 位置=new RectTransform();
        switch (equip.Quality)
        {
            case ItemQuality.普通:
                ItemColor = new Color(1f, 1f, 1f, 1f);
                break;
            case ItemQuality.稀有:
                ItemColor = new Color(0, 1f, 0, 1f);
                break;
            case ItemQuality.贵重:
                ItemColor = new Color(0, 0, 1f, 1f);
                break;
            case ItemQuality.史诗:
                ItemColor = new Color(0.5f, 0, 1f, 1f);
                break;
            case ItemQuality.传世:
                ItemColor = new Color(1f, 0.5f, 0, 1f);
                break;
            case ItemQuality.永恒:
                ItemColor = new Color(1f, 0, 0, 1f);
                break;
        }

        switch (equip.EquipType)
        {
            case EquipType.内裤:
                位置 = 内裤;
                break;
            case EquipType.鞋子:
                位置 = 鞋子;
                break;
            case EquipType.衣服:
                位置 = 衣服;
                break;
            case EquipType.裤子:
                位置 = 裤子;
                break;
            case EquipType.帽子:
                位置 = 帽子;
                break;
            case EquipType.武器:
                位置 = 武器;
                break;
        }
        slotUi(ItemColor,equip,位置);
    }
    private void slotUi(Color ItemColor, Item i,Transform 位置)
    {
        if (位置.GetComponentsInChildren<Transform>(true).Length > 1) Destroy(位置.GetChild(0).gameObject);
        GameObject slot = Instantiate(slotpef,位置);
        slot.name = i.ItemID.ToString();
        slot.transform.Find("mingzi").GetComponent<Text>().text = GetLocalT(i.Index);
        slot.transform.Find("shulaing").GetComponent<Text>().text =" ";
        slot.transform.Find("Icon").GetComponent<Image>().sprite = i.Icon;
        slot.transform.Find("bj").GetComponent<Image>().color = ItemColor;
    }//Ui更新的整合
}
