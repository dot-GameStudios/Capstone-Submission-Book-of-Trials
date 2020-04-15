using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class nevMeshTest : MonoBehaviour
{
    public Vector3[] pathNodes;
    [SerializeField]
    private int pathnode;

    public NavMeshAgent ai;

    /// <summary>
    /// combat settings
    /// </summary>
    /// 
    [Header("Combat Settings")]  
    public int numberOfEnemies;
    public int timeLimit;
    public bool defaultcam;
    public bool doRandom;
    [Header("enemy1 Settings")]
    public int enemy1ID;
    public int e1x;
    public int e1y;
    [Header("enemy2 Settings")]
    public int enemy2ID;
    public int e2x;
    public int e2y;
    [Header("enemy3 Settings")]
    public int enemy3ID;
    public int e3x;
    public int e3y;





    // Start is called before the first frame update
    void Start()
    {
        combatLogic.dummyRegen = false;
        combatLogic.exit = true;
        combatLogic.playerManaLoss = true;
        combatLogic.DoRank = true;
        combatLogic.goToOverworld = true;
    }

    // Update is called once per frame
    void Update()
    {
             if (pathnode < pathNodes.Length)
        {
            ai.SetDestination(pathNodes[pathnode]);
            if ((pathNodes[pathnode].x + 1 > transform.position.x && transform.position.x > pathNodes[pathnode].x - 1) && (pathNodes[pathnode].z + 1 > transform.position.z && transform.position.z > pathNodes[pathnode].z - 1))
            { pathnode++;}
            if (pathnode >= pathNodes.Length) { pathnode = 0; }
        }
    }

    void transitionToCombat()
    {
        if(doRandom == true)
        {
            //enemy1ID = Random.Range(0, 2);
            enemy2ID = Random.Range(0, 2);
            enemy3ID = Random.Range(0, 2);

            //e1x = Random.Range(3, 7);
            //e1y = Random.Range(1, 4);

            e2x = Random.Range(3, 7);
            e2y = Random.Range(1, 4);
            while (e2x == e1x) { e2x = Random.Range(3, 7); }

            e3x = Random.Range(3, 7);
            e3y = Random.Range(1, 4);
            while (e3x == e1x || e3x == e2x) { e3x = Random.Range(3, 7); }

            numberOfEnemies = Random.Range(1, 4);

            timeLimit = 50+numberOfEnemies*50;
        }
        combatLogic.enemy1ID = enemy1ID;
        combatLogic.enemy2ID = enemy2ID;
        combatLogic.enemy3ID = enemy3ID;

        combatLogic.enemy1x = e1x;
        combatLogic.enemy1y = e1y;
        combatLogic.enemy2x = e2x;
        combatLogic.enemy2y = e2y;
        combatLogic.enemy3x = e3x;
        combatLogic.enemy3y = e3y;

        combatLogic.numberOfEnemies = numberOfEnemies;

        combatLogic.maxtime = timeLimit;
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Player" && combatLogic.playerLock == false)
        {
            combatLogic.playerPos = other.transform.position;
            transitionToCombat();
            SceneManager.LoadScene("Combat", LoadSceneMode.Single);
        }
    }
}
