using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class QuestionHolder : MonoBehaviour
{
    [TextArea(3, 10)]
    public string questionText;
    public Answer[] answers; //holds answer classes for the question
    public DialogueHolder nextDialogue; //if we want to start another dialogue after th choice has been made
    public Canvas currentCanvas;

    // Start is called before the first frame update
    void Start()
    {
        currentCanvas = FindObjectOfType<Canvas>();
        foreach(Answer answer in answers)
        {
            answer.UIButton.GetComponentInChildren<TextMeshProUGUI>().text = answer.answerText;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ShowQuestion()
    {

    }
}
