using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class MarkersUtility {
    public static DateTime startDate, endDate;
    public static WWW BuildURL() {
        DateTime from = DialogueUtility.fromDate;
        DateTime to = DialogueUtility.toDate;
        Debug.Log(from);
        Debug.Log(to);
        string beginning = "https://ratapp-af7cf.firebaseio.com/rat+sightings.json?orderBy=%22Created+Date%22&startAt=%22";
        string start = ((TimeZoneInfo.ConvertTimeToUtc(from) - new DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc)).TotalSeconds).ToString() + "000";
        string end = ((TimeZoneInfo.ConvertTimeToUtc(to) - new DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc)).TotalSeconds).ToString() + "000";

        startDate = UnixToDateTime(start);
        endDate = UnixToDateTime(end);
        beginning += start + "%22&endAt=%22" + end + "%22";
        Debug.Log(beginning);

        return new WWW(beginning);
    }

    public static List<Rat> GetRatsFromJSON(string json)
    {
       
        List<Rat> mList = new List<Rat>();
        JSONObject j = new JSONObject(json);
        Debug.Log("HELL");
        for (int i = 0; i < j.list.Count; i++)
        {
            string key = (string)j.keys[i];
            JSONObject jMark = (JSONObject)j.list[i];
            Rat tempRat = new Rat(key);
            try {
                float.TryParse(jMark["Latitude"].str, out tempRat.latitude);
                float.TryParse(jMark["Longitude"].str, out tempRat.longitude);
                tempRat.SetDate((long)Convert.ToDouble(jMark["Created Date"].str)); 

                mList.Add(tempRat);
            } catch (Exception e) {

            }
        }
        return mList;
    }

    private static DateTime UnixToDateTime(string dateString)
    {
        long date = long.Parse(dateString);
        DateTime newDate = new DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc);
        return newDate.AddMilliseconds(date).ToLocalTime();
    }
}

/*
 * jMark.GetField("Borough", delegate (JSONObject b)
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
            */

