using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class StatsDisplay : MonoBehaviour
{
    public GameObject _Comp1Name;
    public GameObject _Comp2Name;
    public GameObject _Comp3Name;
    public GameObject _Comp4Name;

    public GameObject _Comp1Life;
    public GameObject _Comp2Life;
    public GameObject _Comp3Life;
    public GameObject _Comp4Life;

    public SoPlayerParty _PlayerParty;

    public GameObject _TCName1;
    public GameObject _TCName2;
    public GameObject _TCName3;
    public GameObject _TCName4;

    private float comp1CurrentLife;
    private float comp1MaxLife;
    private string comp1Name;

    private float comp2CurrentLife;
    private float comp2MaxLife;
    private string comp2Name;

    private float comp3CurrentLife;
    private float comp3MaxLife;
    private string comp3Name;

    private float comp4CurrentLife;
    private float comp4MaxLife;
    private string comp4Name;

    public GameObject _SkillButton1;
    public GameObject _SkillButton2;
    public GameObject _SkillButton3;
    public GameObject _SkillButton4; 


    public GameObject _SkillName1;
    public GameObject _SkillName2;
    public GameObject _SkillName3;
    public GameObject _SkillName4;

    public GameObject _SkillDesc1;
    public GameObject _SkillDesc2;
    public GameObject _SkillDesc3;
    public GameObject _SkillDesc4;


    // Start is called before the first frame update
    void Start()
    {
       // _PlayerParty.Companion1.GetComponent<CompanionHandler>().name;
    }

    // Update is called once per frame
    void Update()
    {
       // UpdateStatsUI(1);
    }

    public void UpdateStatsUI(int PartyMember = 0)
        {
            if (PartyMember == 1)
            {
               
                if(_PlayerParty.Companion1!=null)
                {
                    UpdateStats(PartyMember);
                    _TCName1.GetComponent<Text>().text = comp1Name;
                    _Comp1Name.GetComponent<Text>().text = comp1Name;                  
                    _Comp1Life.GetComponent<Text>().text = comp1CurrentLife.ToString()+"/"+comp1MaxLife.ToString();
                   
            }
                else
                {
                    _TCName1.GetComponent<Text>().text = "";
                    _Comp1Name.GetComponent<Text>().text = "";
                    _Comp1Life.GetComponent<Text>().text = "";
                }

        }
        if (PartyMember == 2)
        {

            if (_PlayerParty.Companion2 != null)
            {
                UpdateStats(PartyMember);
                _TCName2.GetComponent<Text>().text = comp2Name;
                _Comp2Name.GetComponent<Text>().text = comp2Name;
                _Comp2Life.GetComponent<Text>().text = comp2CurrentLife.ToString() + "/" + comp2MaxLife.ToString();
            }
            else
            {
                _TCName2.GetComponent<Text>().text = "";
                _Comp2Name.GetComponent<Text>().text = "";
                _Comp2Life.GetComponent<Text>().text = "";
            }

        }
        if (PartyMember == 3)
        {

            if (_PlayerParty.Companion3 != null)
            {
                UpdateStats(PartyMember);
                _TCName3.GetComponent<Text>().text = comp3Name;
                _Comp3Name.GetComponent<Text>().text = comp3Name;
                _Comp3Life.GetComponent<Text>().text = comp3CurrentLife.ToString() + "/" + comp3MaxLife.ToString();
            }
            else
            {
                _TCName3.GetComponent<Text>().text = "";
                _Comp3Name.GetComponent<Text>().text = "";
                _Comp3Life.GetComponent<Text>().text = "";
            }

        }
        if (PartyMember == 4)
        {

            if (_PlayerParty.Companion4 != null)
            {
                UpdateStats(PartyMember);
                _TCName4.GetComponent<Text>().text = comp4Name;
                _Comp4Name.GetComponent<Text>().text = comp4Name;
                _Comp4Life.GetComponent<Text>().text = comp4CurrentLife.ToString() + "/" + comp4MaxLife.ToString();
            }
            else
            {
                _TCName4.GetComponent<Text>().text = "";
                _Comp4Name.GetComponent<Text>().text = "";
                _Comp4Life.GetComponent<Text>().text = "";
            }

        }


    }
    public void UpdateSkillButtons(float Companion)
    {
        _SkillButton1.GetComponent<Button>().interactable = false;
        _SkillButton2.GetComponent<Button>().interactable = false;
        _SkillButton3.GetComponent<Button>().interactable = false;
        _SkillButton4.GetComponent<Button>().interactable = false;
        _SkillName1.GetComponent<Text>().text = "Zablokowana";
        _SkillDesc1.GetComponent<Text>().text = "";
        _SkillName2.GetComponent<Text>().text = "Zablokowana";
        _SkillDesc2.GetComponent<Text>().text = "";
        _SkillName3.GetComponent<Text>().text = "Zablokowana";
        _SkillDesc3.GetComponent<Text>().text = "";
        _SkillName4.GetComponent<Text>().text = "Zablokowana";
        _SkillDesc4.GetComponent<Text>().text = "";

        if (Companion == 1) 
        {
           

            if (_PlayerParty.Companion1.GetComponent<CompanionHandler>()._CompanionStats.numberOfActions >= 2) // action with index 0 is basic attack
            {
                
                _SkillName1.GetComponent<Text>().text = _PlayerParty.Companion1.GetComponent<CompanionHandler>()._CompanionStats.skillName;
                _SkillDesc1.GetComponent<Text>().text = _PlayerParty.Companion1.GetComponent<CompanionHandler>()._CompanionStats.skillDesc;
                _SkillButton1.GetComponent<Button>().interactable = true;

                if (_PlayerParty.Companion1.GetComponent<CompanionHandler>().IsActionOnCD(1))
                {
                    _SkillButton1.GetComponent<Button>().interactable = false;

                }
            }
            if (_PlayerParty.Companion1.GetComponent<CompanionHandler>()._CompanionStats.numberOfActions >= 3)
            {
                _SkillName2.GetComponent<Text>().text = _PlayerParty.Companion2.GetComponent<CompanionHandler>()._CompanionStats.skillName2;
                _SkillDesc2.GetComponent<Text>().text = _PlayerParty.Companion2.GetComponent<CompanionHandler>()._CompanionStats.skillDesc2;
                _SkillButton2.GetComponent<Button>().interactable = true;

                if (_PlayerParty.Companion1.GetComponent<CompanionHandler>().IsActionOnCD(2))
                {
                    _SkillButton2.GetComponent<Button>().interactable = false;

                }

            }
            if (_PlayerParty.Companion1.GetComponent<CompanionHandler>()._CompanionStats.numberOfActions >= 4)
            {
                _SkillName3.GetComponent<Text>().text = _PlayerParty.Companion3.GetComponent<CompanionHandler>()._CompanionStats.skillName;
                _SkillDesc3.GetComponent<Text>().text = _PlayerParty.Companion3.GetComponent<CompanionHandler>()._CompanionStats.skillDesc;
                _SkillButton3.GetComponent<Button>().interactable = true;

                if (_PlayerParty.Companion1.GetComponent<CompanionHandler>().IsActionOnCD(3))
                {
                    _SkillButton3.GetComponent<Button>().interactable = false;

                }
            }
            if (_PlayerParty.Companion1.GetComponent<CompanionHandler>()._CompanionStats.numberOfActions >= 5)
            {
                _SkillName4.GetComponent<Text>().text = _PlayerParty.Companion4.GetComponent<CompanionHandler>()._CompanionStats.skillName;
                _SkillDesc4.GetComponent<Text>().text = _PlayerParty.Companion4.GetComponent<CompanionHandler>()._CompanionStats.skillDesc;
                _SkillButton4.GetComponent<Button>().interactable = true;

                if (_PlayerParty.Companion1.GetComponent<CompanionHandler>().IsActionOnCD(4))
                {
                    _SkillButton4.GetComponent<Button>().interactable = false;

                }
            }



        }
        if (Companion == 2)
        {
            if (_PlayerParty.Companion2.GetComponent<CompanionHandler>()._CompanionStats.numberOfActions >= 2) // action with index 0 is basic attack
            {

                _SkillName1.GetComponent<Text>().text = _PlayerParty.Companion2.GetComponent<CompanionHandler>()._CompanionStats.skillName;
                _SkillDesc1.GetComponent<Text>().text = _PlayerParty.Companion2.GetComponent<CompanionHandler>()._CompanionStats.skillDesc;
                _SkillButton1.GetComponent<Button>().interactable = true;

                if (_PlayerParty.Companion2.GetComponent<CompanionHandler>().IsActionOnCD(1))
                {
                    _SkillButton1.GetComponent<Button>().interactable = false;

                }
            }
            if (_PlayerParty.Companion2.GetComponent<CompanionHandler>()._CompanionStats.numberOfActions >= 3) // action with index 0 is basic attack
            {

                _SkillName2.GetComponent<Text>().text = _PlayerParty.Companion2.GetComponent<CompanionHandler>()._CompanionStats.skillName2;
                _SkillDesc2.GetComponent<Text>().text = _PlayerParty.Companion2.GetComponent<CompanionHandler>()._CompanionStats.skillDesc2;
                _SkillButton2.GetComponent<Button>().interactable = true;

                if (_PlayerParty.Companion2.GetComponent<CompanionHandler>().IsActionOnCD(2))
                {
                    _SkillButton2.GetComponent<Button>().interactable = false;

                }
            }
            if (_PlayerParty.Companion2.GetComponent<CompanionHandler>()._CompanionStats.numberOfActions >= 4) // action with index 0 is basic attack
            {

                _SkillName3.GetComponent<Text>().text = _PlayerParty.Companion2.GetComponent<CompanionHandler>()._CompanionStats.skillName;
                _SkillDesc3.GetComponent<Text>().text = _PlayerParty.Companion2.GetComponent<CompanionHandler>()._CompanionStats.skillDesc;
                _SkillButton1.GetComponent<Button>().interactable = true;

                if (_PlayerParty.Companion2.GetComponent<CompanionHandler>().IsActionOnCD(3))
                {
                    _SkillButton3.GetComponent<Button>().interactable = false;

                }
            }
            if (_PlayerParty.Companion2.GetComponent<CompanionHandler>()._CompanionStats.numberOfActions >= 5) // action with index 0 is basic attack
            {

                _SkillName4.GetComponent<Text>().text = _PlayerParty.Companion2.GetComponent<CompanionHandler>()._CompanionStats.skillName;
                _SkillDesc4.GetComponent<Text>().text = _PlayerParty.Companion2.GetComponent<CompanionHandler>()._CompanionStats.skillDesc;
                _SkillButton4.GetComponent<Button>().interactable = true;

                if (_PlayerParty.Companion2.GetComponent<CompanionHandler>().IsActionOnCD(4))
                {
                    _SkillButton4.GetComponent<Button>().interactable = false;

                }
            }



        }
        if (Companion == 3)
        {
            if (_PlayerParty.Companion3.GetComponent<CompanionHandler>()._CompanionStats.numberOfActions >= 2) // action with index 0 is basic attack
            {

                _SkillName1.GetComponent<Text>().text = _PlayerParty.Companion3.GetComponent<CompanionHandler>()._CompanionStats.skillName;
                _SkillDesc1.GetComponent<Text>().text = _PlayerParty.Companion3.GetComponent<CompanionHandler>()._CompanionStats.skillDesc;
                _SkillButton1.GetComponent<Button>().interactable = true;

                if (_PlayerParty.Companion3.GetComponent<CompanionHandler>().IsActionOnCD(1))
                {
                    _SkillButton1.GetComponent<Button>().interactable = false;

                }
            }
            if (_PlayerParty.Companion3.GetComponent<CompanionHandler>()._CompanionStats.numberOfActions >= 3) // action with index 0 is basic attack
            {

                _SkillName2.GetComponent<Text>().text = _PlayerParty.Companion3.GetComponent<CompanionHandler>()._CompanionStats.skillName2;
                _SkillDesc2.GetComponent<Text>().text = _PlayerParty.Companion3.GetComponent<CompanionHandler>()._CompanionStats.skillDesc2;
                _SkillButton2.GetComponent<Button>().interactable = true;

                if (_PlayerParty.Companion3.GetComponent<CompanionHandler>().IsActionOnCD(2))
                {
                    _SkillButton2.GetComponent<Button>().interactable = false;

                }
            }
            if (_PlayerParty.Companion3.GetComponent<CompanionHandler>()._CompanionStats.numberOfActions >= 4) // action with index 0 is basic attack
            {

                _SkillName3.GetComponent<Text>().text = _PlayerParty.Companion3.GetComponent<CompanionHandler>()._CompanionStats.skillName;
                _SkillDesc3.GetComponent<Text>().text = _PlayerParty.Companion3.GetComponent<CompanionHandler>()._CompanionStats.skillDesc;
                _SkillButton3.GetComponent<Button>().interactable = true;

                if (_PlayerParty.Companion3.GetComponent<CompanionHandler>().IsActionOnCD(3))
                {
                    _SkillButton3.GetComponent<Button>().interactable = false;

                }
            }
            if (_PlayerParty.Companion3.GetComponent<CompanionHandler>()._CompanionStats.numberOfActions >= 5) // action with index 0 is basic attack
            {

                _SkillName4.GetComponent<Text>().text = _PlayerParty.Companion3.GetComponent<CompanionHandler>()._CompanionStats.skillName;
                _SkillDesc4.GetComponent<Text>().text = _PlayerParty.Companion3.GetComponent<CompanionHandler>()._CompanionStats.skillDesc;
                _SkillButton4.GetComponent<Button>().interactable = true;

                if (_PlayerParty.Companion3.GetComponent<CompanionHandler>().IsActionOnCD(4))
                {
                    _SkillButton4.GetComponent<Button>().interactable = false;

                }
            }


        }
        if (Companion == 4)
        {
            if (_PlayerParty.Companion4.GetComponent<CompanionHandler>()._CompanionStats.numberOfActions >= 2) // action with index 0 is basic attack
            {

                _SkillName1.GetComponent<Text>().text = _PlayerParty.Companion4.GetComponent<CompanionHandler>()._CompanionStats.skillName;
                _SkillDesc1.GetComponent<Text>().text = _PlayerParty.Companion4.GetComponent<CompanionHandler>()._CompanionStats.skillDesc;
                _SkillButton1.GetComponent<Button>().interactable = true;

                if (_PlayerParty.Companion4.GetComponent<CompanionHandler>().IsActionOnCD(1))
                {
                    _SkillButton1.GetComponent<Button>().interactable = false;

                }
            }
            if (_PlayerParty.Companion4.GetComponent<CompanionHandler>()._CompanionStats.numberOfActions >= 3) // action with index 0 is basic attack
            {

                _SkillName2.GetComponent<Text>().text = _PlayerParty.Companion4.GetComponent<CompanionHandler>()._CompanionStats.skillName2;
                _SkillDesc2.GetComponent<Text>().text = _PlayerParty.Companion4.GetComponent<CompanionHandler>()._CompanionStats.skillDesc2;
                _SkillButton2.GetComponent<Button>().interactable = true;

                if (_PlayerParty.Companion4.GetComponent<CompanionHandler>().IsActionOnCD(2))
                {
                    _SkillButton2.GetComponent<Button>().interactable = false;

                }
            }
            if (_PlayerParty.Companion4.GetComponent<CompanionHandler>()._CompanionStats.numberOfActions >= 4) // action with index 0 is basic attack
            {

                _SkillName3.GetComponent<Text>().text = _PlayerParty.Companion4.GetComponent<CompanionHandler>()._CompanionStats.skillName;
                _SkillDesc3.GetComponent<Text>().text = _PlayerParty.Companion4.GetComponent<CompanionHandler>()._CompanionStats.skillDesc;
                _SkillButton3.GetComponent<Button>().interactable = true;

                if (_PlayerParty.Companion4.GetComponent<CompanionHandler>().IsActionOnCD(3))
                {
                    _SkillButton3.GetComponent<Button>().interactable = false;

                }
            }
            if (_PlayerParty.Companion4.GetComponent<CompanionHandler>()._CompanionStats.numberOfActions >= 5) // action with index 0 is basic attack
            {

                _SkillName4.GetComponent<Text>().text = _PlayerParty.Companion4.GetComponent<CompanionHandler>()._CompanionStats.skillName;
                _SkillDesc4.GetComponent<Text>().text = _PlayerParty.Companion4.GetComponent<CompanionHandler>()._CompanionStats.skillDesc;
                _SkillButton4.GetComponent<Button>().interactable = true;

                if (_PlayerParty.Companion4.GetComponent<CompanionHandler>().IsActionOnCD(4))
                {
                    _SkillButton4.GetComponent<Button>().interactable = false;

                }
            }

        }







    }
    public void UpdateStats(int PartyMember = 0 )
    {   
        if(PartyMember == 1) { 
            if (_PlayerParty.Companion1 != null)
            {
                comp1Name =  _PlayerParty.Companion1.GetComponent<CompanionHandler>()._CompanionStats.companionName;
                comp1CurrentLife = _PlayerParty.Companion1.GetComponent<CompanionHandler>()._CompanionStats.currentLife;
                comp1MaxLife = _PlayerParty.Companion1.GetComponent<CompanionHandler>()._CompanionStats.maxLife;
            }
        }
        if (PartyMember == 2)
        {

            if (_PlayerParty.Companion2 != null)
            {
                comp2Name = _PlayerParty.Companion2.GetComponent<CompanionHandler>()._CompanionStats.companionName;
                comp2CurrentLife = _PlayerParty.Companion2.GetComponent<CompanionHandler>()._CompanionStats.currentLife;
                comp2MaxLife = _PlayerParty.Companion2.GetComponent<CompanionHandler>()._CompanionStats.maxLife;
            }
        }
        if (PartyMember == 3)
        {

            if (_PlayerParty.Companion3 != null)
            {
                comp3Name = _PlayerParty.Companion3.GetComponent<CompanionHandler>()._CompanionStats.companionName;
                comp3CurrentLife = _PlayerParty.Companion3.GetComponent<CompanionHandler>()._CompanionStats.currentLife;
                comp3MaxLife = _PlayerParty.Companion3.GetComponent<CompanionHandler>()._CompanionStats.maxLife;
            }
        }
        if (PartyMember == 4)
        {

            if (_PlayerParty.Companion4 != null)
            {
                comp4Name = _PlayerParty.Companion4.GetComponent<CompanionHandler>()._CompanionStats.companionName;
                comp4CurrentLife = _PlayerParty.Companion4.GetComponent<CompanionHandler>()._CompanionStats.currentLife;
                comp4MaxLife = _PlayerParty.Companion4.GetComponent<CompanionHandler>()._CompanionStats.maxLife;
            }
        }
    }
    public void UpdateTargets() 
    {

       // _TCName1.GetComponent<Text>().text = _PlayerParty1.name;
    
    }

}
