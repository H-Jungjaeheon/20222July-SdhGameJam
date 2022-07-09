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

    private void Awake()
    {
        skillName.Add(0, "�Ϲ� ����");
        skillName.Add(1, "���� ����");
        skillName.Add(2, "���,ȸ��");
        skillName.Add(3, "���� ��ȯ");
        skillName.Add(4, "�˱� �߻�");
        skillName.Add(5, "����");
        skillName.Add(6, "������");
    }
    private void OnEnable()
    {
        canvas = FindObjectOfType<Canvas>();
        for (int i = 0; i < upGradeBtn.Count; i++)
        {
            SetSkillBtn(i);
        }
        for (int i = 0; i < upGradeBtn.Count; i++)
        {
            upGradeBtn[i].onClick.AddListener(() =>
            {
                int num;
                Debug.Log($"{skillName[i]} ��ų�� ���׷��̵� �Ǿ����ϴ�");
                num = i;
                SetSkillBtn(num);
            });
        }
        for (int i = 0; i < skilltxt.Count; i++)
        {
            skilltxt[i].text = skillName[i];
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
   
}
