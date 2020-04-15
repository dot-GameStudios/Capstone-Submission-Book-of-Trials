using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Overworld_Player_Movement : MonoBehaviour
{

    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        transform.position = combatLogic.playerPos;
    }

    // Update is called once per frame
    void Update()
    {
        if (combatLogic.playerLock == false) {
            float vertical = Input.GetAxis("Vertical");
            float Horizontal = Input.GetAxis("Horizontal");
            //Vector3 move = new Vector3(0f, 0f, vertical+ Horizontal) * speed * Time.deltaTime;
            Vector3 move = Vector3.forward * speed * Time.deltaTime;
            if (vertical >= 0.3f || vertical <= -0.3f || Horizontal >= 0.3f || Horizontal <= -0.3f)
            {
                transform.Translate(move, Space.Self);
            }
            //transform.rotation = Quaternion.LookRotation(move);


            if (transform.position.y <= -30)
            {
                transform.position = new Vector3(0, 5, 0);

            }
        }
    }
}
