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
    [SerializeField] private GameObject MainCam;
    private GameObject SkillRangeObj;
    // Start is called before the first frame update
    void Start() => StartSetting();

    // Update is called once per frame
    void Update()
    {
        MoveUpDown();
        EnemyListCorrection();
        Attack();
    }

    private void StartSetting()
    {
        SkillRangeObj = transform.GetChild(0).gameObject;
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
    public void Attack()
    {
        if(AttackCoolTime < MaxAttackCoolTime)
           AttackCoolTime += Time.deltaTime;
        if (Input.GetKeyDown(KeyCode.Z) && AttackCoolTime >= MaxAttackCoolTime)
        {
            var Cam = MainCam.GetComponent<CamShake>();
            for (int NowEnemyListIndex = 0; NowEnemyListIndex < RangeInEnemy.Count; NowEnemyListIndex++)
            {
                if (RangeInEnemy[NowEnemyListIndex] != null)
                {
                    Cam.VibrateForTime(0.2f, 0.3f);
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
            case 1: //�⺻���� ��ȭ ��ų (���)
                print("1�� ��ų ���");
                var Cam = MainCam.GetComponent<CamShake>();
                var FirstSkill = SkillRangeObj.GetComponent<PlayerFirstSkillRange>();
                for (int NowEnemyListIndex = 0; NowEnemyListIndex < FirstSkill.FirstSkillRangeInEnemy.Count; NowEnemyListIndex++)
                {
                    if (FirstSkill.FirstSkillRangeInEnemy[NowEnemyListIndex] != null)
                    {
                        Cam.VibrateForTime(0.2f, 0.5f);
                        FirstSkill.FirstSkillRangeInEnemy[NowEnemyListIndex].GetComponent<tanker>().Damage(BasicAttackDamage * 2);
                    }
                }
                break;
            case 2:
                print("2�� ��ų ���");
                break;
            case 3:
                print("3�� ��ų ���");
                break;
            case 4:
                print("4�� ��ų ���");
                break;
            case 5:
                print("5�� ��ų ���");
                break;
            case 6:
                print("6�� ��ų ���");
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
