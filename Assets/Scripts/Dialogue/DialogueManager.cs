using System;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using DG.Tweening;

public class DialogueManager : MonoBehaviour
{
    // Singleton
    private static DialogueManager instance = null;
    private void Awake(){
        if (instance == null){
            instance = this;
        } else {
            Destroy(this);
        }
    }

    private Queue<string> sentences;
    private void Start() {
        sentences = new Queue<string>();
    }

    [SerializeField] private TextMeshProUGUI nameText;
    [SerializeField] private TextMeshProUGUI sentenceText;

    public void StartDialogue(Dialogue dialogue)
    {
        Debug.Log($"Starting conversation with {dialogue.name}");
        sentences.Clear();
        foreach(string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }
        nameText.text = dialogue.name;
        DisplayNextSentence();
        GetComponent<RectTransform>().DOAnchorPosY(-10, 0.5f);
    }

    public void DisplayNextSentence()
    {
        if (sentences.Count == 0)
        {   
            EndDialogue();
            return;
        }
        String sentence = sentences.Dequeue();
        sentenceText.text = sentence;
        Debug.Log(sentence);
    }

    private void EndDialogue()
    {
        GetComponent<RectTransform>().DOAnchorPosY(370, 0.5f);
    }
}
