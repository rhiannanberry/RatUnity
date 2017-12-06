using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorDoors : MonoBehaviour {
    Animator animator;
    bool isOpen, closing, opening;
    private GameObject[] waitingRoomObjs;
    private GameObject[] mapRoomObjs;
    private GameObject[] graphRoomObjs;
    private int current = 3;
    private int dest = 3;
    // Use this for initialization
    void Start () {
        waitingRoomObjs = GameObject.FindGameObjectsWithTag("WaitingRoom");
        mapRoomObjs = GameObject.FindGameObjectsWithTag("MapRoom");
        graphRoomObjs = GameObject.FindGameObjectsWithTag("GraphRoom");
        isOpen = false;
        closing = false;
        opening = false;
        animator = gameObject.GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
        if (animator.GetCurrentAnimatorStateInfo(0).IsName("DoorIdle") && current != dest) {
            ShiftRooms((dest - current) * 5.76f);
            current = dest;
            OpenDoors();
        }
	}

    public void OpenDoors()
    {
        animator.SetTrigger("Opening");
        Debug.Log("Current: " + current + " Dest: " + dest);
    }
    public void CloseDoors()
    {
        animator.SetTrigger("Closing");
        Debug.Log("Current: " + current + " Dest: " + dest);

    }

    public void MoveRooms(int dest)
    {
        mapRoomObjs = GameObject.FindGameObjectsWithTag("MapRoom");

        this.dest = dest;
        CloseDoors();

    }

    private void ShiftRooms(float yShift)
    {
        foreach (GameObject obj in waitingRoomObjs)
        {
            obj.transform.position = new Vector3(obj.transform.position.x, obj.transform.position.y + yShift, obj.transform.position.z);
        }
        foreach (GameObject obj in mapRoomObjs)
        {
            obj.transform.position = new Vector3(obj.transform.position.x, obj.transform.position.y + yShift, obj.transform.position.z);
        }
        foreach (GameObject obj in graphRoomObjs)
        {
            obj.transform.position = new Vector3(obj.transform.position.x, obj.transform.position.y + yShift, obj.transform.position.z);
        }
    }
}
