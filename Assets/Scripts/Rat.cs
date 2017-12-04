﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rat {
    public string borough, city, zip, address, locationType, key;
    public long date;
    public float latitude, longitude;

    public Rat(string key)
    {
        this.key = key;
    }

    public Rat(string borough, string city, long date, string address, string zip, float latitude, float longitude, string locationType)
    {
        this.borough = borough;
        this.city = city;
        this.zip = zip;
        this.address = address;
        this.locationType = locationType;
        this.date = date;
        this.latitude = latitude;
        this.longitude = longitude;
    }

    public void SetKey(string key)
    {
        this.key = key;
    }

    public void SetBorough(string borough)
    {
        this.borough = borough;
    }
    public void SetCity(string city)
    {
        this.city = city;
    }
    public void SetDate(long date)
    {
        this.date = date;
    }
    public void SetZip(string zip)
    {
        this.zip = zip;
    }
    public void SetAddress(string address)
    {
        this.address = address;
    }
    public void SetLocationType(string locationType)
    {
        this.locationType = locationType;
    }
    public void SetLongitude(float longitude)
    {
        this.longitude = longitude;
    }
    public void SetLatitude(float latitude)
    {
        this.latitude = latitude;
    }
}
