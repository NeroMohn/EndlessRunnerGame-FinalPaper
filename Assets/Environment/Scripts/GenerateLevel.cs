using System.Collections;
using UnityEngine;

public class GenerateLevel : MonoBehaviour
{

    public GameObject[] section;
    public int zPosition = 50;
    public bool creatingSection = false;
    private int sectionNumber;
    private float waitTime = 9.5f;

    void Update()
    {
        if (!creatingSection)
        {
            creatingSection = true;
            StartCoroutine(GenerateSection());
        }
    }

    IEnumerator GenerateSection()
    {
        sectionNumber = Random.Range(0, section.Length);
        Instantiate(section[sectionNumber], new Vector3(0, 0, zPosition), Quaternion.identity);
        zPosition += 50;
        yield return new WaitForSeconds(waitTime);
        creatingSection = false;
    }
}
