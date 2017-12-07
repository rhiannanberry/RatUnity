using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class User {
    public static User current;

    public string email;
    public string password;

    public User()
    {
        email = "";
        password = "";
    }

}
