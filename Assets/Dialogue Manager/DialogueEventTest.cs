using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueEventTest : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void BeforeTest()
    {
        Debug.Log("Ah Yeah! This is happening!");
    }

    public void BeforeTest(bool gottem)
    {
        if (gottem)
        {
            Debug.Log("Ladies and Gentleman. We Gottem");
        }
    }

    public void AfterTest()
    {
        Debug.Log("I'll make you eat those words!");
    }

    public void AfterTest(bool gottem)
    {
        if (gottem)
        {
            Debug.Log("NOW SON!");
        }
    }
}
