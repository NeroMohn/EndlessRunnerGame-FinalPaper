using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerMove : MonoBehaviour
{

    public float moveSpeed;
    public float horizontalSpeed;

    private float rotateSpeedAngle = 45f;
    private float rotateSpeedAngleBack = 60f;

    public float sideRotationMovement;
    private Vector3 camOffset;

    static public bool canMove = false;


    private void Awake()
    {
        camOffset = Camera.main.transform.position - transform.position;
    }

    void Update()
    {
        MovePlayer();
        Camera.main.transform.position = transform.position + camOffset;
    }

    void MovePlayer()
    {
        if (canMove)
        {
            var axisX = Input.GetAxisRaw("Horizontal");
            transform.Translate(Vector3.forward * Time.deltaTime * moveSpeed, Space.World);

            //if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
            if (axisX < -0.3f)
            {
                var force = Remap(-0.3f, -1, 0, 1, axisX);
                Debug.Log("esqueda " + force);

                if (this.gameObject.transform.position.x > LevelBoundaries.leftLimit)
                {
                    transform.Translate(Vector3.left * Time.deltaTime * horizontalSpeed * force, Space.World);
                    transform.Rotate(0, 0, rotateSpeedAngle * Time.deltaTime * force, Space.World);
                    return;
                }
            }
            //if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
            if (axisX > 0.3f)
            {
                var force = Remap(0.3f, 1, 0, 1, axisX);
                Debug.Log("direita " + force);

                if (this.gameObject.transform.position.x < LevelBoundaries.righttLimit)
                {
                    transform.Translate(Vector3.right * Time.deltaTime * horizontalSpeed * force, Space.World);
                    transform.Rotate(0, 0, -rotateSpeedAngle * Time.deltaTime * force, Space.World);
                    return;
                }
            }
            //transform.Rotate(0, 0, -transform.rotation.z * Time.deltaTime, Space.World);
            //var direction = Mathf.Sign(transform.rotation.z);
            //var speed = Mathf.Min(Mathf.Abs(transform.rotation.z), rotateSpeedAngleBack * Time.deltaTime);
            //transform.Rotate(0, 0, -speed * direction, Space.World);

            //transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.identity, (Time.deltaTime * 3f));
            transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.identity, rotateSpeedAngleBack * Time.deltaTime);

            //{
            //    //transform.rotation = Quaternion.Lerp (transform.rotation, , Time.deltaTime * 0.5);
            //timeCount = timeCount + Time.deltaTime;

            //        //if(transform.rotation.z > 0)
            //        //{
            //        //    ;
            //        //}
            //        //if (transform.rotation.z < 0)
            //        //{
            //        //    transform.Rotate(0, 0, 0.1f, Space.World);
            //        //}

            //}
        }
    }

    public static float Remap(float inMin, float inMax, float outMin, float outMax, float t)
    {
        var ratio = Mathf.InverseLerp(inMin, inMax, t);
        return Mathf.Lerp(outMin, outMax, ratio);
    }
}
