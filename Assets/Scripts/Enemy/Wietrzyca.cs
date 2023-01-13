using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wietrzyca : MonoBehaviour
{
    private GameObject _CombatZone;
    public float damage;
    public bool isWaiting = true;
    public float target;
    public GameObject _SkillAnimator;
    public SOEnemyStats _EnemyStats;
    public string showEnemy;

    private void Start()
    {
        _CombatZone = GameObject.FindGameObjectWithTag("CombatZone");
        
    }
    public void WietrzycaAI()
    {

        float SkillEffectTarget;
        GameObject clone;

        damage = DamageCalculation(_EnemyStats.accuracy,_EnemyStats.luck, _EnemyStats.attackDamage1);
        SkillEffectTarget = _CombatZone.GetComponent<CombatHandler>().EnemyDealsDamage(damage,true,0,showEnemy);
        
        
        if (SkillEffectTarget == 1)
        {
            clone = Instantiate(_SkillAnimator, _CombatZone.GetComponent<CombatHandler>()._CompanionPosition1.transform.position, Quaternion.identity);
            clone.transform.parent = _CombatZone.GetComponent<CombatHandler>()._CompanionPosition1.transform;
            clone.GetComponent<SpriteRenderer>().sortingOrder = _CombatZone.GetComponent<CombatHandler>()._CompanionPosition1.GetComponentInChildren<SpriteRenderer>().sortingOrder + 1;
            clone.GetComponent<WietrzycaSkillEffect>().PlayAnimation(0);
            // _CombatZone.GetComponent<CombatHandler>()._EnemyPosition1.transform.position;
        }
        if (SkillEffectTarget == 2)
        {
            clone = Instantiate(_SkillAnimator, _CombatZone.GetComponent<CombatHandler>()._CompanionPosition2.transform.position, Quaternion.identity);
            clone.transform.parent = _CombatZone.GetComponent<CombatHandler>()._CompanionPosition2.transform;
            clone.GetComponent<SpriteRenderer>().sortingOrder = _CombatZone.GetComponent<CombatHandler>()._CompanionPosition2.GetComponentInChildren<SpriteRenderer>().sortingOrder + 1;
            clone.GetComponent<WietrzycaSkillEffect>().PlayAnimation(0);
            // _CombatZone.GetComponent<CombatHandler>()._EnemyPosition1.transform.position;
        }
        if (SkillEffectTarget == 3)
        {
            clone = Instantiate(_SkillAnimator, _CombatZone.GetComponent<CombatHandler>()._CompanionPosition3.transform.position, Quaternion.identity);
            clone.transform.parent = _CombatZone.GetComponent<CombatHandler>()._CompanionPosition3.transform;
            clone.GetComponent<SpriteRenderer>().sortingOrder = _CombatZone.GetComponent<CombatHandler>()._CompanionPosition3.GetComponentInChildren<SpriteRenderer>().sortingOrder + 1;
            clone.GetComponent<WietrzycaSkillEffect>().PlayAnimation(0);
            // _CombatZone.GetComponent<CombatHandler>()._EnemyPosition1.transform.position;
        }
        if (SkillEffectTarget == 4)
        {
            clone = Instantiate(_SkillAnimator, _CombatZone.GetComponent<CombatHandler>()._CompanionPosition4.transform.position, Quaternion.identity);
            clone.transform.parent = _CombatZone.GetComponent<CombatHandler>()._CompanionPosition4.transform;
            clone.GetComponent<SpriteRenderer>().sortingOrder = _CombatZone.GetComponent<CombatHandler>()._CompanionPosition4.GetComponentInChildren<SpriteRenderer>().sortingOrder + 1;
            clone.GetComponent<WietrzycaSkillEffect>().PlayAnimation(0);
            // _CombatZone.GetComponent<CombatHandler>()._EnemyPosition1.transform.position;
        }

        _CombatZone.GetComponentInChildren<CombatSounds>().PickSoundEffect(3);
        //_CombatZone..GetComponent<CombatHandler>().active





    }
    public float DamageCalculation(float accuracy = 0, float luck = 0, float spellDamage = 0)  // kalkulowanie obrazen
    {
        float Damage1 = 0, minDamage = spellDamage - (spellDamage * 0.3f), maxDamage = spellDamage + (spellDamage * 0.3f);
        int minDamage2 = Mathf.RoundToInt(minDamage), maxDamage2 = Mathf.RoundToInt(maxDamage), chceck = Random.Range(minDamage2, maxDamage2);
        int accuracyCheck = Random.Range(0, 101);
        int Damage;
        float crit = 5 + luck;
        int critCheck = Random.Range(0, 101);
        if (accuracyCheck < accuracy)
        {
            if (critCheck < crit)
            {
                Damage1 = chceck * 1.5f;
                Damage = Mathf.RoundToInt(Damage1);
                showEnemy = "Wietrzyca uderza krytycznie za ";
                return Damage;
            }
            else
            {

                Damage1 = chceck;
                Damage = Mathf.RoundToInt(Damage1);
                showEnemy = "Wietrzyca uderza za ";

                return Damage;

            }
        }
        else
        {
            showEnemy = "Wietrzyca nie trafi³a ";
            Damage = 0;

        }

        return Damage;
    }
}
