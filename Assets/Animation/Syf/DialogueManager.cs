using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class DialogueManager : MonoBehaviour
{
    public Text nameText;
    public Text dialogueText;
    private float speedOfText=0.016f;
    public Animator animator;
    public Queue<string> sentences;
    private bool CombatStarter = false;
    private SOEnemyParty _EnemyParty = null;
    //public GameObject _DialogWindow;
    public GameObject _LeftTalker;
    public GameObject _RightTalker;
    private bool oneTalk1;
    private bool oneTalk2;
         private bool oneTalk3;
    public GameObject _CompanionPickUp1;
    public GameObject _CompanionPickUp2;
    public GameObject _CompanionPickUp3;
   


    void Start()
    {
       
        sentences = new Queue<string>();
    }
   
    public void start(Dialogue dialogue,bool ISCombatStarter = false, SOEnemyParty _EnemyPartyToFight = null, bool OneTalking1 = false, bool OneTalking2 = false, bool OneTalking3 = false)
    {
        _EnemyParty = _EnemyPartyToFight;
        CombatStarter = ISCombatStarter;
        oneTalk1 = OneTalking1;
        oneTalk2 = OneTalking2;
              oneTalk3 = OneTalking3;
        GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovment>().ForbidMovment();
        //Debug.Log("starting converaciotn with " + dialogue.name);
        animator.SetBool("IsOpen", true);
        nameText.text = dialogue.name;
        sentences.Clear();

        foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }
        DisplayNext();
    }
    public void DisplayNext() 
    {
        if (sentences.Count == 0) 
        {
            endDialogue();
            return;
        }
       string sentence = sentences.Dequeue();
        // dialogueText.text = sentence;
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));

    }
    IEnumerator TypeSentence(string sentence)
    {
        dialogueText.text = "";
        foreach (char letter in sentence.ToCharArray()) 
        {
            dialogueText.text += letter;
            yield return new WaitForSeconds(speedOfText);
        }
    }
    public void endDialogue() 
    {
        GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovment>().AllowMovment();
        animator.SetBool("IsOpen", false);
        if (CombatStarter)
        {
            GameObject.FindGameObjectWithTag("CombatZone").GetComponent<CombatHandler>().StartCombat(_EnemyParty, gameObject);

        }
        Debug.Log("end of convercation");
        if (oneTalk1)
        {

            Destroy(_CompanionPickUp1);

        }
        if (oneTalk2)
        {

            Destroy(_CompanionPickUp2);

        }
            if (oneTalk3)
            {

                Destroy(_CompanionPickUp3);

            }

        }
    public void SetTalkers(Sprite LeftTalker, Sprite RightTalker)
    {
        _LeftTalker.GetComponent<Image>().sprite = LeftTalker;
        _RightTalker.GetComponent<Image>().sprite = RightTalker;




    }
}
