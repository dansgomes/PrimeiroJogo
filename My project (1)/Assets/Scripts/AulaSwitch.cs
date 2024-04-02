using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AulaSwitch : MonoBehaviour
{
    public int diaSemana;

    // Start is called before the first frame update
    void Start()
    {
        switch(diaSemana)
        {
            case 1:
                Debug.Log("Segunda");
                break;

            case 2:
                Debug.Log("Terça");
                break;

            case 3:
                Debug.Log("Quarta");
                break;

            case 4:
                Debug.Log("Quinta");
                break;

            case 5:
                Debug.Log("Sexta");
                break;

            case 6:
                Debug.Log("Sábado");
                break;

            case 7:
                Debug.Log("Domingo");
                break;

            default:
                Debug.Log("Dia não encontrado");
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
