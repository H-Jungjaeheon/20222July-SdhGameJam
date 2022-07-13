using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Enemy Stat", menuName = "Scriptable Object/Enemy", order = int.MaxValue)]

public class EnemyStat : ScriptableObject
{
    [SerializeField] private float hp;
    public float Hp => hp;

    [SerializeField] private float speed;
    public float Speed => speed;
}
