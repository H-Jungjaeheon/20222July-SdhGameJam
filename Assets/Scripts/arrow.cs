using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class arrow : MonoBehaviour
{
    private void Update()
    {
        Move();
    }

    private void Move()
    {
        Vector2 curPos = transform.position;
        Vector2 nextPos = Vector2.left * 10 * Time.deltaTime;

        transform.position = curPos + nextPos;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("EndLine"))
        {
            Destroy(gameObject);
        }
        if (collision.gameObject.CompareTag("Creature"))
        {
            Destroy(gameObject);
        }
    }
}
