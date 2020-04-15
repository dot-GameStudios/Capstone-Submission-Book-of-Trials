using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class rankcalculation : MonoBehaviour
{
    public Text rank;
    public Text score;
    // Start is called before the first frame update
    void Start()
    {
        int total = combatLogic.advantgeCheck + combatLogic.attackCheck + combatLogic.counterCheck + combatLogic.damageCheck + combatLogic.firedCheck + combatLogic.timeCheck;
        if (total < 0) { total = 0; }
        if (total > combatLogic.maxtime) { total = combatLogic.maxtime; }
        score.text = "" + total + "/"+combatLogic.maxtime;

        if (total <= combatLogic.maxtime*0.5) { rank.text = "F"; }
        if (total >= combatLogic.maxtime * 0.5) { rank.text = "D"; }
        if (total >= combatLogic.maxtime * 0.6) { rank.text = "C"; }
        if (total >= combatLogic.maxtime * 0.7) { rank.text = "B"; }
        if (total >= combatLogic.maxtime * 0.8) { rank.text = "A"; }
        if (total >= combatLogic.maxtime * 0.9) { rank.text = "S"; }

    }

    // Update is called once per frame
    void Update()
    {
        if (combatLogic.goToOverworld == false)
        {
            if (Input.GetKeyDown(KeyCode.E) || Input.GetKeyDown(KeyCode.Joystick1Button1)) { SceneManager.LoadScene("combatBuilder", LoadSceneMode.Single); }
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.E) || Input.GetKeyDown(KeyCode.Joystick1Button1)) { SceneManager.LoadScene("Overworld", LoadSceneMode.Single); }
        }
    }
}
