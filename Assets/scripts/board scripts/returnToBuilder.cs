using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class returnToBuilder : MonoBehaviour
{
    private int count;
    // Start is called before the first frame update
    void Start()
    {
        count = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (count >= 300) { SceneManager.LoadScene("combatBuilder", LoadSceneMode.Single); }      
        count++;
    }
}
