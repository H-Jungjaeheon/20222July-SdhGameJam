using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class UpGradeBoard : MonoBehaviour
{

    protected const int maxLevel = 10;
    #region 인스펙터에서 넣어준것들
    [SerializeField]
    protected double[] cost;
    [SerializeField]
    protected Text skillNametxt;
    [SerializeField]
    protected Text levelTxt;
    [SerializeField]
    protected Button upGradeBtn;
    [SerializeField]
    protected string skillName;
    [SerializeField]
    protected Image picture;
    [SerializeField]
    protected Sprite sprite;
    [SerializeField]
    protected Text costtxt;
    [SerializeField]
    protected Text maxtxt;

    #endregion
    protected int skillLevel;
    public Text SkillName => skillNametxt;
    public int SkillLevel
    {
        get
        {
            return skillLevel;
        }
        set
        {
            levelTxt.text = skillLevel.ToString();
        }
    }
    protected virtual void Start()
    {
        picture.sprite = sprite;
        skillNametxt.text = skillName;
    }
    protected virtual void Update()
    {
        if(skillLevel >= maxLevel)
        {
            upGradeBtn.gameObject.SetActive(false);

        }
        levelTxt.text = skillLevel.ToString() + " Level";
        costtxt.text = Cost.ToString();
    }
    public double Cost => cost[skillLevel];
}