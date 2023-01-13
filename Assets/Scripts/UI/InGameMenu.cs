using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InGameMenu : MonoBehaviour
{
    private bool active;
    public GameObject _InGameMenu;
    // Start is called before the first frame update
    void Start()
    {
        _InGameMenu.SetActive(false);
        active = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (active)
            {
                active =false;
                _InGameMenu.SetActive(false);
                Time.timeScale = 1;

            }
            else
            {

                active = true;
                _InGameMenu.SetActive(true);
                Time.timeScale = 0f;
            }
        }
    }
}
