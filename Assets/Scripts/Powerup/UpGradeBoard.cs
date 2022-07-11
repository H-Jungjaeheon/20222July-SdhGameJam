using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class UpGradeBoard : MonoBehaviour
{
    [SerializeField]
    protected double[] cost;
    [SerializeField]
    protected Text skillName;
    [SerializeField]
    protected Text levelTxt;
    [SerializeField]
    protected Button upGradeBtn;
    [SerializeField]
    protected Image picture;

    protected int skillLevel;
    public Text SkillName => skillName;

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
    public double Cost => cost[skillLevel];
    public Image Picture => picture;
    protected abstract void OnEnable();
}
