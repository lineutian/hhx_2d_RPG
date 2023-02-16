using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillDataController : Singleton<SkillDataController>
{
    private Dictionary<int, SkillData> _skillDatas = new Dictionary<int, SkillData>();

    public SkillData GetSkillData(int _id)
    {
        return _skillDatas[_id];
    }

    public void LoadSkillData(int _id,SkillData skillData)
    {
        
        if (!_skillDatas.ContainsKey(_id))
        {
            _skillDatas.Add(_id,skillData);
        }
        else
        {
            return;
        }
    }
}
