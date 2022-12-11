using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateItem : MonoBehaviour
{

    public float rotationValue = 5.2f;

    void Update()
    {
        this.transform.Rotate(0,rotationValue,0, Space.World);
    }
}
