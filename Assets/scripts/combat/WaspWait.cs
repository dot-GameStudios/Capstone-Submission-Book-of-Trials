using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaspWait : StateMachineBehaviour
{
    private GridMovement CurrentPos;
    private GridMovement targetPos;
    private int moveTick;
    private int Tiles;
    private int playerWait;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        CurrentPos = animator.GetComponent<GridMovement>();
        targetPos = GameObject.FindGameObjectWithTag("Player").GetComponent<GridMovement>();
        Tiles = 0;
        playerWait = 0;
        if (animator.gameObject.tag == "E1") { combatLogic.E1Turn = true; }
        if (animator.gameObject.tag == "E2") { combatLogic.E2Turn = true; }
        if (animator.gameObject.tag == "E3") { combatLogic.E3Turn = true; }
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (pausemenu.paused == false)
        {

            if (combatLogic.turnCount == 1 && (combatLogic.E1Live == false || combatLogic.E1Turn == false)) { combatLogic.turnCount++; Debug.Log("skipped1"); }
            if (combatLogic.turnCount == 2 && (combatLogic.E2Live == false || combatLogic.E2Turn == false)) { combatLogic.turnCount++; Debug.Log("skipped2"); }
            if (combatLogic.turnCount == 3 && (combatLogic.E3Live == false || combatLogic.E3Turn == false)) { combatLogic.turnCount++; Debug.Log("skipped3"); }
           // Debug.Log("turncount"+combatLogic.turnCount);

            if (Tiles <= 6)
            {
                if (targetPos.Xpos != CurrentPos.Xpos)
                {
                    if (combatLogic.turnCount == 1 && animator.gameObject.tag == "E1")
                    {
                            updateMove();
                        //Debug.Log("1active");

                    }
                    if (combatLogic.turnCount == 2 && animator.gameObject.tag == "E2")
                    {
                            updateMove();
                        //Debug.Log("2active");
                    }
                    if (combatLogic.turnCount == 3 && animator.gameObject.tag == "E3")
                    {
                            updateMove();
                        //Debug.Log("3active");
                    }

                }
            }
            if (playerWait >= 6 || Tiles > 6) { animator.SetBool("attack", true); }
            if (combatLogic.turnCount > 3) { combatLogic.turnCount = 1; }
        }
    }

    void updateMove()
    {
        moveTick++;
        if (moveTick > 25)
        {
            if (CurrentPos.Ypos > targetPos.Ypos) { CurrentPos.Ypos--; Tiles++; }
            if (CurrentPos.Ypos < targetPos.Ypos) { CurrentPos.Ypos++; Tiles++; }
            if (CurrentPos.Ypos == targetPos.Ypos) { playerWait++; }
            moveTick = 0;
        }
    }
}