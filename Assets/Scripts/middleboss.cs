using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class middleboss : tanker
{
    [SerializeField] private float skillCooltime;

    [SerializeField] private int spawnEnemyCount;

    [SerializeField] private GameObject spawnEnemyPrefab;

    private float lastSkill = 0;

    private int spawnEnemyLeft;

    private bool canMove = true;
    private bool canSkill = true;

    Animator anim;

    protected override void Awake()
    {
        base.Awake();
        anim = GetComponent<Animator>();
    }

    protected override void Update()
    {
        base.Update();
        Skill();
    }

    protected override void Move()
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
        //spawnEnemyLeft = spawnEnemyCount;
        //canMove = true;
        //canSkill = true;
        //lastSkill = Time.time;
        //anim.SetBool("isSkill", false);

        //float spawnEnemyYPos = (transform.position.y >= 0) ? -3.7f : 0.5f;

        //Instantiate(spawnEnemyPrefab, new Vector2(10, spawnEnemyYPos), Quaternion.identity);
        //spawnEnemyLeft--;
        //StartCoroutine(enemySpawn(spawnEnemyYPos));
        anim.SetBool("isSkill", false);
    }

    IEnumerator enemySpawn(float enemyYPos)
    {
        //yield return new WaitForSecondsRealtime(0.75f);

        //Instantiate(spawnEnemyPrefab, new Vector2(10, enemyYPos), Quaternion.identity);
        //spawnEnemyLeft--;

        //if (spawnEnemyLeft > 0)
        //{
        //    StartCoroutine(enemySpawn(enemyYPos));
        //}
        yield return null;
    }

    protected override void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("EndLine"))
        {
            Destroy(gameObject);
        }
    }
}
