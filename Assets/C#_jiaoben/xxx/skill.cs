using UnityEngine;

[CreateAssetMenu(fileName = "skill", menuName = "自定义/技能", order = 0)]
public class skill : ScriptableObject
{
    public int SkillId;
    public string Index;
    [TextArea]
    public string DescribeIndex;
    public SkillType Type;//技能类型
    public bool IsUnlock;//是否解锁
    [Header("UI")]
    [SerializeField] private skill[] skills;
    public Sprite Icon;//图标

}
public enum SkillType
{
    法杖,剑,盾,弓箭
}
