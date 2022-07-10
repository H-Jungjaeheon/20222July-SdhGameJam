using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class InGameManager : MonoBehaviour
{
    public static InGameManager Instance { get; set; }
    [Header("스킬 확률 변수 모음")]
    [Tooltip("눈금 1 ~ 6까지의 스킬 확률")]
    private Dictionary<int, int> SkillPercentage = new Dictionary<int, int>();
    [Tooltip("눈금 1 ~ 6까지의 스킬 확률 배열")]
    private int[] SkillPercentages = new int[6] { 71, 50, 32, 17, 7, 0 };

    [Header("주사위 관련 변수 모음")]
    [Tooltip("주사위 굴림 가능 횟수")]
    [SerializeField] private int DiceStackCount;
    [Tooltip("주사위 굴림 가능 횟수(MaxCount)")]
    [SerializeField] private int MaxDiceStackCount;

    [Tooltip("주사위 랜덤 눈금 수")]
    [SerializeField] private int RandDiceIndex;

    [Tooltip("주사위 스택 횟수 쿨타임")]
    [SerializeField] private float MaxDiceCoolTime;
    [SerializeField] private float NowDiceCoolTime;

    [Header("오브젝트 모음")]
    [Tooltip("플레이어 오브젝트")]
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject RandDice;
    [SerializeField] private GameObject[] RandDiceObjs;
 
    [Header("스테이지 변수")]
    [SerializeField] private float MaxStageTime;
    [SerializeField] private float StageTime;

    [Header("스테이지 변수")]
    [SerializeField] private GameObject[] HpImage = new GameObject[3];


    [Header("재화")]
    public int GetGold;

    [Header("스탯")]
    public int Hp;

    [HideInInspector]
    public bool IsDiceRolling;



    private void Awake() => StartSetting();


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        DiceCoolTimePlus();
        DiceRoll();
        StageTimer();
        GameOver();
    }

    public void EnemyPass(int CurHp)
    {
        switch (CurHp)
        {
            case 3: HpImage[CurHp - 1].SetActive(false); break;
            case 2: HpImage[CurHp - 1].SetActive(false); break;
            case 1: HpImage[CurHp - 1].SetActive(false); break;
        }
        if(Hp > 0)
           Hp -= 1;
    }

    public void Heal(int CurHp)
    {
        switch (CurHp)
        {
            case 1: HpImage[CurHp].SetActive(true); break;
            case 2: HpImage[CurHp].SetActive(true); break;
        }
        if (Hp < 3)
            Hp += 1;
    }

    private void StartSetting()
    {
        Instance = this;
        for (int NowSkillIndex = 0; NowSkillIndex < 6; NowSkillIndex++)
        {
            SkillPercentage.Add(NowSkillIndex, SkillPercentages[NowSkillIndex]);
        }
    }

    private void DiceCoolTimePlus()
    {
        if(DiceStackCount < 3)
        {
            NowDiceCoolTime += Time.deltaTime;
            if (NowDiceCoolTime >= MaxDiceCoolTime)
            {
                DiceStackCount++;
                NowDiceCoolTime = 0;
            }
        }
    }
    private void StageTimer()
    {
        StageTime += Time.deltaTime;
    }
    private void DiceRoll()
    {
        if (Input.GetKeyDown(KeyCode.X) && DiceStackCount >= 1 && !IsDiceRolling)
        {
            IsDiceRolling = true;
            DiceStackCount -= 1;
            StartCoroutine(RollTheDice());
        }
    }
    private IEnumerator RollTheDice() 
    {
        WaitForSeconds WaitTwoSec =  new WaitForSeconds(2);
        var PlayerComponent = player.GetComponent<Player>();
        RandDiceIndex = Random.Range(1, 101);
        RandDice.SetActive(true);
        yield return WaitTwoSec;
        RandDice.SetActive(false);
        for(int SkillIndex = 0; SkillIndex < 6; SkillIndex++)
        {
            if(RandDiceIndex > SkillPercentage[SkillIndex])
            {
                PlayerComponent.RandSkill(SkillIndex + 1);
                RandDiceObjs[SkillIndex].SetActive(true);
                yield return new WaitForSeconds(3);
                RandDiceObjs[SkillIndex].SetActive(false);
                print(IsDiceRolling);
                IsDiceRolling = false;
                break;
            }
        }
    }
 
    private void GameOver()
    {
        if(Hp <= 0)
        {
            SceneManager.LoadScene("Ending");
        }
        GameManager.Instance.Gold += GetGold;
    }
    private void GameClear()
    {

    }
}
