using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wolfidle : StateMachineBehaviour
{
    private GridMovement CurrentPos;
    private GridMovement targetPos;
    private int moveTick;
    private int Tiles;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Tiles = 0;
        CurrentPos = animator.GetComponent<GridMovement>();
        targetPos = GameObject.FindGameObjectWithTag("Player").GetComponent<GridMovement>();
        animator.SetBool("vulnerable", false);
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (pausemenu.paused == false)
        {
            if (Tiles >= 4 && CurrentPos.Xpos == 3) { Tiles = 0; animator.SetBool("attack", true); }
            else
            {
                if (animator.gameObject.tag == "E1")
                {
                    updateMove();
                    if (GameObject.FindGameObjectWithTag("E2"))
                    {
                        while (GameObject.FindGameObjectWithTag("E2").GetComponent<GridMovement>().Ypos == CurrentPos.Ypos && CurrentPos.Xpos == GameObject.FindGameObjectWithTag("E2").GetComponent<GridMovement>().Xpos)
                        {
                            CurrentPos.Ypos = Random.Range(1, 4);
                        }
                    }
                    if (GameObject.FindGameObjectWithTag("E3"))
                    {
                        while (GameObject.FindGameObjectWithTag("E3").GetComponent<GridMovement>().Ypos == CurrentPos.Ypos && CurrentPos.Xpos == GameObject.FindGameObjectWithTag("E3").GetComponent<GridMovement>().Xpos)
                        {
                            CurrentPos.Ypos = Random.Range(1, 4);
                        }
                    }
                }
                if (animator.gameObject.tag == "E2")
                {
                    updateMove();
                    if (GameObject.FindGameObjectWithTag("E1"))
                    {
                        while (GameObject.FindGameObjectWithTag("E1").GetComponent<GridMovement>().Ypos == CurrentPos.Ypos && CurrentPos.Xpos == GameObject.FindGameObjectWithTag("E1").GetComponent<GridMovement>().Xpos)
                        {
                            CurrentPos.Ypos = Random.Range(1, 4);
                        }
                    }
                    if (GameObject.FindGameObjectWithTag("E3"))
                    {
                        while (GameObject.FindGameObjectWithTag("E3").GetComponent<GridMovement>().Ypos == CurrentPos.Ypos && CurrentPos.Xpos == GameObject.FindGameObjectWithTag("E3").GetComponent<GridMovement>().Xpos)
                        {
                            CurrentPos.Ypos = Random.Range(1, 4);
                        }
                    }
                }
                if (animator.gameObject.tag == "E3")
                {
                    updateMove();
                    if (GameObject.FindGameObjectWithTag("E2"))
                    {
                        while (GameObject.FindGameObjectWithTag("E2").GetComponent<GridMovement>().Ypos == CurrentPos.Ypos && CurrentPos.Xpos == GameObject.FindGameObjectWithTag("E2").GetComponent<GridMovement>().Xpos)
                        {
                            CurrentPos.Ypos = Random.Range(1, 4);
                        }
                    }
                    if (GameObject.FindGameObjectWithTag("E1"))
                    {
                        while (GameObject.FindGameObjectWithTag("E1").GetComponent<GridMovement>().Ypos == CurrentPos.Ypos && CurrentPos.Xpos == GameObject.FindGameObjectWithTag("E1").GetComponent<GridMovement>().Xpos)
                        {
                            CurrentPos.Ypos = Random.Range(1, 4);
                        }
                    }
                }
            }
        }
    }


    void updateMove()
    {
        moveTick++;
        if (moveTick > 50)
        {
            CurrentPos.Xpos--;
         
            CurrentPos.Ypos = Random.Range(1,4);
            moveTick = 0;
            Tiles++;
        }
        if (CurrentPos.Xpos <= 2) { CurrentPos.Xpos = 6; }       
    }
}
