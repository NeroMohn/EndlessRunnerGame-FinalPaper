using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class ObstacleColision : MonoBehaviour
{
    public GameObject envController;
    public GameObject player;
    public GameObject countDownDisplay;

    void OnTriggerEnter(Collider other)
    {
        envController = GameObject.FindGameObjectWithTag("GameControl");
        player = GameObject.FindGameObjectWithTag("Player");
        envController.GetComponent<CountDown>().ActivateDisplay();

        countDownDisplay = GameObject.FindGameObjectWithTag("CountDown");
        player.GetComponent<PlayerMove>().enabled = false;
        this.gameObject.GetComponent<BoxCollider>().enabled = false;
        envController.GetComponent<LevelDistance>().started = false;
        countDownDisplay.SetActive(true);
        StartCoroutine(Stop());
    }



    private IEnumerator Stop()
    {
        countDownDisplay.GetComponent<Text>().text = "Que pena, você acertou o obstáculo!";
        yield return new WaitForSeconds(3);
        countDownDisplay.GetComponent<Text>().text += $"\n Distância: {Points.distance}";
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene("Menu");

    }
}
