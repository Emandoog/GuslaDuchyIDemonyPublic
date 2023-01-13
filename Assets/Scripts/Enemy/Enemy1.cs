//using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1 : MonoBehaviour
{
    public GameObject test234;
    private int Health = 100;
    private int Damage = 20;
    private int partySize = 4;
    private int target = 0;
    private int enemy = 4;
    private float test;
    bool isWaiting = true;
    int tryAttack = 0;
    int acition;
    //private int sumeCombate ;
    // statystki bohatera do ataku
    private int basickAttack;
    private int skillAttack;
    private int accBasickAttack;
    private int accSkillAttack;
    private int luck;
    //
    // statytyka przeciwnika wybranego przez gracze potzrabna dalje do obliczen obeazen 
    private int arrmor;
    //


    public GameObject enemy1;
    public GameObject enemy2;
    private void Start()
    {

    }

    public void playerAttack(int acition,int target) // potzrbuje satystyk przeciwnika
    {
        switch (acition) 
        {
            case 0:
                // podstawowy atak
                //link to companion stats
                DamageCalculation(accBasickAttack,luck,basickAttack,arrmor);
                break;

            case 1:
                // umiejetnosc
                DamageCalculation(accSkillAttack,luck, skillAttack,arrmor);
                break;
        }

    } 
    
    
    public void AIbabahrochowa()
    {
        tryAttack = Random.Range(1,partySize +1);

        if (isWaiting == true) 
        {
            // nothing 
            isWaiting = false;

        }else if (isWaiting ==false)
        {
            Damage = 30;
            isWaiting = true; 
        }

    }
    
    public void selecting(int partySize , bool melee= false) // wybranie ktorego sojusznika gracz zaatkawac
    {
        target = Random.Range(1, partySize + 1);
        int alive1 = 1; //zmienna tymczasowa .
        int alive2 = 1; //zmienna tymczasowa .
        if (melee == false)
            {
            //target = target;
            }
        else if(melee == true) 
        {
            if (target == 4 && alive1 == 1)
            {
                target = 1;
            }
            if (target == 3 && alive2 == 1) 
            {
                target = 2;
            }
        }
        Debug.Log(target);
    }
    public void takeDamage(int Damage) // otzrymywanie obrazen
    {
        Health = Health - Damage;
        Debug.Log(Health);
    }
    public float DamageCalculation(int accuracy = 0, int luck = 0, int spellDamage = 0, int arrmor = 0)  // kalkulowanie obrazen
    {
        float Damage = 0;
        int accuracyCheck = Random.Range(0, 101);
        int crit = 5 + luck;
        int critCheck = Random.Range(0, 101);
        if (accuracyCheck < accuracy)
        {
            if (critCheck < crit)
            {
                Damage = spellDamage * 1.5f - arrmor;
              
            }
            else
            {
                Damage = spellDamage - arrmor; 
              
            }
        }
        else
        {
            Damage = 0;
          
        }
        //Debug.Log(Damage);
        return Damage;
    }
    public static string[] queue()
    {
        string[] inputArray= new string[4] {"1e", "2e", "3e", "4e" }; 
        for (int i = inputArray.Length - 1; i > 0; i--)
        {
            int randomIndex = Random.Range(0, i + 1);

            string temp = inputArray[i];
            inputArray[i] = inputArray[randomIndex];
            inputArray[randomIndex] = temp;
        }

        string[] inputArray2 = new string[4] { "1c", "2c", "3c", "4c" };
        for (int ii = inputArray2.Length -1; ii>0 ; ii--) 
        {
            int randomIndex2 = Random.Range(0, ii + 1);

            string tmp2 = inputArray2[ii];
            inputArray2[ii] = inputArray2[randomIndex2];
            inputArray2[randomIndex2] = tmp2;

        }
        string [] arrayCombination = new string [8];

        arrayCombination[0] = inputArray2[0];
        arrayCombination[1] = inputArray[0];
        arrayCombination[2] = inputArray2[1];
        arrayCombination[3] = inputArray[1];
        arrayCombination[4] = inputArray2[2];
        arrayCombination[5] = inputArray[2];
        arrayCombination[6] = inputArray2[3];
        arrayCombination[7] = inputArray[3];
        /*
        for (int zz = 0; zz < 4; zz++) 
        {
            Debug.Log(inputArray[zz]);

        }
        Debug.Log(" ");
        for (int zzz = 0; zzz < 4; zzz++)
        {
            Debug.Log(inputArray2[zzz]);
        }
        Debug.Log(arrayCombination);
*/
        Debug.Log("enemy" + inputArray[0] + inputArray[1] + inputArray[2] + inputArray[3]);
        Debug.Log("player" + inputArray2[0] + inputArray2[1] + inputArray2[2] + inputArray2[3]);
        Debug.Log("sprawdzenie" + arrayCombination[0] + arrayCombination[1] + arrayCombination[2] + arrayCombination[3] + arrayCombination[4] + arrayCombination[5] + arrayCombination[6] + arrayCombination[7]);
        return arrayCombination;
    }
        
    
   
    void Update() // wywolanie wczesniej opisanych funkcji pod danym przyciskiem 
    {   
        if (Input.GetKeyDown("g")) {
            takeDamage(Damage);
        }
        if (Input.GetKeyDown("t"))
        {
            selecting(partySize); // zawsze musi byæ +1
        }
        if (Input.GetKeyDown("l"))
        {
            test = DamageCalculation(50,5,20,5);
            Debug.Log(test + "kurwa dziala");
        }
        if (Input.GetKeyDown("x"))
        {
            queue();
           
        }
        if (Input.GetKeyDown("o"))
        {
            test234.SetActive(true);
            //test234.GetComponent<Dialogue>().startDia();
        }
    }
}
/*
        float[] tryy = new float[sumeCombate];
        
        
        int n = tryy.Length;
        float temp = 0;
        for (int i = 0; i < n; i++)
        {
            for (int v = 1; v < (n - i); v++)
            {
                if (tryy[v - 1] < tryy[v])
                {
                    temp = tryy[v - 1];
                    tryy[v - 1] = tryy[v];
                    tryy[v] = temp;
                }

            }
        }
        Debug.Log(tryy[0]);
        Debug.Log(tryy[1]);
        */