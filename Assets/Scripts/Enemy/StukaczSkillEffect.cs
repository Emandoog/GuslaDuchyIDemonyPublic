using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StukaczSkillEffect : MonoBehaviour
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
            _SkillEffects.Play("Base Layer.StukaczAttack");

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
