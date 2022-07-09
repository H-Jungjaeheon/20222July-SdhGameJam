using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SkillLevelNum", menuName = "Scriptable Object/levelbardata", order = int.MaxValue)]
public class SkillLevelbar : ScriptableObject
{
    public GameObject[] levelBars;
}
