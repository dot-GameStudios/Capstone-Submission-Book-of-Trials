using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerIdle : StateMachineBehaviour
{
    // private GridMovement CurrentPos;
    //private bool XAxisInUse;
    //private bool YAxisInUse;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        combatLogic.AttackID = 0;
        //CurrentPos = animator.GetComponent<GridMovement>();
        animator.SetBool("vulnerable", true);
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.SetInteger("AttackChoice", combatLogic.AttackID);
        if (pausemenu.paused == false && combatLogic.playerLock == false)
        {
            if (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Joystick1Button2)) { animator.SetBool("shooting", true); combatLogic.firedCheck -= 1; }
            if (Input.GetKeyDown(KeyCode.LeftShift) || Input.GetKeyDown(KeyCode.Joystick1Button6)) { animator.SetBool("block", true); }

        }

    }
}
