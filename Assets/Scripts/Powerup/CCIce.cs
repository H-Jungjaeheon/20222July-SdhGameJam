using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CCIce : UpGradeBoard
{
    protected override void Update()
    {
        base.Update();
    }
    protected override void Start()
    {
        skillLevel = SkillManager.Instance.FifthSkillLevel;
        base.Start();
        upGradeBtn.onClick.AddListener(() =>
        {
            if (GameManager.Instance.Gold >= Cost)
            {
                skillLevel++;
                GameManager.Instance.Gold -= Cost;
                SkillManager.Instance.FifthSkillLevel = skillLevel;
            }
        });
    }
}
