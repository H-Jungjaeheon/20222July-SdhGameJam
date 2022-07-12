using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WideAttackUp : UpGradeBoard
{
    protected override void Update()
    {
        base.Update();
    }
    protected override void Start()
    {
        skillLevel = SkillManager.Instance.FirstSkillLevel;
        base.Start();
        upGradeBtn.onClick.AddListener(() =>
        {
            if(GameManager.Instance.Gold >= Cost)
            {
                skillLevel++;
                GameManager.Instance.Gold -= Cost;
                SkillManager.Instance.FirstSkillLevel = skillLevel;
            }
        });
    }
}
