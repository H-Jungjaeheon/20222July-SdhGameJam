using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillUpGrade : MonoBehaviour
{
    
    //[SerializeField]
    //[Tooltip("��ų ��")]
    //private List<GameObject> skilluplist = new List<GameObject>();
    [SerializeField]
    [Tooltip("���׷��̵� ��ư")]
    private List<Button> upGradeBtn = new List<Button>();
    [SerializeField]
    [Tooltip("���׷��̵� �ʿ��� ��ȭ, ��ư�� ǥ��")]
    private List<Text> upGradeBtnTxt = new List<Text>();

    [SerializeField]
    [Tooltip("��ų �̸� Txt")]
    private List<Text> skilltxt = new List<Text>();

    [SerializeField]
    [Tooltip("��ų ����")]
    private List<Text> skillLeveltxt = new List<Text>();

    [SerializeField]
    private Levelupbar[] levelupbar;

    public Dictionary<int, string> skillName = new Dictionary<int, string>();

    private Canvas canvas;

    private void Start()
    {
        
    }
    private void OnEnable()
    {
        if(GameManager.Instance == null)
        {
            StartCoroutine(wait());
        }
        
    }
    /// <summary>
    /// ���׷��̵带 �ϴµ� ���������� � ��ư���� 
    /// </summary>
    /// <param name="type"></param>
    private void SetSkillBtn(int type)
    {
        levelupbar[type].UpGrade((ESkillType)type);
    }
    private IEnumerator wait()
    {
        yield return new WaitForSeconds(0.05f);
        skillName.Add(0, "�Ϲ� ����");
        skillName.Add(1, "���� ����");
        skillName.Add(2, "���,ȸ��");
        skillName.Add(3, "���� ��ȯ");
        skillName.Add(4, "�˱� �߻�");
        skillName.Add(5, "����");
        skillName.Add(6, "������");
        canvas = FindObjectOfType<Canvas>();
        for (int i = 0; i < upGradeBtn.Count; i++)
        {
            SetSkillBtn(i);
        }
        for (int i = 0; i < skillName.Count; i++)
        {
            upGradeBtn[i].onClick.AddListener(() =>
            {
                int num;
                num = i;
                SetSkillBtn(num);
                Debug.Log($"{skillName[num]} ��ų�� ���׷��̵� �Ǿ����ϴ�");
            });
        }
        for (int i = 0; i < skilltxt.Count; i++)
        {
            skilltxt[i].text = skillName[i];
        }

        skillLeveltxt[0].text = GameManager.Instance.SkillLevelStat.DamageLevel + " Level".ToString();
        skillLeveltxt[1].text = GameManager.Instance.SkillLevelStat.CloseWideRangeLevel + " Level".ToString();
        skillLeveltxt[2].text = GameManager.Instance.SkillLevelStat.HealLevel + " Level".ToString();
        skillLeveltxt[3].text = GameManager.Instance.SkillLevelStat.SpawnCreatureLevel + " Level".ToString();
        skillLeveltxt[4].text = GameManager.Instance.SkillLevelStat.AllLineAttackLevel + " Level".ToString();
        skillLeveltxt[5].text = GameManager.Instance.SkillLevelStat.CCSkillLevel + " Level".ToString();
        skillLeveltxt[6].text = GameManager.Instance.SkillLevelStat.AllMapAttackLevel + " Level".ToString();
    }
}
