using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class viewSwitch : MonoBehaviour
{
    public DialogueHolder detection;
    // Start is called before the first frame update
    void Start()
    {
        detection.state = combatLogic.defaultcam;
    }

    // Update is called once per frame
    void Update()
    {
        if (detection.state == false) { combatLogic.defaultcam = false; }
        if (detection.state == true) { combatLogic.defaultcam = true; }
    }

    public void SwitchView(bool state_)
    {
        if(state_ == false)
        {
            combatLogic.defaultcam = false;
        }
        else
        {
            combatLogic.defaultcam = true;
        }
    }
}
