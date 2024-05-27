using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Serialization;
using static myExpected;

/// <summary>
/// ?????????????????????????
/// </summary>
public class NewBehaviourScript : MonoBehaviour
{
    private Animator Animator;
    public bool isStop=true;
    public GameObject UI_2;
    [FormerlySerializedAs("Equip")] public WeaponAtk equipObject=null;
    public Animator 动画;
    public float 无敌;
    public float 无敌存储;
    public bool 是否无敌;
    const string PLAYER_DATA_KEY = "PlayerData";

    //public Animator animator;
    // Start is called before the first frame update
    private void Awake()
    {
        
    }
    void Start()
    {
        Animator = transform.GetComponent<Animator>();
        Load();
    }

    // Update is called once per frame
    void Update()
    {
        无敌时间();
        atk();
        IsOpen();
    }

    public void IsOpen()
    {
        //游戏需要被暂停，按下ESC，游戏暂停，显示我的设置UI界面，然后将标志位设置成false，等待下次点击ESC启动游戏
        if (isStop == true)
        {
            if (Input.GetKeyDown(KeyCode.Z))
            {
                Time.timeScale = 0;
                UI_2.SetActive(true);
                isStop = false;
            }
        }
        //游戏不需要被暂停，按下ESC，游戏启动，隐藏我的设置UI界面，然后将标志位设置成true，等待下次点击ESC暂停游戏
        else {
            if (Input.GetKeyDown(KeyCode.Z))
            {
                Time.timeScale = 1;
                UI_2.SetActive(false);
                isStop = true;
            }
        }
        
    }
    
    #region 攻击

    void atk()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Atk();
        }

        if (Input.GetKeyDown(KeyCode.N))
        {
            SkillDataController.Instance.GetSkillData(1).SkillEffect();
        }
    }

    void Atk()
    {
        if (equipObject==null)
        {
            return;
        }
        equipObject.ATK();
    }

    public void ATKPefUPDATE(GameObject equip)
    {
        if (transform.GetChild(0).GetComponentsInChildren<Transform>(true).Length > 1)
        {
            Destroy(transform.GetChild(0).GetChild(0).gameObject);
        }
        equipObject =Instantiate(equip, transform.GetChild(0)).GetComponent<WeaponAtk>();
    }
    #endregion

    #region 无敌

    private void 无敌时间()
    {
        if (是否无敌&&无敌存储>0)
        {
            无敌存储 = 无敌存储 - 0.01f;
        }
        if(无敌存储<=0)
        {
            是否无敌 = false;
        }

        if (无敌存储 > 0)
        {
            transform.GetComponent<BoxCollider2D>().enabled = false;
        }
        else
        {
            transform.GetComponent<BoxCollider2D>().enabled = true;
        }
    }

    public void 开启无敌()
    {
        是否无敌 = true;
        无敌存储 = 无敌;
    }
    #endregion

    #region 存档机制

    public void Save()
    {
        SaveByJson();
    }

    public void Load()
    {
        LoadFromJson();
    }
    void SaveByJson()
    {
        saveSystem.SaveByJson(saveSystem.gameName,savingData());
    }

    void LoadFromJson()
    {
        var save = saveSystem.LoadFromJson<SaveData>(saveSystem.gameName);//读档
        LocaData(save);//加载读档数据
        Player.Instance.playerData.locaData(save);
    }

    SaveData savingData()
    {
        var saveData = new SaveData();
        saveData.playerPosition = transform.position;
        //DictionaryCopy(saveData.ItemList, GlobalController.Instance.Data.Inventory);
        //saveData.ItemList = GlobalController.Instance.Data.Inventory;
        //saveData.Data = Player.Instance.playerData;
        Player.Instance.playerData.saveData(saveData);
        saveData.EQUIPid = equipController.id;
        ItemController.Instance.saveEquip(saveData);
        return saveData;
    }

    void LocaData(SaveData saveData)
    {
        transform.position = saveData.playerPosition;
        //ItemController.Instance.RefreshhUI(GlobalController.Instance.Data.Inventory = saveData.ItemList);
        //Player.Instance.playerData=(PlayerData)saveData.Data;
        equipController.id = saveData.EQUIPid;
        ItemController.Instance.locaEquip(saveData);
        //ItemController.Instance.RefreshhUI(Inventory);
    }

    #endregion
}