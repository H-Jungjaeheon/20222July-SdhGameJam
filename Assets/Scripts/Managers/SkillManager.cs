using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillManager : MonoBehaviour
{
    private static SkillManager instance = null;
    private void Awake()
    {
        if (instance == null)
        {
            instance = GetComponent<SkillManager>();
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    public static SkillManager Instance
    {
        get
        {
            if(instance == null)
            {
                return null;
            }
            return instance;
        }
    }
    private int baseAttackLevel;
    private int firstSkillLevel;
    private int secondSkillLevel;
    private int thirdSkillLevel;
    private int fourthSkillLevel;
    private int fifthSkillLevel;
    private int sixthSkillLevel;

    private float baseDmg = 10;
    private float firstDmg = 5;
    private float secondShield;
    private float unitHp = 10;
    private float unitDmg = 10;
    private float fourthDmg = 10;
    private float fifthIceTime = 1;
    private float sixthDmg = 100;

    #region 스킬 스탯 프로퍼티
    public float BaseDmg
    {
        get
        {
            return baseDmg;
        }
        set
        {
            baseDmg = value;
        }
    } 
    public float FirstDmg
    {
        get
        {
            return firstDmg;
        }
        set
        {
            firstDmg = value;
        }
    }
    public float SecondShield
    {
        get
        {
            return secondShield;
        }
        set
        {
            secondShield = value;
        }
    }
    public float ThirdUnitHp
    {
        get
        {
            return unitHp;
        }
        set
        {
            unitHp = value;
        }
    }
    public float ThirdUnitDmg
    {
        get
        {
            return unitDmg;
        }
        set
        {
            unitDmg = value;
        }
    }
    public float FourthDmg
    {
        get
        {
            return fourthDmg;
        }
        set
        {
            fourthDmg = value;
        }
    }
    public float FifthIceTime
    {
        get
        {
            return fifthIceTime;
        }
        set
        {
            fifthIceTime = value;
        }
    }
    public float SixthDmg
    {
        get
        {
            return sixthDmg;
        }
        set
        {
            sixthDmg = value;
        }
    }
    #endregion


    #region 스킬 레벨 프로퍼티
    public int BaseAttackLevel
    {
        get
        {
            return baseAttackLevel;
        }
        set
        {
            baseAttackLevel = value;
        }
    }
    public int FirstSkillLevel
    {
        get => firstSkillLevel;
        set
        {
            firstSkillLevel = value;
        }
    }
    public int SecondSkillLevel
    {
        get => secondSkillLevel;
        set
        {
            secondSkillLevel = value;
        }
    }
    public int ThirdSkillLevel
    {
        get => thirdSkillLevel;
        set
        {
            thirdSkillLevel = value;
        }
    }
    public int FourthSkillLevel
    {
        get => fourthSkillLevel;
        set
        {
            fourthSkillLevel = value;
        }
    }
    public int FifthSkillLevel
    {
        get => fifthSkillLevel;
        set
        {
            fifthSkillLevel = value;
        }
    }
    public int SixthSkillLevel
    {
        get => sixthSkillLevel;
        set
        {
            sixthSkillLevel = value;
        }
    }
    #endregion
}
