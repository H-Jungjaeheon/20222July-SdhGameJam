using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum Times
{
    BossGameOverTimes = 100
}

public class BasicEnemy : MonoBehaviour
{
    [Header("유닛 기본 변수 모음")]
    [Tooltip("기본 스탯 세팅")]
    [SerializeField] protected EnemyStat enemyStat;
    [Header("(자동 할당)")]
    [Tooltip("체력")]
    [SerializeField] protected float hp;
    [Tooltip("이동속도")]
    [SerializeField] protected float speed;
    [Tooltip("주는 돈")]
    [SerializeField] protected float giveMoney;
    [Space(20)]

    [SerializeField] protected bool isBoss;
    [SerializeField] protected bool isFreeze;
    protected float GameOverTime;
    protected float knockbackStart;
    protected bool knockback;
    private bool skillknockback;
     
    [SerializeField] protected Rigidbody2D rigid;

    protected virtual void Awake() => StartSetting();

    protected virtual void Update()
    {
        Move();
        CheckKnockback();
    }

    void StartSetting()
    {
        hp = enemyStat.Hp;
        speed = enemyStat.Speed;
        giveMoney = enemyStat.GiveMoney;
    }
    public void Damage(float Damage, bool IsSkill)
    {
        hp -= Damage;

        if (hp > 0 && !isBoss && !IsSkill)
            Knockback();
        else if (hp > 0 && !isBoss && IsSkill)
            skillKnockback();
        else if (hp <= 0)
            Dead();

        ParticleManager.Instance.playHitEffect(transform.position);
    }

    protected virtual void Move()
    {
        if (isBoss)
            GameOverTime += Time.deltaTime;
        if(!isFreeze)
            transform.position -= new Vector3(speed * Time.deltaTime, 0, 0);
        if (GameOverTime >= (int)Times.BossGameOverTimes || Input.GetKeyDown(KeyCode.F1))
            speed += Time.deltaTime;

    }
    private void Knockback()
    {
        knockback = true;
        knockbackStart = Time.time;

        Vector2 curPos = transform.position;
        Vector2 nextPos = Vector2.right * 0.3f;

        transform.position = curPos + nextPos;
    }

    protected virtual void Dead()
    {
        ParticleManager.Instance.playDeathEffect(transform.position);
        InGameManager.Instance.GetGold += giveMoney;
        GameManager.Instance.Gold += giveMoney;
        Destroy(gameObject);
    }


    private void CheckKnockback()
    {
        //0.1초 후에 넉백 해제
        if (Time.time >= knockbackStart + 0.1f && knockback)
        {
            knockback = false;
        }
        if (Time.time >= knockbackStart + 0.5f && skillknockback)
        {
            knockback = false;
            rigid.velocity = new Vector2(0.0f, rigid.velocity.y);
        }
    }

    private void skillKnockback()
    {
        skillknockback = true;
        knockbackStart = Time.time;
        rigid.velocity = new Vector2(10 * Vector2.right.x, rigid.velocity.y);
    }

    public void freeze(float sec)
    {
        if (isFreeze)
        {
            return;
        }

        isFreeze = true;

        ParticleManager.Instance.playFreezeEffect(transform.position);

        StartCoroutine(freezeOff(sec));
    }

    IEnumerator freezeOff(float sec)
    {
        yield return new WaitForSecondsRealtime(sec);

        isFreeze = false;
    }

    protected virtual void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("EndLine") && !isBoss)
        {
            InGameManager.Instance.EnemyPass(InGameManager.Instance.Hp);
            Destroy(gameObject);
        }
        else if (collision.gameObject.CompareTag("EndLine") && isBoss)
            SceneManager.LoadScene("Ending");
    }
}
