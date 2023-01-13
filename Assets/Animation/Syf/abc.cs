using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class abc : MonoBehaviour
{
    public bool range;
    public KeyCode key;
    public UnityEvent action;
    public GameObject _Pointer;
     
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (range)
        {
            if (Input.GetKeyDown(key))
            {
                action.Invoke();
                range = false;
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            _Pointer.SetActive(true);
            range = true;
           // Debug.Log("Pleyer is in range");
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            _Pointer.SetActive(false);
            range = false;
            //Debug.Log("Pleyer isn't in range so go fuck yourself");
        }
    }
}
