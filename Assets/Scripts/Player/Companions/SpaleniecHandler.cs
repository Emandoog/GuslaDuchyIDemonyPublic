using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaleniecHandler : MonoBehaviour
{
    public SoCompanion _CompanionStats;
    private GameObject _CombatZone;
    public string show;
    public GameObject _SkillAnimator;
    private GameObject clone;

    void Start()
    {
        _CombatZone = GameObject.FindGameObjectWithTag("CombatZone");
        _CompanionStats.currentLife = _CompanionStats.maxLife;
    }

    public float playerAttack(int action, int target)
    {
        float damage = 0;
        float damageTwo = 0;
        float SkillEffectTarget=0;
        float SkillEffectTargetTwo=0;
        float damgeToSelf=0;
        int intdamgeToSelf=0;

        switch (action)
        {
            case 0:
                damage = DamageCalculation(_CompanionStats.accBasickAttack, _CompanionStats.luck, _CompanionStats.basickAttack);
                SkillEffectTarget = _CombatZone.GetComponent<CombatHandler>().CompanionDealsDamage(damage, true,true,show);
                if (SkillEffectTarget == 1)
                {
                    clone = Instantiate(_SkillAnimator, _CombatZone.GetComponent<CombatHandler>()._EnemyPosition1.transform.position, Quaternion.identity);
                    clone.transform.parent = _CombatZone.GetComponent<CombatHandler>()._EnemyPosition1.transform;
                    clone.GetComponent<SpriteRenderer>().sortingOrder = _CombatZone.GetComponent<CombatHandler>()._EnemyPosition1.GetComponentInChildren<SpriteRenderer>().sortingOrder + 1;
                    clone.GetComponent<SpaleniecSkillEffect>().PlayAnimation(0);
                    // _CombatZone.GetComponent<CombatHandler>()._EnemyPosition1.transform.position;
                }
                if (SkillEffectTarget == 2)
                {
                    clone = Instantiate(_SkillAnimator, _CombatZone.GetComponent<CombatHandler>()._EnemyPosition2.transform.position, Quaternion.identity);
                    clone.transform.parent = _CombatZone.GetComponent<CombatHandler>()._EnemyPosition2.transform;
                    clone.GetComponent<SpriteRenderer>().sortingOrder = _CombatZone.GetComponent<CombatHandler>()._EnemyPosition2.GetComponentInChildren<SpriteRenderer>().sortingOrder + 1;
                    clone.GetComponent<SpaleniecSkillEffect>().PlayAnimation(0);
                    // _CombatZone.GetComponent<CombatHandler>()._EnemyPosition1.transform.position;
                }
                if (SkillEffectTarget == 3)
                {
                    clone = Instantiate(_SkillAnimator, _CombatZone.GetComponent<CombatHandler>()._EnemyPosition3.transform.position, Quaternion.identity);
                    clone.transform.parent = _CombatZone.GetComponent<CombatHandler>()._EnemyPosition3.transform;
                    clone.GetComponent<SpriteRenderer>().sortingOrder = _CombatZone.GetComponent<CombatHandler>()._EnemyPosition3.GetComponentInChildren<SpriteRenderer>().sortingOrder + 1;
                    clone.GetComponent<SpaleniecSkillEffect>().PlayAnimation(0);
                    // _CombatZone.GetComponent<CombatHandler>()._EnemyPosition1.transform.position;
                }
                if (SkillEffectTarget == 4)
                {
                    clone = Instantiate(_SkillAnimator, _CombatZone.GetComponent<CombatHandler>()._EnemyPosition4.transform.position, Quaternion.identity);
                    clone.transform.parent = _CombatZone.GetComponent<CombatHandler>()._EnemyPosition4.transform;
                    clone.GetComponent<SpriteRenderer>().sortingOrder = _CombatZone.GetComponent<CombatHandler>()._EnemyPosition4.GetComponentInChildren<SpriteRenderer>().sortingOrder + 1;
                    clone.GetComponent<SpaleniecSkillEffect>().PlayAnimation(0);
                    _CombatZone.GetComponentInChildren<CombatSounds>().PickSoundEffect(2);
                    // _CombatZone.GetComponent<CombatHandler>()._EnemyPosition1.transform.position;
                }
                _CombatZone.GetComponentInChildren<CombatSounds>().PickSoundEffect(2);
                return damage;

            case 1:
                damage = DamageCalculation(_CompanionStats.accSkillAttack, _CompanionStats.luck, _CompanionStats.skillAttack);
                damageTwo = DamageCalculation(_CompanionStats.accSkillAttack, _CompanionStats.luck, _CompanionStats.skillAttack);
                SkillEffectTarget = _CombatZone.GetComponent<CombatHandler>().CompanionDealsDamage(damage, false, true, show);
                SkillEffectTargetTwo = _CombatZone.GetComponent<CombatHandler>().CompanionDealsDamage(damage, false, true, show,true);
                damgeToSelf = _CompanionStats.maxLife * 0.25f;
                intdamgeToSelf = Mathf.RoundToInt(damgeToSelf);
                takeDamage(intdamgeToSelf);

                if (SkillEffectTarget == 1)
                {
                    clone = Instantiate(_SkillAnimator, _CombatZone.GetComponent<CombatHandler>()._EnemyPosition1.transform.position, Quaternion.identity);
                    clone.transform.parent = _CombatZone.GetComponent<CombatHandler>()._EnemyPosition1.transform;
                    clone.GetComponent<SpriteRenderer>().sortingOrder = _CombatZone.GetComponent<CombatHandler>()._EnemyPosition1.GetComponentInChildren<SpriteRenderer>().sortingOrder + 1;
                    clone.GetComponent<SpaleniecSkillEffect>().PlayAnimation(1);
                    // _CombatZone.GetComponent<CombatHandler>()._EnemyPosition1.transform.position;
                }
                if (SkillEffectTarget == 2)
                {
                    clone = Instantiate(_SkillAnimator, _CombatZone.GetComponent<CombatHandler>()._EnemyPosition2.transform.position, Quaternion.identity);
                    clone.transform.parent = _CombatZone.GetComponent<CombatHandler>()._EnemyPosition2.transform;
                    clone.GetComponent<SpriteRenderer>().sortingOrder = _CombatZone.GetComponent<CombatHandler>()._EnemyPosition2.GetComponentInChildren<SpriteRenderer>().sortingOrder + 1;
                    clone.GetComponent<SpaleniecSkillEffect>().PlayAnimation(1);
                    // _CombatZone.GetComponent<CombatHandler>()._EnemyPosition1.transform.position;
                }
                if (SkillEffectTarget == 3)
                {
                    clone = Instantiate(_SkillAnimator, _CombatZone.GetComponent<CombatHandler>()._EnemyPosition3.transform.position, Quaternion.identity);
                    clone.transform.parent = _CombatZone.GetComponent<CombatHandler>()._EnemyPosition3.transform;
                    clone.GetComponent<SpriteRenderer>().sortingOrder = _CombatZone.GetComponent<CombatHandler>()._EnemyPosition3.GetComponentInChildren<SpriteRenderer>().sortingOrder + 1;
                    clone.GetComponent<SpaleniecSkillEffect>().PlayAnimation(1);
                    // _CombatZone.GetComponent<CombatHandler>()._EnemyPosition1.transform.position;
                }
                if (SkillEffectTarget == 4)
                {
                    clone = Instantiate(_SkillAnimator, _CombatZone.GetComponent<CombatHandler>()._EnemyPosition4.transform.position, Quaternion.identity);
                    clone.transform.parent = _CombatZone.GetComponent<CombatHandler>()._EnemyPosition4.transform;
                    clone.GetComponent<SpriteRenderer>().sortingOrder = _CombatZone.GetComponent<CombatHandler>()._EnemyPosition4.GetComponentInChildren<SpriteRenderer>().sortingOrder + 1;
                    clone.GetComponent<SpaleniecSkillEffect>().PlayAnimation(1);
                    // _CombatZone.GetComponent<CombatHandler>()._EnemyPosition1.transform.position;
                }
                if (SkillEffectTargetTwo == 1)
                {
                    clone = Instantiate(_SkillAnimator, _CombatZone.GetComponent<CombatHandler>()._EnemyPosition1.transform.position, Quaternion.identity);
                    clone.transform.parent = _CombatZone.GetComponent<CombatHandler>()._EnemyPosition1.transform;
                    clone.GetComponent<SpriteRenderer>().sortingOrder = _CombatZone.GetComponent<CombatHandler>()._EnemyPosition1.GetComponentInChildren<SpriteRenderer>().sortingOrder + 1;
                    clone.GetComponent<SpaleniecSkillEffect>().PlayAnimation(1);
                    // _CombatZone.GetComponent<CombatHandler>()._EnemyPosition1.transform.position;
                }
                if (SkillEffectTargetTwo == 2)
                {
                    clone = Instantiate(_SkillAnimator, _CombatZone.GetComponent<CombatHandler>()._EnemyPosition2.transform.position, Quaternion.identity);
                    clone.transform.parent = _CombatZone.GetComponent<CombatHandler>()._EnemyPosition2.transform;
                    clone.GetComponent<SpriteRenderer>().sortingOrder = _CombatZone.GetComponent<CombatHandler>()._EnemyPosition2.GetComponentInChildren<SpriteRenderer>().sortingOrder + 1;
                    clone.GetComponent<SpaleniecSkillEffect>().PlayAnimation(1);
                    // _CombatZone.GetComponent<CombatHandler>()._EnemyPosition1.transform.position;
                }
                if (SkillEffectTargetTwo == 3)
                {
                    clone = Instantiate(_SkillAnimator, _CombatZone.GetComponent<CombatHandler>()._EnemyPosition3.transform.position, Quaternion.identity);
                    clone.transform.parent = _CombatZone.GetComponent<CombatHandler>()._EnemyPosition3.transform;
                    clone.GetComponent<SpriteRenderer>().sortingOrder = _CombatZone.GetComponent<CombatHandler>()._EnemyPosition3.GetComponentInChildren<SpriteRenderer>().sortingOrder + 1;
                    clone.GetComponent<SpaleniecSkillEffect>().PlayAnimation(1);
                    // _CombatZone.GetComponent<CombatHandler>()._EnemyPosition1.transform.position;
                }
                if (SkillEffectTargetTwo == 4)
                {
                    clone = Instantiate(_SkillAnimator, _CombatZone.GetComponent<CombatHandler>()._EnemyPosition4.transform.position, Quaternion.identity);
                    clone.transform.parent = _CombatZone.GetComponent<CombatHandler>()._EnemyPosition4.transform;
                    clone.GetComponent<SpriteRenderer>().sortingOrder = _CombatZone.GetComponent<CombatHandler>()._EnemyPosition4.GetComponentInChildren<SpriteRenderer>().sortingOrder + 1;
                    clone.GetComponent<SpaleniecSkillEffect>().PlayAnimation(1);
                    // _CombatZone.GetComponent<CombatHandler>()._EnemyPosition1.transform.position;
                }
                _CombatZone.GetComponentInChildren<CombatSounds>().PickSoundEffect(4);
                return damage;

        }
        return damage;
    }
    public void takeDamage(int Damage) // otzrymywanie obrazen
    {
        _CompanionStats.currentLife = _CompanionStats.currentLife - Damage;
        if (_CompanionStats.currentLife <= 0)
        {
            _CompanionStats.isAlive = false;
            Destroy(gameObject);
        }
        Debug.Log(_CompanionStats.currentLife);
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
                show = "Spaleniec uderza krytycznie za ";
                return Damage;
            }
            else
            {

                Damage1 = chceck;
                Damage = Mathf.RoundToInt(Damage1);
                show = "Spaleniec uderza za ";
                return Damage;

            }
        }
        else
        {
            show = "Spaleniec nie trafia ";
            Damage = 0;

        }

        return Damage;
    }

    public bool CheckTargetOfAction(int action) // this is for checking if the skils targets companions or enemies
    {
        if (action == 0)
        {

            return false;

        }
        if (action == 1)
        {

            return false;

        }
        return false;

    }
}
