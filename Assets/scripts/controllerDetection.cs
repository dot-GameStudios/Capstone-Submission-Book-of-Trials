using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class controllerDetection : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        string[] names = Input.GetJoystickNames();
        for (int x = 0; x < names.Length; x++)
        {
            //print(names[x].Length);
            if (names[x].Length == 19)
            {
                Debug.Log("PS4 CONTROLLER IS CONNECTED");
                combatLogic.ps4InUse = true; 
            }
            if (names[x].Length == 33)
            {
                Debug.Log("XBOX CONTROLLER IS CONNECTED");
                //set a controller bool to true
                combatLogic.ps4InUse = false;

            }
        }
    }
}
