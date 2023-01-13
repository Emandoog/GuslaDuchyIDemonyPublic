using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "EnemyStats", menuName = "Enemy/EnemyStats", order = 1)]
public class SOEnemyStats : ScriptableObject
{
    public string enemyName;
    public float speed;
    public float maxLife;
    public float currentLife;
    public float accuracy;
    public float attackDamage1;
    public float attackDamage2;
    public float luck;
}
