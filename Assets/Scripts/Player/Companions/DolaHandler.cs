using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DolaHandler : MonoBehaviour
{
    public SoCompanion _CompanionStats;
    private GameObject _CombatZone;
    public GameObject _SkillAnimator;
    public float CoolDown = 1;
    public string show ;
  
    void Start()
    {
        _CombatZone = GameObject.FindGameObjectWithTag("CombatZone");
        _CompanionStats.currentLife = _CompanionStats.maxLife;
        //CoolDown = 0;
        Debug.Log("Saimon says CD is " + CoolDown+" at first");
    }

   

    public float playerAttack(int action, int target) // potzrbuje satystyk przeciwnika
    {
        float damage;
        float SkillEffectTarget;
        
        GameObject clone;
        switch (action)
        {
            case 0:
                // podstawowy atak
                //link to companion stats 
                damage = DamageCalculation(_CompanionStats.accBasickAttack, _CompanionStats.luck, _CompanionStats.basickAttack);
                SkillEffectTarget = _CombatZone.GetComponent<CombatHandler>().CompanionDealsDamage(damage,true,false,show);
                Debug.Log("Companion Trafa oraz animuje "+ SkillEffectTarget);
                if (SkillEffectTarget == 1) 
                {
                   clone = Instantiate(_SkillAnimator, _CombatZone.GetComponent<CombatHandler>()._EnemyPosition1.transform.position,Quaternion.identity);
                   clone.transform.parent =  _CombatZone.GetComponent<CombatHandler>()._EnemyPosition1.transform;
                   clone.GetComponent<SpriteRenderer>().sortingOrder = _CombatZone.GetComponent<CombatHandler>()._EnemyPosition1.GetComponentInChildren<SpriteRenderer>().sortingOrder + 1;
                   clone.GetComponent<DolaSkillEffect>().PlayAnimation(0);
                   // _CombatZone.GetComponent<CombatHandler>()._EnemyPosition1.transform.position;
                }
                if (SkillEffectTarget == 2)
                {
                    clone = Instantiate(_SkillAnimator, _CombatZone.GetComponent<CombatHandler>()._EnemyPosition2.transform.position, Quaternion.identity);
                    clone.transform.parent = _CombatZone.GetComponent<CombatHandler>()._EnemyPosition2.transform;
                    clone.GetComponent<SpriteRenderer>().sortingOrder = _CombatZone.GetComponent<CombatHandler>()._EnemyPosition2.GetComponentInChildren<SpriteRenderer>().sortingOrder +1;
                    clone.GetComponent<DolaSkillEffect>().PlayAnimation(0);
                    // _CombatZone.GetComponent<CombatHandler>()._EnemyPosition1.transform.position;
                }
                if (SkillEffectTarget == 3)
                {
                    clone = Instantiate(_SkillAnimator, _CombatZone.GetComponent<CombatHandler>()._EnemyPosition3.transform.position, Quaternion.identity);
                    clone.transform.parent = _CombatZone.GetComponent<CombatHandler>()._EnemyPosition3.transform;
                    clone.GetComponent<SpriteRenderer>().sortingOrder = _CombatZone.GetComponent<CombatHandler>()._EnemyPosition3.GetComponentInChildren<SpriteRenderer>().sortingOrder +1;
                    clone.GetComponent<DolaSkillEffect>().PlayAnimation(0);
                    // _CombatZone.GetComponent<CombatHandler>()._EnemyPosition1.transform.position;
                }
                if (SkillEffectTarget == 4)
                {
                    clone = Instantiate(_SkillAnimator, _CombatZone.GetComponent<CombatHandler>()._EnemyPosition4.transform.position, Quaternion.identity);
                    clone.transform.parent = _CombatZone.GetComponent<CombatHandler>()._EnemyPosition4.transform;
                    clone.GetComponent<SpriteRenderer>().sortingOrder = _CombatZone.GetComponent<CombatHandler>()._EnemyPosition4.GetComponentInChildren<SpriteRenderer>().sortingOrder + 1;
                    clone.GetComponent<DolaSkillEffect>().PlayAnimation(0);
                    // _CombatZone.GetComponent<CombatHandler>()._EnemyPosition1.transform.position;
                }

                //damage =  DamageCalculation(_CompanionStats.accBasickAttack, _CompanionStats.luck,_CompanionStats.basickAttack);
                //Debug.Log(damage);
               _CompanionStats.coolDown1 -= 1;
                //Debug.Log("Saimon says CD is  " + CoolDown+" after attack");
                _CombatZone.GetComponentInChildren<CombatSounds>().PickSoundEffect(2);
                return damage;
                
            case 1:
                // umiejetnosc
                // leczenie sojusznika
                //play animation
               
                damage = DamageCalculation(_CompanionStats.accSkillAttack,_CompanionStats.luck, _CompanionStats.skillAttack);
                SkillEffectTarget = _CombatZone.GetComponent<CombatHandler>().CompanionHeals(damage);
                if (SkillEffectTarget == 1)
                {
                    clone = Instantiate(_SkillAnimator, _CombatZone.GetComponent<CombatHandler>()._CompanionPosition1.transform.position, Quaternion.identity);
                    clone.transform.parent = _CombatZone.GetComponent<CombatHandler>()._CompanionPosition1.transform;
                    clone.GetComponent<SpriteRenderer>().sortingOrder = _CombatZone.GetComponent<CombatHandler>()._CompanionPosition1.GetComponentInChildren<SpriteRenderer>().sortingOrder + 1;
                    clone.GetComponent<DolaSkillEffect>().PlayAnimation(1);
                    // _CombatZone.GetComponent<CombatHandler>()._EnemyPosition1.transform.position;
                }
                if (SkillEffectTarget == 2)
                {
                    clone = Instantiate(_SkillAnimator, _CombatZone.GetComponent<CombatHandler>()._CompanionPosition2.transform.position, Quaternion.identity);
                    clone.transform.parent = _CombatZone.GetComponent<CombatHandler>()._CompanionPosition2.transform;
                    clone.GetComponent<SpriteRenderer>().sortingOrder = _CombatZone.GetComponent<CombatHandler>()._CompanionPosition2.GetComponentInChildren<SpriteRenderer>().sortingOrder + 1;
                    clone.GetComponent<DolaSkillEffect>().PlayAnimation(1);
                    // _CombatZone.GetComponent<CombatHandler>()._EnemyPosition1.transform.position;
                }
                if (SkillEffectTarget == 3)
                {
                    clone = Instantiate(_SkillAnimator, _CombatZone.GetComponent<CombatHandler>()._CompanionPosition3.transform.position, Quaternion.identity);
                    clone.transform.parent = _CombatZone.GetComponent<CombatHandler>()._CompanionPosition3.transform;
                    clone.GetComponent<SpriteRenderer>().sortingOrder = _CombatZone.GetComponent<CombatHandler>()._CompanionPosition3.GetComponentInChildren<SpriteRenderer>().sortingOrder + 1;
                    clone.GetComponent<DolaSkillEffect>().PlayAnimation(1);
                    // _CombatZone.GetComponent<CombatHandler>()._EnemyPosition1.transform.position;
                }
                if (SkillEffectTarget == 4)
                {
                    clone = Instantiate(_SkillAnimator, _CombatZone.GetComponent<CombatHandler>()._CompanionPosition4.transform.position, Quaternion.identity);
                    clone.transform.parent = _CombatZone.GetComponent<CombatHandler>()._CompanionPosition4.transform;
                    clone.GetComponent<SpriteRenderer>().sortingOrder = _CombatZone.GetComponent<CombatHandler>()._CompanionPosition4.GetComponentInChildren<SpriteRenderer>().sortingOrder + 1;
                    clone.GetComponent<DolaSkillEffect>().PlayAnimation(1);
                    // _CombatZone.GetComponent<CombatHandler>()._EnemyPosition1.transform.position;
                }

                _CompanionStats.coolDown1 = 1;
                // Debug.Log("Saimon says CD is " + CoolDown);
                _CombatZone.GetComponentInChildren<CombatSounds>().PickSoundEffect(1);
                return damage;

            case 2:

   
                if (_CombatZone.GetComponent<CombatHandler>()._CompanionInCombat1 != null) 
                {
                    damage = DamageCalculation(_CompanionStats.accSkillAttack, _CompanionStats.luck, _CompanionStats.skillAttack);
                    _CombatZone.GetComponent<CombatHandler>()._CompanionInCombat1.GetComponent<CompanionHandler>().TakeDamage(-damage);

                    clone = Instantiate(_SkillAnimator, _CombatZone.GetComponent<CombatHandler>()._CompanionInCombat1.transform.position, Quaternion.identity);
                    clone.transform.parent = _CombatZone.GetComponent<CombatHandler>()._CompanionInCombat1.transform;
                    clone.GetComponent<SpriteRenderer>().sortingOrder = _CombatZone.GetComponent<CombatHandler>()._CompanionInCombat1.GetComponentInChildren<SpriteRenderer>().sortingOrder + 1;
                    clone.GetComponent<DolaSkillEffect>().PlayAnimation(1);
                }
                if (_CombatZone.GetComponent<CombatHandler>()._CompanionInCombat2 != null) 
                {
                    damage = DamageCalculation(_CompanionStats.accSkillAttack, _CompanionStats.luck, _CompanionStats.skillAttack);
                    _CombatZone.GetComponent<CombatHandler>()._CompanionInCombat2.GetComponent<CompanionHandler>().TakeDamage(-damage);

                    clone = Instantiate(_SkillAnimator, _CombatZone.GetComponent<CombatHandler>()._CompanionInCombat2.transform.position, Quaternion.identity);
                    clone.transform.parent = _CombatZone.GetComponent<CombatHandler>()._CompanionInCombat2.transform;
                    clone.GetComponent<SpriteRenderer>().sortingOrder = _CombatZone.GetComponent<CombatHandler>()._CompanionInCombat2.GetComponentInChildren<SpriteRenderer>().sortingOrder + 1;
                    clone.GetComponent<DolaSkillEffect>().PlayAnimation(1);
                }
                if (_CombatZone.GetComponent<CombatHandler>()._CompanionInCombat3 != null)
                {
                    damage = DamageCalculation(_CompanionStats.accSkillAttack, _CompanionStats.luck, _CompanionStats.skillAttack);
                    _CombatZone.GetComponent<CombatHandler>()._CompanionInCombat3.GetComponent<CompanionHandler>().TakeDamage(-damage);

                    clone = Instantiate(_SkillAnimator, _CombatZone.GetComponent<CombatHandler>()._CompanionInCombat3.transform.position, Quaternion.identity);
                    clone.transform.parent = _CombatZone.GetComponent<CombatHandler>()._CompanionInCombat3.transform;
                    clone.GetComponent<SpriteRenderer>().sortingOrder = _CombatZone.GetComponent<CombatHandler>()._CompanionInCombat3.GetComponentInChildren<SpriteRenderer>().sortingOrder + 1;
                    clone.GetComponent<DolaSkillEffect>().PlayAnimation(1);
                }
                if (_CombatZone.GetComponent<CombatHandler>()._CompanionInCombat4 != null)
                {
                    damage = DamageCalculation(_CompanionStats.accSkillAttack, _CompanionStats.luck, _CompanionStats.skillAttack);
                    _CombatZone.GetComponent<CombatHandler>()._CompanionInCombat4.GetComponent<CompanionHandler>().TakeDamage(-damage);

                    clone = Instantiate(_SkillAnimator, _CombatZone.GetComponent<CombatHandler>()._CompanionInCombat4.transform.position, Quaternion.identity);
                    clone.transform.parent = _CombatZone.GetComponent<CombatHandler>()._CompanionInCombat4.transform;
                    clone.GetComponent<SpriteRenderer>().sortingOrder = _CombatZone.GetComponent<CombatHandler>()._CompanionInCombat4.GetComponentInChildren<SpriteRenderer>().sortingOrder + 1;
                    clone.GetComponent<DolaSkillEffect>().PlayAnimation(1);
                }
                _CombatZone.GetComponentInChildren<CombatSounds>().PickSoundEffect(1);
                gameObject.GetComponentInChildren<DolaSkillEffect>().DestroyObject();
                gameObject.GetComponentInChildren<DolaSkillEffect>().DestroyObject();
                clone = Instantiate(_SkillAnimator, _CombatZone.GetComponent<CombatHandler>().gameObject.transform.position, Quaternion.identity);
                //clone.transform.parent = _CombatZone.GetComponent<CombatHandler>()._CompanionPosition4.transform;
                clone.GetComponent<Animator>().enabled = true;
                clone.GetComponent<DolaSkillEffect>().enabled = true;
                clone.GetComponent<SpriteRenderer>().sortingOrder = 5;
                clone.GetComponent<DolaSkillEffect>().PlayAnimation(2);
                gameObject.GetComponent<CompanionHandler>().TakeDamage(_CompanionStats.currentLife);
                break;
        }
        return 0;

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
        int minDamage2 = Mathf.RoundToInt(minDamage) , maxDamage2 = Mathf.RoundToInt(maxDamage) , chceck = Random.Range(minDamage2,maxDamage2);        
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
                show = "Dola uderza krytycznie za ";
                return Damage;
            }
            else
            {

                Damage1 = chceck;
                Damage = Mathf.RoundToInt(Damage1);
                show = "Dola zada³a ";
               
                return Damage;

            }
        }
        else
        {
            show = "Dola nie trafi³a. ";
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

            return true;

        }
        if (action == 2)
        {
            return true;
        }
        return false;

    }
}
