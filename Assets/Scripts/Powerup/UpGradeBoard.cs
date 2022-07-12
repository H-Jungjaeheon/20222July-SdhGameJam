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
    
    protected Image picture;
    [SerializeField]
    protected Sprite sprite;

    protected int skillLevel;
    public Text SkillName => skillName;

    protected virtual void Start()
    {
        picture = GetComponent<Image>();
        picture.sprite = sprite;
    }
    
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
    protected abstract void OnEnable();
}
