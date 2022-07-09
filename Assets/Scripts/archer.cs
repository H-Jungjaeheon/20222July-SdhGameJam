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

    private bool isTargeting;
    private bool canMove = true;

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
        CheckTargeting();
        Move();
        Attack();
    }

    private void Move()
    {
        if (!canMove)
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

        if (curHealth <= 0)  //체력이 0이하이면 사망
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

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;

        Gizmos.DrawLine(transform.position, new Vector2((transform.position.x + targetingDistance * -1), transform.position.y));
    }
}
