using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueHolder : MonoBehaviour
{
    private bool interactable;
    public GameObject menu;
    public Dialogue[] dialogues;
    //public KeyCode InteractButton;
    [HideInInspector] public bool inConversation;

    //used for setting up the interaction zone
    public bool isTrigger;
    public Collider triggerCollider;
    private int dialogCooldown = 0;
    public bool state;

    void Start()
    {
        interactable = false;
        inConversation = false;

        //if not 'isTrigger', set 'interactable' to true
        if (!isTrigger)
        {
            interactable = true;
        }
        else
        {
            //else do GetComponent and get any 3D collider type you can find
            triggerCollider = GetComponent<Collider>();
        }

        //check if trigger is empty, if yes, throw an error
        if(triggerCollider == null)
        {
            Debug.LogError("Dialogue Holder is set to 'isTrigger' but it can't find the corresponding collider trigger");
        }
        //check if you have set your interact key so that you can initiate conversation
    }

    private void Update()
    {
        if (triggerCollider && isTrigger || !triggerCollider && !isTrigger) {
            //check if not in a conversation already and if interactable is true
            if (!inConversation && interactable)
            {
                if (Input.GetAxis("Confirm")>= 1 && dialogCooldown <=0)
                {
                    inConversation = true;
                    combatLogic.playerLock = true;
                    menu.SetActive(true);
                    TriggerDialogue();
                    dialogCooldown = 150;
                }
            }           
        }
        if (!inConversation && dialogCooldown > 0) { dialogCooldown--; }
    }

    public void TriggerDialogue()
    {
        //Find the Dialogue Controller in the scene and run the function StartDialogue with the dialogues as a parameter
        FindObjectOfType<DialogueController>().StartDialogue(dialogues);
        
        //Find the Dialogue Controller in the scene and SetDialogueHolder to be the this one
        FindObjectOfType<DialogueController>().SetDialogueHolder(this);

        if (state == false) { state = true; }
        else { state = false; }
    }

    public void OnTriggerEnter(Collider other)
    {
        interactable = true;
    }

    public void OnTriggerExit(Collider other)
    {
        interactable = false;
    }
}
