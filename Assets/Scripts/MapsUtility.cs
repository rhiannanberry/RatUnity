﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class MapsUtility {
    static float GOOGLEOFFSET = 268435456f;
    static float GOOGLEOFFSET_RADIUS = 85445659.44705395f;//GOOGLEOFFSET / Mathf.PI;
    static float MATHPI_180 = Mathf.PI / 180f;
    static float CENTERLON = -95.53710968749999f;
    static float CENTERLAT = 37.90545880594998f;

    static private float preLonToX1 = GOOGLEOFFSET_RADIUS * (Mathf.PI / 180f);

    public static int LonToX(float lon)
    {
        return ((int)Mathf.Round(GOOGLEOFFSET + preLonToX1 * lon));
    }

    public static int LatToY(float lat)
    {
        return (int)Mathf.Round(GOOGLEOFFSET - GOOGLEOFFSET_RADIUS * Mathf.Log((1f + Mathf.Sin(lat * MATHPI_180)) / (1f - Mathf.Sin(lat * MATHPI_180))) / 2f);
    }

    public static float XToLon(float x)
    {
        return ((Mathf.Round(x) - GOOGLEOFFSET) / GOOGLEOFFSET_RADIUS) * 180f / Mathf.PI;
    }

    public static float YToLat(float y)
    {
        return (Mathf.PI / 2f - 2f * Mathf.Atan(Mathf.Exp((Mathf.Round(y) - GOOGLEOFFSET) / GOOGLEOFFSET_RADIUS))) * 180f / Mathf.PI;
    }
    //zoom is 5
    //center 37.90545880594998%2C-95.53710968749999
    public static float adjustLonByPixels(float lon, int delta, int zoom)
    {
        return XToLon(LonToX(lon) + (delta << (21 - zoom)));
    }

    public static float adjustLatByPixels(float lat, int delta, int zoom)
    {
        return YToLat(LatToY(lat) + (delta << (21 - zoom)));
    }
}
