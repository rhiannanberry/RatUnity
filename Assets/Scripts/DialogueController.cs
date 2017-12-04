using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Characters.FirstPerson;
using UnityStandardAssets.CrossPlatformInput;

public class DialogueController : MonoBehaviour {

    public float distance = 0.5f;

    GameObject dialoguePanel, questionPanel, playerController, clipboard;
    Text dialogue, question, answer1, answer2;
    Button b1, b2;
    bool exit = false;
    bool exit1 = false;
    bool signup = false;


    //add an exit button to all dialogue options
    string[] qIntro = {"Oh, hello! Can you sign in for me?", "Sure!", "I've never been here before..." };
    string[] qIntroFail = { "Uwah, I'm so sorry :( Would you like to sign up to use our services?", "Hmmmm... Ok!", "Nah." };
    string[] qOption = { "So what can I help you with?", "I'd like to see some rats.", "I'd like to report a sighting." };
    //string[] qOptionView = { "Lovely! "}; option view will be a dialogue and start and end date picker

    string dFail = "U-Uh. O-Okay, have a nice day...";
    string dPass = "Great! Fill out this form, please!";

    void Start() {
        playerController = GameObject.Find("FPSController");

        dialoguePanel = GameObject.Find("PattyDialogue");
        questionPanel = GameObject.Find("PattyDialogueAnswer");

        clipboard = GameObject.Find("Clipboard");

        dialogue = dialoguePanel.GetComponent<Text>();
        question = GameObject.Find("Question").GetComponent<Text>();
        b1 = GameObject.Find("Answer1").GetComponent<Button>();
        b2 = GameObject.Find("Answer2").GetComponent<Button>();

        answer1 = GameObject.Find("TextAnswer1").GetComponent<Text>();
        answer2 = GameObject.Find("TextAnswer2").GetComponent<Text>();

        questionPanel.SetActive(false);
        dialoguePanel.SetActive(false);

        gameObject.SetActive(false);

    }

    void Update() {
        if (exit && Input.GetMouseButtonDown(0)) {
            questionPanel.SetActive(false);
            dialoguePanel.SetActive(false);

            exit1 = false;
            exit = false;
            if (signup) {

            } else {
                gameObject.SetActive(false);
                playerController.GetComponent<FirstPersonController>().enabled = true;
            }
        }
        if (exit1) {
            exit1 = false;
            exit = true;
        }
    }

    public void TriggerIntro() {
        b1.onClick.AddListener(SignIn);
        b2.onClick.AddListener(SignUp);
        SetDialogue(qIntro);
    }

    private void SignIn() {
        Debug.Log("Sign in");
    }

    private void SignUp() {
        RemoveButtonListeners();
        b1.onClick.AddListener(SignUpPass);
        b2.onClick.AddListener(SignUpFail);
        SetDialogue(qIntroFail);
    }

    private void SignUpPass() {
        RemoveButtonListeners();
        SetDialogue(dPass);
        
        //clipboard.transform.LookAt(transform);
        exit1 = true;
        signup = true;

    }

    private void SignUpFail() {
        RemoveButtonListeners();
        SetDialogue(dFail);
        exit1 = true;
    }

    private void RemoveButtonListeners() {
        b1.onClick.RemoveAllListeners();
        b2.onClick.RemoveAllListeners();
    }

    private void SetDialogue(string dialogue) {
        questionPanel.SetActive(false);
        dialoguePanel.SetActive(true);
        this.dialogue.text = dialogue;
    }

    private void SetDialogue(string[] pack) {
        questionPanel.SetActive(true);
        dialoguePanel.SetActive(false);
        this.question.text = pack[0];
        this.answer1.text = pack[1];
        this.answer2.text = pack[2];
    }
    
}
