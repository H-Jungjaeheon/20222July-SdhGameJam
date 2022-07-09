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
    /// 업그래이드를 하는데 정수형으로 어떤 버튼인지 
    /// </summary>
    /// <param name="type"></param>
    private void SetSkillBtn(int type)
    {
        levelupbar[type].UpGrade((ESkillType)type);
    }
    private IEnumerator wait()
    {
        yield return new WaitForSeconds(0.05f);
        skillName.Add(0, "일반 공격");
        skillName.Add(1, "광역 공격");
        skillName.Add(2, "방어,회복");
        skillName.Add(3, "유닛 소환");
        skillName.Add(4, "검기 발사");
        skillName.Add(5, "빙결");
        skillName.Add(6, "참참참");
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
                Debug.Log($"{skillName[num]} 스킬이 업그래이드 되었습니다");
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
