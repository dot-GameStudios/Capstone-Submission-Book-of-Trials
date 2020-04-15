using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaspShoot : StateMachineBehaviour
{
    public GameObject bullet;
    private Vector3 pos;
    private int moveTick;
    private bool Spawned;
    public wolfAudio sounds;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Spawned = false;
        sounds = animator.GetComponent<wolfAudio>();
        animator.SetBool("vulnerable", true);
        pos = new Vector3(animator.gameObject.transform.position.x, animator.gameObject.transform.position.y + 0.5f, animator.gameObject.transform.position.z + 1);
        sounds.attacking();
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (moveTick >= 10 && Spawned == false)
        {

            Instantiate(bullet, pos, Quaternion.Euler(0, 0, 0));
            Spawned = true;

        }
        if (moveTick >= 20)
        {
            animator.SetBool("vulnerable", false);
            animator.SetBool("attack", false);
            
        }
        moveTick++;
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        combatLogic.turnCount++;
    }
}