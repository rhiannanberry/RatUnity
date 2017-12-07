using System.Collections;
using System.Collections.Generic;

using SimpleFirebaseUnity;
using SimpleFirebaseUnity.MiniJSON;
using UnityStandardAssets.CrossPlatformInput;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class PlayerController : MonoBehaviour {
    public GameObject MapPrefab;
    public Transform pattyTransform;
    public float range = 3;
    private bool helpOn = false;
    private bool inDialogue = false;
    private GameObject reticle;
    public GameObject pattySpace;
    public GameObject dialogueController;
	// Use this for initialization
	void Start () {
        SaveLoad.Load();
        pattySpace.GetComponent<CanvasGroup>().alpha = 0;
        reticle = GameObject.Find("Reticle");
    }

    
	
	// Update is called once per frame
	void Update () {
    }

    private bool CheckDistance(Transform other) {
        return Vector3.Distance(transform.position, other.position) < range;
    }

    public void CreateMap() {
        if (GameObject.Find("MapCanvas(Clone)") != null)
        {
            Destroy(GameObject.Find("MapCanvas(Clone)"));
        }
        Instantiate(MapPrefab);
    }
    public void SetDateRange() {
        DialogueUtility.SetDateRange();
    }
}
