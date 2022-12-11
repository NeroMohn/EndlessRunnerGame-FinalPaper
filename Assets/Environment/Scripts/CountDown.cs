using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;


public class CountDown : MonoBehaviour
{

    public GameObject countDownDisplay;
    //public GameObject FadeIn;
    void Start()
    {
        StartCoroutine(CountSequence());
    }

    IEnumerator CountSequence()
    {
        yield return new WaitForSeconds(0.3f);
        countDownDisplay.GetComponent<Text>().text = 3.ToString();
        yield return new WaitForSeconds(1);
        countDownDisplay.GetComponent<Text>().text = 2.ToString();
        yield return new WaitForSeconds(1);
        countDownDisplay.GetComponent<Text>().text = 1.ToString();
        yield return new WaitForSeconds(1);
        countDownDisplay.GetComponent<Text>().text = "VAI!";
        yield return new WaitForSeconds(1);
        countDownDisplay.SetActive(false);
        PlayerMove.canMove = true;
    }

}
