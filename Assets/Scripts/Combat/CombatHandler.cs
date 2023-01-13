using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CombatHandler : MonoBehaviour
{
    public GameObject _LoseScreen;
    public GameObject _InGameMenu;
    public GameObject _CombatCamera;
    public GameObject _CombatUI;

    public GameObject _EnemyPosition1;
    public GameObject _EnemyPosition2;
    public GameObject _EnemyPosition3;
    public GameObject _EnemyPosition4;

    public GameObject _CompanionPosition1;
    public GameObject _CompanionPosition2;
    public GameObject _CompanionPosition3;
    public GameObject _CompanionPosition4;

    public GameObject _CompanionPosition11;
    public GameObject _CompanionPosition22;
    public GameObject _CompanionPosition33;
    public GameObject _CompanionPosition44;

    public GameObject _AnimatorKurwa;
    private GameObject clone;

    public SoPlayerParty _PlayerParty;

    private GameObject _EnemyInCombat1;
    private GameObject _EnemyInCombat2;
    private GameObject _EnemyInCombat3;
    private GameObject _EnemyInCombat4;


    
    public GameObject _CompanionInCombat1;
    public GameObject _CompanionInCombat2;
    public GameObject _CompanionInCombat3;
    public GameObject _CompanionInCombat4;




    private  GameObject _Player;
    private GameObject _CombatStarter;
    public GameObject _Middle;

    public GameObject Temp;

    public int enemyCount;
    public int compCount;
    public int pointer=0;
    public int pointer2=0;

    public float activeCopmanion;
    public int actionType;
    public float actionTarget;
    public int round = 1;

    public float activeEnemy;
    public float turns;
    public int currentTurn;
    public SOEnemyParty _EnemySetUp;
    public string[] currentQueue;

   
    public GameObject _MusicHandler;
    private int targetedEnemy;
    // Start is called before the first frame update
    void Start()
    {
        _CompanionPosition11.transform.position = _CompanionPosition1.transform.position;
        _CompanionPosition22.transform.position = _CompanionPosition2.transform.position;
        _CompanionPosition33.transform.position = _CompanionPosition3.transform.position;
        _CompanionPosition44.transform.position = _CompanionPosition4.transform.position;
        _Player = GameObject.FindGameObjectWithTag("Player");
       // Temp.position = _Middle.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void StartCombat(SOEnemyParty _EnemyParty, GameObject CombatStarter = null)
    {
        StartCoroutine(CombatStart(_EnemyParty,CombatStarter));

    }
    public  void CombatWon()
    {
        //random loot 
        Destroy(_CombatStarter);
        _CombatUI.SetActive(false);
        _CombatCamera.SetActive(false);
        KillAll();
        _Player.GetComponent<PlayerManager>().CameraOn();
        _Player.GetComponent<PlayerMovment>().AllowMovment();

    }

    public void PointerOn(int target)
    {
        if (target == 1) 
        {
            if (_EnemyInCombat1 != null)
            {
                _EnemyInCombat1.GetComponent<EnemyCombat>().SetPointer(true);
            }
        }
        if (target == 2)
        {
            if (_EnemyInCombat2 != null)
            {
                _EnemyInCombat2.GetComponent<EnemyCombat>().SetPointer(true);
            }

        }
        if (target == 3)
        {
            if (_EnemyInCombat3 != null)
            {
                _EnemyInCombat3.GetComponent<EnemyCombat>().SetPointer(true);
            }
        }
        if (target == 4)
        {
            if (_EnemyInCombat4 != null)
            {
                _EnemyInCombat4.GetComponent<EnemyCombat>().SetPointer(true);
            }
        }

    }
    public void PointerOff(int target)
    {
        if (target == 1)
        {
            if (_EnemyInCombat1 != null)
            {
                _EnemyInCombat1.GetComponent<EnemyCombat>().SetPointer(false);
            }
        }
        if (target == 2)
        {
            if(_EnemyInCombat2!= null) 
            { 
             _EnemyInCombat2.GetComponent<EnemyCombat>().SetPointer(false);
            }
        }
        if (target == 3)
        {
            if (_EnemyInCombat3 != null)
            {
                _EnemyInCombat3.GetComponent<EnemyCombat>().SetPointer(false);
            }
        }
        if (target == 4)
        {
            if (_EnemyInCombat4 != null)
            {
                _EnemyInCombat4.GetComponent<EnemyCombat>().SetPointer(false);
            }
        }

    }

    public void KillAll()
    {
        _MusicHandler.GetComponent<MusicHandler>().PickMusic(false,true);
        if (_EnemyInCombat1 != null) 
        {
            Destroy(_EnemyInCombat1);
        }
        if (_EnemyInCombat2 != null)
        {
            Destroy(_EnemyInCombat2);
        }
        if (_EnemyInCombat3 != null)
        {
            Destroy(_EnemyInCombat3);
        }
        if (_EnemyInCombat4 != null)
        {
            Destroy(_EnemyInCombat4);
        }

        if (_CompanionInCombat1 != null)
        {
            Destroy(_CompanionInCombat1);
        }
        if (_CompanionInCombat2 != null)
        {
            Destroy(_CompanionInCombat2);
        }
        if (_CompanionInCombat3 != null)
        {
            Destroy(_CompanionInCombat3);
        }
        if (_CompanionInCombat4 != null)
        {
            Destroy(_CompanionInCombat4);
        }




    }
    public void PlayerTurn(string Companion)
    {
        if (_CompanionInCombat1 == null && _CompanionInCombat2 == null && _CompanionInCombat3 == null && _CompanionInCombat4 == null) 
        {
            Destroy(_InGameMenu);
            _LoseScreen.SetActive(true);
            Time.timeScale = 0;

           // SceneManager.LoadScene(0);
        }

        _CombatUI.GetComponent<CombatUIHandler>().StartPlayerTurn();
        //enable Buttons
        //if there are no companions then player lost
        if (Companion == "1c")
        {
            Temp.transform.position = _CompanionPosition1.transform.position;
            _CompanionPosition1.transform.position = _Middle.transform.position;
            activeCopmanion = 1f;
            // this is shite, first we check the companion in combat then we check the SO of the copanion 
            if (_CompanionInCombat1 == null  )
            {
                _CompanionPosition1.transform.position = Temp.transform.position;
                currentTurn += 1;
                StartCoroutine(EnemyTurn(currentQueue[currentTurn]));
                return;
                
            }
            return;

        }
       else if (Companion == "2c")
        {
            Temp.transform.position = _CompanionPosition2.transform.position;
            _CompanionPosition2.transform.position = _Middle.transform.position;
            activeCopmanion = 2f;
           // Debug.Log("xd2");
            if (_CompanionInCombat2 == null )
            {
                _CompanionPosition2.transform.position = Temp.transform.position;
                currentTurn += 1;
                StartCoroutine(EnemyTurn(currentQueue[currentTurn]));
                return;
            }
            return;
        }
       else if (Companion == "3c")
        {
            Temp.transform.position = _CompanionPosition3.transform.position;
            _CompanionPosition3.transform.position = _Middle.transform.position;
            activeCopmanion = 3f;
           // Debug.Log("xd3");
            if (_CompanionInCombat3 == null)
            {
                _CompanionPosition3.transform.position = Temp.transform.position;
                currentTurn += 1;
                StartCoroutine(EnemyTurn(currentQueue[currentTurn]));
                return;
            }
            return;
        }
      else  if (Companion == "4c")
        {
           Temp.transform.position = _CompanionPosition4.transform.position;
            _CompanionPosition4.transform.position = _Middle.transform.position;
            activeCopmanion = 4f;
            //Debug.Log("xd4");
            if (_CompanionInCombat4 == null )
            {
                _CompanionPosition4.transform.position = Temp.transform.position;
                currentTurn += 1;
                StartCoroutine(EnemyTurn(currentQueue[currentTurn]));
                return;
            }
            return;
        }
        
        //Debug.Log(activeCopmanion);
    }

    IEnumerator EnemyTurn(string enemy) 
    {
        _CombatUI.GetComponent<CombatUIHandler>().StopPlayerTurn();

        if (_EnemyInCombat1 == null && _EnemyInCombat2 == null && _EnemyInCombat3 == null && _EnemyInCombat4 == null )
        {
            enemyCount = 0;
            _CompanionPosition1.transform.position = _CompanionPosition11.transform.position;
            _CompanionPosition2.transform.position = _CompanionPosition22.transform.position;
            _CompanionPosition3.transform.position = _CompanionPosition33.transform.position;
            _CompanionPosition4.transform.position = _CompanionPosition44.transform.position;
            _EnemySetUp = null; 
           _EnemyInCombat1 = null;
            _EnemyInCombat2 = null;
            _EnemyInCombat3 = null;
            _EnemyInCombat4 = null;
           /* _EnemyParty.Enemy1 = null;
            _EnemyParty.Enemy2 = null;
            _EnemyParty.Enemy3 = null;
            _EnemyParty.Enemy4 = null;*/
           /* _PlayerParty.Companion1 = null;
            _PlayerParty.Companion2 = null;
            _PlayerParty.Companion3 = null;
            _PlayerParty.Companion4 = null;*/
            compCount = 0;
            pointer2 = 0;
            pointer = 0;
            enemyCount = 0;
            Debug.Log("PLayer Won");
            CombatWon();
        
        }

       else if (enemy == "1e" && _EnemyInCombat1 != null)
        {
            
            activeEnemy = 1f;
            Debug.Log("Enemy Turn Active Enemy: " + activeEnemy);
            yield return new WaitForSeconds(1);
            Temp.transform.position = _EnemyPosition1.transform.position;
           
            _EnemyPosition1.transform.position = _Middle.transform.position;

            yield return new WaitForSeconds(1f);
            _EnemyInCombat1.GetComponent<EnemyCombat>().TakeAction();
            yield return new WaitForSeconds(2f);
            HideCombatLog();
            _EnemyPosition1.transform.position = Temp.transform.position;

        }
        else if (enemy == "2e" && _EnemyInCombat2 != null)
        {
            activeEnemy = 2f;
            Debug.Log("Enemy Turn Active Enemy: " + activeEnemy);
            yield return new WaitForSeconds(1f);
            Temp.transform.position = _EnemyPosition2.transform.position;
           
            _EnemyPosition2.transform.position = _Middle.transform.position;

            yield return new WaitForSeconds(1f);
            _EnemyInCombat2.GetComponent<EnemyCombat>().TakeAction();
            yield return new WaitForSeconds(2f);
            HideCombatLog();
            _EnemyPosition2.transform.position = Temp.transform.position;


        }
        else if (enemy == "3e" && _EnemyInCombat3 != null)
        {
            activeEnemy = 3f;
            Debug.Log("Enemy Turn Active Enemy: " + activeEnemy);
            yield return new WaitForSeconds(1f);
            Temp.transform.position = _EnemyPosition3.transform.position;
           
            _EnemyPosition3.transform.position = _Middle.transform.position;

            yield return new WaitForSeconds(1f);
            _EnemyInCombat3.GetComponent<EnemyCombat>().TakeAction();
            yield return new WaitForSeconds(2f);
            HideCombatLog();
            _EnemyPosition3.transform.position = Temp.transform.position;

        }
        else if (enemy == "4e" && _EnemyInCombat4 != null)
        {
            activeEnemy = 4f;
            Debug.Log("Enemy Turn Active Enemy: " + activeEnemy);
            yield return new WaitForSeconds(1f);
            Temp.transform.position = _EnemyPosition4.transform.position;
            
            _EnemyPosition4.transform.position = _Middle.transform.position;

            yield return new WaitForSeconds(1f);
            _EnemyInCombat4.GetComponent<EnemyCombat>().TakeAction();
            yield return new WaitForSeconds(2f);
            HideCombatLog();
            _EnemyPosition4.transform.position = Temp.transform.position;
        }
        else 
        {
            yield return new WaitForSeconds(2f);

        }
       
        
       


        //tell enemy to do something

       
        
        currentTurn += 1;
        
        
        
        if (currentTurn >= 7)
        {
            currentTurn = 0;
            StartQueue();
            round += 1;
            Debug.Log("Round:"+round);

        }
        PlayerTurn(currentQueue[currentTurn]);
    }
    public void ActionToTake(int action,int actionTarget)
    {
        StartCoroutine(Action(action, actionTarget));

    }


    
    public void ActionTaken(int action,int target)
    {
        actionType = action;
        actionTarget = target;
       // Debug.Log("AttakTry");
        float damage = _CompanionInCombat1.GetComponent<CompanionHandler>().TakeAction(actionType);
        
        
        if (target == 1)
        {
            _EnemyInCombat1.GetComponent<EnemyCombat>().TakeDamage(damage);
        
        
        }
        if (target == 2)
        {
            _EnemyInCombat2.GetComponent<EnemyCombat>().TakeDamage(damage);


        }
        if (target == 3)
        {
            if (_EnemyInCombat1 == null)
            {
                _EnemyInCombat3.GetComponent<EnemyCombat>().TakeDamage(damage);
            }
            else 
            {
                _EnemyInCombat1.GetComponent<EnemyCombat>().TakeDamage(damage);
            }

        }
        if (target == 4)
        {
            if (_EnemyInCombat2 == null)
            {
                _EnemyInCombat4.GetComponent<EnemyCombat>().TakeDamage(damage);
            }
            else
            {
                _EnemyInCombat2.GetComponent<EnemyCombat>().TakeDamage(damage);
            }

        }
       // _CombatUI.


        //Debug.Log("Action Type:"+action + " Target:" + target);
    }
   

    public void StartQueue()
    {
        string[] inputArray = new string[4] { "1e", "2e", "3e", "4e" };
        for (int i = inputArray.Length - 1; i > 0; i--)
        {
            int randomIndex = Random.Range(0, i + 1);

            string temp = inputArray[i];
            inputArray[i] = inputArray[randomIndex];
            inputArray[randomIndex] = temp;
        }

        string[] inputArray2 = new string[4] { "1c", "2c", "3c", "4c" };
        for (int ii = inputArray2.Length - 1; ii > 0; ii--)
        {
            int randomIndex2 = Random.Range(0, ii + 1);

            string tmp2 = inputArray2[ii];
            inputArray2[ii] = inputArray2[randomIndex2];
            inputArray2[randomIndex2] = tmp2;

        }
        string[] arrayCombination = new string[8];

        arrayCombination[0] = inputArray2[0];
        arrayCombination[1] = inputArray[0];
        arrayCombination[2] = inputArray2[1];
        arrayCombination[3] = inputArray[1];
        arrayCombination[4] = inputArray2[2];
        arrayCombination[5] = inputArray[2];
        arrayCombination[6] = inputArray2[3];
        arrayCombination[7] = inputArray[3];
        
        currentQueue = arrayCombination;
    }
    IEnumerator JustWait(float waitTime)
    {

        yield return new WaitForSeconds(waitTime);
    
    }
    public void EnemySkipTurn()
    {
        Debug.Log("EnemySkips");


    }
    public  float CompanionDealsDamage(float DamageDealt,bool melee = false, bool penetration = false, string cmopname="",bool spaleniec=false) 
    {
        float misscheck = DamageDealt;
        int target = targetedEnemy;
        
        if (spaleniec == true) 
        {
           target = randomEnemy(1, 5);
        }
        if (melee)
        {
            if (target == 1)
            {

                if (penetration == false)
                {
                    DamageDealt = DamageDealt - _EnemyInCombat1.GetComponent<EnemyCombat>().armor;
                    DamageDealt = Mathf.Clamp(DamageDealt, 0, 100000);
                    _EnemyInCombat1.GetComponent<EnemyCombat>().TakeDamage(DamageDealt);
                    target = 1;
                    
                }
                else if (penetration == true)
                {
                    _EnemyInCombat1.GetComponent<EnemyCombat>().TakeDamage(DamageDealt);
                    DamageDealt = Mathf.Clamp(DamageDealt, 0, 100000);
                    Debug.Log("damage was skiped");
                    target = 1;
                }

            }
            else if (target == 2)
            {
                if (penetration == false)
                {
                    DamageDealt = DamageDealt - _EnemyInCombat2.GetComponent<EnemyCombat>().armor;
                    DamageDealt = Mathf.Clamp(DamageDealt, 0, 100000);
                    _EnemyInCombat2.GetComponent<EnemyCombat>().TakeDamage(DamageDealt);
                    target = 2;

                } else if (penetration == true) 
                {
                    DamageDealt = Mathf.Clamp(DamageDealt, 0, 100000);
                    _EnemyInCombat2.GetComponent<EnemyCombat>().TakeDamage(DamageDealt);
                    Debug.Log("damage was skiped");
                    target = 2;

                }
                
            }
            else if (target == 3)
            {    if (_EnemyInCombat1 == null)
                {
                    if (penetration == false)
                    {
                        DamageDealt = DamageDealt - _EnemyInCombat3.GetComponent<EnemyCombat>().armor;
                        DamageDealt = Mathf.Clamp(DamageDealt, 0, 100000);
                        _EnemyInCombat3.GetComponent<EnemyCombat>().TakeDamage(DamageDealt);
                        target = 3;

                    }
                    else if (penetration == true)
                    {
                        DamageDealt = Mathf.Clamp(DamageDealt, 0, 100000);
                        _EnemyInCombat3.GetComponent<EnemyCombat>().TakeDamage(DamageDealt);
                        target = 3;

                    }

                }
                else 
                {
                    if (penetration == false)
                    {

                        DamageDealt = DamageDealt - _EnemyInCombat1.GetComponent<EnemyCombat>().armor;
                        DamageDealt = Mathf.Clamp(DamageDealt, 0, 100000);
                        _EnemyInCombat1.GetComponent<EnemyCombat>().TakeDamage(DamageDealt);
                        target = 1;

                    }
                    else if (penetration == true) 
                    {
                        DamageDealt = Mathf.Clamp(DamageDealt, 0, 100000);
                        _EnemyInCombat1.GetComponent<EnemyCombat>().TakeDamage(DamageDealt);
                        target = 1;

                    }
                    

                }
            }
            if (target == 4)
            {

                if (_EnemyInCombat2 == null)
                {
                    if (penetration == false) 
                    {
                        DamageDealt = DamageDealt - _EnemyInCombat4.GetComponent<EnemyCombat>().armor;
                        DamageDealt = Mathf.Clamp(DamageDealt, 0, 100000);
                        _EnemyInCombat4.GetComponent<EnemyCombat>().TakeDamage(DamageDealt);
                        target = 4;

                    }
                    else if (penetration == true)
                    {
                        DamageDealt = Mathf.Clamp(DamageDealt, 0, 100000);
                        _EnemyInCombat4.GetComponent<EnemyCombat>().TakeDamage(DamageDealt);
                        target = 4;

                    }
 
                }
                else
                {
                    if (penetration == false)
                    {
                        DamageDealt = DamageDealt - _EnemyInCombat2.GetComponent<EnemyCombat>().armor;
                        DamageDealt = Mathf.Clamp(DamageDealt, 0, 100000);
                        _EnemyInCombat2.GetComponent<EnemyCombat>().TakeDamage(DamageDealt);
                        target = 2;

                    }
                    else if (penetration == true) 
                    {
                        DamageDealt = Mathf.Clamp(DamageDealt, 0, 100000);
                        _EnemyInCombat2.GetComponent<EnemyCombat>().TakeDamage(DamageDealt);
                        target = 2;

                    }

                }

            }
        }
      else  if (target == 1)
        {
            if (penetration == false)
            {
                DamageDealt = DamageDealt - _EnemyInCombat1.GetComponent<EnemyCombat>().armor;
                DamageDealt = Mathf.Clamp(DamageDealt, 0, 100000);
                _EnemyInCombat1.GetComponent<EnemyCombat>().TakeDamage(DamageDealt);
                target = 1;

            }
            else if (penetration == true) 
            {
                DamageDealt = Mathf.Clamp(DamageDealt, 0, 100000);
                _EnemyInCombat1.GetComponent<EnemyCombat>().TakeDamage(DamageDealt);
                target = 1;

            }
        }
      else  if (target == 2)
        {
            if (penetration == false)
            {
                DamageDealt = DamageDealt - _EnemyInCombat2.GetComponent<EnemyCombat>().armor;
                DamageDealt = Mathf.Clamp(DamageDealt, 0, 100000);
                _EnemyInCombat2.GetComponent<EnemyCombat>().TakeDamage(DamageDealt);
                target = 2;

            }
            else if (penetration==true) 
            {
                DamageDealt = Mathf.Clamp(DamageDealt, 0, 100000);
                _EnemyInCombat2.GetComponent<EnemyCombat>().TakeDamage(DamageDealt);
                target = 2;

            }

        }
      else  if (target == 3)
        {
            if (penetration == false)
            {
                DamageDealt = DamageDealt - _EnemyInCombat3.GetComponent<EnemyCombat>().armor;
                DamageDealt = Mathf.Clamp(DamageDealt, 0, 100000);
                _EnemyInCombat3.GetComponent<EnemyCombat>().TakeDamage(DamageDealt);
                target = 3;

            }
            else if (penetration==true)
            {
                DamageDealt = Mathf.Clamp(DamageDealt, 0, 100000);
                _EnemyInCombat3.GetComponent<EnemyCombat>().TakeDamage(DamageDealt);
                target = 3;

            }

        }
      else  if (target == 4)
        {
            if (penetration == false)
            {
                DamageDealt = DamageDealt - _EnemyInCombat4.GetComponent<EnemyCombat>().armor;
                DamageDealt = Mathf.Clamp(DamageDealt, 0, 100000);
                _EnemyInCombat4.GetComponent<EnemyCombat>().TakeDamage(DamageDealt);
                target = 4;

            }
            else if (penetration == true) 
            {
                DamageDealt = Mathf.Clamp(DamageDealt, 0, 100000);
                _EnemyInCombat4.GetComponent<EnemyCombat>().TakeDamage(DamageDealt);
                target = 4;

            }

        }
        if (misscheck != 0)
        {
            DisplayCombatLog(cmopname + DamageDealt + " obra¿eñ.");
        }
        else if(misscheck ==0)
        {
            DisplayCombatLog(cmopname);
        }
        Debug.Log("Companion Trafa  " +target);
        return target;
        

    }
    public float  CompanionHeals(float Healing, float target = 0) 
    {
        target = targetedEnemy;
        if (target == 1)
        {
            _CompanionInCombat1.GetComponent<CompanionHandler>().TakeDamage(-Healing);
            return target;

        }
        if (target == 2)
        {
            _CompanionInCombat2.GetComponent<CompanionHandler>().TakeDamage(-Healing);
            return target;

        }
        if (target == 3)
        {
            _CompanionInCombat3.GetComponent<CompanionHandler>().TakeDamage(-Healing);
            return target;

        }
        if (target == 4)
        {
            _CompanionInCombat4.GetComponent<CompanionHandler>().TakeDamage(-Healing);
            return target;

        }
        return target;

    }
    public float EnemyDealsDamage(float DamageDealt,  bool melee = true,float target = 0,string showEnemy="",bool penetration= false,bool sub= false,bool Wodnik= false)
    {
        float misscheck = DamageDealt;
        Debug.Log("Enemy deals damage");
        if(Wodnik == true) 
        {
            //if(_CompanionInCombat1.>)
        }
        if (target == 0)
        {
            target = RandomExpection(1, 5);
            //Debug.Log( target);
        }
        if (melee)
        {

            if (target == 1 && _CompanionInCombat1 != null)
            {
                if (penetration == false)
                {
                    DamageDealt = DamageDealt - _CompanionInCombat1.GetComponent<CompanionHandler>().armor;
                    DamageDealt = Mathf.Clamp(DamageDealt, 0, 100000);
                    _CompanionInCombat1.GetComponent<CompanionHandler>().TakeDamage(DamageDealt);
                    target = 1;
               
                }
                else if (penetration == true) 
                {
                    DamageDealt = Mathf.Clamp(DamageDealt, 0, 100000);
                    _CompanionInCombat1.GetComponent<CompanionHandler>().TakeDamage(DamageDealt);
                    target = 1;
                }

            }
            else if (target == 2 && _CompanionInCombat2 != null)
            {
                if (penetration == false)
                {
                    DamageDealt = DamageDealt - _CompanionInCombat2.GetComponent<CompanionHandler>().armor;
                    DamageDealt = Mathf.Clamp(DamageDealt, 0, 100000);
                    _CompanionInCombat2.GetComponent<CompanionHandler>().TakeDamage(DamageDealt);
                    target = 2;
                    //_EnemyInCombat2.GetComponent<EnemyCombat>().TakeDamage(damage);
                }
                else if (penetration == true) 
                {
                    DamageDealt = Mathf.Clamp(DamageDealt, 0, 100000);
                    _CompanionInCombat2.GetComponent<CompanionHandler>().TakeDamage(DamageDealt);
                    target = 2;
                }


            }
            else if (target == 3 && _CompanionInCombat3 != null)
            {

                if (_CompanionInCombat1 == null)
                {
                    if (penetration == false)
                    {
                        DamageDealt = DamageDealt - _CompanionInCombat3.GetComponent<CompanionHandler>().armor;
                        DamageDealt = Mathf.Clamp(DamageDealt, 0, 100000);
                        _CompanionInCombat3.GetComponent<CompanionHandler>().TakeDamage(DamageDealt);
                        target = 3;
                    }
                    else if (penetration == true) 
                    {
                        DamageDealt = Mathf.Clamp(DamageDealt, 0, 100000);
                        _CompanionInCombat3.GetComponent<CompanionHandler>().TakeDamage(DamageDealt);
                        target = 3;
                    }
                }
                else if (_CompanionInCombat1 != null)
                {
                    Debug.Log("nasrane?");
                    if (penetration == false)
                    {
                        DamageDealt = DamageDealt - _CompanionInCombat1.GetComponent<CompanionHandler>().armor;
                        DamageDealt = Mathf.Clamp(DamageDealt, 0, 100000);
                        _CompanionInCombat1.GetComponent<CompanionHandler>().TakeDamage(DamageDealt);
                        target = 1;
                    }
                    else if (penetration == true) 
                    {
                        DamageDealt = Mathf.Clamp(DamageDealt, 0, 100000);
                        _CompanionInCombat1.GetComponent<CompanionHandler>().TakeDamage(DamageDealt);
                        target = 1;
                    }
                }
                
                

            }
            else if (target == 4 && _CompanionInCombat4 != null)
            {
                if (_EnemyInCombat2 == null)
                {
                    if (penetration == false)
                    {
                        DamageDealt = DamageDealt - _CompanionInCombat4.GetComponent<CompanionHandler>().armor;
                        DamageDealt = Mathf.Clamp(DamageDealt, 0, 100000);
                        _CompanionInCombat4.GetComponent<CompanionHandler>().TakeDamage(DamageDealt);
                        target = 4;
                    }
                    else if (penetration == true) 
                    {
                        DamageDealt = Mathf.Clamp(DamageDealt, 0, 100000);
                        _CompanionInCombat4.GetComponent<CompanionHandler>().TakeDamage(DamageDealt);
                        target = 4;
                    }
                }
                else if (_CompanionInCombat2 != null)
                {
                    if (penetration == false)
                    {
                        DamageDealt = DamageDealt - _CompanionInCombat2.GetComponent<CompanionHandler>().armor;
                        DamageDealt = Mathf.Clamp(DamageDealt, 0, 100000);
                        _CompanionInCombat2.GetComponent<CompanionHandler>().TakeDamage(DamageDealt);
                        target = 2;
                    }
                    else if (penetration == true) 
                    {
                        DamageDealt = Mathf.Clamp(DamageDealt, 0, 100000);
                        _CompanionInCombat2.GetComponent<CompanionHandler>().TakeDamage(DamageDealt);
                        target = 2;
                    }
                }

            }
           

        }
        else {
            if (target == 1 && _CompanionInCombat1 != null)
            {
                
                if (penetration == false)
                {
                    
                    DamageDealt = DamageDealt - _CompanionInCombat1.GetComponent<CompanionHandler>().armor;
                    DamageDealt = Mathf.Clamp(DamageDealt, 0, 100000);
                    _CompanionInCombat1.GetComponent<CompanionHandler>().TakeDamage(DamageDealt);
                    target = 1;
                }
                else if (penetration == true) 
                {
                    DamageDealt = Mathf.Clamp(DamageDealt, 0, 100000);
                    _CompanionInCombat1.GetComponent<CompanionHandler>().TakeDamage(DamageDealt);
                    target = 1;
                }


            }
            else if (target == 2 && _CompanionInCombat2 != null)
            {
                if (penetration == false)
                {
                    DamageDealt = DamageDealt - _CompanionInCombat2.GetComponent<CompanionHandler>().armor;
                    DamageDealt = Mathf.Clamp(DamageDealt, 0, 100000);
                    _CompanionInCombat2.GetComponent<CompanionHandler>().TakeDamage(DamageDealt);
                    target = 2;
                }
                else if (penetration == true) 
                {
                    DamageDealt = Mathf.Clamp(DamageDealt, 0, 100000);
                    _CompanionInCombat2.GetComponent<CompanionHandler>().TakeDamage(DamageDealt);
                    target = 2;
                }


            }
            else if (target == 3 && _CompanionInCombat3 != null)
            {

                if (penetration == false)
                {
                    DamageDealt = DamageDealt - _CompanionInCombat3.GetComponent<CompanionHandler>().armor;
                    DamageDealt = Mathf.Clamp(DamageDealt, 0, 100000);
                    _CompanionInCombat3.GetComponent<CompanionHandler>().TakeDamage(DamageDealt);
                    target = 3;
                }
                else if (penetration == true) 
                {
                    DamageDealt = Mathf.Clamp(DamageDealt, 0, 100000);
                    _CompanionInCombat3.GetComponent<CompanionHandler>().TakeDamage(DamageDealt);
                    target = 3;
                }
            }
            else if (target == 4 && _CompanionInCombat4 != null)
            {
                if (penetration == false)
                {
                    DamageDealt = DamageDealt - _CompanionInCombat4.GetComponent<CompanionHandler>().armor;
                    DamageDealt = Mathf.Clamp(DamageDealt, 0, 100000);
                    _CompanionInCombat4.GetComponent<CompanionHandler>().TakeDamage(DamageDealt);
                    target = 4;
                }
                else if (penetration == true) 
                {
                    DamageDealt = Mathf.Clamp(DamageDealt, 0, 100000);
                    _CompanionInCombat4.GetComponent<CompanionHandler>().TakeDamage(DamageDealt);
                    target = 4;
                }


            }           
        }
        if (sub == false)
        {
            if (misscheck != 0)
            {
                DisplayCombatLog(showEnemy + DamageDealt + " Obra¿eñ.");
            }
            else if (misscheck == 0)
            {
                DisplayCombatLog(showEnemy);
            }
            return target;
        }
        else if(sub == true)
        {
            //return DamageDealt;
        }
        return target;
    }
    public void EnemyDealsDamageTwice(float damageOne,float damageTwo, bool meele,bool penetration,int miss )
    {
        int target = RandomExpection(1, 5);
        float damageCheckOne=0,damegeCheckTwo=0;
        Debug.Log(target);
        damageCheckOne = EnemyDealsDamage(damageOne, true, target, "", false, true);
        damegeCheckTwo = EnemyDealsDamage(damageTwo, true, target, "", false, true);
        Debug.Log("obrazenia 1" + damageCheckOne);
        Debug.Log("obrazenia 2" + damegeCheckTwo);
        if (miss == 0) // maksymalnie mozesz skrucic wiadomosc bo jest zd³uga nie wiem jak ale to zrob 
        {
            DisplayCombatLog("Stukacz uderza za " + damageCheckOne + " oraz " + damegeCheckTwo+" obra¿eñ.");
        }
        else if (miss == 1 && damageCheckOne == 0)
        {
            DisplayCombatLog("Stukacz uderza za " + damageCheckOne + " oraz " + damegeCheckTwo + " obra¿eñ.");
        }
        else if (miss == 1 && damegeCheckTwo == 0)
        {
            DisplayCombatLog("Stukacz uderza za " + damageCheckOne + " oraz " + damegeCheckTwo + " obra¿eñ.");
        }
        else if (miss == 2) 
        {
            DisplayCombatLog("Stukacz uderza za " + damageCheckOne + " oraz " + damegeCheckTwo + " obra¿eñ.");
        }
       
        
        if (damageCheckOne == 1 || damegeCheckTwo == 1)
        {
            Debug.Log("1");
            //_AnimatorKurwa.GetComponent<StukaczSkillEffect>().
            clone = Instantiate(_AnimatorKurwa,_CompanionPosition1.transform.position, Quaternion.identity);
            clone.transform.parent = _CompanionPosition1.transform;
            clone.GetComponent<SpriteRenderer>().sortingOrder =_CompanionPosition1.GetComponentInChildren<SpriteRenderer>().sortingOrder + 1;
            clone.GetComponent<StukaczSkillEffect>().PlayAnimation(0);


        }
        if (damageCheckOne == 2 || damegeCheckTwo == 2)
        {
            Debug.Log("2");
            //_AnimatorKurwa.GetComponent<StukaczSkillEffect>().
            clone = Instantiate(_AnimatorKurwa, _CompanionPosition2.transform.position, Quaternion.identity);
            clone.transform.parent = _CompanionPosition2.transform;
            clone.GetComponent<SpriteRenderer>().sortingOrder = _CompanionPosition2.GetComponentInChildren<SpriteRenderer>().sortingOrder + 1;
            clone.GetComponent<StukaczSkillEffect>().PlayAnimation(0);


        }
        if (damageCheckOne == 3 || damegeCheckTwo == 3)
        {
            Debug.Log("3");
            //_AnimatorKurwa.GetComponent<StukaczSkillEffect>().
            clone = Instantiate(_AnimatorKurwa, _CompanionPosition3.transform.position, Quaternion.identity);
            clone.transform.parent = _CompanionPosition3.transform;
            clone.GetComponent<SpriteRenderer>().sortingOrder = _CompanionPosition3.GetComponentInChildren<SpriteRenderer>().sortingOrder + 1;
            clone.GetComponent<StukaczSkillEffect>().PlayAnimation(0);


        }
        if (damageCheckOne == 4 || damegeCheckTwo == 4)
        {
            Debug.Log("4");
            //_AnimatorKurwa.GetComponent<StukaczSkillEffect>().
            clone = Instantiate(_AnimatorKurwa, _CompanionPosition4.transform.position, Quaternion.identity);
            clone.transform.parent = _CompanionPosition4.transform;
            clone.GetComponent<SpriteRenderer>().sortingOrder = _CompanionPosition4.GetComponentInChildren<SpriteRenderer>().sortingOrder + 1;
            clone.GetComponent<StukaczSkillEffect>().PlayAnimation(0);


        }

    }
    public int RandomExpection(int min, int max)
    {
        int random = 0;
        int Exc1 = 0;
        int Exc2 = 0;
        int Exc3 = 0;
        int Exc4 = 0;

        if (_CompanionInCombat1 == null)
        {
            Exc1 = 1;
            //Debug.Log(Exc1);

        }
        if (_CompanionInCombat2 == null)
        {
            Exc2 = 2;
            // Debug.Log(Exc2);

        }
        if (_CompanionInCombat3 == null)
        {
            Exc3 = 3;
            // Debug.Log(Exc3);

        }
        if (_CompanionInCombat4 == null)
        {
            Exc4 = 4;
            // Debug.Log(Exc4);

        }
        while (random == Exc1 || random == Exc2 || random == Exc3 || random == Exc4 || random == 0) 
        {
            random = Random.Range(min, max);
            //Debug.Log(random);
        }
        
        return random;
    }
    public int randomEnemy(int min , int max) 
    {
        int random = 0;
        int Exc1 = 0;
        int Exc2 = 0;
        int Exc3 = 0;
        int Exc4 = 0;
        if (_EnemyInCombat1 == null) 
        {
            Exc1 = 1;
        }
        if (_EnemyInCombat2 == null)
        {
            Exc2 = 2;
        }
        if (_EnemyInCombat3 == null)
        {
            Exc3 = 3;
        }
        if (_EnemyInCombat4 == null)
        {
            Exc4 = 4;
        }
        while (random == Exc1 || random == Exc2 || random == Exc3 || random == Exc4 || random == 0)
        {
            random = Random.Range(min, max);
            //Debug.Log(random);
        }
        return random;

    }
    public bool CheckCompanionTarget(int action)
    {
        bool check;

        if (activeCopmanion == 1)
        {

            check = _CompanionInCombat1.GetComponent<CompanionHandler>().CheckAction(action);
            return check;
        
        }
       else if (activeCopmanion == 2)
        {

            check = _CompanionInCombat2.GetComponent<CompanionHandler>().CheckAction(action);
            return check;

        }
        else if (activeCopmanion ==3)
        {

            check = _CompanionInCombat3.GetComponent<CompanionHandler>().CheckAction(action);
            return check;

        }
        else if (activeCopmanion == 4)
        {

            check = _CompanionInCombat4.GetComponent<CompanionHandler>().CheckAction(action);
            return check;

        }
        return false;


    }
    public void CompPointerOn(int target)
    {
        if (target == 1)
        {
            if (_CompanionInCombat1 != null)
            {
                _CompanionInCombat1.GetComponent<CompanionHandler>().SetPointer(true);
            }
        }
        if (target == 2)
        {
            if (_CompanionInCombat2 != null)
            {
                _CompanionInCombat2.GetComponent<CompanionHandler>().SetPointer(true);
            }

        }
        if (target == 3)
        {
            if (_CompanionInCombat3 != null)
            {
                _CompanionInCombat3.GetComponent<CompanionHandler>().SetPointer(true);
            }
        }
        if (target == 4)
        {
            if (_CompanionInCombat4 != null)
            {
                _CompanionInCombat4.GetComponent<CompanionHandler>().SetPointer(true);
            }
        }

    }
    public void CompPointerOff(int target)
    {
        if (target == 1)
        {
            if (_CompanionInCombat1 != null)
            {
                _CompanionInCombat1.GetComponent<CompanionHandler>().SetPointer(false);
            }
        }
        if (target == 2)
        {
            if (_CompanionInCombat2 != null)
            {
                _CompanionInCombat2.GetComponent<CompanionHandler>().SetPointer(false);
            }
        }
        if (target == 3)
        {
            if (_CompanionInCombat3 != null)
            {
                _CompanionInCombat3.GetComponent<CompanionHandler>().SetPointer(false);
            }
        }
        if (target == 4)
        {
            if (_CompanionInCombat4 != null)
            {
                _CompanionInCombat4.GetComponent<CompanionHandler>().SetPointer(false);
            }
        }

       

    }
    public float ActiveCompanion()
    {
        return activeCopmanion;


    }
    public void DisplayCombatLog(string Log)
    {

        _CombatUI.GetComponent<CombatUIHandler>().ShowLog(Log);
    
    }
    public void HideCombatLog()
    {

        _CombatUI.GetComponent<CombatUIHandler>().HideLog();
    }

    IEnumerator Action(int action, int actionTarget)
    {

        targetedEnemy = actionTarget;

        //Debug.Log("Companion:"+activeCopmanion +" "+ action + " Target:" + actionTarget);
        //do action with index 1 on selected target, the action is made by the active companion
        // Debug.Log("lol2 " + currentTurn);
        //Debug.Log(currentQueue[currentTurn]);
        currentTurn += 1;
        // ActionTaken(action, actionTarget);
        _CombatUI.GetComponent<CombatUIHandler>().StopPlayerTurn();
        yield return new WaitForSeconds(1f);

        if (activeCopmanion == 1)
        {
           
            _CompanionInCombat1.GetComponent<CompanionHandler>().TakeAction(action);
            _CombatUI.GetComponent<CombatUIHandler>().StopPlayerTurn();
            yield return new WaitForSeconds(2f);
            _CompanionPosition1.transform.position = Temp.transform.position;
            //Debug.Log("TempChange");
        }
        if (activeCopmanion == 2)
        {
          
            _CompanionInCombat2.GetComponent<CompanionHandler>().TakeAction(action);
            _CombatUI.GetComponent<CombatUIHandler>().StopPlayerTurn();
            yield return new WaitForSeconds(2f);
            _CompanionPosition2.transform.position = Temp.transform.position;

        }
        if (activeCopmanion == 3)
        {
            
            _CompanionInCombat3.GetComponent<CompanionHandler>().TakeAction(action);
            _CombatUI.GetComponent<CombatUIHandler>().StopPlayerTurn();
            yield return new WaitForSeconds(2f);
            _CompanionPosition3.transform.position = Temp.transform.position;


        }
        if (activeCopmanion == 4)
        {
           
            _CompanionInCombat4.GetComponent<CompanionHandler>().TakeAction(action);
            _CombatUI.GetComponent<CombatUIHandler>().StopPlayerTurn();
            yield return new WaitForSeconds(2f);
            _CompanionPosition4.transform.position = Temp.transform.position;

        }

        //disable Buttons

        if (activeCopmanion == 1)
        {

        }
        //yield return new WaitForSeconds(1f);
        HideCombatLog();
       
        StartCoroutine(EnemyTurn(currentQueue[currentTurn]));

    }
    IEnumerator CombatStart(SOEnemyParty _EnemyParty, GameObject CombatStarter = null) 
    {
        _CompanionPosition1.transform.position = _CompanionPosition11.transform.position;
        _CompanionPosition2.transform.position = _CompanionPosition22.transform.position;
        _CompanionPosition3.transform.position = _CompanionPosition33.transform.position;
        _CompanionPosition4.transform.position = _CompanionPosition44.transform.position;
        _CombatCamera.SetActive(true);
        _CombatUI.SetActive(true);
        _EnemySetUp = _EnemyParty;
        
        //Disable non-Combat UI
        _MusicHandler.GetComponent<MusicHandler>().PickMusic(true);
        if (_EnemyParty.Enemy1 != null)
        {
            enemyCount += 1;
        }
        if (_EnemyParty.Enemy2 != null)
        {
            enemyCount += 1;
        }
        if (_EnemyParty.Enemy3 != null)
        {
            enemyCount += 1;
        }
        if (_EnemyParty.Enemy4 != null)
        {
            enemyCount += 1;
        }
        int[] enemyArray = new int[enemyCount];
        _CombatStarter = CombatStarter;
        #region EnemySpawn
        if (_EnemyParty.Enemy1 != null)
        {
            _EnemyInCombat1 = Instantiate(_EnemyParty.Enemy1, _EnemyPosition1.transform);
            _EnemyInCombat1.GetComponentInChildren<SpriteRenderer>().sortingOrder = 4;
            enemyArray[pointer] = 1;
            pointer++;

        }
        if (_EnemyParty.Enemy2 != null)
        {

            _EnemyInCombat2 = Instantiate(_EnemyParty.Enemy2, _EnemyPosition2.transform);
            _EnemyInCombat2.GetComponentInChildren<SpriteRenderer>().sortingOrder = 8;
            //pointer++;
            enemyArray[pointer] = 2;
            pointer++;

        }
        if (_EnemyParty.Enemy3 != null)
        {

            _EnemyInCombat3 = Instantiate(_EnemyParty.Enemy3, _EnemyPosition3.transform);
            _EnemyInCombat3.GetComponentInChildren<SpriteRenderer>().sortingOrder = 2;
            //pointer++;
            enemyArray[pointer] = 3;
            pointer++;
        }
        if (_EnemyParty.Enemy4 != null)
        {

            _EnemyInCombat4 = Instantiate(_EnemyParty.Enemy4, _EnemyPosition4.transform);
            _EnemyInCombat4.GetComponentInChildren<SpriteRenderer>().sortingOrder = 6;
            //pointer++;
            enemyArray[pointer] = 4;
            pointer++;
        }
        #endregion
        if (_PlayerParty.Companion1 != null)
        {
            compCount += 1;
        }
        if (_PlayerParty.Companion2 != null)
        {
            compCount += 1;
        }
        if (_PlayerParty.Companion3 != null)
        {
            compCount += 1;
        }
        if (_PlayerParty.Companion4 != null)
        {
            compCount += 1;
        }
        int[] companionArray = new int[compCount];
        #region PlayerSpawn
        if (_PlayerParty.Companion1 != null)
        {
            _CompanionInCombat1 = Instantiate(_PlayerParty.Companion1, _CompanionPosition1.transform);
            _CompanionInCombat1.GetComponentInChildren<SpriteRenderer>().sortingOrder = 4;
            companionArray[pointer2] = 1;
            pointer2++;

        }
        if (_PlayerParty.Companion2 != null)
        {
            _CompanionInCombat2 = Instantiate(_PlayerParty.Companion2, _CompanionPosition2.transform);
            _CompanionInCombat2.GetComponentInChildren<SpriteRenderer>().sortingOrder = 8;
            companionArray[pointer2] = 2;
            pointer2++;

        }
        if (_PlayerParty.Companion3 != null)
        {
            _CompanionInCombat3 = Instantiate(_PlayerParty.Companion3, _CompanionPosition3.transform);
            _CompanionInCombat3.GetComponentInChildren<SpriteRenderer>().sortingOrder = 2;
            companionArray[pointer2] = 3;
            pointer2++;

        }
        if (_PlayerParty.Companion4 != null)
        {
            _CompanionInCombat4 = Instantiate(_PlayerParty.Companion4, _CompanionPosition4.transform);
            _CompanionInCombat4.GetComponentInChildren<SpriteRenderer>().sortingOrder = 6;
            companionArray[pointer2] = 4;
            pointer2++;

        }
        #endregion

        //yield return new WaitForSeconds(3);
        

        yield return new WaitForSeconds(2);
        //_CombatUI.SetActive(true);


        StartQueue();
        // Debug.Log("lol"+ currentTurn);
       // yield return new WaitForSeconds(1);
        PlayerTurn(currentQueue[currentTurn]);
    }
    public void CompanionDefend()
    {
        StartCoroutine(CompanionDefendsTimer());


    }
    IEnumerator CompanionDefendsTimer()
    {

        
        if (activeCopmanion == 1)
        {
            _CompanionInCombat1.GetComponent<CompanionHandler>().Defend();
            DisplayCombatLog(_CompanionInCombat1.GetComponent<CompanionHandler>()._CompanionStats.companionName +" blokuje.");
            _CombatUI.GetComponent<CombatUIHandler>().StopPlayerTurn();
            yield return  new WaitForSeconds(2f);
            _CompanionPosition1.transform.position = Temp.transform.position;
            currentTurn += 1;
            StartCoroutine(EnemyTurn(currentQueue[currentTurn]));


        }
        if (activeCopmanion == 2)
        {
            _CompanionInCombat2.GetComponent<CompanionHandler>().Defend();
            DisplayCombatLog(_CompanionInCombat2.GetComponent<CompanionHandler>()._CompanionStats.companionName + " blokuje.");
            _CombatUI.GetComponent<CombatUIHandler>().StopPlayerTurn();
            yield return new WaitForSeconds(2f);
            _CompanionPosition2.transform.position = Temp.transform.position;
            currentTurn += 1;
            StartCoroutine(EnemyTurn(currentQueue[currentTurn]));


        }
        if (activeCopmanion == 3)
        {
            _CompanionInCombat3.GetComponent<CompanionHandler>().Defend();
            DisplayCombatLog(_CompanionInCombat3.GetComponent<CompanionHandler>()._CompanionStats.companionName + " blokuje.");
            _CombatUI.GetComponent<CombatUIHandler>().StopPlayerTurn();
            yield return new WaitForSeconds(2f);
            _CompanionPosition3.transform.position = Temp.transform.position;
            currentTurn += 1;
            StartCoroutine(EnemyTurn(currentQueue[currentTurn]));


        }
        if (activeCopmanion == 4)
        {
            _CompanionInCombat4.GetComponent<CompanionHandler>().Defend();
            DisplayCombatLog(_CompanionInCombat4.GetComponent<CompanionHandler>()._CompanionStats.companionName + " blokuje.");
            _CombatUI.GetComponent<CombatUIHandler>().StopPlayerTurn();
            yield return new WaitForSeconds(2f);
            _CompanionPosition4.transform.position = Temp.transform.position;
            currentTurn += 1;
            StartCoroutine(EnemyTurn(currentQueue[currentTurn]));


        }
        _CombatUI.GetComponent<CombatUIHandler>().StopPlayerTurn();
        HideCombatLog();
    }
}




