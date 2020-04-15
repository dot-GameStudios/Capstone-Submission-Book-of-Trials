using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletmove : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject hitbox;
    void Start()
    {
        Destroy(this.gameObject, 1);
    }

    // Update is called once per frame
    void Update()
    {
        if (this.gameObject.CompareTag("PlayerProjectile")) { transform.position += Vector3.back * 20 * Time.deltaTime; }
        else if (this.gameObject.CompareTag("Posionous")) { transform.position += Vector3.back * 20 * Time.deltaTime; }
        else if (this.gameObject.CompareTag("Xshot")) { transform.position += Vector3.back * 25 * Time.deltaTime; }
        else if (this.gameObject.CompareTag("HeavyProjectile")) { transform.position += Vector3.back * 15 * Time.deltaTime; }
        else if(this.gameObject.CompareTag("VolleyProjectile")) {transform.position += Vector3.down * 20 * Time.deltaTime;}
        else if (this.gameObject.CompareTag("wideShot")) { transform.position += Vector3.back * 25 * Time.deltaTime; }
        else { transform.position += Vector3.forward * 20 * Time.deltaTime; }


    }

    private void OnTriggerEnter(Collider other)
    {
        if ((other.tag == "E1"|| other.tag == "E2"|| other.tag == "E3")&& this.gameObject.CompareTag("PlayerProjectile"))
        {
            Destroy(this.gameObject);

        }
        if ((other.tag == "E1" || other.tag == "E2" || other.tag == "E3") && this.gameObject.CompareTag("HeavyProjectile"))
        {
            Destroy(this.gameObject);

        }
        if ((other.tag == "E1" || other.tag == "E2" || other.tag == "E3") && this.gameObject.CompareTag("wideShot"))
        {
            Destroy(this.gameObject);

        }
        if ((other.tag == "E1" || other.tag == "E2" || other.tag == "E3") && this.gameObject.CompareTag("Xshot"))
        {
            Vector3 pos = new Vector3(other.gameObject.transform.position.x, 0, other.gameObject.transform.position.z);
            Instantiate(hitbox, pos, Quaternion.Euler(0, 0, 0));
            Destroy(this.gameObject);
        }
        if (other.tag == "Player"  && this.gameObject.CompareTag("EnemyAttack"))
        {
            Destroy(this.gameObject);

        }
    }
}
