using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleColision : MonoBehaviour
{
    public GameObject envController;
    public GameObject player;
    void OnTriggerEnter(Collider other) 
    {
        player.GetComponent<PlayerMove>().enabled = false;
        this.gameObject.GetComponent<BoxCollider>().enabled = false;
        envController.GetComponent<LevelDistance>().started = false;
    }
}
