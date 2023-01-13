using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyStatsDisplay : MonoBehaviour
{
    public GameObject _Enemy1;
    public GameObject _Enemy2;
    public GameObject _Enemy3;
    public GameObject _Enemy4;

    public GameObject _Enemy1Name;
    public GameObject _Enemy2Name;
    public GameObject _Enemy3Name;
    public GameObject _Enemy4Name;

    public GameObject _Enemy1Life;
    public GameObject _Enemy2Life;
    public GameObject _Enemy3Life;
    public GameObject _Enemy4Life;

    public SOEnemyParty _EnemyParty;

    public GameObject _TName1;
    public GameObject _TName2;
    public GameObject _TName3;
    public GameObject _TName4;

    private float Enemy1CurrentLife;
    private float Enemy1MaxLife;
    private string Enemy1Name;

    private float Enemy2CurrentLife;
    private float Enemy2MaxLife;
    private string Enemy2Name;

    private float Enemy3CurrentLife;
    private float Enemy3MaxLife;
    private string Enemy3Name;

    private float Enemy4CurrentLife;
    private float Enemy4MaxLife;
    private string Enemy4Name;



    public GameObject _CombatZone;
    //private GameObject _CombatZone;
   
    void Start()
    {

       // _EnemyParty = _CombatZone.GetComponent<CombatHandler>()._EnemySetUp;
        //_EnemyParty.Enemy1;

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void UpdateStatsUI(int PartyMember = 0)
    {
        _EnemyParty = _CombatZone.GetComponent<CombatHandler>()._EnemySetUp;
        if (PartyMember == 1)
        {

            if (_Enemy1.GetComponentInChildren<EnemyCombat>() != null)
            {
                UpdateStats(PartyMember);
                _TName1.GetComponent<Text>().text = Enemy1Name;
                _Enemy1Name.GetComponent<Text>().text = Enemy1Name;
                _Enemy1Life.GetComponent<Text>().text = Enemy1CurrentLife.ToString() + "/" + Enemy1MaxLife.ToString();
            }
            else 
            {
                _TName1.GetComponent<Text>().text = "";
                _Enemy1Name.GetComponent<Text>().text = "";
                _Enemy1Life.GetComponent<Text>().text = " ";
            }

        }
        if (PartyMember == 2)
        {

            if (_Enemy2.GetComponentInChildren<EnemyCombat>() != null)
            {
                UpdateStats(PartyMember);
                _TName2.GetComponent<Text>().text = Enemy2Name;
                _Enemy2Name.GetComponent<Text>().text = Enemy2Name;
                _Enemy2Life.GetComponent<Text>().text = Enemy2CurrentLife.ToString() + "/" + Enemy2MaxLife.ToString();
            }
            else
            {
                _TName2.GetComponent<Text>().text = "";
                _Enemy2Name.GetComponent<Text>().text = "";
                _Enemy2Life.GetComponent<Text>().text = " ";
            }

        }
        if (PartyMember == 3)
        {

            if (_Enemy3.GetComponentInChildren<EnemyCombat>() != null)
            {
                UpdateStats(PartyMember);
                _TName3.GetComponent<Text>().text = Enemy3Name;
                _Enemy3Name.GetComponent<Text>().text = Enemy3Name;
                _Enemy3Life.GetComponent<Text>().text = Enemy3CurrentLife.ToString() + "/" + Enemy3MaxLife.ToString();
            }
            else
            {
                _TName3.GetComponent<Text>().text = "";
                _Enemy3Name.GetComponent<Text>().text = "";
                _Enemy3Life.GetComponent<Text>().text = " ";
            }

        }
        if (PartyMember == 4)
        {

            if (_Enemy4.GetComponentInChildren<EnemyCombat>() != null)
            {
                UpdateStats(PartyMember);
                _TName4.GetComponent<Text>().text = Enemy4Name;
                _Enemy4Name.GetComponent<Text>().text = Enemy4Name;
                _Enemy4Life.GetComponent<Text>().text = Enemy4CurrentLife.ToString() + "/" + Enemy4MaxLife.ToString();
            }
            else
            {
                _TName4.GetComponent<Text>().text = "";
                _Enemy4Name.GetComponent<Text>().text = "";
                _Enemy4Life.GetComponent<Text>().text = " ";
            }

        }
    }
    public void UpdateStats(int PartyMember = 0)
    {
        if (PartyMember == 1) 
        {

            Enemy1CurrentLife = _Enemy1.GetComponentInChildren<EnemyCombat>().currentLife;
            Enemy1MaxLife = _Enemy1.GetComponentInChildren<EnemyCombat>().maxLife;
            Enemy1Name = _Enemy1.GetComponentInChildren<EnemyCombat>().enemyName;

            //Enemy1CurrentLife = _EnemyParty.Enemy1.GetComponent<EnemyCombat>().currentLife;
            //Enemy1MaxLife = _EnemyParty.Enemy1.GetComponent<EnemyCombat>().maxLife;
            //Enemy1Name = _EnemyParty.Enemy1.GetComponent<EnemyCombat>().enemyName;
        }
        if (PartyMember == 2)
        {
            Enemy2CurrentLife = _Enemy2.GetComponentInChildren<EnemyCombat>().currentLife;
            Enemy2MaxLife = _Enemy2.GetComponentInChildren<EnemyCombat>().maxLife;
            Enemy2Name = _Enemy2.GetComponentInChildren<EnemyCombat>().enemyName;
        }
        if (PartyMember == 3)
        {
            Enemy3CurrentLife = _Enemy3.GetComponentInChildren<EnemyCombat>().currentLife;
            Enemy3MaxLife = _Enemy3.GetComponentInChildren<EnemyCombat>().maxLife;
            Enemy3Name = _Enemy3.GetComponentInChildren<EnemyCombat>().enemyName;
        }
        if (PartyMember == 4)
        {
            Enemy4CurrentLife = _Enemy4.GetComponentInChildren<EnemyCombat>().currentLife;
            Enemy4MaxLife = _Enemy4.GetComponentInChildren<EnemyCombat>().maxLife;
            Enemy4Name = _Enemy4.GetComponentInChildren<EnemyCombat>().enemyName;
        }
    }
}
