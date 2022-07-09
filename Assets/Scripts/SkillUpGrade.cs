using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillUpGrade : MonoBehaviour
{
    [SerializeField]
    [Tooltip("")]
    private List<GameObject> skilluplist = new List<GameObject>();
    [SerializeField]
    [Tooltip("업그래이드 버튼")]
    private List<Button> upGradeBtn = new List<Button>();
    [SerializeField]
    [Tooltip("업그래이드 필요한 재화")]
    private List<Text> upGradeBtnTxt = new List<Text>();
    

    private void Start()
    {
        for (int i = 0; i < upGradeBtn.Count; i++)
        {
            upGradeBtn[i].onClick.AddListener(() =>
            {
                Debug.Log($"{i}번째 스킬이 업그래이드 되었습니다");

            });
        }
    }
    private void SkillUIActive()
    {
        
    }
}
