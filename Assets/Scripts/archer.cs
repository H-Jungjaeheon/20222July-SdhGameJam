using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class archer : MonoBehaviour
{
    [SerializeField] private GameObject arrow;

    [SerializeField] private float baseHealth;
    [SerializeField] private float moveSpeed;
    [SerializeField] private float targetingDistance;

    [SerializeField] private Transform arrowPos;

    [SerializeField] private LayerMask creatureLayer;

    private float curHealth;
    private float knockbackStart;

    private bool isTargeting;
    private bool isFreeze;
    private bool canMove = true;
    private bool knockback;
    private bool skillknockback;

    Rigidbody2D rigid;

    private void OnEnable()
    {
        curHealth = baseHealth;
    }

    private void Awake()
    {
        curHealth = baseHealth;
        rigid = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        CheckKnockback();
        CheckTargeting();
        Move();
        Attack();
    }

    private void Move()
    {
        if (!canMove || isFreeze || knockback)
            return;

        Vector2 curPos = transform.position;
        Vector2 nextPos = Vector2.left * moveSpeed * Time.deltaTime;

        transform.position = curPos + nextPos;
    }

    private void CheckTargeting()
    {
        isTargeting = Physics2D.Raycast(transform.position,Vector2.left,targetingDistance, creatureLayer);
    }

    private void Attack()
    {
        if(!isTargeting)
        {
            canMove = true;
            return;
        }

        canMove = false;
        Instantiate(arrow, arrowPos.position, Quaternion.identity);
    }

    public void Damage(float damage)
    {
        curHealth -= damage;

        //������ �˹�
        if (curHealth > 0)
        {
            Knockback();
        }

        if (curHealth <= 0)  //ü���� 0�����̸� ���
        {
            ParticleManager.Instance.playDeathEffect(transform.position);
            Destroy(gameObject);
        }

        ParticleManager.Instance.playHitEffect(transform.position);
    }

    public void skillDamage(float damage)
    {
        curHealth -= damage;

        //������ �˹�
        if (curHealth > 0)
        {
            skillKnockback();
        }

        if (curHealth <= 0)  //ü���� 0�����̸� ���
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
        if(isFreeze)
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
        //0.1�� �Ŀ� �˹� ����
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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("EndLine"))
        {
            Destroy(gameObject);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;

        Gizmos.DrawLine(transform.position, new Vector2((transform.position.x + targetingDistance * -1), transform.position.y));
    }
}