using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum ESkillType
{
    BaseAttack,
    BaseSkill,
    ShieldHeal,
    UnitSpawn,
    Sword,
    CCSkill,
    chamchamcham
}
public class Levelupbar : MonoBehaviour
{
    public SkillLevelbar skillLevelbar;
    public ESkillType eSkillType;
    public Transform[] pos;
    private Canvas canvas;

    private void Start()
    {
        canvas = FindObjectOfType<Canvas>();
    }
    private void Update()
    {

    }
    public void UpGrade(ESkillType skillType)
    {
        switch (skillType)
        {
            case ESkillType.BaseAttack:
                GameManager.Instance.SkillLevelStat.DamageLevel++;
                Levelbar(GameManager.Instance.SkillLevelStat.DamageLevel);
                break;
            case ESkillType.BaseSkill:
                GameManager.Instance.SkillLevelStat.CloseWideRangeLevel++;
                Levelbar(GameManager.Instance.SkillLevelStat.CloseWideRangeLevel);
                break;
            case ESkillType.ShieldHeal:
                GameManager.Instance.SkillLevelStat.HealLevel++;
                Levelbar(GameManager.Instance.SkillLevelStat.HealLevel);
                break;
            case ESkillType.UnitSpawn:
                GameManager.Instance.SkillLevelStat.SpawnCreatureLevel++;
                Levelbar(GameManager.Instance.SkillLevelStat.SpawnCreatureLevel);
                break;
            case ESkillType.Sword:
                GameManager.Instance.SkillLevelStat.AllLineAttackLevel++;
                Levelbar(GameManager.Instance.SkillLevelStat.AllLineAttackLevel);
                break;
            case ESkillType.CCSkill:
                GameManager.Instance.SkillLevelStat.CCSkillLevel++;
                Levelbar(GameManager.Instance.SkillLevelStat.CCSkillLevel);
                break;
            case ESkillType.chamchamcham:
                GameManager.Instance.SkillLevelStat.AllMapAttackLevel++;
                Levelbar(GameManager.Instance.SkillLevelStat.AllMapAttackLevel);
                break;
        }
        Debug.Log(GameManager.Instance.SkillLevelStat.DamageLevel);
    }
    public void Levelbar(int level)
    {
        for (int i = 0; i < skillLevelbar.levelBars.Length; i++)
        {
            if (level >= i)
            {
                Instantiate(skillLevelbar.levelBars[i], pos[i].position, Quaternion.identity, canvas.transform);
            }
        }
    }
}
