using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class volleyShot : StateMachineBehaviour
{
    public GameObject bullet;
    private int spawncap;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        spawncap = 0;
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (spawncap <= 4)
        {
            bullet.GetComponent<GridMovement>().Xpos = Random.Range(3, 7);
            bullet.GetComponent<GridMovement>().Ypos = Random.Range(1, 4);
            Instantiate(bullet, new Vector3(bullet.transform.position.x, 15, bullet.transform.position.z), Quaternion.Euler(0, 0, 0));
            spawncap++;
        }
        if (spawncap >= 4)
        {
            animator.SetInteger("AttackChoice", 0);
        }
    }

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
