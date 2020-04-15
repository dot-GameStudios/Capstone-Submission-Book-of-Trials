using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : MonoBehaviour
{
    public int HP;
    public int elementStrength;
    public int elementWeakness;
    public bool poisoned;
    public Animator animate;
    private int count;
    public bool dummy;

    public List<Renderer> rendList = new List<Renderer>();
    // Start is called before the first frame update
    void Start()
    {
        animate = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (poisoned)
        {
            if (count == 10) { HP--; count = 0; }
            count++;
        }

        if (combatLogic.dummyRegen && dummy && HP <= 0) {
            Debug.Log("dummyregen: " + combatLogic.dummyRegen);
            Debug.Log("dummy: " + dummy);
            Debug.Log("hp: " + HP);
            HP = 100;

        }
        else if (HP <= 0)
        {
            

                if (this.gameObject.CompareTag("E1"))
                {
                    combatLogic.E1Live = false;
                    combatLogic.enemyNumber--;
                }
                else if (this.gameObject.CompareTag("E2"))
                {
                    combatLogic.E2Live = false;
                    combatLogic.enemyNumber--;
                }
                else if (this.gameObject.CompareTag("E3"))
                {
                    combatLogic.E3Live = false;
                    combatLogic.enemyNumber--;
                }
                animate.SetBool("dead", true);
            HP = 0;
        }



    }

    private void OnTriggerEnter(Collider other)
    {
        if (animate.GetBool("dead") == false)
        {
            if (other.tag == "PlayerAttack")
            {
                HP -= combatLogic.CurrentDamage;

                if (animate.GetBool("countered") == true)
                {
                    animate.SetBool("countered", false);
                }

                if (animate.GetBool("vulnerable") == true)
                {
                    animate.SetBool("countered", true);
                    combatLogic.counter = true; combatLogic.countertime = 0;
                    combatLogic.counterCheck += 15;
                }
                if (combatLogic.CurrentElement == elementWeakness)
                {
                    combatLogic.advantage = true;
                    combatLogic.advantagetime = 0;
                    HP -= combatLogic.CurrentDamage;
                    combatLogic.advantgeCheck += 5;
                }
            }
            if (other.tag == "PlayerProjectile")
            {
                HP--;

                if (animate.GetBool("countered") == true)
                {
                    animate.SetBool("countered", false);
                }
            }
            if (other.tag == "VolleyProjectile")
            {
                HP -= combatLogic.CurrentDamage;

                if (animate.GetBool("countered") == true)
                {
                    animate.SetBool("countered", false);
                }

                if (animate.GetBool("vulnerable") == true)
                {
                    animate.SetBool("countered", true);
                    combatLogic.counter = true;
                    combatLogic.countertime = 0;
                    combatLogic.counterCheck += 15;
                }
                if (combatLogic.CurrentElement == elementWeakness) {
                    combatLogic.advantage = true;
                    combatLogic.advantagetime = 0;
                    HP -= combatLogic.CurrentDamage;
                    combatLogic.advantgeCheck +=5;
                }
            }
            if (other.tag == "wideShot")
            {
                HP -= combatLogic.CurrentDamage;

                if (animate.GetBool("countered") == true)
                {
                    animate.SetBool("countered", false);
                }

                if (animate.GetBool("vulnerable") == true)
                {
                    animate.SetBool("countered", true);
                    combatLogic.counter = true;
                    combatLogic.countertime = 0;
                    combatLogic.counterCheck += 15;
                }
                if (combatLogic.CurrentElement == elementWeakness)
                {
                    combatLogic.advantage = true;
                    combatLogic.advantagetime = 0;
                    HP -= combatLogic.CurrentDamage;
                    combatLogic.advantgeCheck += 5;
                }
            }
            if (other.tag == "HeavyProjectile")
            {
                HP -= combatLogic.CurrentDamage;

                if (animate.GetBool("countered") == true)
                {
                    animate.SetBool("countered", false);
                }
                else
                {

                    animate.SetBool("countered", true);
                    combatLogic.counter = true; combatLogic.countertime = 0;
                    combatLogic.counterCheck += 5;
                }
                if (combatLogic.CurrentElement == elementWeakness)
                {
                    combatLogic.advantage = true;
                    combatLogic.advantagetime = 0;
                    HP -= combatLogic.CurrentDamage;
                    combatLogic.advantgeCheck += 5;
                }
            }

        }
    }
}
