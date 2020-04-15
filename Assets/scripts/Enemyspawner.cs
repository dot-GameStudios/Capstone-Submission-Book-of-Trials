using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemyspawner : MonoBehaviour
{
    public GameObject enemy1;
    public GameObject enemy2;
    public int respawntime;
    public bool spawnTrue = true;
    private int counter = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (spawnTrue == true && counter >= respawntime)
        {
            enemy1.SetActive(true);
            enemy2.SetActive(true);
            spawnTrue = false;
            counter = 0;
        }
        if (counter < respawntime && spawnTrue == true) { counter++; }
    }
}
