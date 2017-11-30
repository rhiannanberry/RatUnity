using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clipboard : MonoBehaviour {
    Transform player;
    // Use this for initialization
    void Start () {
        player = GameObject.Find("FPSController").transform;
	}
	
	// Update is called once per frame
	void Update () {
        transform.LookAt(player);
        transform.localEulerAngles = new Vector3(-30, transform.localEulerAngles.y, transform.localEulerAngles.z);
	}
}
