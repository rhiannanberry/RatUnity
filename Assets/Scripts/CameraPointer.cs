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
        ray = cam.ScreenPointToRay(reticlePos);
        RaycastHit hit;
	}

    public Ray getRay() {
        return ray;
    }
}
