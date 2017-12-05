using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clipboard : MonoBehaviour {
    public GameObject signUpPanel, signInPanel, RatSightingPanel;

    Transform player;
    Vector3 homePosition;
    Quaternion homeRotation;
    bool isLookAt;
    // Use this for initialization
    void Start () {
        player = GameObject.Find("FPSController").transform;
        homePosition = transform.position;
        homeRotation = transform.rotation;
        isLookAt = false;
	}
	
	// Update is called once per frame
	void Update () {
        if (isLookAt) {
            transform.LookAt(player);
            transform.localEulerAngles = new Vector3(-30, transform.localEulerAngles.y, transform.localEulerAngles.z);
        }
	}

    //choice 0 = sign up, 1 = sign in, 2 = rat sighting
    public void PickUpClipboard(GameObject holder, int choice) {
        Ray ray = Camera.main.GetComponent<CameraPointer>().getRay();
        Vector3 forward = holder.transform.forward;
        Quaternion rotation = holder.transform.rotation;
        SetContext(choice);
        transform.position = ray.GetPoint(0.5f);
        isLookAt = true;
    }

    public void PutDownClipboard() {
        isLookAt = false;
        transform.position = homePosition;
        transform.rotation = homeRotation;
        signUpPanel.SetActive(false);
        signInPanel.SetActive(false);
        RatSightingPanel.SetActive(false);



    }

    private void SetContext(int choice)
    {
        if (choice == 0)
        {
            signUpPanel.SetActive(true);
        } else if (choice == 1)
        {
            signInPanel.SetActive(true);
        } else if (choice == 2)
        {
            RatSightingPanel.SetActive(true);
        } else
        {
            //date range panel
        }
    }
}
