using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrigerNpc : MonoBehaviour
{
    public Dialogue dialogue;
    public Dialogue dialogue2;
    private bool dialoge1 = false;
    public bool IsCombatStarter = false;
    public SOEnemyParty _EnemyParty = null;
    public Sprite _LeftTalker;
    public Sprite _RightTalker;
    public bool destroyAfterTalk1 = false;
    public bool destroyAfterTalk2 = false;
    public bool destroyAfterTalk3 = false;






    public void TriggerDialogue()
    {
       
        if (dialoge1 == false) 
        {
            dialoge1 = true;
            FindObjectOfType<DialogueManager>().start(dialogue,IsCombatStarter,_EnemyParty,destroyAfterTalk1,destroyAfterTalk2,destroyAfterTalk3);
            FindObjectOfType<DialogueManager>().SetTalkers(_LeftTalker, _RightTalker);
        }
        else if (dialoge1 == true) 
        {
            Debug.Log(dialoge1);
            dialoge1 = false;
            FindObjectOfType<DialogueManager>().start(dialogue2, IsCombatStarter, _EnemyParty,destroyAfterTalk1,destroyAfterTalk2,destroyAfterTalk3);
            FindObjectOfType<DialogueManager>().SetTalkers(_LeftTalker, _RightTalker);

        }
    }
}
