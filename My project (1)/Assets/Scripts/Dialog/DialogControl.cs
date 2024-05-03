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
    private bool isShowing; //se a janela está visível
    private int index; //index das sentenças
    private string[] sentences;

    public static DialogControl instance;

    //awake é chamado antes de todos os Star() na hierarquia de execução de scripts
    private void Awake()
    {
        instance = this;
    }

    //é chamado ao inicializar
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

    //pular pra próxima fala
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
