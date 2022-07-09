using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InGameManager : MonoBehaviour
{
    public static InGameManager Instance { get; set; }
    [Header("��ų Ȯ�� ���� ����")]
    [Tooltip("���� 1 ~ 6������ ��ų Ȯ��")]
    private Dictionary<int, int> SkillPercentage = new Dictionary<int, int>();
    [Tooltip("���� 1 ~ 6������ ��ų Ȯ�� �迭")]
    private int[] SkillPercentages = new int[6] { 71, 50, 32, 17, 7, 0 };

    [Header("�ֻ��� ���� ���� ����")]
    [Tooltip("�ֻ��� ���� ���� Ƚ��")]
    [SerializeField] private int DiceStackCount;
    [Tooltip("�ֻ��� ���� ���� Ƚ��(MaxCount)")]
    [SerializeField] private int MaxDiceStackCount;

    [Tooltip("�ֻ��� ���� ���� ��")]
    [SerializeField] private int RandDiceIndex;

    [Tooltip("�ֻ��� ���� Ƚ�� ��Ÿ��")]
    [SerializeField] private float MaxDiceCoolTime;
    [SerializeField] private float NowDiceCoolTime;

    [Header("������Ʈ ����")]
    [Tooltip("�÷��̾� ������Ʈ")]
    [SerializeField] private GameObject player;

    [Header("�������� ����")]
    [SerializeField] private float MaxStageTime;
    [SerializeField] private float StageTime;

    [Header("��ȭ")]
    public int GetGold;

    [Header("����")]
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
        var PlayerComponent = player.GetComponent<Player>();
        RandDiceIndex = Random.Range(1, 101);
        //�ֻ��� �ִϸ��̼� ����
        yield return new WaitForSeconds(3);
        //�ֻ��� �ִϸ��̼� ����
        yield return new WaitForSeconds(1); 
        for(int SkillIndex = 0; SkillIndex < 6; SkillIndex++)
        {
            if(RandDiceIndex > SkillPercentage[SkillIndex])
            {
                PlayerComponent.RandSkill(SkillIndex + 1);
                break;
            }
        }
    }
 
    private void GameOver()
    {
        GameManager.Instance.Gold += GetGold;
    }
    private void GameClear()
    {

    }
}
