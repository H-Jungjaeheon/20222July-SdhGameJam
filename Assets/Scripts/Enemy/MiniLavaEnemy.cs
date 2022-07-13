using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniLavaEnemy : MonoBehaviour
{
    [SerializeField] private EnemyStat enemyStat;
    [SerializeField] private float hp;
    // Start is called before the first frame update
    void Start()
    {
        hp = enemyStat.Hp;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
