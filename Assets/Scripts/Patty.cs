using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patty : MonoBehaviour {
    Transform player;
    // Use this for initialization
    void Start () {
        player = GameObject.Find("FPSController").transform;
    }
	
	// Update is called once per frame
	void Update () {
        transform.LookAt(player);
        transform.localEulerAngles = new Vector3(transform.localEulerAngles.x +5, transform.localEulerAngles.y, transform.localEulerAngles.z);

    }
}
