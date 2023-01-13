using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyCombat : MonoBehaviour
{
    public SOEnemyStats _EnemyStats;
    public float speed;
    public float maxLife;
    public float currentLife;
    public GameObject _Pointer;
    public string enemyName;
    public SOEnemyAttack _EnemyAttacks;
    public float armor = 5 ;
    // Start is called before the first frame update

    void Start()
    {
        speed = _EnemyStats.speed;
        maxLife = _EnemyStats.maxLife;
        currentLife = maxLife;
        enemyName = _EnemyStats.enemyName;

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void SetPointer (bool set)
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
    public void TakeDamage(float Damage) 
    {
        currentLife = currentLife - Damage;
        if (currentLife <= 0)
        {
            if (_EnemyStats.enemyName == "Dziki  Myœliwy") 
            {

                SceneManager.LoadScene(2);
            }
            Destroy(gameObject);
        }
        //updateUI
        Debug.Log("Enemy has:"+currentLife+" life");
    }
    public void TakeAction()
    {
        enemyName = _EnemyStats.enemyName;
        if (enemyName == "Grochowa Baba") 
        {
            Debug.Log("Grochowa Baba took action");
            gameObject.GetComponent<Baba>().BabaAI();
            return;
        }
        if (enemyName == "Wietrzyca") 
        {
            Debug.Log("Wietrzyca took action");
            gameObject.GetComponent<Wietrzyca>().WietrzycaAI();
            return;
        }
        if (enemyName == "Stukacz")
        {
            Debug.Log("Stukacz XDDDDDd");
            gameObject.GetComponent<Stukacz>().StukaczAI();
            return;
        }
        if (enemyName == "Wodnik") 
        {
            gameObject.GetComponent<Wodnik>().WodnikAI();
        }
        if (enemyName == "Dziki  Myœliwy") 
        {
            gameObject.GetComponent<DzikiMysliwyHandler>().DzikiMysliwyAI();
        }

        Debug.Log(enemyName);
        Debug.Log("NiemozliweXD");
    }
}
