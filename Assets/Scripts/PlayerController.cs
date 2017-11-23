using System.Collections;
using System.Collections.Generic;
using UnityStandardAssets.CrossPlatformInput;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class PlayerController : MonoBehaviour {
    public Transform pattyTransform;
    public float range = 2;
    private bool helpOn = false;
    private bool inDialogue = false;
    private GameObject spacePattyText;
    public GameObject dialogueController;
	// Use this for initialization
	void Start () {
        spacePattyText = GameObject.Find("SpacePatty");
        spacePattyText.SetActive(false);
    }
	
	// Update is called once per frame
	void Update () {
		if (CheckDistance(pattyTransform) && !inDialogue) {
            if (!helpOn) {
                spacePattyText.SetActive(true);
                helpOn = true;
            }
            if (CrossPlatformInputManager.GetButtonDown("Jump")) {
                gameObject.GetComponent<FirstPersonController>().enabled = false;
                spacePattyText.SetActive(false);
                dialogueController.SetActive(true);
                dialogueController.GetComponent<DialogueController>().TriggerIntro();
                inDialogue = true;
            }
        } else if (helpOn) {
            spacePattyText.SetActive(false);
            helpOn = false;
        }
	}

    private bool CheckDistance(Transform other) {
        return Vector3.Distance(transform.position, other.position) < range;
    }
}
