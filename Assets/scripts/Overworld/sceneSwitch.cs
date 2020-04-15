using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class sceneSwitch : MonoBehaviour
{
    public string SceneTpName;
    public Vector3 SceneSpawnPos;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider C)
    {
        if (C.CompareTag("Player"))
        {
            SceneManager.LoadScene(SceneTpName, LoadSceneMode.Single);
            combatLogic.playerPos = SceneSpawnPos;
        }
    }
}
