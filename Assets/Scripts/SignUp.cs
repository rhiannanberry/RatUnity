using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SignUp : MonoBehaviour {
    string email, password;
	// Use this for initialization
	void Start () {
        

    }

    // Update is called once per frame
    void Update () {
		
	}

    public void SaveSignUp()
    {
        email = transform.GetChild(1).GetChild(0).GetChild(1).GetComponent<Text>().text;
        password = transform.GetChild(2).GetChild(0).GetChild(1).GetComponent<Text>().text;
        User.current = new User();
        User.current.email = email;
        User.current.password = password;
        SaveLoad.Save();
    }
}
