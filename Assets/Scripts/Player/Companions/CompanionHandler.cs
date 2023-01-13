using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CompanionHandler : MonoBehaviour
{
    public SoCompanion _CompanionStats;
    public string CompanionSkills;
    public float damage;
    public float currentLife;
    public float maxLife;
    public float armor;
    public float tmp;
    public GameObject _Pointer;

    private void OnApplicationQuit()
    {
        Defend(false);
    }
    private void OnDestroy()
    {
        Defend(false);
    }


    // Start is called before the first frame update
    void Start()
    {
        _CompanionStats.isAlive = true;
        currentLife = _CompanionStats.maxLife;
        _CompanionStats.currentLife = _CompanionStats.maxLife;
        armor = _CompanionStats.arrmor;
        tmp = _CompanionStats.arrmor;
        _CompanionStats.coolDown1 = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public float TakeAction(int action)
    {
        if (_CompanionStats.companionName == "Dola")
        {
            damage = gameObject.GetComponent<DolaHandler>().playerAttack(action, 2);
            Defend(false);
            // Debug.Log(damage);
            return damage;
        }
        if (_CompanionStats.companionName == "Bia造 Ludek")
        {
            damage = gameObject.GetComponent<BialyLudekHandler>().playerAttack(action, 2);
            Defend(false);
            // Debug.Log(damage);
            return damage;
        }
        if (_CompanionStats.companionName == "K這buk")
        {
            damage = gameObject.GetComponent<KlobukHandler>().playerAttack(action, 2);
            Defend(false);
            // Debug.Log(damage);
            return damage;
        }
        if (_CompanionStats.companionName == "Spaleniec")
        {
            damage = gameObject.GetComponent<SpaleniecHandler>().playerAttack(action, 2);
            Defend(false);
            // Debug.Log(damage);
            return damage;
        }


        return 0;
    }
    public bool CheckAction(int action)
    {
        if (_CompanionStats.companionName == "Dola")
        {
            bool check = gameObject.GetComponent<DolaHandler>().CheckTargetOfAction(action);
           Defend(false);
            // Debug.Log(damage);
            return check;
        }
        if (_CompanionStats.companionName == "Bia造 Ludek")
        {
            bool check = gameObject.GetComponent<BialyLudekHandler>().CheckTargetOfAction(action);
            
            // Debug.Log(damage);
            return check;
        }
        if (_CompanionStats.companionName == "K這buk")
        {
            bool check = gameObject.GetComponent<KlobukHandler>().CheckTargetOfAction(action);
            
            // Debug.Log(damage);
            return check;
        }
        if (_CompanionStats.companionName == "Spaleniec")
        {
            bool check = gameObject.GetComponent<SpaleniecHandler>().CheckTargetOfAction(action);
            
            // Debug.Log(damage);
            return check;
        }
        Defend(false);
        return false;
        
    }
    public void TakeDamage(float Damage)
    {
        _CompanionStats.currentLife =  _CompanionStats.currentLife - Damage;
        if (_CompanionStats.currentLife <= 0)
        {
            Destroy(gameObject);
        }
        _CompanionStats.currentLife = Mathf.Clamp(_CompanionStats.currentLife, 0, _CompanionStats.maxLife);


        Debug.Log("Companion has:" + _CompanionStats.currentLife + " life");
    }
    public void SetPointer(bool set)
    {
        if (set)
        {
            _Pointer.SetActive(true);
        }
        else
        {
            _Pointer.SetActive(false);
        }

    }
    public bool IsActionOnCD(int action) 
    {
        if (_CompanionStats.companionName == "Dola")
        {
            if (action == 1) 
            {

                float CD = gameObject.GetComponent<DolaHandler>().CoolDown;
                if (_CompanionStats.coolDown1 > 0)
                {
                    Debug.Log("Teelephone says CD is " + CD+ " true");
                    return true;
                }
                else if (_CompanionStats.coolDown1 == 0)
                {
                    Debug.Log("Teelephone says CD is " + CD +" false");
                    return false;
                }
            }
        }


        Debug.Log("Teelephone says CD is  fucked");
        //float actions = _CompanionStats.numberOfActions;
        return false;
    
    }
    public void Defend(bool defend = true) 
    {
        _CompanionStats.arrmor = tmp;

        if (defend == true)
        {
            _CompanionStats.arrmor = _CompanionStats.arrmor * 2;
        }
        else if (defend == false) 
        {
            _CompanionStats.arrmor = tmp; 
        }
    }
}
