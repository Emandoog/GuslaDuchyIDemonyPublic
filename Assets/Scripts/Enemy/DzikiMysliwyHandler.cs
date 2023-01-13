using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DzikiMysliwyHandler : MonoBehaviour
{
    private GameObject _CombatZone;
    public SOEnemyStats _EnemyStats;
    public float damage;
    private bool isCharging = false;
    public float target=0;
    public string showEnemy;
    public int action;
    private bool chargeAoe = false;
    private bool chargeSingle = false;
    private int actionCheck;
    private int deBuff=0;

    private string comp;
    public GameObject _SkillAnimator;
    private GameObject clone;



    private void Awake()
    {
        _CombatZone = GameObject.FindGameObjectWithTag("CombatZone");
        
    }
    private void Start()
    {
        _CombatZone = GameObject.FindGameObjectWithTag("CombatZone");
        GameObject.FindGameObjectWithTag("Player").GetComponentInChildren<MusicHandler>().BossMusic();
    }
    public void DzikiMysliwyAI()
    {
        //Debug.Log("ale dlaczego"+ chargeAoe + chargeSingle+ isCharging);


        if (chargeAoe == true && isCharging == true)
        {
            
            chargeAoe = false;
            isCharging = false;
            chargeSingle = false;
            damage = DamageCalculation(_EnemyStats.accuracy, -6, _EnemyStats.attackDamage1 * 0.8f);
            
            if (_CombatZone.GetComponent<CombatHandler>()._CompanionInCombat1 != null)
            {
                _CombatZone.GetComponent<CombatHandler>().EnemyDealsDamage(damage, true, 1, showEnemy);
                clone = Instantiate(_SkillAnimator, _CombatZone.GetComponent<CombatHandler>()._CompanionPosition1.transform.position, Quaternion.identity);
                clone.transform.parent = _CombatZone.GetComponent<CombatHandler>()._CompanionPosition1.transform;
                clone.GetComponent<SpriteRenderer>().sortingOrder = _CombatZone.GetComponent<CombatHandler>()._CompanionPosition1.GetComponentInChildren<SpriteRenderer>().sortingOrder + 1;
                clone.GetComponent<DzikiMysliwySkillEffect>().PlayAnimation(1);

            }
            if (_CombatZone.GetComponent<CombatHandler>()._CompanionInCombat2 != null)
            {
                _CombatZone.GetComponent<CombatHandler>().EnemyDealsDamage(damage, true, 2, showEnemy);
                clone = Instantiate(_SkillAnimator, _CombatZone.GetComponent<CombatHandler>()._CompanionPosition2.transform.position, Quaternion.identity);
                clone.transform.parent = _CombatZone.GetComponent<CombatHandler>()._CompanionPosition2.transform;
                clone.GetComponent<SpriteRenderer>().sortingOrder = _CombatZone.GetComponent<CombatHandler>()._CompanionPosition2.GetComponentInChildren<SpriteRenderer>().sortingOrder + 1;
                clone.GetComponent<DzikiMysliwySkillEffect>().PlayAnimation(1);

            }
            if (_CombatZone.GetComponent<CombatHandler>()._CompanionInCombat3 != null)
            {
                _CombatZone.GetComponent<CombatHandler>().EnemyDealsDamage(damage, true, 3, showEnemy);
                clone = Instantiate(_SkillAnimator, _CombatZone.GetComponent<CombatHandler>()._CompanionPosition3.transform.position, Quaternion.identity);
                clone.transform.parent = _CombatZone.GetComponent<CombatHandler>()._CompanionPosition3.transform;
                clone.GetComponent<SpriteRenderer>().sortingOrder = _CombatZone.GetComponent<CombatHandler>()._CompanionPosition3.GetComponentInChildren<SpriteRenderer>().sortingOrder + 1;
                clone.GetComponent<DzikiMysliwySkillEffect>().PlayAnimation(1);


            }
            if (_CombatZone.GetComponent<CombatHandler>()._CompanionInCombat3 != null)
            {
                _CombatZone.GetComponent<CombatHandler>().EnemyDealsDamage(damage, true, 4, showEnemy);
                clone = Instantiate(_SkillAnimator, _CombatZone.GetComponent<CombatHandler>()._CompanionPosition4.transform.position, Quaternion.identity);
                clone.transform.parent = _CombatZone.GetComponent<CombatHandler>()._CompanionPosition4.transform;
                clone.GetComponent<SpriteRenderer>().sortingOrder = _CombatZone.GetComponent<CombatHandler>()._CompanionPosition4.GetComponentInChildren<SpriteRenderer>().sortingOrder + 1;
                clone.GetComponent<DzikiMysliwySkillEffect>().PlayAnimation(1);

            }
            _CombatZone.GetComponentInChildren<CombatSounds>().PickSoundEffect(6);


        }
        else if (isCharging == true && chargeSingle == true)
        {
           
            chargeAoe = false;
            isCharging = false;
            chargeSingle = false;
            damage = DamageCalculation(_EnemyStats.accuracy, -6, _EnemyStats.attackDamage1 * 1.2f);

            _CombatZone.GetComponent<CombatHandler>().EnemyDealsDamage(damage, true, target, showEnemy);
            if (target == 1)
            {

                clone = Instantiate(_SkillAnimator, _CombatZone.GetComponent<CombatHandler>()._CompanionPosition1.transform.position, Quaternion.identity);
                clone.transform.parent = _CombatZone.GetComponent<CombatHandler>()._CompanionPosition1.transform;
                clone.GetComponent<SpriteRenderer>().sortingOrder = _CombatZone.GetComponent<CombatHandler>()._CompanionPosition1.GetComponentInChildren<SpriteRenderer>().sortingOrder + 1;
                clone.GetComponent<DzikiMysliwySkillEffect>().PlayAnimation(0);

            }
            if (target == 2)
            {

                clone = Instantiate(_SkillAnimator, _CombatZone.GetComponent<CombatHandler>()._CompanionPosition2.transform.position, Quaternion.identity);
                clone.transform.parent = _CombatZone.GetComponent<CombatHandler>()._CompanionPosition2.transform;
                clone.GetComponent<SpriteRenderer>().sortingOrder = _CombatZone.GetComponent<CombatHandler>()._CompanionPosition2.GetComponentInChildren<SpriteRenderer>().sortingOrder + 1;
                clone.GetComponent<DzikiMysliwySkillEffect>().PlayAnimation(0);

            }
            if (target == 3)
            {

                clone = Instantiate(_SkillAnimator, _CombatZone.GetComponent<CombatHandler>()._CompanionPosition3.transform.position, Quaternion.identity);
                clone.transform.parent = _CombatZone.GetComponent<CombatHandler>()._CompanionPosition3.transform;
                clone.GetComponent<SpriteRenderer>().sortingOrder = _CombatZone.GetComponent<CombatHandler>()._CompanionPosition3.GetComponentInChildren<SpriteRenderer>().sortingOrder + 1;
                clone.GetComponent<DzikiMysliwySkillEffect>().PlayAnimation(0);

            }
            if (target == 4)
            {

                clone = Instantiate(_SkillAnimator, _CombatZone.GetComponent<CombatHandler>()._CompanionPosition4.transform.position, Quaternion.identity);
                clone.transform.parent = _CombatZone.GetComponent<CombatHandler>()._CompanionPosition4.transform;
                clone.GetComponent<SpriteRenderer>().sortingOrder = _CombatZone.GetComponent<CombatHandler>()._CompanionPosition4.GetComponentInChildren<SpriteRenderer>().sortingOrder + 1;
                clone.GetComponent<DzikiMysliwySkillEffect>().PlayAnimation(0);

            }

            _CombatZone.GetComponentInChildren<CombatSounds>().PickSoundEffect(3);
            ///

        }
        else if (isCharging == false && chargeAoe == false && chargeSingle == false) //loswoanie ataku 
        {   
            actionCheck = Random.Range(0, 101);
            if (actionCheck < 20)
            {
                action = 1;
            }
            else if (actionCheck >= 20 && actionCheck < 40)
            {
                action = 2;
            }
            else if (actionCheck >= 40) 
            {
                action = 3;
            }
            Debug.Log("do sparwdzenia losowanie " + actionCheck );
            Debug.Log("wylosowana liczba to " + action);
            
            
            if (action == 1)
            {
                Debug.Log("wybra³ pierwsza akcjie");
                isCharging = true;
                chargeAoe = true;
                _CombatZone.GetComponent<CombatHandler>().DisplayCombatLog("Dziki Myœliwy przygotowuje potêrzny atak.");
                _CombatZone.GetComponent<CombatHandler>().EnemySkipTurn();



            }
            else if (action == 2)
            {
                //Debug.Log("ok");
                
                //Debug.Log("wybra³ druga ackjie");
                isCharging = true;
                chargeSingle = true;
                target = _CombatZone.GetComponent<CombatHandler>().RandomExpection(1,5);
                if (target == 1)
                {
                    comp = _CombatZone.GetComponent<CombatHandler>()._CompanionInCombat1.GetComponent<CompanionHandler>()._CompanionStats.companionName;
                }
                else if (target == 2)
                {
                    comp = _CombatZone.GetComponent<CombatHandler>()._CompanionInCombat2.GetComponent<CompanionHandler>()._CompanionStats.companionName;

                }
                else if (target == 3)
                {
                    comp = _CombatZone.GetComponent<CombatHandler>()._CompanionInCombat3.GetComponent<CompanionHandler>()._CompanionStats.companionName;

                }
                else if (target == 4) 
                {
                    comp = _CombatZone.GetComponent<CombatHandler>()._CompanionInCombat4.GetComponent<CompanionHandler>()._CompanionStats.companionName;
                }
                Debug.Log("target");
                _CombatZone.GetComponent<CombatHandler>().DisplayCombatLog("Dziki Myœliwy patrzy na " + comp); // nazwa tego na kogo patrzy/
                _CombatZone.GetComponent<CombatHandler>().EnemySkipTurn();
                 




            }
            else if (action == 3)
            {
                Debug.Log("wybra³ 3 akcjie");
                damage = DamageCalculation(_EnemyStats.accuracy, _EnemyStats.luck, _EnemyStats.attackDamage1);
                target = _CombatZone.GetComponent<CombatHandler>().EnemyDealsDamage(damage, true, 0, showEnemy,true);
                if (target == 1)
                {

                    clone = Instantiate(_SkillAnimator, _CombatZone.GetComponent<CombatHandler>()._CompanionPosition1.transform.position, Quaternion.identity);
                    clone.transform.parent = _CombatZone.GetComponent<CombatHandler>()._CompanionPosition1.transform;
                    clone.GetComponent<SpriteRenderer>().sortingOrder = _CombatZone.GetComponent<CombatHandler>()._CompanionPosition1.GetComponentInChildren<SpriteRenderer>().sortingOrder + 1;
                    clone.GetComponent<DzikiMysliwySkillEffect>().PlayAnimation(0);
                   

                }
                if (target == 2)
                {

                    clone = Instantiate(_SkillAnimator, _CombatZone.GetComponent<CombatHandler>()._CompanionPosition2.transform.position, Quaternion.identity);
                    clone.transform.parent = _CombatZone.GetComponent<CombatHandler>()._CompanionPosition2.transform;
                    clone.GetComponent<SpriteRenderer>().sortingOrder = _CombatZone.GetComponent<CombatHandler>()._CompanionPosition2.GetComponentInChildren<SpriteRenderer>().sortingOrder + 1;
                    clone.GetComponent<DzikiMysliwySkillEffect>().PlayAnimation(0);
                    

                }
                if (target == 3)
                {

                    clone = Instantiate(_SkillAnimator, _CombatZone.GetComponent<CombatHandler>()._CompanionPosition3.transform.position, Quaternion.identity);
                    clone.transform.parent = _CombatZone.GetComponent<CombatHandler>()._CompanionPosition3.transform;
                    clone.GetComponent<SpriteRenderer>().sortingOrder = _CombatZone.GetComponent<CombatHandler>()._CompanionPosition3.GetComponentInChildren<SpriteRenderer>().sortingOrder + 1;
                    clone.GetComponent<DzikiMysliwySkillEffect>().PlayAnimation(0);
                    

                }
                if (target == 4)
                {

                    clone = Instantiate(_SkillAnimator, _CombatZone.GetComponent<CombatHandler>()._CompanionPosition4.transform.position, Quaternion.identity);
                    clone.transform.parent = _CombatZone.GetComponent<CombatHandler>()._CompanionPosition4.transform;
                    clone.GetComponent<SpriteRenderer>().sortingOrder = _CombatZone.GetComponent<CombatHandler>()._CompanionPosition4.GetComponentInChildren<SpriteRenderer>().sortingOrder + 1;
                    clone.GetComponent<DzikiMysliwySkillEffect>().PlayAnimation(0);
                    

                }

                _CombatZone.GetComponentInChildren<CombatSounds>().PickSoundEffect(3);
                
            }
            
        }

       // Debug.Log("ale dlaczego" + chargeAoe + chargeSingle + isCharging);
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
                showEnemy = "Dziki Myœliwy uderza krytycznie za ";

                return Damage;
            }
            else
            {

                Damage1 = chceck;
                Damage = Mathf.RoundToInt(Damage1);
                showEnemy = "Dziki Myœliwy uderza za ";
                return Damage;

            }
        }
        else
        {
            showEnemy = "Dziki Myœliwy nie trafi³.";
            Damage = 0;

        }

        return Damage;
    }

}
