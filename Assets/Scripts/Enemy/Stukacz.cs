using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stukacz : MonoBehaviour
{
    private GameObject _CombatZone;
    public SOEnemyStats _EnemyStats;
    public float target;
    public float damage;
    public float damageStorageOne;
    public float damageStorageTwo;
    public string showEnemyOne;
    public string showEnemyTwo;
    public int crit;
    public int missed;
    public GameObject _SkillAnimator;
    private GameObject clone;
    



    private void Awake()
    {
        _CombatZone = GameObject.FindGameObjectWithTag("CombatZone");
    }
    private void Start()
    {
        _CombatZone = GameObject.FindGameObjectWithTag("CombatZone");
    }

    // Update is called once per frame

    public void StukaczAI()
    {
        target = Random.Range(1, 5);
        //damageStorageOne = DamageCalculation(_EnemyStats.accuracy,_EnemyStats.luck,_EnemyStats.attackDamage1);
        //damageStorageTwo = DamageCalculation(_EnemyStats.accuracy, _EnemyStats.luck, _EnemyStats.attackDamage1);
        //damage = damageStorageOne + damageStorageTwo;
        //_CombatZone.GetComponent<CombatHandler>().EnemyDealsDamageTwice(array,damageStorageOne,damageStorageTwo,true,false);
       //_CombatZone.GetComponent<CombatHandler>().EnemyDealsDamage(damage,true);
       damageStorageOne = DamageCalculation(_EnemyStats.accuracy, _EnemyStats.luck, _EnemyStats.attackDamage1);
       damageStorageTwo = DamageCalculation(_EnemyStats.accuracy, _EnemyStats.luck, _EnemyStats.attackDamage1);
       _CombatZone.GetComponent<CombatHandler>().EnemyDealsDamageTwice(damageStorageOne, damageStorageTwo, true, false,missed);
        


        _CombatZone.GetComponentInChildren<CombatSounds>().PickSoundEffect(5);

    }

    public float DamageCalculation(float accuracy = 0, float luck = 0, float spellDamage = 0)  // kalkulowanie obrazen
    {
        float Damage1 = 0, minDamage = spellDamage - (spellDamage * 0.3f), maxDamage = spellDamage + (spellDamage * 0.3f);
        int minDamage2 = Mathf.RoundToInt(minDamage), maxDamage2 = Mathf.RoundToInt(maxDamage), chceck = Random.Range(minDamage2, maxDamage2);
        int accuracyCheck = Random.Range(0, 101);
        int Damage=0;
        float crit = 5 + luck;
        int critCheck = Random.Range(0, 101);
        
        
            if (accuracyCheck < accuracy)
            {
                if (critCheck < crit)
                {
                    crit++;
                    Damage1 = chceck * 1.5f;
                    Damage = Mathf.RoundToInt(Damage1);
                    showEnemyOne = "Stukacz uderza krytycznie za ";
                    return Damage;
                }
                else
                {

                    Damage1 = chceck;
                    Damage = Mathf.RoundToInt(Damage1);
                    showEnemyOne = "Stukacz udzerza za ";
                    return Damage;

                }
            }
            else
            {
                missed++;      
                Damage = 0;
                showEnemyOne = "Stukacz nie trafia" ;
                return Damage;
            }

        }
        
    }
    

