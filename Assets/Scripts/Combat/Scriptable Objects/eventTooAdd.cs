using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class eventTooAdd : MonoBehaviour
{
    public SoPlayerParty _PlayerParty;
    public GameObject companion2;
    public GameObject companion3;
    public GameObject companion4;
    public GameObject triggerCompanion;
    public bool triggerCompanionTwo = false;
    public bool triggerCompanionThree = false;
    public bool triggerCompanionFour = false;
    public GameObject _Destroy=null;

    public void addToParty(bool triggerCompanionTwo, bool triggerCompanionThree, bool triggerCompanionFour) 
    {

        if (triggerCompanionTwo == true)
        {
            _PlayerParty.Companion2 = companion2;
            _PlayerParty.Companion3 = null;
            _PlayerParty.Companion4 = null;
        }
        if (triggerCompanionThree == true)
        {
            _PlayerParty.Companion3 = companion3;
        }
        if (triggerCompanionFour == true) 
        {
            _PlayerParty.Companion4 = companion4;
        }
    }
    public void destroyTrigger() 
    {
        //Destroy(triggerCompanion)
        if (_Destroy != null)
        {
            Destroy(_Destroy);
        }
    }

    private void OnDestroy()
    {
        addToParty(triggerCompanionTwo,triggerCompanionThree,triggerCompanionFour);
        destroyTrigger();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            addToParty(triggerCompanionTwo, triggerCompanionThree, triggerCompanionFour);
            //Debug.Log("Pleyer isn't in range so go fuck yourself");
        }
    }
    /*
    void Start()
    {
        
    }

    void Update()
    {
        
    }
    */
}
