using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class pausemenu : MonoBehaviour
{
    public static bool paused;

    public GameObject ingameUI;
    public GameObject CountDownUI;
    public GameObject PauseUI;
    private int wait;
    private int cycle;
    private bool startup;
    public Text count;
    // Start is called before the first frame update
    void Start()
    {
        CountDownUI.SetActive(true);
        Time.timeScale = 0f;
        ingameUI.SetActive(false);
        paused = true;
        startup = true;
        cycle = 3;

        combatLogic.paused = true;
    }

    // Update is called once per frame
    void Update()
    {


        if (startup == false) {
            if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.Joystick1Button9))
            {
                if (paused == true)
                {
                    PauseUI.SetActive(false);
                    Time.timeScale = 1f;
                    ingameUI.SetActive(true);
                    paused = false;
                    combatLogic.paused = false;
                }
                else if (paused == false)
                {
                    PauseUI.SetActive(true);
                    Time.timeScale = 0f;
                    ingameUI.SetActive(false);
                    paused = true;
                    combatLogic.paused = true;
                }
            }
        }

        if (startup == true)
        {
            wait++;
            if (wait >= 50)
            {
                count.text = "" + cycle;
                cycle--;
                wait = 0;
            }
            if (cycle == -1)
            {
                CountDownUI.SetActive(false);
                startup = false;
                Time.timeScale = 1f;
                ingameUI.SetActive(true);
                paused = false;
                combatLogic.playerLock = false;
                combatLogic.paused = false;
            }
        }
    }
}
