using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogControl : MonoBehaviour
{
    [Header("Components")] 
    public GameObject dialogObj; //janela do dialogo
    public Image profileSprite; //sprite do perfil
    public Text speechText; // texto da fala
    public Text actorNameText; //nome do npc

    [Header("Settings")]
    public float typingSpeed; //velocidade da fala

    //variaveis de controle
    private bool isShowing; //se a janela est� vis�vel
    private int index; //index das senten�as
    private string[] sentences;

    public static DialogControl instance;

    //awake � chamado antes de todos os Star() na hierarquia de execu��o de scripts
    private void Awake()
    {
        instance = this;
    }

    //� chamado ao inicializar
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    IEnumerator TypeSentence()
    {
        foreach (char letter in sentences[index].ToCharArray())
        {
            speechText.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }
    }

    //pular pra pr�xima fala
    public void NextSentence()
    {

    }

    //chamar a fala do npc
    public void Speech(string[] txt) 
    { 
        if (!isShowing)
        {
            dialogObj.SetActive(true);
            sentences = txt;
            StartCoroutine(TypeSentence());
            isShowing = true;
        }
    }
}
