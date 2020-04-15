using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridMovement : MonoBehaviour
{
    public int Xpos;
    public int Ypos;

    public float X;
    public float Z;

    public int startX;
    public bool gridLock = true;
    // Start is called before the first frame update
    void Start()
    {
        if (gameObject.tag == "E1")
        {
            Xpos = combatLogic.enemy1x;
            Ypos = combatLogic.enemy1y;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (gridLock == true)
        {
            if (Ypos > 3) { Ypos = 3; }
            if (Xpos > 6) { Xpos = 6; }
            if (Ypos < 1) { Ypos = 1; }
            if (Xpos < 1) { Xpos = 1; }


            if (Xpos == 1) { Z = 19.95f; }
            if (Xpos == 2) { Z = 17.48f; }
            if (Xpos == 3) { Z = 15.038f; }
            if (Xpos == 4) { Z = 12.568f; }
            if (Xpos == 5) { Z = 10.15f; }
            if (Xpos == 6) { Z = 7.68f; }
            //Y's
            if (Ypos == 1) { X = -20.28f; }
            if (Ypos == 2) { X = -17.83f; }
            if (Ypos == 3) { X = -15.37f; }

            if (gameObject.CompareTag("VolleyProjectile"))
            {
                transform.localPosition = new Vector3(X, transform.position.y, Z);
            }
            else
            {
                transform.localPosition = new Vector3(X, 0f, Z);
                if (this.gameObject.CompareTag("Player")) { transform.localPosition = new Vector3(X, 1f, Z); }
            }
        }
    }

    public void PosReset()
    {
        Xpos = startX;
    }
}
