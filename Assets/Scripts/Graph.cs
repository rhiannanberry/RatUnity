using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class Graph : MonoBehaviour {
    public GameObject bar1, bar2, bar3, bar4, bar5;
    private int[] sizes;
    private int barSize, splitDays, totalCnt;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void SetGraph(List<Rat> rats)
    {
        int numDays = (MarkersUtility.endDate - MarkersUtility.startDate).Days;
        splitDays = 5;
        barSize = 1;
        sizes = new int[5]{ 0, 0, 0, 0, 0 };
        totalCnt = 0;
        if (numDays < 5)
        {
            splitDays = numDays;

        } else
        {
            barSize = numDays / 5;
        }
        

        foreach (Rat rat in rats)
        {
            DateTime currStart = MarkersUtility.startDate;
            DateTime currEnd = MarkersUtility.startDate.AddDays(barSize);
            for (int i = 0; i < splitDays; i++)
            {
                if((rat.date >= currStart && rat.date < currEnd) || (rat.date == currEnd && splitDays == i - 1))
                {
                    sizes[i]++;
                    totalCnt++;
                    break;
                }

                currStart = currEnd;
                currEnd = currStart.AddDays(barSize);
            }
        }
        Debug.Log("HEWOO");
        SetBars();
    }
    
    private void SetBars()
    {
        float height = 1080;
        DateTime currStart = MarkersUtility.startDate;
        DateTime currEnd = MarkersUtility.startDate.AddDays(barSize);
        for (int i = 0; i < 5; i++)
        {
            
            GameObject current, countLabel, dateLabel;
            switch(i)
            {
                case 0: current = bar1;
                    break;
                case 1: current = bar2;
                    break;
                case 2: current = bar3;
                    break;
                case 3: current = bar4;
                    break;
                default: current = bar5;
                    break;
            }
            countLabel = current.transform.Find("Count").gameObject;
            dateLabel = current.transform.Find("Date").gameObject;
            countLabel.GetComponent<Text>().text = sizes[i].ToString();
            dateLabel.GetComponent<Text>().text = currStart.ToShortDateString() + " - " + currEnd.ToShortDateString();
            Debug.Log(totalCnt);
            
            float delta = (sizes[i] * 1.0f / totalCnt) * height;
            Debug.Log(delta);
            current.GetComponent<RectTransform>().offsetMax = new Vector2(current.GetComponent<RectTransform>().offsetMax.x, -1*delta);
            currStart = currEnd;
            currEnd = currStart.AddDays(barSize);
        }
    }
}
