using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridColorChange : MonoBehaviour
{
    Material originalMaterial;
    public Material MaterialChange;
    public Material MaterialChange2;
    public Material Posion;
    public bool posioned;
    public Material PlayerChange;
    private bool trigger;
    private bool projTrigger;
    private int reset;
    // Start is called before the first frame update
    void Start()
    {
        originalMaterial = GetComponent<Renderer>().material;
    }

    // Update is called once per frame
    void Update()
    {
        if (pausemenu.paused == false)
        {
            if (trigger)
            {
                reset++;
                if (reset >= 50)
                {
                    GetComponent<Renderer>().material = originalMaterial;
                    trigger = false;
                    reset = 0;
                }
            }
            if (trigger == false && combatLogic.targeting==false && projTrigger == false) { GetComponent<Renderer>().material = originalMaterial; }
            if (posioned) { GetComponent<Renderer>().material = Posion; }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (trigger == false)
        {
            if (other.tag == "EnemyProjectile")
            {
                GetComponent<Renderer>().material = MaterialChange;
                projTrigger = true;

            }
            if (other.tag == "E1" && combatLogic.target == 1)
            {
                GetComponent<Renderer>().material = MaterialChange2;

            }
            if (other.tag == "E2" && combatLogic.target == 2)
            {
                GetComponent<Renderer>().material = MaterialChange2;

            }
            if (other.tag == "E3" && combatLogic.target == 3)
            {
                GetComponent<Renderer>().material = MaterialChange2;
            }
            if (other.tag == "PlayerProjectile")
            {
                GetComponent<Renderer>().material = PlayerChange;
                projTrigger = true;
            }
            if (other.tag == "Xshot")
            {
                GetComponent<Renderer>().material = PlayerChange;
                projTrigger = true;
            }
            if (other.tag == "wideShot")
            {
                GetComponent<Renderer>().material = PlayerChange;
                projTrigger = true;
            }
            if (other.tag == "HeavyProjectile")
            {
                GetComponent<Renderer>().material = PlayerChange;
                projTrigger = true;
            }
            if (other.tag == "VolleyProjectile")
            {
                GetComponent<Renderer>().material = PlayerChange;
                projTrigger = true;
            }
        }

        if (other.tag == "Posionous")
        {
            posioned = true;
        }

        if (other.tag == "PlayerAttack")
        {
            GetComponent<Renderer>().material = PlayerChange;
            trigger = true;
        }

        if (other.tag == "EnemyAttack")
        {
            GetComponent<Renderer>().material = MaterialChange;
            trigger = true;
        }

        if ((other.tag == "E1" || other.tag == "E2" || other.tag == "E3") && posioned != true)
        {
            other.gameObject.GetComponent<EnemyStats>().poisoned = false;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (trigger == false)
        {
            if (other.tag == "E1" && combatLogic.target == 1)
            {
                GetComponent<Renderer>().material = MaterialChange2;
            }
            else if (other.tag == "E2" && combatLogic.target == 2)
            {
                GetComponent<Renderer>().material = MaterialChange2;
            }
            else if (other.tag == "E3" && combatLogic.target == 3)
            {
                GetComponent<Renderer>().material = MaterialChange2;
            }

        }

        if (other.tag == "Posionous")
        {
            posioned = true;
        }

        if ((other.tag == "E1" || other.tag == "E2" || other.tag == "E3") && posioned)
        {
            other.gameObject.GetComponent<EnemyStats>().poisoned = true;
        }

    }

    private void OnTriggerExit(Collider other)
    {
        if (trigger == false) {
            if (other.tag == "EnemyProjectile")
            {
                GetComponent<Renderer>().material = originalMaterial;
                projTrigger = false;
            }

            if (other.tag == "PlayerProjectile")
            {
                GetComponent<Renderer>().material = originalMaterial;
                projTrigger = false;
            }

            if (other.tag == "VolleyProjectile")
            {
                GetComponent<Renderer>().material = originalMaterial;
                projTrigger = false;
            }

            if (other.tag == "Xshot")
            {
                GetComponent<Renderer>().material = originalMaterial;
                projTrigger = false;
            }

            if (other.tag == "wideShot")
            {
                GetComponent<Renderer>().material = originalMaterial;
                projTrigger = false;
            }

            if (other.tag == "HeavyProjectile")
            {
                GetComponent<Renderer>().material = originalMaterial;
                projTrigger = false;
            }

            if (other.tag == "E1")
            {
                GetComponent<Renderer>().material = originalMaterial;

            }
            if (other.tag == "E2")
            {
                GetComponent<Renderer>().material = originalMaterial; ;

            }
            if (other.tag == "E3")
            {
                GetComponent<Renderer>().material = originalMaterial;

            }
        }
        
    }
}
