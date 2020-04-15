using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    // Start is called before the first frame update
    public List<Camera> cams;
    public int camInt;
    //[SerializeField] private bool DefaultCam;
    private int size;
    void Start()
    {

        if (combatLogic.defaultcam)
        {
            combatLogic.combatOrientation = 1;
        }
        else { combatLogic.combatOrientation = 2; }
        camInt = combatLogic.combatOrientation;
        foreach (Camera cam in cams)
        {
            size++;
            cam.gameObject.SetActive(false);
        }
        cams[camInt - 1].gameObject.SetActive(true);
        combatLogic.camNum = camInt;
    }

    // Update is called once per frame
    void Update()
    {


    }

   public void SetStart()
    {

        if (combatLogic.defaultcam)
        {
            combatLogic.combatOrientation = 1;
        }
        else { combatLogic.combatOrientation = 2; }
        camInt = combatLogic.combatOrientation;
        foreach (Camera cam in cams)
        {
            size++;
            cam.gameObject.SetActive(false);
        }
        cams[camInt - 1].gameObject.SetActive(true);
        combatLogic.camNum = camInt;
    }

    public void SwitchCamera(int camSwap)
    {
        //if (camInt == 1 || camInt == 2)
        //{
        //    camInt = camSwap;
        //    //camInt++;

        //    foreach (Camera cam in cams)
        //    {
        //        cam.gameObject.SetActive(false);
        //    }
        //    cams[camInt - 1].gameObject.SetActive(true);
        //    combatLogic.camNum = camInt;
        //    if (camInt == size) { camInt = combatLogic.combatOrientation - 1; }
        //}
    }
    
}
