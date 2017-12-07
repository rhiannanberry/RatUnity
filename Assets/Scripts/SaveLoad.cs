using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public static class SaveLoad {
    public static List<User> users = new List<User>();
    public static void Save()
    {
        users.Add(User.current);
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/savedUsers.gd");
        bf.Serialize(file, SaveLoad.users);
        file.Close();
    }
    public static void Load()
    {
        if (File.Exists(Application.persistentDataPath + "/savedUsers.gd"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/savedUsers.gd", FileMode.Open);
            SaveLoad.users = (List<User>)bf.Deserialize(file);
            file.Close();
        }
    }

    public static IEnumerator WaitForRequest(WWW url)
    {
        yield return url;
        Debug.Log(url.text);
    }

    public static WWW POST(Rat rat)
    {
        JSONObject j = new JSONObject(JSONObject.Type.OBJECT);
        j.AddField("Borough", rat.borough);
        j.AddField("Borough", rat.city);
        j.AddField("Created Date", MarkersUtility.DateTimeNowToUnix());
        j.AddField("Incident Address", rat.address);
        j.AddField("Incident Zip", rat.zip);

        j.AddField("Location Type", rat.locationType);

        j.AddField("Latitude", rat.latitude);
        j.AddField("Longitude", rat.longitude);

        WWW www;
        Hashtable postHeader = new Hashtable();
        postHeader.Add("Content-Type", "application/json");
        string POSTAddUserURL = "https://ratapp-af7cf.firebaseio.com/rat+sightings/";
        // convert json string to byte
        byte[] formData = System.Text.Encoding.UTF8.GetBytes(j.ToString());

        www = new WWW(POSTAddUserURL, formData, postHeader);
        WaitForRequest(www);
        return www;
    }


    public static IEnumerator WaitForLocRequest(WWW url)
    {
        yield return url;
        Debug.Log(url.text);
    }

    /*public Rat AddRat()
    {
        Rat rat = new Rat();
        rat.address = address.text;
        rat.zip = zip.text;
        rat.locationType = locationType.text;
        rat.borough = borough.text;
        return rat;

    }*/
    //       SaveLoad.GeoCode(address.text, zip.text, state.text, locationType.text, borough.text);

    public static void GeoCode(string address, string zip, string state, string locationType, string borough)
    {
        string start = "https://maps.googleapis.com/maps/api/geocode/json?address=";
        string apiKey = "&key=AIzaSyDotO5V7kTAu239A7f8gP5YDq0ZUGiMywY";

        string urlString = WWW.EscapeURL(start + address + "," + state + apiKey);
        WaitForLocRequest(new WWW(urlString));
        //https://maps.googleapis.com/maps/api/geocode/json?address=1600+Amphitheatre+Parkway,+Mountain+View,+CA&key=AIzaSyDotO5V7kTAu239A7f8gP5YDq0ZUGiMywY
    }


}
