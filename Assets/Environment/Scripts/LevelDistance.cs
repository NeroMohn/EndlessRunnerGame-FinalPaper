using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelDistance : MonoBehaviour
{
    private bool addingDistance = false;

    public bool started = false;

    private void Awake()
    {
        StartCoroutine(WaitForStartMoving());
    }
    void Update()
    {
        AddDistance();
    }

    private void AddDistance()
    {
        if (!addingDistance && started)
        {
            addingDistance = true;
            StartCoroutine(Adding());
        }
    }

    IEnumerator Adding()
    {
        Points.AddDistance();
        yield return new WaitForSeconds(0.19f);
        addingDistance = false;
    }
    IEnumerator WaitForStartMoving()
    {
        yield return new WaitForSeconds(4.3f);
        started = true;
    }


}
