using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicHandler : MonoBehaviour
{
    public AudioClip _BackGroundMusic1;
    public AudioClip _BackGroundMusic2;

    public AudioClip _CombatMusic1;
    public AudioClip _CombatMusic2;

    public AudioClip _BossFight;

    //public AudioClip _BossMusic1;

    private GameObject _MusicSource;
    void Start()
    {
        PickMusic(false, true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void PickMusic(bool CombatMusic = false, bool BackGroundMusic = true, int MusicIndex = -1)
    {
        if (CombatMusic)
        {
            if (MusicIndex == -1)
            {
                MusicIndex = Random.Range(0, 2);
            }
            switch (MusicIndex)
            {
                case 0:
                    gameObject.GetComponent<AudioSource>().clip = _CombatMusic1;
                    gameObject.GetComponent<AudioSource>().Play();
                    return;

                case 1:
                    gameObject.GetComponent<AudioSource>().clip = _CombatMusic2;
                    gameObject.GetComponent<AudioSource>().Play();
                    return;

            }



        }

        if (BackGroundMusic)
        {
            if (MusicIndex == -1) 
            {
                MusicIndex = Random.Range(0, 2);
            }
            switch (MusicIndex)
            {
                case 0:
                    gameObject.GetComponent<AudioSource>().clip = _BackGroundMusic1;
                    gameObject.GetComponent<AudioSource>().Play();
                    return;

                case 1:
                    gameObject.GetComponent<AudioSource>().clip = _BackGroundMusic2;
                    gameObject.GetComponent<AudioSource>().Play();
                    return;

            }



        }

    }
    public void BossMusic() 
    {

        gameObject.GetComponent<AudioSource>().clip = _BossFight;
        gameObject.GetComponent<AudioSource>().Play();
    }

}
