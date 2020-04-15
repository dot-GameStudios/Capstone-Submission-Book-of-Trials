using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

[System.Serializable]
public class Answer
{
    [TextArea(3, 10)]
    public string answerText;
    public UnityEvent dialogueEvent;
    public Button UIButton;
}
