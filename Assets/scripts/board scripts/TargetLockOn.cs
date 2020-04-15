using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetLockOn : MonoBehaviour
{
    // Start is called before the first frame update
    public int enemyCount;
    public int enemyAlive;
    public GridMovement enemy1;
    public GridMovement enemy2;
    public GridMovement enemy3;
    private GridMovement PlayerPos;
    private bool targeting = false;

    public int targetCount = 0;

    void Start()
    {
        PlayerPos = GameObject.FindGameObjectWithTag("Player").GetComponent<GridMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        if (GameObject.FindWithTag("E1")&&enemy1==null)
        {
            enemy1 = GameObject.FindWithTag("E1").GetComponent<GridMovement>();
            enemyCount++;
        }
        if (GameObject.FindWithTag("E2") && enemy2 == null)
        {
            enemy2 = GameObject.FindWithTag("E2").GetComponent<GridMovement>();
            enemyCount++;
        }
        if (GameObject.FindWithTag("E3") && enemy3 == null)
        {
            enemy3 = GameObject.FindWithTag("E3").GetComponent<GridMovement>();
            enemyCount++;
        }

        if (Input.GetMouseButtonDown(1) || Input.GetKeyDown(KeyCode.Joystick1Button7))
        {
            if (targeting == false) { targeting = true; }
            else { targeting = false; targetCount = 0; combatLogic.target = targetCount; combatLogic.targeting = false; }
        }

        if(targeting == true){
            if (enemyCount == 3)
            {
                if (PlayerPos.Ypos == enemy1.Ypos && enemy1.Ypos == enemy2.Ypos && enemy1.Ypos == enemy3.Ypos && enemy1.Xpos == Mathf.Min(enemy1.Xpos, enemy2.Xpos, enemy3.Xpos)) { combatLogic.targeting = true; targetCount = 1; }
                else if (PlayerPos.Ypos == enemy1.Ypos && enemy1.Ypos == enemy2.Ypos && enemy1.Ypos != enemy3.Ypos && enemy1.Xpos == Mathf.Min(enemy1.Xpos, enemy2.Xpos)) { combatLogic.targeting = true; targetCount = 1; }
                else if (PlayerPos.Ypos == enemy1.Ypos && enemy1.Ypos != enemy2.Ypos && enemy1.Ypos == enemy3.Ypos && enemy1.Xpos == Mathf.Min(enemy1.Xpos, enemy3.Xpos)) { combatLogic.targeting = true; targetCount = 1; }
                else if (PlayerPos.Ypos == enemy1.Ypos && enemy1.Ypos != enemy2.Ypos && enemy1.Ypos != enemy3.Ypos) { combatLogic.targeting = true; targetCount = 1; }
                else if (PlayerPos.Ypos == enemy2.Ypos && enemy2.Ypos == enemy1.Ypos && enemy2.Ypos == enemy3.Ypos && enemy2.Xpos == Mathf.Min(enemy1.Xpos, enemy2.Xpos, enemy3.Xpos)) { combatLogic.targeting = true; targetCount = 2; }
                else if (PlayerPos.Ypos == enemy2.Ypos && enemy2.Ypos == enemy1.Ypos && enemy2.Ypos != enemy3.Ypos && enemy2.Xpos == Mathf.Min(enemy1.Xpos, enemy2.Xpos)) { combatLogic.targeting = true; targetCount = 2; }
                else if (PlayerPos.Ypos == enemy2.Ypos && enemy2.Ypos != enemy1.Ypos && enemy2.Ypos == enemy3.Ypos && enemy2.Xpos == Mathf.Min(enemy2.Xpos, enemy3.Xpos)) { combatLogic.targeting = true; targetCount = 2; }
                else if (PlayerPos.Ypos == enemy2.Ypos && enemy2.Ypos != enemy1.Ypos && enemy2.Ypos != enemy3.Ypos) { combatLogic.targeting = true; targetCount = 2; }
                else if (PlayerPos.Ypos == enemy3.Ypos && enemy3.Ypos == enemy1.Ypos && enemy3.Ypos == enemy2.Ypos && enemy3.Xpos == Mathf.Min(enemy1.Xpos, enemy2.Xpos, enemy3.Xpos)) { combatLogic.targeting = true; targetCount = 3; }
                else if (PlayerPos.Ypos == enemy3.Ypos && enemy3.Ypos == enemy1.Ypos && enemy3.Ypos != enemy2.Ypos && enemy3.Xpos == Mathf.Min(enemy1.Xpos, enemy3.Xpos)) { combatLogic.targeting = true; targetCount = 3; }
                else if (PlayerPos.Ypos == enemy3.Ypos && enemy3.Ypos != enemy1.Ypos && enemy3.Ypos == enemy2.Ypos && enemy3.Xpos == Mathf.Min(enemy2.Xpos, enemy3.Xpos)) { combatLogic.targeting = true; targetCount = 3; }
                else if (PlayerPos.Ypos == enemy3.Ypos && enemy3.Ypos != enemy1.Ypos && enemy3.Ypos != enemy2.Ypos) { combatLogic.targeting = true; targetCount = 3; }
            }
            if (enemyCount == 2)
            {
                if (PlayerPos.Ypos == enemy1.Ypos && enemy1.Ypos == enemy2.Ypos && enemy1.Xpos == Mathf.Min(enemy1.Xpos, enemy2.Xpos)) { combatLogic.targeting = true; targetCount = 1; }
                else if (PlayerPos.Ypos == enemy1.Ypos && enemy1.Ypos != enemy2.Ypos) { combatLogic.targeting = true; targetCount = 1; }
                else if (PlayerPos.Ypos == enemy2.Ypos && enemy2.Ypos == enemy1.Ypos && enemy2.Xpos == Mathf.Min(enemy1.Xpos, enemy2.Xpos)) { combatLogic.targeting = true; targetCount = 2; }
                else if (PlayerPos.Ypos == enemy2.Ypos && enemy2.Ypos != enemy1.Ypos) { combatLogic.targeting = true; targetCount = 2; }
                else { combatLogic.targeting = false; targetCount = 0; }
            }
            if (enemyCount == 1)
            {
                if (PlayerPos.Ypos == enemy1.Ypos) { combatLogic.targeting = true; targetCount = 1; }
                else { combatLogic.targeting = false; targetCount = 0; }
            }

        }
        if (targetCount > enemyCount) { targetCount = 0; combatLogic.targeting = false; }
        combatLogic.target = targetCount;


    }
}
