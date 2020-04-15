using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Countered : StateMachineBehaviour
{
    private Renderer rend;
    private BoxCollider collider;
    private int count;
    public wolfAudio sounds;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.SetBool("attack", false);
        animator.SetBool("shooting", false);
        animator.SetBool("vulnerable", false);
        animator.SetInteger("AttackChoice", 0);
        //rend = animator.gameObject.GetComponent<Renderer>();
        collider = animator.gameObject.GetComponent<BoxCollider>();
        count = 0;
        if (animator.CompareTag("Player"))
        {
            combatLogic.attacklock = true;
        }
        sounds = animator.GetComponent<wolfAudio>();
        sounds.damaged();

    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (count >= 200) { animator.SetBool("countered", false); }
        if (count >= 100 && animator.gameObject.CompareTag("Player")) { animator.SetBool("countered", false); }

        if (count % 5 == 0)
            {
            if (animator.CompareTag("Player"))
            {
                for (int x = 0; x < animator.gameObject.GetComponent<playerStats>().rendList.Count; x++)
                {
                    animator.gameObject.GetComponent<playerStats>().rendList[x].enabled = false;
                }
            }
            else
            {
                for (int x = 0; x < animator.gameObject.GetComponent<EnemyStats>().rendList.Count; x++)
                {
                    animator.gameObject.GetComponent<EnemyStats>().rendList[x].enabled = false;
                }
            }
                count++;
            }
            else
            {
            if (animator.CompareTag("Player"))
            {
                for (int x = 0; x < animator.gameObject.GetComponent<playerStats>().rendList.Count; x++)
                {
                    animator.gameObject.GetComponent<playerStats>().rendList[x].enabled = true;
                }
            }
            else
            {
                for (int x = 0; x < animator.gameObject.GetComponent<EnemyStats>().rendList.Count; x++)
                {
                    animator.gameObject.GetComponent<EnemyStats>().rendList[x].enabled = true;
                }
            }
            count++;
            }
        if (animator.gameObject.CompareTag("Player"))
        {
            collider.enabled = false;
            if (count >= 20) { combatLogic.playerLock = false; }
            else { combatLogic.playerLock = true; }
        }

        //}   
        //wait++;
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (animator.CompareTag("Player"))
        {
            for (int x = 0; x < animator.gameObject.GetComponent<playerStats>().rendList.Count; x++)
            {
                animator.gameObject.GetComponent<playerStats>().rendList[x].enabled = true;
            }
            combatLogic.attacklock = false;
        }
        else
        {
            for (int x = 0; x < animator.gameObject.GetComponent<EnemyStats>().rendList.Count; x++)
            {
                animator.gameObject.GetComponent<EnemyStats>().rendList[x].enabled = true;
            }
        }
        collider.enabled = true;
    }

}
