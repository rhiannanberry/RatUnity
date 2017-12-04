using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class MapsUtility {
    static float GOOGLEOFFSET = 268435456f;
    static float GOOGLEOFFSET_RADIUS = 85445659.44705395f;//GOOGLEOFFSET / Mathf.PI;
    static float MATHPI_180 = Mathf.PI / 180f;
    static float CENTERLON = -95.53710968749999f;
    static float CENTERLAT = 37.90545880594998f;
    static float SCALEX = 49.2f;
    static float SCALEY = 16;

    //static float NWLON = -112.41211f; //left
    //static float SELON = -78.66211f; //right
    
    static float WIDTH = 2048;
    //nw=43.799091%2C-112.41211
    //se=31.499226%2C-78.66211
    //31.499226

    public static float LonToWorldPos(float lon)
    {
        return 128 * (1 + DegToRad(lon) / Mathf.PI);
    }

    public static float LatToWorldPos(float lat)
    {
        float param = DegToRad(lat) / 2 + Mathf.PI / 4;
        return 128 * (1 - Mathf.Log(Mathf.Tan(param)));
    }

    private static float DegToRad(float deg)
    {
        return (Mathf.PI / 180) * deg;
    }

    public static float GetMarkerPositionX(float lon)
    {
        float worldCenterX = LonToWorldPos(CENTERLON);
        float markerCenterX = LonToWorldPos(lon);
        return (markerCenterX - worldCenterX) * SCALEX;
    }

    public static float GetMarkerPositionY(float lat)
    {
        float worldCenterY = LatToWorldPos(CENTERLAT);
        float markerCenterY = LatToWorldPos(lat);
        return -1*(markerCenterY - worldCenterY) * SCALEY;
    }
}
