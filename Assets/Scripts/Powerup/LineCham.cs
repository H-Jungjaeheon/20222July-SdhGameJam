using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineCham : UpGradeBoard
{
    protected override void Update()
    {
        base.Update();
    }
    protected override void Start()
    {
        skillLevel = SkillManager.Instance.FourthSkillLevel;
        base.Start();
        upGradeBtn.onClick.AddListener(() =>
        {
            if (GameManager.Instance.Gold >= Cost)
            {
                skillLevel++;
                GameManager.Instance.Gold -= Cost;
                SkillManager.Instance.FourthSkillLevel = skillLevel;
            }
        });
    }
}
