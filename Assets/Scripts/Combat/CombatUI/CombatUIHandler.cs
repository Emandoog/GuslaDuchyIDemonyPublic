using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CombatUIHandler : MonoBehaviour
{
    public GameObject _CombatLog;
    public GameObject _CombatUI;
    public GameObject _Generic;
    public GameObject _Specialst;
    public GameObject _Target;
    public GameObject _ConfirmButton;
    public GameObject _EnemyStats;
    public GameObject _PartyStats;

    public GameObject _CompanionTarget;

    public GameObject _Party1;
    public GameObject _Party2;
    public GameObject _Party3;
    public GameObject _Party4;

    public GameObject _Button1;
    public GameObject _Button2;
    public GameObject _Button3;
    public GameObject _Button4;

    public GameObject _TButton1;
    public GameObject _TButton2;
    public GameObject _TButton3;
    public GameObject _TButton4;

    public GameObject _TCButton1;
    public GameObject _TCButton2;
    public GameObject _TCButton3;
    public GameObject _TCButton4;

    
    public GameObject _Enemy1;
    public GameObject _Enemy2;
    public GameObject _Enemy3;
    public GameObject _Enemy4;

    //public Animator animatorBox;

    
    // public GameObject _Button1;

    private SOEnemyParty _EnemyParty;

    private  bool normalAttack;
    private int action;
    private int skillTarget = 0;
    private GameObject _CombatZone;
        private bool targetCopmanion;
    // Start is called before the first frame update
    private void Awake()
    {
        //animatorBox.SetBool("isOpen", true);
        _EnemyParty = GameObject.FindGameObjectWithTag("CombatZone").GetComponent<CombatHandler>()._EnemySetUp;
    }
    void Start()
    {
        _CombatZone = GameObject.FindGameObjectWithTag("CombatZone");
       // _EnemyParty = GameObject.FindGameObjectWithTag("CombatZone").GetComponent<CombatHandler>()._EnemySetUp;
    }
   

    // Update is called once per frame
    void Update()
    {
        UpdateCompanionUIAll();
        UpdateEnemyUIAll();
    }

    public void  CombatUIOn() 
    {

        //_CombatUI.SetActive(true);
       // UpdateUI();
    
    }
    public void CombatUIOFf()
    {
        //animatorBox.SetBool("isOpen", false);
        _CombatUI.SetActive(false);

    }
    public void NormalAttack()
    {
        _Generic.SetActive(false); 
        _Target.SetActive(true);
        action = 0;
        _EnemyStats.SetActive(true);
        _PartyStats.SetActive(false);
        HideTargets();

    }
    public void NormalAttackBack()
    {
       
        _Generic.SetActive(true);
        _Target.SetActive(false);
        _EnemyStats.SetActive(false);
        _PartyStats.SetActive(true);
       

    }
    public void ChooseTargetCompBAck()
    {
        //_CombatZone.GetComponent<CombatHandler>().CompPointerOff(skillTarget);
        HideTargetsComp();
        HideAllEnemyPointers();


        _ConfirmButton.SetActive(false);
        _CompanionTarget.SetActive(false);
        _Generic.SetActive(true);

    }
    public void ChooseTargetComp(int target)
    {
        if (skillTarget != 0)
        {
             _CombatZone.GetComponent<CombatHandler>().CompPointerOff(skillTarget);
           // HideAllEnemyPointers();
           
            //GameObject.FindGameObjectWithTag("CombatZone").GetComponent<CombatHandler>().PointerOff(skillTarget);
        }
        _ConfirmButton.SetActive(true);
       

        skillTarget = target;
        _CombatZone.GetComponent<CombatHandler>().CompPointerOn(skillTarget);
        

    }

    public void ChooseTarget(int target)
    {
        if (skillTarget != 0)
        {
            //GameObject.FindGameObjectWithTag("CombatZone").GetComponent<CombatHandler>().PointerOff(skillTarget);
            HideAllEnemyPointers();
        }
        _ConfirmButton.SetActive(true);
        
        skillTarget = target;
        GameObject.FindGameObjectWithTag("CombatZone").GetComponent<CombatHandler>().PointerOn(skillTarget);
       
    }
   
    public void ChooseTargetBAck()
    {
        // GameObject.FindGameObjectWithTag("CombatZone").GetComponent<CombatHandler>().PointerOff(skillTarget);
        HideAllEnemyPointers();
        _EnemyStats.SetActive(false);
        _PartyStats.SetActive(true);
        _ConfirmButton.SetActive(false);
        _Target.SetActive(false);
        _Generic.SetActive(true);
       
    }
    public void ChooseSpecial()
    {
        
        _Generic.SetActive(false);
        _Specialst.SetActive(true);
        _PartyStats.GetComponent<StatsDisplay>().UpdateSkillButtons(_CombatZone.GetComponent<CombatHandler>().ActiveCompanion());
    }
    public void ChooseSpecialBack()
    {
        _Generic.SetActive(true);
        _Specialst.SetActive(false);
    }
    public void ChooseSpecialAction(int actionIndex) 
    {
         //float active =_CombatZone.GetComponent<CombatHandler>().activeCopmanion;
        targetCopmanion = _CombatZone.GetComponent<CombatHandler>().CheckCompanionTarget(actionIndex);
        action = actionIndex;
        if (!targetCopmanion)
        {
            //check if we want to target enemy or companion.
            
            _Specialst.SetActive(false);
            _Target.SetActive(true);
            _EnemyStats.SetActive(true);
            _PartyStats.SetActive(false);
            HideTargets();
        }
        else
        {
            _Specialst.SetActive(false);
            _CompanionTarget.SetActive(true);
            HideTargetsComp();
            //Debug.Log("Heal");
        
        }

    }
    public void ChooseSpecialActionBack()
    {
        HideTargetsComp();
        _ConfirmButton.SetActive(false);
        _Specialst.SetActive(false);
        _Generic.SetActive(true);
        _EnemyStats.SetActive(false);
        _PartyStats.SetActive(true);

    }


    public void ConfirmTurn() 
    {
        if (targetCopmanion)
        {
            _CombatZone.GetComponent<CombatHandler>().CompPointerOff(skillTarget);
            HideAllEnemyPointers();


        }
        else 
        {
            GameObject.FindGameObjectWithTag("CombatZone").GetComponent<CombatHandler>().PointerOff(skillTarget);
            HideAllEnemyPointers();
        }
           
        _ConfirmButton.SetActive(false);
        _Target.SetActive(false);
        _EnemyStats.SetActive(false);
        _PartyStats.SetActive(true);
        _Generic.SetActive(true);
        _CompanionTarget.SetActive(false);
        GameObject.FindGameObjectWithTag("CombatZone").GetComponent<CombatHandler>().ActionToTake(action,skillTarget);
     // pick another player/ enemy
    
    }

    public void UpdateCompanionUIAll()
    {
        if (gameObject.GetComponentInChildren<StatsDisplay>() != null)
        { 
       
            gameObject.GetComponentInChildren<StatsDisplay>().UpdateStatsUI(1);
            gameObject.GetComponentInChildren<StatsDisplay>().UpdateStatsUI(2);
            gameObject.GetComponentInChildren<StatsDisplay>().UpdateStatsUI(3);
            gameObject.GetComponentInChildren<StatsDisplay>().UpdateStatsUI(4);
        }

    }
    public void UpdateEnemyUIAll()
    {
        if (gameObject.GetComponentInChildren<EnemyStatsDisplay>() != null)
        {

            gameObject.GetComponentInChildren<EnemyStatsDisplay>().UpdateStatsUI(1);
            gameObject.GetComponentInChildren<EnemyStatsDisplay>().UpdateStatsUI(2);
            gameObject.GetComponentInChildren<EnemyStatsDisplay>().UpdateStatsUI(3);
            gameObject.GetComponentInChildren<EnemyStatsDisplay>().UpdateStatsUI(4);
        }

    }
    public void StartPlayerTurn()
    {
        
            _Button1.GetComponent<Button>().interactable = true;
       
            _Button2.GetComponent<Button>().interactable = true;
       
            _Button3.GetComponent<Button>().interactable = true;
       
            _Button4.GetComponent<Button>().interactable = true;
       
    }
    public void StopPlayerTurn()
    {
        _Button1.GetComponent<Button>().interactable = false;
        _Button2.GetComponent<Button>().interactable = false;
        _Button3.GetComponent<Button>().interactable = false;
        _Button4.GetComponent<Button>().interactable = false;
    }

    public void HideTargets() 
    {
        if (_Enemy1.GetComponentInChildren<EnemyCombat>() == null) 
        {
            Debug.Log("NoEnemy1");
            _TButton1.GetComponent<Button>().interactable = false;
        }
        if (_Enemy2.GetComponentInChildren<EnemyCombat>() == null)
        {
            Debug.Log("NoEnemy2");
            _TButton2.GetComponent<Button>().interactable = false;
        }
        if (_Enemy3.GetComponentInChildren<EnemyCombat>() == null)
        {
            Debug.Log("NoEnemy3");
            _TButton3.GetComponent<Button>().interactable = false;
        }
        if (_Enemy4.GetComponentInChildren<EnemyCombat>() == null)
        {
            Debug.Log("NoEnemy4");
            _TButton4.GetComponent<Button>().interactable = false;
        }


        if (_Enemy1.GetComponentInChildren<EnemyCombat>() != null)
        {
            Debug.Log("IsEnemy1");
            _TButton1.GetComponent<Button>().interactable = true;
        }
        if (_Enemy2.GetComponentInChildren<EnemyCombat>() != null)
        {
            Debug.Log("IsEnemy2");
            _TButton2.GetComponent<Button>().interactable = true;
        }
        if (_Enemy3.GetComponentInChildren<EnemyCombat>() != null)
        {
            Debug.Log("IsEnemy3");
            _TButton3.GetComponent<Button>().interactable = true;
        }
        if (_Enemy4.GetComponentInChildren<EnemyCombat>() != null)
        {
            Debug.Log("IsEnemy4");
            _TButton4.GetComponent<Button>().interactable = true;
        }



    }
    public void HideTargetsComp()
    {
        if (_Party1.GetComponentInChildren<CompanionHandler>() == null)
        {
            _TCButton1.GetComponent<Button>().interactable = false;
        }
        if (_Party2.GetComponentInChildren<CompanionHandler>() == null)
        {
            _TCButton2.GetComponent<Button>().interactable = false;
        }
        if (_Party3.GetComponentInChildren<CompanionHandler>() == null)
        {
            _TCButton3.GetComponent<Button>().interactable = false;
        }
        if (_Party4.GetComponentInChildren<CompanionHandler>() == null)
        {
            _TCButton4.GetComponent<Button>().interactable = false;
        }

        
    }
    public void ShowLog(string Log)
    {
        _CombatLog.SetActive(true);
        _CombatLog.GetComponentInChildren<Text>().text = Log;
    
    }
    public void HideLog()
    {
        //_CombatLog.GetComponentInChildren<Text>().text = Log;

        _CombatLog.SetActive(false);
        
    }
    public void HideAllEnemyPointers()
    { 
        _CombatZone.GetComponent<CombatHandler>().PointerOff(1);
        _CombatZone.GetComponent<CombatHandler>().PointerOff(2);
        _CombatZone.GetComponent<CombatHandler>().PointerOff(3);
        _CombatZone.GetComponent<CombatHandler>().PointerOff(4);
    }
}
