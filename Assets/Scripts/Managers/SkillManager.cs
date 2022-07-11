using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillManager : MonoBehaviour
{
    private int firstSkillLevel = 1;
    private int secondSkillLevel = 1;
    private int thirdSkillLevel = 1;
    private int fourthSkillLevel = 1;
    private int fifthSkillLevel = 1;
    private int sixthSkillLevel = 1;

    public float firstDmg;
    public float secondShield;
    public struct ThirdunitStat
    {
        public float hp;
        public float dmg;
    }
    public float fourthDmg;
    public float fifthIceTime;
    public float sixthDmg;

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

}
