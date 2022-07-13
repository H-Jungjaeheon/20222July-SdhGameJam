using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class Player : MonoBehaviour
{
    private bool IsUp = true;
    private float MoveCoolTimeCount = 0.5f;
    [Tooltip("이동 쿨타임 변수")]
    [SerializeField] private float MaxMoveCoolTimeCount;
    [Tooltip("기본 공격 범위안 적 판별")]
    [SerializeField] private List<GameObject> RangeInEnemy = new List<GameObject>();
    [Tooltip("기본 공격 쿨타임")]
    [SerializeField] private float MaxAttackCoolTime;
    [Tooltip("현재 기본 공격 쿨타임")]
    [SerializeField] private float AttackCoolTime;
    [SerializeField] private GameObject MainCam;
    [Tooltip("일반 스킬 검기 오브젝트")]
    [SerializeField] private GameObject EnergySword;
    [Tooltip("궁극기 검기 오브젝트")]
    [SerializeField] private GameObject SuperEnergySword;
    [Tooltip("프리즈 스킬 전용 페이드 이미지")]
    [SerializeField] private Image FifthSkillFaidImage;
    [Tooltip("프리즈 스킬 적 판별")]
    [SerializeField] private GameObject[] FreezeSkillTargetEnemys;

    [SerializeField] private bool IsAttackDelay;

    [SerializeField] private float FreezeTime;
    private GameObject SkillRangeObj;
    public float BasicAttackDamage;
    private Animator animator;

    void Start() => StartSetting();

    // Update is called once per frame
    void Update()
    {
        MoveUpDown();
        EnemyListCorrection();
        Attack();
        BugKeyHeHe();
    }

    private void StartSetting()
    {
        SkillRangeObj = transform.GetChild(0).gameObject;
        animator = gameObject.GetComponent<Animator>();
    }

    private void MoveUpDown()
    {
        MoveCoolTimeCount += Time.deltaTime;
        if (Input.GetKeyDown(KeyCode.DownArrow) && IsUp && MoveCoolTimeCount >= MaxMoveCoolTimeCount)
        {
            transform.position = new Vector3(-6.6f, -2.15f, 0);
            MoveCoolTimeCount = 0;
            IsUp = false;
        }
        else if (Input.GetKeyDown(KeyCode.UpArrow) && !IsUp && MoveCoolTimeCount >= MaxMoveCoolTimeCount)
        {
            transform.position = new Vector3(-6.6f, 2.05f, 0);
            MoveCoolTimeCount = 0;
            IsUp = true;
        }
        if (MoveCoolTimeCount >= MaxMoveCoolTimeCount)
            MoveCoolTimeCount = MaxMoveCoolTimeCount;
    }
    public void Attack()
    {
        if(AttackCoolTime < MaxAttackCoolTime && !IsAttackDelay)
           AttackCoolTime += Time.deltaTime;
        if (Input.GetKeyDown(KeyCode.Z) && AttackCoolTime >= MaxAttackCoolTime && !IsAttackDelay)
        {
            AttackCoolTime = 0;
            animator.SetTrigger("IsAttack");
            StartCoroutine(AttackDelay());
        }
    }
    IEnumerator AttackDelay()
    {
        yield return new WaitForSeconds(0.5f);
        for (int NowEnemyListIndex = 0; NowEnemyListIndex < RangeInEnemy.Count; NowEnemyListIndex++)
        {
            if (RangeInEnemy[NowEnemyListIndex] != null)
            {
                if (!IsAttackDelay)
                {
                    IsAttackDelay = true;
                    var Cam = MainCam.GetComponent<CamShake>();
                    Cam.VibrateForTime(0.2f, 0.3f);
                }
                RangeInEnemy[NowEnemyListIndex].GetComponent<tanker>().Damage(BasicAttackDamage);
            }
        }
        IsAttackDelay = false;
    }
    public void RandSkill(int SkillIndex)
    {
        switch (SkillIndex)
        {
            case 1: //기본공격 강화 스킬 (찌르기)
                print("1번 스킬 사용");
                var FirstSkillCamShake = MainCam.GetComponent<CamShake>();
                var FirstSkill = SkillRangeObj.GetComponent<PlayerFirstSkillRange>();
                for (int NowEnemyListIndex = 0; NowEnemyListIndex < FirstSkill.FirstSkillRangeInEnemy.Count; NowEnemyListIndex++)
                {
                    if (FirstSkill.FirstSkillRangeInEnemy[NowEnemyListIndex] != null)
                    {
                        FirstSkillCamShake.VibrateForTime(0.2f, 0.5f);
                        FirstSkill.FirstSkillRangeInEnemy[NowEnemyListIndex].GetComponent<tanker>().Damage(BasicAttackDamage * 2);
                    }
                }
                break;
            case 2: //힐
                print("2번 스킬 사용");
                InGameManager.Instance.Heal(InGameManager.Instance.Hp);
                break;
            case 3:
                print("3번 스킬 사용");
                print("후 순위");
                break;
            case 4:
                print("4번 스킬 사용");
                var FourthSkillCamShake = MainCam.GetComponent<CamShake>();
                FourthSkillCamShake.VibrateForTime(0.2f, 0.4f);
                ShootEnergySword(false);
                break;
            case 5:
                print("5번 스킬 사용");
                FreezeSkill();
                break;
            case 6:
                print("6번 스킬 사용");
                var SixthSkillCamShake = MainCam.GetComponent<CamShake>();
                SixthSkillCamShake.VibrateForTime(0.3f, 0.6f);
                ShootEnergySword(true);
                break;
        }
        //InGameManager.Instance.IsDiceRolling = false;
    }
    private void ShootEnergySword(bool IsSixthSkill)
    {
        if (!IsSixthSkill)
        {
            animator.SetTrigger("IsSpecialAttack");
            Instantiate(EnergySword, transform.position, EnergySword.transform.rotation);
        }
        else
        {
            animator.SetTrigger("IsSpecialAttack");
            Instantiate(SuperEnergySword, new Vector3(-7, -1.5f, 0), EnergySword.transform.rotation);
        }
    }

    private void FreezeSkill()
    {
        StartCoroutine(FreezeFaid(6f));
    }

    private void BugKeyHeHe()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
            FreezeSkill();
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            print("6번 스킬 사용");
            var SixthSkillCamShake = MainCam.GetComponent<CamShake>();
            SixthSkillCamShake.VibrateForTime(0.3f, 0.6f);
            ShootEnergySword(true);
        }
    }

    private IEnumerator FreezeFaid(float FaidTime)
    {
        float NowFaidTime = 0;
        Color color = FifthSkillFaidImage.color;
        while (NowFaidTime <= 1)
        {
            color.a = NowFaidTime;
            FifthSkillFaidImage.color = color;
            NowFaidTime += Time.deltaTime * FaidTime;
            yield return null;
        }
        while (NowFaidTime >= 0)
        {
            color.a = NowFaidTime;
            FifthSkillFaidImage.color = color;
            NowFaidTime -= Time.deltaTime * (FaidTime * 2);
            yield return null;
        }
        color.a = NowFaidTime;
        FifthSkillFaidImage.color = color;
        NowFaidTime = 0;
        FreezeSkillTargetEnemys = GameObject.FindGameObjectsWithTag("Enemy");
        for(int TargetEnemyIndex = 0; TargetEnemyIndex < FreezeSkillTargetEnemys.Length; TargetEnemyIndex++)
        {
            FreezeSkillTargetEnemys[TargetEnemyIndex].GetComponent<tanker>().freeze(FreezeTime);
        }
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
