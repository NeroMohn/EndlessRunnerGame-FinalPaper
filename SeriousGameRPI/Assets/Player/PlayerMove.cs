using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{

    public float moveSpeed;
    public float horizontalSpeed;

    void Update()
    {
        MovePlayer();
    }

    void MovePlayer()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * moveSpeed, Space.World);

        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            if (this.gameObject.transform.position.x > LevelBoundaries.leftLimit)
                transform.Translate(Vector3.left * Time.deltaTime * horizontalSpeed, Space.World);
        }
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            if (this.gameObject.transform.position.x < LevelBoundaries.righttLimit)
                transform.Translate(Vector3.right * Time.deltaTime * horizontalSpeed, Space.World);
        }
    }
}
