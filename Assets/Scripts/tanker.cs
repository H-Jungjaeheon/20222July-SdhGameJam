using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tanker : MonoBehaviour
{
    [SerializeField] private float baseHealth;
    [SerializeField] private float moveSpeed;

    private float curHealth;

    Rigidbody2D rigid;

    private void OnEnable()
    {
        curHealth = baseHealth;
    }

    private void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        Vector2 curPos = transform.position;
        Vector2 nextPos = Vector2.left * moveSpeed * Time.deltaTime;

        transform.position = curPos + nextPos;
    }

    public void Damage(float damage)
    {
        curHealth -= damage;

        if(curHealth <= 0)  //체력이 0이하이면 사망
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("EndLine"))
        {
            Destroy(gameObject);
        }
    }
}