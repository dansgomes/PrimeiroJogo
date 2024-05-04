using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC_Dialog: MonoBehaviour
{
    public float dialogRange;
    public LayerMask playerLayer;

    public DialogSettings dialog;

    bool playerHit;

    private List<string> sentences = new List<string>();

    private void Start()
    {
        GetNPCInfo();
    }

    //é chamado a cada frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E) && playerHit)
        {
            DialogControl.instance.Speech(sentences.ToArray());
        }
    }

    void GetNPCInfo()
    {
        for(int i = 0; i<dialog.dialogs.Count; i++)
        {
            sentences.Add(dialog.dialogs[i].sentence.portuguese);
        }
    }

    //é usado pela física 
    void FixedUpdate()
    {
        ShowDialog();
    }

    void ShowDialog()
    {
        Collider2D hit = Physics2D.OverlapCircle(transform.position, dialogRange, playerLayer);

        if(hit != null)
        {
            playerHit = true;
        }
        else
        {
            playerHit = false;
            DialogControl.instance.dialogObj.SetActive(false);
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, dialogRange);
    }
}
