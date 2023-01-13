using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "EnemyAttack", menuName = "Enemy/EnemyAttack", order = 1)]

public class SOEnemyAttack : ScriptableObject
{
    private bool isWaiting =true;
    private float damage;

    public float GrochowaBaba()
    {
       //random target from aviable targets
        if (isWaiting == true)
        {
            // nothing 
            isWaiting = false;

        }
        else if (isWaiting == false)
        {
            damage = 30;
            isWaiting = true;
        }
        return damage;
    }
}
