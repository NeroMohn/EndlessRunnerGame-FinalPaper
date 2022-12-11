using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Points : MonoBehaviour
{
    public static int coinCount;
    public GameObject countDisplay;
    public static double distance;

    private void Awake()
    {
        distance = 0;
    }

    void Update()
    {
        countDisplay.GetComponent<Text>().text = distance.ToString();
    }

    public static void AddPoints()
    {
        coinCount++;
    }    
    
    public static void AddDistance()
    {
        distance+=0.13;
    }

    public static void ResetPoint()
    {
        coinCount = 0;
        distance  = 0;
    }
}
