using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tanker : MonoBehaviour
{
    [SerializeField] private float baseHealth;
    [SerializeField] private float moveSpeed;

    [SerializeField] private float curHealth;
    private float knockbackStart;

    private bool isFreeze;
    private bool knockback;

    private void OnEnable()
    {
        curHealth = baseHealth;
    }

    private void Awake()
    {
        curHealth = baseHealth;
    }

    private void Update()
    {
        Move();
        CheckKnockback();
    }

    private void Move()
    {
        if (isFreeze)
            return;

        Vector2 curPos = transform.position;
        Vector2 nextPos = Vector2.left * moveSpeed * Time.deltaTime;

        transform.position = curPos + nextPos;
    }

    public void Damage(float damage)
    {
        curHealth -= damage;

        //맞으면 넉백
        if (curHealth > 0)
        {
            Knockback();
        }

        if (curHealth <= 0)  //체력이 0이하이면 사망
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