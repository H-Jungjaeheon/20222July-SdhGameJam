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
    [Tooltip("���׷��̵� ��ư")]
    private List<Button> upGradeBtn = new List<Button>();
    [SerializeField]
    [Tooltip("���׷��̵� �ʿ��� ��ȭ")]
    private List<Text> upGradeBtnTxt = new List<Text>();
    

    private void Start()
    {
        for (int i = 0; i < upGradeBtn.Count; i++)
        {
            upGradeBtn[i].onClick.AddListener(() =>
            {
                Debug.Log($"{i}��° ��ų�� ���׷��̵� �Ǿ����ϴ�");

            });
        }
    }
    private void SkillUIActive()
    {
        
    }
}
