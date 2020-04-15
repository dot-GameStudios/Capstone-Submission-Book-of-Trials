using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class playerStats : MonoBehaviour
{
    public Text healthText;
    public Slider manaBar;
    public int health;
    public Animator animate;
    public bool takedamage;
    public Text manaCount;

    public List<Renderer> rendList = new List<Renderer>();
    // Start is called before the first frame update
    void Start()
    {
        combatLogic.playerLive = true;
        combatLogic.mana = 100;
        animate = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {


        healthText.text = "HP" + health;
        if (combatLogic.mana < 0) { combatLogic.mana = 0; }
        if (combatLogic.mana > 100) { combatLogic.mana = 100; }
        combatLogic.mana += 0.2f;
        manaBar.value = combatLogic.mana;
        manaCount.text = manaBar.value + "/100";
        if (health<=0)
        {
            health = 0;
            combatLogic.playerLive = false;
            animate.SetBool("dead", true);
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (takedamage)
        {
            if (other.tag == "EnemyAttack")
            {
                health -= 10;
                combatLogic.damageCheck -= 5;
                if (animate.GetBool("vulnerable") == true)
                {
                    animate.SetBool("countered", true);
                }
            }
            if (other.tag == "EnemyProjectile")
            {
                health -= 5;
                combatLogic.damageCheck -= 5;
                if (animate.GetBool("vulnerable") == true)
                {
                    animate.SetBool("countered", true);
                }
            }
        }
    }
}
