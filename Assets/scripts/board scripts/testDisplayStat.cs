using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testDisplayStat : MonoBehaviour
{
    public GameObject floatingtext;
    public TextMesh text;
    private int previousCam;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        text.text = ""+this.gameObject.GetComponent<EnemyStats>().HP;
        //floatingtext.transform.LookAt(Camera.current.transform.position);
        if (previousCam != combatLogic.camNum)
        {
            switch (combatLogic.camNum)
            {
                case 1:
                    floatingtext.transform.rotation = Quaternion.Euler(20, 90, 0);
                    break;
                case 2:
                    floatingtext.transform.rotation = Quaternion.Euler(0, 180, 0);
                    break;
            }
            previousCam = combatLogic.camNum;
        }
    }
}
