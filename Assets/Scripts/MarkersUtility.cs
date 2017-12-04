using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class MarkersUtility {
    public static List<Rat> GetRatsFromJSON(string json)
    {
        List<Rat> mList = new List<Rat>();
        JSONObject j = new JSONObject(json);
        for (int i = 0; i < j.list.Count; i++)
        {
            string key = (string)j.keys[i];
            JSONObject jMark = (JSONObject)j.list[i];
            Rat tempRat = new Rat(key);
            jMark.GetField("Borough", delegate (JSONObject b)
            {
                tempRat.SetBorough(b.str);
            });

            jMark.GetField("City", delegate (JSONObject c)
            {
                tempRat.SetCity(c.str);
            });

            jMark.GetField("Incident Address", delegate (JSONObject a)
            {
                tempRat.SetAddress(a.str);
            });

            jMark.GetField("Incident Zip", delegate (JSONObject z)
            {
                tempRat.SetAddress(z.str);
            });

            jMark.GetField("Location Type", delegate (JSONObject t)
            {
                tempRat.SetLocationType(t.str);
            });

            jMark.GetField("Created Date", delegate (JSONObject d)
            {
                tempRat.SetDate(long.Parse(d.str));
            });

            jMark.GetField("Latitude", delegate (JSONObject la)
            {
                tempRat.SetLatitude(float.Parse(la.str));
            });
            jMark.GetField("Longitude", delegate (JSONObject lo)
            {
                tempRat.SetLongitude(float.Parse(lo.str));
            });
            mList.Add(tempRat);
        }
        return mList;
    }

    private static void AccessData(JSONObject j)
    {
        
    }
}


