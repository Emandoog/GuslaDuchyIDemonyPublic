using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WodnikSkillEffect : MonoBehaviour
{
    private Animator _SkillEffects;
   
    void Start()
    {
        _SkillEffects = gameObject.GetComponent<Animator>();
    }

    public void PlayAnimation(int animIndex = 0)
    {
        _SkillEffects = gameObject.GetComponent<Animator>();
        if (animIndex == 0)
        {
            _SkillEffects.Play("Base Layer.WaterExplosion");

        }
        //if (animIndex == 1)
        //{
        //    _SkillEffects.Play("Base Layer.Healing");

        //}



    }
    public void DestroyObject()
    {
        Destroy(gameObject);

    }
}
