using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatSounds : MonoBehaviour
{
    public AudioClip _WaterSplash;
    public AudioClip _Healing;
    public AudioClip _Slash;
    public AudioClip _SlashSplash;
    public AudioClip _FireBall;
    public AudioClip _Bonk;
    public AudioClip _Vines;

    public void PickSoundEffect(int SoundIndex)
    {
        
        
            switch (SoundIndex)   
            {

                case 0:
                    gameObject.GetComponent<AudioSource>().clip = _WaterSplash;
                    gameObject.GetComponent<AudioSource>().Play();
                    return;
                case 1:
                    gameObject.GetComponent<AudioSource>().clip = _Healing;
                    gameObject.GetComponent<AudioSource>().Play();
                    return;
                case 2:
                    gameObject.GetComponent<AudioSource>().clip = _Slash;
                    gameObject.GetComponent<AudioSource>().Play();
                    return;
                case 3:
                    gameObject.GetComponent<AudioSource>().clip = _SlashSplash;
                    gameObject.GetComponent<AudioSource>().Play();
                    return;
                case 4:
                    gameObject.GetComponent<AudioSource>().clip = _FireBall;
                    gameObject.GetComponent<AudioSource>().Play();
                    return;
                case 5:
                    gameObject.GetComponent<AudioSource>().clip = _Bonk; ;
                    gameObject.GetComponent<AudioSource>().Play();
                    return;
                case 6:
                    gameObject.GetComponent<AudioSource>().clip = _Vines; ;
                    gameObject.GetComponent<AudioSource>().Play();
                    return;


        }


    }
}
