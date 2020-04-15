using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playermovement : MonoBehaviour
{
    private GridMovement CurrentPos;
    private bool XAxisInUse;
    private bool YAxisInUse;
    // Start is called before the first frame update
    void Start()
    {
        CurrentPos = this.GetComponent<GridMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        if (pausemenu.paused == false && combatLogic.playerLock == false)
        {

            if (combatLogic.combatOrientation == 1)
            {
                if (Input.GetAxisRaw("Vertical") == 1 && YAxisInUse == false)
                {
                    CurrentPos.Ypos++;
                    if (CurrentPos.Ypos > 3) { CurrentPos.Ypos = 3; }
                    YAxisInUse = true;
                }
                if (Input.GetAxisRaw("Vertical") == -1 && YAxisInUse == false)
                {
                    CurrentPos.Ypos--;
                    if (CurrentPos.Ypos < 1) { CurrentPos.Ypos = 1; }
                    YAxisInUse = true;
                }
                if (Input.GetAxisRaw("Vertical") == 0) { YAxisInUse = false; }

                if (Input.GetAxisRaw("Horizontal") == 1 && XAxisInUse == false)
                {
                    CurrentPos.Xpos++;
                    if (CurrentPos.Xpos > 2) { CurrentPos.Xpos = 2; }
                    XAxisInUse = true;
                }
                if (Input.GetAxisRaw("Horizontal") == -1 && XAxisInUse == false)
                {
                    CurrentPos.Xpos--;
                    if (CurrentPos.Xpos < 1) { CurrentPos.Xpos = 1; }
                    XAxisInUse = true;
                }
                if (Input.GetAxisRaw("Horizontal") == 0) { XAxisInUse = false; }
            }
            if (combatLogic.combatOrientation == 2)
            {
                if (Input.GetAxisRaw("Vertical") == 1 && YAxisInUse == false)
                {
                    CurrentPos.Xpos++;
                    if (CurrentPos.Xpos > 2) { CurrentPos.Xpos = 2; }
                    YAxisInUse = true;
                }
                if (Input.GetAxisRaw("Vertical") == -1 && YAxisInUse == false)
                {
                    CurrentPos.Xpos--;
                    if (CurrentPos.Xpos < 1) { CurrentPos.Xpos = 1; }
                    YAxisInUse = true;
                }
                if (Input.GetAxisRaw("Vertical") == 0) { YAxisInUse = false; }

                if (Input.GetAxisRaw("Horizontal") == 1 && XAxisInUse == false)
                {
                    CurrentPos.Ypos--;
                    if (CurrentPos.Ypos > 3) { CurrentPos.Ypos = 3; }
                    XAxisInUse = true;
                }
                if (Input.GetAxisRaw("Horizontal") == -1 && XAxisInUse == false)
                {
                    CurrentPos.Ypos++;
                    if (CurrentPos.Ypos < 1) { CurrentPos.Ypos = 1; }
                    XAxisInUse = true;
                }
                if (Input.GetAxisRaw("Horizontal") == 0) { XAxisInUse = false; }
            }

        }
    }
}
