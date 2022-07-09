using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFirstSkillRange : MonoBehaviour
{
    public List<GameObject> FirstSkillRangeInEnemy = new List<GameObject>();
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            FirstSkillRangeInEnemy.Add(collision.gameObject);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            FirstSkillRangeInEnemy.Remove(collision.gameObject);
        }
    }
    private void EnemyListCorrection()
    {
        for (int NowEnemyListIndex = 0; NowEnemyListIndex < FirstSkillRangeInEnemy.Count; NowEnemyListIndex++)
        {
            if (FirstSkillRangeInEnemy[NowEnemyListIndex] == null)
            {
                FirstSkillRangeInEnemy.Remove(FirstSkillRangeInEnemy[NowEnemyListIndex]);
            }
        }
    }
}
