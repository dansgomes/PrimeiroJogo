using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnim : MonoBehaviour
{
    [Header("Attack Settings")]
    [SerializeField] private Transform attackPoint;
    [SerializeField] private float radius;
    [SerializeField] private LayerMask enemyLayer;

    private Player player;
    private Animator anim;

    private Casting cast;

    private bool isHitting;
    private float recoveryTime = 1f;
    private float timeCount;

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

        if (isHitting)
        {
            timeCount += Time.deltaTime;

            if (timeCount >= recoveryTime)
            {
                isHitting = false;
                timeCount = 0f;
            }
        }
    }

    #region Movement

    private void OnMove()
    {
        if (player.direction.sqrMagnitude > 0)
        {
            if (player.isRolling)
            {
                if (!anim.GetCurrentAnimatorStateInfo(0).IsName("Roll"))
                {
                    anim.SetTrigger("isRoll");
                }              
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
        if(player.isRunning && player.direction.sqrMagnitude > 0)
        {
            anim.SetInteger("transition", 2);
        }
    }

    #endregion

    #region Attack

    public void OnAttack()
    {
        Collider2D hit = Physics2D.OverlapCircle(attackPoint.position, radius, enemyLayer);

        if(hit != null)
        {
            //atacou o inimigo
            hit.GetComponentInChildren<AnimationControl>().OnHit();
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(attackPoint.position, radius);
    }

    #endregion
    //� chamado quando jogador pressiona o bot�o de a��o na �gua
    public void OnCastingStarted()
    {
        anim.SetTrigger("isCasting");
        player.isPaused = true;
    }

    //� chamado quando termina de executar a anima��o de pescaria
    public void OnCastingEnded()
    {
        cast.OnCasting();
        player.isPaused = false;
    }

    public void OnHammeringStarted()
    {
        anim.SetBool("Hammering", true);
    }

    public void OnHammeringEnded()
    {
        anim.SetBool("Hammering", false);
    }

    public void OnHit()
    {
        if (!isHitting)
        {
            anim.SetTrigger("Hit");
            isHitting = true;
        }
        
    }
}
