using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelBoundaries : MonoBehaviour
{

    public static float leftLimit = -4.55f;
    public static float righttLimit = 4.55f;
    public float internalLeft;
    public float internalRight;

    void Update()
    {
        internalLeft = leftLimit;
        internalRight = righttLimit;
    }
}
