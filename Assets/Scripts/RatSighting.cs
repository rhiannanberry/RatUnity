using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RatSighting : MonoBehaviour {
    private Text address, zip, state, locationType, borough;
	// Use this for initialization
	void Start () {
        address = transform.GetChild(1).GetChild(0).GetChild(1).GetComponent<Text>();
        zip = transform.GetChild(2).GetChild(0).GetChild(1).GetComponent<Text>();
        state = transform.GetChild(3).GetChild(0).GetChild(0).GetComponent<Text>();
        locationType = transform.GetChild(4).GetChild(0).GetChild(1).GetComponent<Text>();
        borough = transform.GetChild(5).GetChild(0).GetChild(1).GetComponent<Text>();




    }

    // Update is called once per frame
    void Update () {
		
	}

    public void GeoCode()
    {
        SaveLoad.GeoCode(address.text, zip.text, state.text, locationType.text, borough.text);
    }
}
