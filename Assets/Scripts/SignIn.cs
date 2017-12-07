using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SignIn : MonoBehaviour {

    string email, password;
    // Use this for initialization
    void Start()
    {
        email = transform.GetChild(1).GetChild(0).GetChild(1).GetComponent<Text>().text;
        password = transform.GetChild(2).GetChild(0).GetChild(1).GetComponent<Text>().text;

    }

    // Update is called once per frame
    void Update () {
		
	}

    public void CheckUserLoad()
    {
        SaveLoad.Load();
        foreach(User usr in SaveLoad.users)
        {
            if (usr.email == email && usr.password == password)
            {
                //success
            }
        }
    }
}
