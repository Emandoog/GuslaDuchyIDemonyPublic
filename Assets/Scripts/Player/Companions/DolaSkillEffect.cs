using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DolaSkillEffect : MonoBehaviour

{
    private Animator _SkillEffects;
    // Start is called before the first frame update
    void Start()
    {
        _SkillEffects = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void PlayAnimation(int animIndex = 0)
    {
        _SkillEffects = gameObject.GetComponent<Animator>();
        if (animIndex == 0) 
        {
            _SkillEffects.Play("Base Layer.BasicAttack");
        
        }
        if (animIndex == 1)
        {
            _SkillEffects.Play("Base Layer.Healing");

        }
        if (animIndex == 2)
        {
            Debug.Log("XD");
            _SkillEffects.Play("Base Layer.DolaSadDeath");
        }



        }
        public void DestroyObject()
    {
        Destroy(gameObject);   
    
    }
}