using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldCham : UpGradeBoard
{
    protected override void Update()
    {
        base.Update();
    }
    protected override void Start()
    {
        skillLevel = SkillManager.Instance.SixthSkillLevel;
        base.Start();
        upGradeBtn.onClick.AddListener(() =>
        {
            if (GameManager.Instance.Gold >= Cost)
            {
                skillLevel++;
                GameManager.Instance.Gold -= Cost;
                SkillManager.Instance.SixthSkillLevel = skillLevel;
            }
        });
    }
}
