using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelCharge : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> levelObj = new List<GameObject>();

    private int level = 1;
    public int Level
    {
        get
        {
            return level;
        }
        set
        {
            GameManager.Instance.SkillLevelStat.DamageLevel = level;
            for (int i = 0; i < levelObj.Count; i++)
            {
                if(level >= i)
                {
                    levelObj[i].SetActive(true);
                }
            }
        }
    }
    private void Start()
    {
        
    }
    private void SetLevel()
    {

    }
}
