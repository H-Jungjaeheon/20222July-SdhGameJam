using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Player : MonoBehaviour
{
    private bool IsUp = true;
    private float MoveCoolTimeCount = 0.5f;
    [SerializeField] private float MaxMoveCoolTimeCount;
    [SerializeField] private List<GameObject> RangeInEnemy = new List<GameObject>();
    [SerializeField] private float MaxAttackCoolTime, AttackCoolTime;
    [SerializeField] private float BasicAttackDamage;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        MoveUpDown();
        EnemyListCorrection();
        Attack();
    }
    private void MoveUpDown()
    {
        MoveCoolTimeCount += Time.deltaTime;
        if (Input.GetKeyDown(KeyCode.DownArrow) && IsUp && MoveCoolTimeCount >= MaxMoveCoolTimeCount)
        {
            transform.position = new Vector3(-7.05f, -3.66f, 0);
            MoveCoolTimeCount = 0;
            IsUp = false;
        }
        else if (Input.GetKeyDown(KeyCode.UpArrow) && !IsUp && MoveCoolTimeCount >= MaxMoveCoolTimeCount)
        {
            transform.position = new Vector3(-7.05f, 0.5f, 0);
            MoveCoolTimeCount = 0;
            IsUp = true;
        }
        if (MoveCoolTimeCount >= MaxMoveCoolTimeCount)
            MoveCoolTimeCount = MaxMoveCoolTimeCount;
    }
    private void Attack()
    {
        if(AttackCoolTime < MaxAttackCoolTime)
           AttackCoolTime += Time.deltaTime;
        if (Input.GetKeyDown(KeyCode.Z) && AttackCoolTime >= MaxAttackCoolTime)
        {
            for (int NowEnemyListIndex = 0; NowEnemyListIndex < RangeInEnemy.Count; NowEnemyListIndex++)
            {
                if (RangeInEnemy[NowEnemyListIndex] != null)
                {
                    RangeInEnemy[NowEnemyListIndex].GetComponent<tanker>().Damage(BasicAttackDamage);
                }
            }
            AttackCoolTime = 0;
        }
    }
    public void RandSkill(int SkillIndex)
    {
        switch (SkillIndex)
        {
            case 1:
                print("1번 스킬 사용");
                break;
            case 2:
                print("2번 스킬 사용");
                break;
            case 3:
                print("3번 스킬 사용");
                break;
            case 4:
                print("4번 스킬 사용");
                break;
            case 5:
                print("5번 스킬 사용");
                break;
            case 6:
                print("6번 스킬 사용");
                break;
        }
        InGameManager.Instance.IsDiceRolling = false;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            RangeInEnemy.Add(collision.gameObject);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            RangeInEnemy.Remove(collision.gameObject);
        }
    }
    private void EnemyListCorrection()
    {
        for(int NowEnemyListIndex = 0; NowEnemyListIndex < RangeInEnemy.Count; NowEnemyListIndex++)
        {
            if (RangeInEnemy[NowEnemyListIndex] == null)
            {
                RangeInEnemy.Remove(RangeInEnemy[NowEnemyListIndex]);
            }
        }
    }
}
