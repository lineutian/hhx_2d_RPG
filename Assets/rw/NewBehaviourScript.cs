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
    public float speed = 5f;//??????
    private float moveX, moveY;
    private Animator Animator;
    public bool isStop=true;
    public GameObject beibao;
    [FormerlySerializedAs("Equip")] public EquipObject equipObject=null;
    public Animator 动画;
    public float 无敌;
    public float 无敌存储;
    public bool 是否无敌;
    const string PLAYER_DATA_KEY = "PlayerData";
    const string PLAYER_DATA_FILE_NAME = "PlayerData.xxc";

    //public Animator animator;
    // Start is called before the first frame update
    private void Awake()
    {
        beibao.SetActive(false);
    }
    void Start()
    {
        Animator = transform.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        无敌时间();
        atk();
        run();
        IsOpen();
    }
    
    private void Flip()
    {
        if (moveX > 0)
            transform.eulerAngles = new Vector3(0, 0, 0);
        if (moveX < 0)
            transform.eulerAngles = new Vector3(0, 180, 0);
    }

    public void IsOpen()
    {
        //游戏需要被暂停，按下ESC，游戏暂停，显示我的设置UI界面，然后将标志位设置成false，等待下次点击ESC启动游戏
        if (isStop == true)
        {
            if (Input.GetKeyDown(KeyCode.Z))
            {
                Time.timeScale = 0;
                beibao.SetActive(true);
                isStop = false;
            }
        }
        //游戏不需要被暂停，按下ESC，游戏启动，隐藏我的设置UI界面，然后将标志位设置成true，等待下次点击ESC暂停游戏
        else {
            if (Input.GetKeyDown(KeyCode.Z))
            {
                Time.timeScale = 1;
                beibao.SetActive(false);
                isStop = true;
            }
        }
    }

    #region 移动

    private void run()
    {
        moveX = Input.GetAxisRaw("Horizontal")*speed;//a:-1 d:1 0
        moveY = Input.GetAxisRaw("Vertical")*speed;//w:1 s:-1 0
        /*if (moveX!=0||moveY!=0)
        {
            animator.SetBool("pd",true);
        }
        else
        {
            animator.SetBool("pd",false);
        }*/
        //??????
        Flip();//图片反转
        Vector2 position = transform.position;
        position.x += moveX * Time.deltaTime;
        position.y += moveY * Time.deltaTime;
        transform.position = position;//???????
    }
    #endregion

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
        equipObject =Instantiate(equip, transform.GetChild(0)).GetComponent<EquipObject>();
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
        saveSystem.SaveByJson(PLAYER_DATA_FILE_NAME,savingData());
    }

    void LoadFromJson()
    {
        var save = saveSystem.LoadFromJson<SaveData>(PLAYER_DATA_FILE_NAME);//读档
        LocaData(save);//加载读档数据
    }

    SaveData savingData()
    {
        var saveData = new SaveData();
        saveData.playerPosition = transform.position;
        DictionaryCopy(saveData.ItemList, GlobalController.Instance.Data.Inventory);
        foreach (var s in saveData.ItemList)
        {
            Debug.Log(s);
        }
        //saveData.ItemList = GlobalController.Instance.Data.Inventory;
        saveData.Data = (PlayerData)Player.Instance.Data;
        return saveData;
    }

    void LocaData(SaveData saveData)
    {
        transform.position = saveData.playerPosition;
        DictionaryCopy(GlobalController.Instance.Data.Inventory,saveData.ItemList);
        //ItemController.Instance.RefreshhUI(GlobalController.Instance.Data.Inventory = saveData.ItemList);
        Player.Instance.Data=saveData.Data;
        ItemController.Instance.RefreshhUI(GlobalController.Instance.Data.Inventory);
    }

    #endregion
}