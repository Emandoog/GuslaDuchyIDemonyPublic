using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatStartHandler : MonoBehaviour
{
    private GameObject _Player;
    private GameObject _CombatCamera;
    private GameObject _CombatArea;
    public SOEnemyParty _PartySetUp;
    private void Start()
    {
        _CombatArea = GameObject.FindGameObjectWithTag("CombatZone");
        _Player = GameObject.FindGameObjectWithTag("Player");
        _CombatCamera = GameObject.FindGameObjectWithTag("CombatCamera");
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Start Battle");
            _Player.GetComponent<PlayerMovment>().ForbidMovment();
            //play animation
            //camera changed to combat view
            _Player.GetComponent<PlayerManager>().CameraOff();
           // _CombatArea.GetComponent<CombatHandler>().StartCombat(_PartySetUp.Enemy1, _PartySetUp.Enemy2, _PartySetUp.Enemy3, _PartySetUp.Enemy4,gameObject);
            _CombatArea.GetComponent<CombatHandler>().StartCombat(_PartySetUp, gameObject);
        }
    }

}
