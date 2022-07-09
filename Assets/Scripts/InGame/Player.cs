using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class Player : MonoBehaviour
{
    private bool IsUp = true;
    private float MoveCoolTimeCount = 0.5f;
    [Tooltip("�̵� ��Ÿ�� ����")]
    [SerializeField] private float MaxMoveCoolTimeCount;
    [Tooltip("�⺻ ���� ������ �� �Ǻ�")]
    [SerializeField] private List<GameObject> RangeInEnemy = new List<GameObject>();
    [Tooltip("�⺻ ���� ��Ÿ��")]
    [SerializeField] private float MaxAttackCoolTime;
    [Tooltip("���� �⺻ ���� ��Ÿ��")]
    [SerializeField] private float AttackCoolTime;
    [SerializeField] private GameObject MainCam;
    [Tooltip("�Ϲ� ��ų �˱� ������Ʈ")]
    [SerializeField] private GameObject EnergySword;
    [Tooltip("�ñر� �˱� ������Ʈ")]
    [SerializeField] private GameObject SuperEnergySword;
    [Tooltip("������ ��ų ���� ���̵� �̹���")]
    [SerializeField] private Image FifthSkillFaidImage;
    [Tooltip("������ ��ų �� �Ǻ�")]
    [SerializeField] private GameObject[] FreezeSkillTargetEnemys;
    [SerializeField] private float FreezeTime;
    private GameObject SkillRangeObj;
    public float BasicAttackDamage;


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
            case 2: //��
                print("2�� ��ų ���");
                InGameManager.Instance.Heal(InGameManager.Instance.Hp);
                break;
            case 3:
                print("3�� ��ų ���");
                print("�� ����");
                break;
            case 4:
                print("4�� ��ų ���");
                var FourthSkillCamShake = MainCam.GetComponent<CamShake>();
                FourthSkillCamShake.VibrateForTime(0.2f, 0.4f);
                ShootEnergySword(false);
                break;
            case 5:
                print("5�� ��ų ���");
                FreezeSkill();
                break;
            case 6:
                print("6�� ��ų ���");
                var SixthSkillCamShake = MainCam.GetComponent<CamShake>();
                SixthSkillCamShake.VibrateForTime(0.3f, 0.6f);
                ShootEnergySword(true);
                break;
        }
        InGameManager.Instance.IsDiceRolling = false;
    }
    private void ShootEnergySword(bool IsSixthSkill)
    {
        if(!IsSixthSkill)
            Instantiate(EnergySword, transform.position, EnergySword.transform.rotation);
        else
            Instantiate(SuperEnergySword, new Vector3(-7, -1.5f, 0), EnergySword.transform.rotation);
    }

    private void FreezeSkill()
    {
        StartCoroutine(FreezeFaid(4.5f));
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
