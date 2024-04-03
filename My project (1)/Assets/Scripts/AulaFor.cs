using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AulaFor : MonoBehaviour
{
    //For é um laço/loop de repetição

    public int[] arrayInt = {1,2,3,4,5 };
    void Start()
    {
        //for(int i = 0; i < 10; i++)
        //{
        //    Debug.Log(i);
        //}

        foreach(int valor in arrayInt)
        {
            Debug.Log(valor);
        }

    }
}
