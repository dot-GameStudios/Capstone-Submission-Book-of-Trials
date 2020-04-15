using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sheild : StateMachineBehaviour
{
    Material originalMaterial;
    public Material MaterialChange;
    private int count;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        originalMaterial = animator.gameObject.GetComponent<Renderer>().material;
       animator.SetBool("vulnerable", false);
        animator.gameObject.GetComponent<playerStats>().takedamage = false;
        animator.gameObject.GetComponent<Renderer>().material = MaterialChange;
        count = 0;
        combatLogic.playerLock = true;
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        count++;
        if (count ==30)
        {
            animator.gameObject.GetComponent<Renderer>().material = originalMaterial;
            animator.SetBool("vulnerable", true);
        }
        if (count >= 40)
        {
            animator.gameObject.GetComponent<playerStats>().takedamage = true;
            combatLogic.playerLock = false;
            animator.SetBool("block", false);
        }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

    }

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
