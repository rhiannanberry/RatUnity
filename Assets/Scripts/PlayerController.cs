﻿using System.Collections;
using System.Collections.Generic;

using SimpleFirebaseUnity;
using SimpleFirebaseUnity.MiniJSON;
using UnityStandardAssets.CrossPlatformInput;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class PlayerController : MonoBehaviour {
    public Transform pattyTransform;
    public float range = 2;
    private bool helpOn = false;
    private bool inDialogue = false;
    public GameObject pattySpace;
    public GameObject dialogueController;
	// Use this for initialization
	void Start () {
        pattySpace.GetComponent<CanvasGroup>().alpha = 0;
    }

    
	
	// Update is called once per frame
	void Update () {
		if (CheckDistance(pattyTransform) && !inDialogue) {
            if (!helpOn) {
                pattySpace.GetComponent<CanvasGroup>().alpha = 1;
                helpOn = true;
            }
            if (CrossPlatformInputManager.GetButtonDown("Jump")) {
                gameObject.GetComponent<FirstPersonController>().enabled = false;
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
                //spacePattyText.SetActive(false);
                dialogueController.SetActive(true);
                dialogueController.GetComponent<DialogueController>().TriggerIntro();
                inDialogue = true;
            }
        } else if (helpOn) {
            pattySpace.GetComponent<CanvasGroup>().alpha = 0;
            helpOn = false;
        }
    }

    private bool CheckDistance(Transform other) {
        return Vector3.Distance(transform.position, other.position) < range;
    }
}
