using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class winLoseTransit : MonoBehaviour
{
    private int count;
    public Animator sounds;
    private bool fadeOut = false;
    //public bool exitScene;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (combatLogic.exit)
        {
            if ((combatLogic.E1Live == false && combatLogic.E2Live == false && combatLogic.E3Live == false) || combatLogic.playerLive == false)
            {
                combatLogic.playerLock = true;
                if (fadeOut == false) {
                    sounds.SetTrigger("fade out");
                    fadeOut = true;
                }
                count++;
            }
            if (combatLogic.DoRank)
            {
                combatLogic.playerLock = false;
                if (combatLogic.playerLive == false && count >= 150) { SceneManager.LoadScene("Overworld", LoadSceneMode.Single); }
                if (combatLogic.E1Live == false && combatLogic.E2Live == false && combatLogic.E3Live == false && count >= 150) { SceneManager.LoadScene("RankScene", LoadSceneMode.Single); }
            }
            else
            {
                combatLogic.playerLock = false;
                if (combatLogic.playerLive == false && count >= 150) { SceneManager.LoadScene("loseScene", LoadSceneMode.Single); }
                if (combatLogic.E1Live == false && combatLogic.E2Live == false && combatLogic.E3Live == false && count >= 150) { SceneManager.LoadScene("winScene", LoadSceneMode.Single); }
            }
        }
    }
}
