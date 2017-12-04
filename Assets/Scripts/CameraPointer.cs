using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPointer : MonoBehaviour {
    private Camera cam;
    private GameObject hitObj = null;
    private Vector3 reticlePos = Vector3.zero;
    private Ray ray;

	// Use this for initialization
    void Awake() {
        cam = GetComponent<Camera>();
    }
	void Start () {
        reticlePos = GameObject.Find("Reticle").transform.position;
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown(0))
        {
            ray = cam.ScreenPointToRay(reticlePos);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.transform.name == "EButton1") //graph room
                {
                    GameObject.Find("Door").GetComponent<ElevatorDoors>().MoveRooms(1);
                }
                else if (hit.transform.name == "EButton2") //map room
                {
                    GameObject.Find("Door").GetComponent<ElevatorDoors>().MoveRooms(2);
                }
                else if (hit.transform.name == "EButton3") //ground waiting room
                {
                    GameObject.Find("Door").GetComponent<ElevatorDoors>().MoveRooms(3);
                } else if (hit.transform.name == "OuterEButton")
                {
                    GameObject.Find("Door").GetComponent<ElevatorDoors>().OpenDoors();
                } else if (hit.transform.name == "PATTY" && hit.distance <= 0.5f) { 
}
            }
        }

    }

    public Ray getRay() {
        return ray;
    }
}
