using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class middleboss : MonoBehaviour
{
    [SerializeField] private float baseHealth;
    [SerializeField] private float moveSpeed;
    [SerializeField] private float skillCooltime;

    [SerializeField] private int spawnEnemyCount;

    [SerializeField] private GameObject spawnEnemyPrefab;

    private float curHealth;
    private float knockbackStart;
    private float lastSkill = 0;

    private int spawnEnemyLeft;

    private bool isFreeze;
    private bool canMove = true;
    private bool canSkill = true;
    private bool knockback;
    private bool skillknockback;

    Rigidbody2D rigid;

    Animator anim;

    private void OnEnable()
    {
        curHealth = baseHealth;
    }

    private void Awake()
    {
        curHealth = baseHealth;
        rigid = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        Move();
        Skill();
        CheckKnockback();
    }

    private void Move()
    {
        if (isFreeze || !canMove || knockback)
            return;

        Vector2 curPos = transform.position;
        Vector2 nextPos = Vector2.left * moveSpeed * Time.deltaTime;

        transform.position = curPos + nextPos;
    }

    private void Skill()
    {
        if(Time.time >= (lastSkill + skillCooltime) && canSkill)
        {
            canMove = false;
            canSkill = false;
            anim.SetBool("isSkill",true);
        }
    }

    private void spawnEnemy()
    {
        spawnEnemyLeft = spawnEnemyCount;
        canMove = true;
        canSkill = true;
        lastSkill = Time.time;
        anim.SetBool("isSkill", false);

        float spawnEnemyYPos = (transform.position.y >= 0) ? -3.7f : 0.5f;

        Instantiate(spawnEnemyPrefab, new Vector2(10, spawnEnemyYPos), Quaternion.identity);
        spawnEnemyLeft--;
        StartCoroutine(enemySpawn(spawnEnemyYPos));
    }

    IEnumerator enemySpawn(float enemyYPos)
    {
        yield return new WaitForSecondsRealtime(0.75f);

        Instantiate(spawnEnemyPrefab, new Vector2(10, enemyYPos), Quaternion.identity);
        spawnEnemyLeft--;

        if(spawnEnemyLeft > 0)
        {
            StartCoroutine(enemySpawn(enemyYPos));
        }
    }

    public void Damage(float damage)
    {
        curHealth -= damage;

        //맞으면 넉백
        if (curHealth > 0)
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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("EndLine"))
        {
            Destroy(gameObject);
        }
    }
}
