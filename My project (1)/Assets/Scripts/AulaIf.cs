using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AulaIf : MonoBehaviour
{
    public bool isAlive;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("Pressionou");
        }
    }
}
