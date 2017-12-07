using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map : MonoBehaviour {

    public GameObject MarkerPrefab;
    // Use this for initialization
    private List<Rat> rats;
	IEnumerator Start () {
        WWW url = MarkersUtility.BuildURL();
        Debug.Log(url);

        yield return url;
        Debug.Log(url.text);
        rats = (MarkersUtility.GetRatsFromJSON(url.text));
        GameObject.Find("GraphImage").GetComponent<Graph>().SetGraph(rats);
        Debug.Log(rats.Count);
        foreach (Rat rat in rats)
        {
            GameObject temp = Instantiate(MarkerPrefab, new Vector3(0, 0, 0), Quaternion.identity);
            temp.transform.SetParent(transform, false);
            temp.transform.localPosition = new Vector3(MapsUtility.GetMarkerPositionX(rat.longitude), MapsUtility.GetMarkerPositionY(rat.latitude), -0.1f);


        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    IEnumerator LoadMarkers(WWW url)
    {
        Debug.Log("Hi0");
        yield return url;
        Debug.Log(url.text);
        rats = (MarkersUtility.GetRatsFromJSON(url.text));
        foreach (Rat rat in rats)
        {
            GameObject temp = Instantiate(MarkerPrefab, new Vector3(0, 0, 0), Quaternion.identity);
            temp.transform.localPosition = new Vector3(MapsUtility.GetMarkerPositionX(rat.longitude), MapsUtility.GetMarkerPositionY(rat.latitude), 0);


        }
    }

    public void SetRatRange()
    {
        WWW url = new WWW("https://ratapp-af7cf.firebaseio.com/rat+sightings.json?orderBy=%22Created+Date%22&limitToFirst=3");
        LoadMarkers(url);
    }
}
