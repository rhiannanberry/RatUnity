using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Characters.FirstPerson;
using UI.Dates;


public static class DialogueUtility {
    public static GameObject dialoguePanel, questionPanel, playerController, clipboard, dialogueController, q4Panel, dateRangePanel;
    public static Text dialogue, question, answer1, answer2, q4, a1, a2, a3, a4;
    public static Button b1, b2, qb1, qb2, qb3, qb4;

    public static bool signedIn = false;
    public static bool hasRange = false;
    public static System.DateTime fromDate, toDate;

    public static void SetDialogue(string[] pack)
    {
        questionPanel.SetActive(true);
        dialoguePanel.SetActive(false);
        q4Panel.SetActive(false);
        question.text = pack[0];
        answer1.text = pack[1];
        answer2.text = pack[2];
    }
    public static void SetDialogue(string dia)
    {
        questionPanel.SetActive(false);
        q4Panel.SetActive(false);
        dialoguePanel.SetActive(true);
        dialogue.text = dia;
    }

    public static void SetDialogue2(string[] pack)
    {
        questionPanel.SetActive(false);
        dialoguePanel.SetActive(false);
        q4Panel.SetActive(true);
        q4.text = pack[0];

        a1.text = pack[1];
        a2.text = pack[2];
        a3.text = pack[3];
        a4.text = pack[4];

    }

    public static void ClearAllText()
    {
        question.text = "";
        answer1.text = "";
        answer2.text = "";
        dialogue.text = "";
        q4.text = "";
        a1.text = "";
        a2.text = "";
        a3.text = "";
        a4.text = "";
    }

    public static void PickUpClipboard(int choice)
    {
        clipboard.GetComponent<Clipboard>().PickUpClipboard(playerController, choice);
    }

    public static void PutDownClipboard()
    {
        clipboard.GetComponent<Clipboard>().PutDownClipboard();

    }

    public static void ExitDialogue(bool cameraUnlock)
    {
        dialogueController.SetActive(false);
        if (cameraUnlock)
        {
            playerController.GetComponent<FirstPersonController>().enabled = true;
            Cursor.lockState = CursorLockMode.Confined;
            Cursor.visible = false;
        }
    }

    public static void ReEnterDialogue()
    {
        dialogueController.SetActive(true);
    }

    public static void Afun()
    {
        dialogueController.GetComponent<DialogueController>().AListener();
    }
    public static void Bfun()
    {
        dialogueController.GetComponent<DialogueController>().BListener();
    }

    public static void SetDateRange() {
        fromDate = dateRangePanel.transform.GetChild(3).GetComponent<DatePicker_DateRange>().FromDate.Date;
        toDate = dateRangePanel.transform.GetChild(3).GetComponent<DatePicker_DateRange>().ToDate.Date;
        hasRange = true;
    }

    public static void SetMap() {
        if (hasRange) {
            playerController.GetComponent<PlayerController>().CreateMap();
        }
    }
}
