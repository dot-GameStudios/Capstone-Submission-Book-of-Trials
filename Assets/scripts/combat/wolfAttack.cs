using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wolfAttack : StateMachineBehaviour
{
    public GameObject hitbox;
    private GridMovement CurrentPos;
    private GridMovement targetPos;
    private Vector3 pos;
    private int moveTick;
    private int X;
    private int Y;
    private bool Spawned;
    private bool move;
    public wolfAudio sounds;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.SetBool("vulnerable", true);
        sounds = animator.GetComponent<wolfAudio>();
        X = 0;
        Y = 0;
        CurrentPos = animator.GetComponent<GridMovement>();
        targetPos = GameObject.FindGameObjectWithTag("Player").GetComponent<GridMovement>();
        X = CurrentPos.Xpos;
        Y = CurrentPos.Ypos;
        move = false;
        Spawned = false;
        moveTick = 0;
        sounds.attacking();
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (pausemenu.paused == false)
        {
            if (moveTick >= 100)
            {
                CurrentPos.Xpos = 6;
                CurrentPos.Ypos = Y;
                animator.SetBool("attack", false);
            }
            if (move == false)
            {
                CurrentPos.Xpos = targetPos.Xpos + 1;
                CurrentPos.Ypos = targetPos.Ypos;
                move = true;
            }
            //if (moveTick >= 50) { animator.SetBool("vulnerable", false); }
            if (moveTick >= 25)
            {
                animator.SetBool("vulnerable", false);
                if (Spawned == false && animator.GetBool("countered") == false)
                {
                    pos = new Vector3(animator.gameObject.transform.position.x, 0, animator.gameObject.transform.position.z + 3);
                    Instantiate(hitbox, pos, Quaternion.Euler(0, 0, 0));
                    Spawned = true;
                }
            }
            moveTick++;

        }

    }
}
