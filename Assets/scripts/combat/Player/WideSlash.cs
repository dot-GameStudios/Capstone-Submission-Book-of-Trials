using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WideSlash : StateMachineBehaviour
{
    private GridMovement CurrentPos;
    public GameObject hitbox;
    private Vector3 pos;
    private int moveTick;
    private int X;
    private int Y;
    private bool Spawned;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Spawned = false;
        moveTick = 0;
        CurrentPos = animator.GetComponent<GridMovement>();
        X = CurrentPos.Xpos;
        Y = CurrentPos.Ypos;
        if (combatLogic.targeting)
        {
            if (combatLogic.target == 1)
            {
                CurrentPos.Xpos = GameObject.FindGameObjectWithTag("E1").GetComponent<GridMovement>().Xpos - 1;
                CurrentPos.Ypos = GameObject.FindGameObjectWithTag("E1").GetComponent<GridMovement>().Ypos;
            }
            if (combatLogic.target == 2)
            {
                CurrentPos.Xpos = GameObject.FindGameObjectWithTag("E2").GetComponent<GridMovement>().Xpos - 1;
                CurrentPos.Ypos = GameObject.FindGameObjectWithTag("E2").GetComponent<GridMovement>().Ypos;
            }
            if (combatLogic.target == 3)
            {
                CurrentPos.Xpos = GameObject.FindGameObjectWithTag("E3").GetComponent<GridMovement>().Xpos - 1;
                CurrentPos.Ypos = GameObject.FindGameObjectWithTag("E3").GetComponent<GridMovement>().Ypos;
            }
        }
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (Spawned == false)
        {
            pos = new Vector3(animator.gameObject.transform.position.x, 0, animator.gameObject.transform.position.z - 3);
            Instantiate(hitbox, pos, Quaternion.Euler(0, 0, 0));
            Spawned = true;
        }
        if (moveTick >= 40) { animator.SetInteger("AttackChoice", 0); }
        moveTick++;
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        CurrentPos.Xpos = X;
        CurrentPos.Ypos = Y;
    }
}
