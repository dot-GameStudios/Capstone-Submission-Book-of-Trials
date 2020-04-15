using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class death : StateMachineBehaviour
{
    //private Renderer rend;
    private BoxCollider collider;
    private int count;
    public wolfAudio sounds;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
       // rend = animator.gameObject.GetComponent<Renderer>();
        collider = animator.gameObject.GetComponent<BoxCollider>();
        count = 0;
        collider.enabled = false;
        sounds = animator.GetComponent<wolfAudio>();
        sounds.dying();
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Destroy(animator.gameObject, 2);
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

        }

        count++;
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    //override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    
    //}

    // OnStateMove is called right after Animator.OnAnimatorMove()
    //override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that processes and affects root motion
    //}

    // OnStateIK is called right after Animator.OnAnimatorIK()
    //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that sets up animation IK (inverse kinematics)
    //}
}
