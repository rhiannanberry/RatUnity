using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Characters.FirstPerson;
using UnityStandardAssets.CrossPlatformInput;

public class DialogueController : MonoBehaviour {
    GameObject dialoguePanel, questionPanel, q4Panel, playerController, clipboard;
    Text dialogue, question, answer1, answer2, q4, a1, a2, a3, a4;
    Animator animator;
    Button b1, b2, qb1, qb2, qb3, qb4;

    void Start() {

        DialogueUtility.playerController = GameObject.Find("FPSController");
        DialogueUtility.dialoguePanel = GameObject.Find("PattyDialogue");
        DialogueUtility.q4Panel = GameObject.Find("PattyDialogue4");
        DialogueUtility.questionPanel = GameObject.Find("PattyDialogueAnswer");

        DialogueUtility.clipboard = GameObject.Find("Clipboard");

        DialogueUtility.dialogue = DialogueUtility.dialoguePanel.GetComponent<Text>();
        DialogueUtility.question = GameObject.Find("Question").GetComponent<Text>();
        DialogueUtility.q4 = GameObject.Find("Q4").GetComponent<Text>();

        DialogueUtility.b1 = GameObject.Find("Answer1").GetComponent<Button>();
        DialogueUtility.b2 = GameObject.Find("Answer2").GetComponent<Button>();
        DialogueUtility.qb1 = GameObject.Find("A1").GetComponent<Button>();
        DialogueUtility.qb2 = GameObject.Find("A2").GetComponent<Button>();
        DialogueUtility.qb3 = GameObject.Find("A3").GetComponent<Button>();
        DialogueUtility.qb4 = GameObject.Find("A4").GetComponent<Button>();

        animator = GameObject.Find("Canvas").GetComponent<Animator>();
        DialogueUtility.b1.onClick.AddListener(AListener);
        DialogueUtility.b2.onClick.AddListener(BListener);

        DialogueUtility.qb1.onClick.AddListener(AListener);
        DialogueUtility.qb2.onClick.AddListener(BListener);
        DialogueUtility.qb3.onClick.AddListener(CListener);
        DialogueUtility.qb4.onClick.AddListener(DListener);

        DialogueUtility.answer1 = GameObject.Find("TextAnswer1").GetComponent<Text>();
        DialogueUtility.answer2 = GameObject.Find("TextAnswer2").GetComponent<Text>();
        DialogueUtility.a1 = GameObject.Find("TextA1").GetComponent<Text>();
        DialogueUtility.a2 = GameObject.Find("TextA2").GetComponent<Text>();
        DialogueUtility.a3 = GameObject.Find("TextA3").GetComponent<Text>();
        DialogueUtility.a4 = GameObject.Find("TextA4").GetComponent<Text>();

        DialogueUtility.questionPanel.SetActive(false);
        DialogueUtility.dialoguePanel.SetActive(false);
        DialogueUtility.q4Panel.SetActive(false);
        DialogueUtility.dialogueController = gameObject;
        gameObject.SetActive(false);

    }

    void Update() {
    }

    public void AListener()
    {
        Debug.Log("A");
        animator.SetTrigger("Click");
        animator.SetTrigger("OptA");
    }

    public void BListener()
    {
        Debug.Log("B");
        animator.SetTrigger("Click");
        animator.SetTrigger("OptB");
    }

    public void CListener()
    {
        Debug.Log("C");
        animator.SetTrigger("Click");
        animator.SetTrigger("OptC");
    }

    public void DListener()
    {
        Debug.Log("D");
        animator.SetTrigger("Click");
        animator.SetTrigger("OptD");
    }
}
