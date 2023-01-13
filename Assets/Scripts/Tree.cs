using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tree : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject _Tree;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void FixedUpdate()
    {
        if (GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerManager>()._PivotPoint.transform.position.y > gameObject.transform.position.y)
        {
            //GameObject.FindGameObjectWithTag("Player").GetComponentInChildren<SpriteRenderer>().sortingOrder = 1;
           _Tree.GetComponent<SpriteRenderer>().sortingOrder = 2;

        }

        if (GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerManager>()._PivotPoint.transform.position.y < gameObject.transform.position.y)
            {

           // GameObject.FindGameObjectWithTag("Player").GetComponentInChildren<SpriteRenderer>().sortingOrder = 2;

            _Tree.GetComponent<SpriteRenderer>().sortingOrder = 0;


            }
        }
}
