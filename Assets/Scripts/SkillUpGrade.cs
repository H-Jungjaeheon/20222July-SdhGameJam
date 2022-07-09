using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillUpGrade : MonoBehaviour
{
    
    //[SerializeField]
    //[Tooltip("스킬 바")]
    //private List<GameObject> skilluplist = new List<GameObject>();
    [SerializeField]
    [Tooltip("업그래이드 버튼")]
    private List<Button> upGradeBtn = new List<Button>();
    [SerializeField]
    [Tooltip("업그래이드 필요한 재화, 버튼에 표시")]
    private List<Text> upGradeBtnTxt = new List<Text>();

    [SerializeField]
    [Tooltip("스킬 이름 Txt")]
    private List<Text> skilltxt = new List<Text>();

    [SerializeField]
    [Tooltip("스킬 레벨")]
    private List<Text> skillLeveltxt = new List<Text>();

    [SerializeField]
    private Levelupbar[] levelupbar;

    public Dictionary<int, string> skillName = new Dictionary<int, string>();

    private Canvas canvas;

    private void Awake()
    {
        skillName.Add(0, "일반 공격");
        skillName.Add(1, "광역 공격");
        skillName.Add(2, "방어,회복");
        skillName.Add(3, "유닛 소환");
        skillName.Add(4, "검기 발사");
        skillName.Add(5, "빙결");
        skillName.Add(6, "참참참");
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
                Debug.Log($"{skillName[i]} 스킬이 업그래이드 되었습니다");
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
    /// 업그래이드를 하는데 정수형으로 어떤 버튼인지 
    /// </summary>
    /// <param name="type"></param>
    private void SetSkillBtn(int type)
    {
        levelupbar[type].UpGrade((ESkillType)type);
    }
   
}
