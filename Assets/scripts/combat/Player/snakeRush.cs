using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class snakeRush : StateMachineBehaviour
{
    public GameObject hitbox;
    private int count;
    public GameObject bullet;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.gameObject.GetComponent<GridMovement>().gridLock = false;
        if (combatLogic.AttackID == 10)
        {
            Instantiate(bullet, animator.transform.position, Quaternion.Euler(0, 0, 0));
        }
        count = 0;
        //animator.gameObject.tag = "Posionous";
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.transform.position += new Vector3(0,0,-1) * 25 * Time.deltaTime;
        //animator.transform.Translate(Vector3.forward * 0.1f);
        if (count % 5 == 0)
        {
            Instantiate(hitbox, animator.transform.position, Quaternion.Euler(0, 0, 0));
        }

        if (animator.transform.position.z <= -1) { animator.gameObject.GetComponent<GridMovement>().gridLock = true;
          // animator.tag = "Player";
            animator.SetInteger("AttackChoice", 0); }
        count++;
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.gameObject.GetComponent<GridMovement>().gridLock = true;
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
