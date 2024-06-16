using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipSuitManager : Singleton<EquipSuitManager>
{
    private Dictionary<int, EquipMentSet> _equipMentSets = new Dictionary<int, EquipMentSet>();

    private List<GameObject> SuitDic = new List<GameObject>();
    // Start is called before the first frame update
    void Start()
    {
        Init();
    }

    void Init()
    {
        foreach (var suit in Resources.LoadAll<EquipMentSet>("EquipSuit"))
        {
            EquipMentSet Suit = (EquipMentSet)suit;
            _equipMentSets.Add(Suit.EquipSuitId,Suit);
        }
    }

    public void UseSuit()
    {
        foreach (var suitGame in SuitDic)
        {
            Destroy(suitGame);
        }
        SuitDic.Clear();
        foreach (var suitDic in Player.Instance.playerData.EquipMentSetDic)
        {
            if (suitDic.Value>=2)
            {
                SuitDic.Add(Instantiate(suitDic.Key.EquipSuitModel));
            }
        }
    }
}
