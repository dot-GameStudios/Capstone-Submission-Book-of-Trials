using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DialogueController : MonoBehaviour
{
    private DialogueHolder currentDialogueHolder;
    private Queue<Dialogue> sentences;
    private Dialogue currentDialogue;
    private int indexer = 0;
    public int index = 0;
    public GameObject menu;
    public Animator dialogueAnim; //for animating the text window
    public TextMeshProUGUI nameText; //for the current speaker
    public TextMeshProUGUI dialogueText; //the text being spoken

    private bool AxisInUse;

    private float dialogueTimer; //used to prevent spamming through the dialogue text
    public float dialogueLagTime; //used to set up what the lag time is before you can move to the next dialogue text

    // Start is called before the first frame update
    void Start()
    {
        //Initialize the sentences queue as empty
        sentences = new Queue<Dialogue>();
    }

    void Update()
    {
        //on button press, call DisplayNextSentence()
        if (Input.GetAxisRaw("Confirm") >=1 && currentDialogueHolder != null && AxisInUse == false)
        {
            AxisInUse = true;
            DisplayNextSentence();
            //Set Dialogue Timer equal to the lag time set up in the inspector
            dialogueTimer = dialogueLagTime;
        }
        //if not holding down button and lag time is over, set AxisInUse to False
        if (Input.GetAxisRaw("Confirm") == 0 && dialogueTimer <= 0) { AxisInUse = false; }

        //Make Dialogue Timer count down via DeltaTime
        dialogueTimer -= Time.deltaTime;
    }

    public void SetDialogueHolder(DialogueHolder dHolder)
    {
        currentDialogueHolder = dHolder;
    }

    public void StartDialogue(Dialogue[] dialogues_)
    {
        //Open animation for dialogue box
        dialogueAnim.SetBool("isOpen", true);

        //Clear all the sentences
        sentences.Clear();

        //Loop through each dialogue in the dialogues_ array
        foreach (Dialogue dialogue in dialogues_)
        {
            sentences.Enqueue(dialogue);
        }
        //set currentDialogue to be the first item in the queue
        currentDialogue = sentences.Dequeue();
        //Display next name and sentence
        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        index++;

        //check if the indexer is equal or greater than the size of the sentences array in the current Dialogue
        if (indexer >= currentDialogue.sentences.Length)
        {
            //if the CurrentDialogue has an afterDialogue event, invoke that event
            if (currentDialogue.afterDialogue != null) { currentDialogue.afterDialogue.Invoke(); }

            //reset indexer back to 0
            indexer = 0;
            //if the queue is empty close the dialogue
            if (sentences.Count == 0)
            {
                EndDialogue();
                return;
            }
            else
            {
                //else dequeue the next line of dialogue
                currentDialogue = sentences.Dequeue();
            }
        }

        if (indexer == 0)
        {
            //If the indexer is equal to 0, check if there is a BeforeDialogue, if yes invoke it
            if (currentDialogue.beforeDialogue != null) { currentDialogue.beforeDialogue.Invoke(); }
        }

        //Set the Name field to be the name in the current Dialogue
        nameText.text = currentDialogue.name;

        //stop any running coroutines and start a new one
        StopAllCoroutines();
        StartCoroutine(TypeSentence(currentDialogue.sentences[indexer]));
        
        //indexer plus 1
        indexer++;
    }

    IEnumerator TypeSentence(string sentence_)
    {
        dialogueText.text = "";
        foreach(char letter in sentence_.ToCharArray())
        {
            dialogueText.text += letter;
            yield return null;
        }
    }

    public void EndDialogue()
    {
        menu.SetActive(false);
        dialogueAnim.SetBool("isOpen", false);
        combatLogic.playerLock = false;
        currentDialogueHolder.inConversation = false;
        index = 0;
    }

    public void StartQuestion(QuestionHolder question_)
    {

    }
}
