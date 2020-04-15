using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tutorial : MonoBehaviour
{
    public DialogueController control;
    public DialogueHolder holder;
    public List<GameObject> tut = new List<GameObject>();
    private int prevIndex = 0;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        if (holder.inConversation)
        {
            Debug.Log(control.index);
            for (int x = 0; x < tut.Count; x++)
            {
                tut[x].SetActive(false);
            }
            tut[control.index-2].SetActive(true);
            prevIndex = control.index;
        }
        else
        {
            for (int x = 0; x <= tut.Count; x++)
            {
                tut[x].SetActive(false);
            }
        }
    }
}
