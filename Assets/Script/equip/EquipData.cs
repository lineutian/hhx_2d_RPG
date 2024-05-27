using UnityEngine;

public class EquipData
{
    public int Atk;
    public int Hp;
    public int Ftk;
    public int LV;
    public int ID;

    public void UpGrade(int i)
    {
        for (int j=0;j<i;j++)
        {
            if (LV>=100)
            {
                break;
            }
            Atk =(int)(Atk*(1 + Random.Range(0, 0.2f)));
            Hp =(int)(Hp*(1 + Random.Range(0, 0.2f)));
            Ftk =(int)(Ftk*(1 + Random.Range(0, 0.2f)));
            LV += 1;
        }
        Player.Instance.playerData.UPdate();
    }
}

public enum EquipType
{
    鞋子,衣服,武器,裤子,帽子,内裤
}
