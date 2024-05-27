using UnityEngine;

[CreateAssetMenu(fileName ="Item",menuName ="自定义/物品",order=0)]
public class ItemUI : ScriptableObject
{
    public string Index;
    public int ItemID;
    public int ItemTypeID;
    [TextArea]
    public string DescribeIndex;
    public Sprite Icon;//图标
    public ItemType Type;
    public ItemQuality Quality;//品质
    public bool IsUse;//是否可以使用
    public bool IsStack;//是否可堆叠
}
public enum ItemType
{
    消耗品,装备,材料,其他
}
public enum ItemQuality
{
    普通,稀有,贵重,史诗,传世,永恒
}