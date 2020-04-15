using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Overworld_Camera_Movement : MonoBehaviour
{
    // Start is called before the first frame update
    public float rotateSpeed;
    public Transform target;
    public Transform player;
    float mouseX;
    float playerX;
    float playerY;
    float mouseY;
    float joyY;

    bool axisInUse;

    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void LateUpdate()
    {

            mouseX += Input.GetAxis("Mouse X") * rotateSpeed;
            playerX = Input.GetAxis("Horizontal") * rotateSpeed;
            playerY = Input.GetAxis("Vertical") * rotateSpeed;
            mouseY -= Input.GetAxis("Mouse Y") * rotateSpeed;

            mouseY = Mathf.Clamp(mouseY, -35, 60);

            transform.LookAt(target);

            target.rotation = Quaternion.Euler(mouseY, mouseX, 0);
        if (combatLogic.playerLock == false)
        {
            if (playerY >= 0.7) { player.rotation = Quaternion.Euler(0, mouseX, 0); }
            else if (playerY <= -0.7) { player.rotation = Quaternion.Euler(0, mouseX - 180, 0); }
            else if (playerX >= 0.7) { player.rotation = Quaternion.Euler(0, mouseX + 90, 0); }
            else if (playerX <= -0.7) { player.rotation = Quaternion.Euler(0, mouseX - 90, 0); }
            else { }
        }
    }
}
