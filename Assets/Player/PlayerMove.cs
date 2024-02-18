using UnityEngine;

public class PlayerMove : MonoBehaviour
{

    public float moveSpeed;
    public float horizontalSpeed;

    private float rotateSpeedAngle = 45f;
    private float rotateSpeedAngleBack = 60f;

    public float sideRotationMovement;
    private Vector3 camOffset;

    static public bool canMove = false;
    public bool _useAccelController;


    private void Awake()
    {
        canMove = false;
        camOffset = Camera.main.transform.position - transform.position;
    }

    void Update()
    {
        switch (_useAccelController)
        {
            case true:
                MovePlayerSensor();
                break;
            default:
                MovePlayerController();
                break;
        }
        Camera.main.transform.position = transform.position + camOffset;
    }

    void MovePlayerController()
    {
        if (canMove)
        {
            var axisX = Input.GetAxisRaw("Horizontal");
            transform.Translate(Vector3.forward * Time.deltaTime * moveSpeed, Space.World);

            //if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
            if (axisX < -0.3f)
            {
                var force = Remap(-0.3f, -1, 0, 1, axisX);
                //Debug.Log("esqueda " + force);

                if (this.gameObject.transform.position.x > LevelBoundaries.leftLimit)
                {
                    transform.Translate(Vector3.left * Time.deltaTime * horizontalSpeed * force, Space.World);
                    transform.Rotate(0, 0, rotateSpeedAngle * Time.deltaTime * force, Space.World);
                    return;
                }
            }
            if (axisX > 0.3f)
            {
                var force = Remap(0.3f, 1, 0, 1, axisX);
                //Debug.Log("direita " + force);

                if (this.gameObject.transform.position.x < LevelBoundaries.righttLimit)
                {
                    transform.Translate(Vector3.right * Time.deltaTime * horizontalSpeed * force, Space.World);
                    transform.Rotate(0, 0, -rotateSpeedAngle * Time.deltaTime * force, Space.World);
                    return;
                }
            }
            
            transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.identity, rotateSpeedAngleBack * Time.deltaTime);

        }
    }

    /// <summary>
    /// Moves the player using the motion sensor.
    /// Note: The values may not be intuitive due to accelerometer calibration.
    /// It's recommended to check the values first and then apply the movement range accordingly.
    /// </summary>
    void MovePlayerSensor()
    {
        if (canMove)
        {
            var axisX = ArduinoIntegration.receivedString;
            transform.Translate(Vector3.forward * Time.deltaTime * moveSpeed, Space.World);

            //This should be setted up in a variable. fix this latter
            if (axisX < 2000)
            {
                var force = Remap(1000, -2700, 0, 1, axisX);

                if (this.gameObject.transform.position.x > LevelBoundaries.leftLimit)
                {
                    transform.Translate(Vector3.left * Time.deltaTime * horizontalSpeed * force, Space.World);
                    transform.Rotate(0, 0, rotateSpeedAngle * Time.deltaTime * force, Space.World);
                    return;
                }
            }
            //if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
            if (axisX > 3000)
            {
                var force = Remap(3000, 6000, 0, 1, axisX);
                //Debug.Log("direita " + force);

                if (this.gameObject.transform.position.x < LevelBoundaries.righttLimit)
                {
                    transform.Translate(Vector3.right * Time.deltaTime * horizontalSpeed * force, Space.World);
                    transform.Rotate(0, 0, -rotateSpeedAngle * Time.deltaTime * force, Space.World);
                    return;
                }
            }
            transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.identity, rotateSpeedAngleBack * Time.deltaTime);
        }
    }

    public static float Remap(float inMin, float inMax, float outMin, float outMax, float t)
    {
        var ratio = Mathf.InverseLerp(inMin, inMax, t);
        return Mathf.Lerp(outMin, outMax, ratio);
    }
}
