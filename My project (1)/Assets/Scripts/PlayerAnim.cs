using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnim : MonoBehaviour
{

    private Player player;
    private Animator anim;

    private Casting cast;

    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<Player>();
        anim = GetComponent<Animator>();

        cast = FindObjectOfType<Casting>();
    }

    // Update is called once per frame
    void Update()
    {
        OnMove();
        OnRun();
    }

    #region Movement

    private void OnMove()
    {
        if (player.direction.sqrMagnitude > 0)
        {
            if (player.isRolling)
            {
                anim.SetTrigger("isRoll");
            }
            else
            {
                anim.SetInteger("transition", 1);
            }
            
        }
        else
        {
            anim.SetInteger("transition", 0);
        }

        if (player.direction.x > 0)
        {
            transform.eulerAngles = new Vector2(0, 0);
        }

        if (player.direction.x < 0)
        {
            transform.eulerAngles = new Vector2(0, 180);
        }

        if (player.IsCutting)
        {
            anim.SetInteger("transition", 3);
        }

        if (player.IsDigging)
        {
            anim.SetInteger("transition", 4);
        }

        if (player.IsWatering)
        {
            anim.SetInteger("transition", 5);
        }
    }

    void OnRun()
    {
        if(player.isRunning)
        {
            anim.SetInteger("transition", 2);
        }
    }

    #endregion

    //é chamado quando jogador pressiona o botão de ação na água
    public void OnCastingStarted()
    {
        anim.SetTrigger("isCasting");
        player.isPaused = true;
    }

    //é chamado quando termina de executar a animação de pescaria
    public void OnCastingEnded()
    {
        cast.OnCasting();
        player.isPaused = false;
    }
}
