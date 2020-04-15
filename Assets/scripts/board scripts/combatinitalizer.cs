using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class combatinitalizer : MonoBehaviour
{
    [Header("enemyCount")]
    [SerializeField] private int enemyCount;
    [Header("GameObjects")]
    [SerializeField] private GameObject enemy1;
    [SerializeField] private GameObject enemy2;
    [SerializeField] private GameObject enemy3;

    [SerializeField] private GameObject wasp;
    [SerializeField] private GameObject wolf;
    [SerializeField] private GameObject dummy;

    private int count;

    // Start is called before the first frame update
    void Start()
    {
        combatLogic.timeCheck = combatLogic.maxtime;
        combatLogic.advantgeCheck = 0;
        combatLogic.attackCheck = 0;
        combatLogic.counterCheck = 0;
        combatLogic.damageCheck = 0;
        combatLogic.firedCheck = 0;


        if (combatLogic.enemy1ID == 0) { enemy1 = wolf; }
        if (combatLogic.enemy1ID == 1) { enemy1 = wasp; }
        if (combatLogic.enemy1ID == 2) { enemy1 = dummy; }

        if (combatLogic.enemy2ID == 0) { enemy2 = wolf; }
        if (combatLogic.enemy2ID == 1) { enemy2 = wasp; }
        if (combatLogic.enemy2ID == 2) { enemy2 = dummy; }

        if (combatLogic.enemy3ID == 0) { enemy3 = wolf; }
        if (combatLogic.enemy3ID == 1) { enemy3 = wasp; }
        if (combatLogic.enemy3ID == 2) { enemy3 = dummy; }

        enemyCount = combatLogic.numberOfEnemies;

        if (enemyCount > 3) { enemyCount = 3; }
        if(enemyCount == 3)
        {
            enemy1.tag = ("E1");
            Instantiate(enemy1, new Vector3(0, 0, 0), Quaternion.Euler(0, 0, 0));
            enemy2.GetComponent<GridMovement>().Xpos = combatLogic.enemy2x;
            enemy2.GetComponent<GridMovement>().startX = combatLogic.enemy2x;
            enemy2.GetComponent<GridMovement>().Ypos = combatLogic.enemy2y;

            enemy2.tag = ("E2");
            Instantiate(enemy2, new Vector3(0, 0, 0), Quaternion.Euler(0, 0, 0));
            enemy3.GetComponent<GridMovement>().Xpos = combatLogic.enemy3x;
            enemy3.GetComponent<GridMovement>().startX = combatLogic.enemy3x;
            enemy3.GetComponent<GridMovement>().Ypos = combatLogic.enemy3y;

            enemy3.tag = ("E3");
            Instantiate(enemy3, new Vector3(0, 0, 0), Quaternion.Euler(0, 0, 0));
            enemy1.GetComponent<GridMovement>().Xpos = combatLogic.enemy1x;
            enemy1.GetComponent<GridMovement>().startX = combatLogic.enemy1x;
            enemy1.GetComponent<GridMovement>().Ypos = combatLogic.enemy1y;

            combatLogic.enemyNumber = 3;
            combatLogic.E1Live = true;
            combatLogic.E2Live = true;
            combatLogic.E3Live = true;
        }
        if (enemyCount == 2)
        {
            enemy1.tag = ("E1");
            Instantiate(enemy1, new Vector3(0, 0, 0), Quaternion.Euler(0, 0, 0));
            enemy2.GetComponent<GridMovement>().Xpos = combatLogic.enemy2x;
            enemy2.GetComponent<GridMovement>().startX = combatLogic.enemy2x;
            enemy2.GetComponent<GridMovement>().Ypos = combatLogic.enemy2y;

            enemy2.tag = ("E2");
            Instantiate(enemy2, new Vector3(0, 0, 0), Quaternion.Euler(0, 0, 0));
            enemy1.GetComponent<GridMovement>().Xpos = combatLogic.enemy1x;
            enemy1.GetComponent<GridMovement>().startX = combatLogic.enemy1x;
            enemy1.GetComponent<GridMovement>().Ypos = combatLogic.enemy1y;

            combatLogic.enemyNumber = 2;
            combatLogic.E1Live = true;
            combatLogic.E2Live = true;
            combatLogic.E3Live = false;
        }
        if (enemyCount == 1)
        {

            enemy1.tag = ("E1");
            Instantiate(enemy1, new Vector3(0, 0, 0), Quaternion.Euler(0, 0, 0));
            enemy1.GetComponent<GridMovement>().Xpos = combatLogic.enemy1x;
            enemy1.GetComponent<GridMovement>().startX = combatLogic.enemy1x;
            enemy1.GetComponent<GridMovement>().Ypos = combatLogic.enemy1y;

            combatLogic.enemyNumber = 1;
            combatLogic.E1Live = true;
            combatLogic.E2Live = false;
            combatLogic.E3Live = false;
        }
        combatLogic.turnCount = 1;
    }

    void Update()
    {
        if (combatLogic.paused == false)
        {
            if (count == 30) { combatLogic.timeCheck -= 1; count = 0; }
            count++;
            //Debug.Log("timecheck:"+ combatLogic.timeCheck);
        }
    }
}
