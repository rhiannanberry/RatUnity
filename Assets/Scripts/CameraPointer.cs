using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class CameraPointer : MonoBehaviour {
    private Camera cam;
    private GameObject canvas;
    private Animator animator;
    private GameObject hitObj = null;
    private GameObject reticle, player;
    public GameObject toolTip, dialogueController;
    private Vector3 reticlePos = Vector3.zero;
    private Ray ray;
    private bool inDialogue;

	// Use this for initialization
    void Awake() {
        cam = GetComponent<Camera>();
    }
	void Start () {
        canvas = GameObject.Find("Canvas");
        animator = canvas.GetComponent<Animator>();
        reticle = GameObject.Find("Reticle");
        reticlePos = reticle.transform.position;
        player = transform.parent.gameObject;
        inDialogue = false;
	}
	
	// Update is called once per frame
	void Update () {
        if (!inDialogue)
        {
            FreeCameraUpdate();
        } else
        {

        }
    }

    public void FreeCameraUpdate()
    {
        ray = cam.ScreenPointToRay(reticlePos); //this way we still have a pos when camera gets locked
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            toolTip.GetComponent<CanvasGroup>().alpha = (hit.transform.name == "PATTY" && hit.distance <= 3) ? 1 : 0;
            if (Input.GetMouseButtonDown(0) && Cursor.lockState != CursorLockMode.None)
            {
                switch (hit.transform.name)
                {
                    case "EButton1":
                        GameObject.Find("Door").GetComponent<ElevatorDoors>().MoveRooms(1);
                        break;
                    case "EButton2":
                        GameObject.Find("Door").GetComponent<ElevatorDoors>().MoveRooms(2);
                        break;
                    case "EButton3":
                        GameObject.Find("Door").GetComponent<ElevatorDoors>().MoveRooms(3);
                        break;
                    case "OuterEButton":
                        GameObject.Find("Door").GetComponent<ElevatorDoors>().OpenDoors();
                        break;
                    case "PATTY":
                        if (hit.distance <= 3)
                        {
                            toolTip.SetActive(false);

                            //Disable CameraMove
                            player.GetComponent<FirstPersonController>().enabled = false;
                            Cursor.lockState = CursorLockMode.None;
                            Cursor.visible = true;

                            dialogueController.SetActive(true);
                            animator.SetTrigger("Start");
                            //inDialogue = true;
                        }
                        break;
                }
            }
        }
    }

    public void LockedCameraUpdate()
    {
        //track mouse
    }

    public Ray getRay() {
        return ray;
    }
}
