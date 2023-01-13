using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "CompanionStats", menuName = "Party/Companion", order = 1)]
public class SoCompanion : ScriptableObject
{
    public string companionName;
    public float maxLife;
    public float currentLife;
    public float basickAttack;
    public float skillAttack;
    public float accBasickAttack;
    public float accSkillAttack;
    public float arrmor;
    public float luck;
    public string skillName;
    public string skillDesc;
    public string basickAttackDesc="zwykly atak";
    public bool isAlive = true;
    public int numberOfActions;
    public float coolDown1;
    public string skillName2;
    public string skillDesc2;

    /*
    private int basickAttack;
    private int skillAttack;
    private int accBasickAttack;
    private int accSkillAttack;
    private int luck;
    */
}
