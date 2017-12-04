using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clipboard : MonoBehaviour {
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

    public void PickUpClipboard(GameObject holder) {
        Ray ray = Camera.main.GetComponent<CameraPointer>().getRay();
        Vector3 forward = holder.transform.forward;
        Quaternion rotation = holder.transform.rotation;

        transform.position = ray.GetPoint(0.5f);
        isLookAt = true;
    }

    public void PutDownClipboard() {
        isLookAt = false;
        transform.position = homePosition;
        transform.rotation = homeRotation;
    }
}
