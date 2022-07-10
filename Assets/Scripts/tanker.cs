using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tanker : MonoBehaviour
{
    [SerializeField] private float baseHealth;
    [SerializeField] protected float moveSpeed;

    [SerializeField] private float curHealth;
    [SerializeField] private float GameOverCount;
    [SerializeField] private bool IsBoss;
    protected float knockbackStart;

    protected bool isFreeze;
    protected bool knockback;
    private bool skillknockback;

    Rigidbody2D rigid;

    

    protected virtual void OnEnable()
    {
        curHealth = baseHealth;
    }

    protected virtual void Awake()
    {
        curHealth = baseHealth;
        rigid = GetComponent<Rigidbody2D>();
    }

    protected virtual void Update()
    {
        Move();
        CheckKnockback();
    }

    protected virtual void Move()
    {
        GameOverCount += Time.deltaTime;
        if (isFreeze)
            return;
        if(GameOverCount >= 100)
            moveSpeed += Time.deltaTime;
        transform.position -= new Vector3(moveSpeed * Time.deltaTime, 0, 0);
    }

    public void Damage(float damage)
    {
        curHealth -= damage;

        //맞으면 넉백
        if (curHealth > 0 && !IsBoss)
        {
            Knockback();
        }

        else if (curHealth <= 0)  //체력이 0이하이면 사망
        {
            ParticleManager.Instance.playDeathEffect(transform.position);
            Destroy(gameObject);
        }

        ParticleManager.Instance.playHitEffect(transform.position);
    }

    private void Knockback()
    {
        knockback = true;
        knockbackStart = Time.time;

        Vector2 curPos = transform.position;
        Vector2 nextPos = Vector2.right * 0.3f;

        transform.position = curPos + nextPos;
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

    public void skillDamage(float damage)
    {
        curHealth -= damage;

        //맞으면 넉백
        if (curHealth > 0)
        {
            skillKnockback();
        }

        if (curHealth <= 0)  //체력이 0이하이면 사망
        {
            ParticleManager.Instance.playDeathEffect(transform.position);
            Destroy(gameObject);
        }

        ParticleManager.Instance.playHitEffect(transform.position);
    }

    private void skillKnockback()
    {
        skillknockback = true;
        knockbackStart = Time.time;
        rigid.velocity = new Vector2(10 * Vector2.right.x,rigid.velocity.y);
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
        if (collision.gameObject.CompareTag("EndLine") && !IsBoss)
        {
            InGameManager.Instance.EnemyPass(InGameManager.Instance.Hp);
            Destroy(gameObject);
        }
        else if(collision.gameObject.CompareTag("EndLine") && IsBoss)
        {
            InGameManager.Instance.Hp = 0;
            InGameManager.Instance.EnemyPass(InGameManager.Instance.Hp);
            Destroy(gameObject);
        }
    }
}