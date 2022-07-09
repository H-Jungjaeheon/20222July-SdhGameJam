using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnergySword : MonoBehaviour
{
    [SerializeField] private GameObject Player;
    [SerializeField] private float Speed;
    [SerializeField] private float Damage;
    private void Awake() => Player = GameObject.Find("Player");
    void Update() => Moving();
    private void Moving() => transform.position += new Vector3(Speed * Time.deltaTime, 0, 0);
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
            collision.gameObject.GetComponent<tanker>().Damage(Player.GetComponent<Player>().BasicAttackDamage * Damage); //이거 다 적 상속으로 바꿔서 넣기
        else if (collision.gameObject.CompareTag("ObjDestroy"))
            Destroy(gameObject);
    }
}
