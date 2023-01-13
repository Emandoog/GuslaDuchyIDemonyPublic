using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public GameObject _MainCamera;
    public GameObject _PivotPoint;
    public GameObject _InGameMenu;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void CameraOff()
    {

        _MainCamera.SetActive(false);
    
    }
    public void CameraOn()
    {

        _MainCamera.SetActive(true);

    }
}
