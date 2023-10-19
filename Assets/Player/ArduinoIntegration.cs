using UnityEngine;
using System.IO.Ports;

public class ArduinoIntegration : MonoBehaviour
{
    private SerialPort data_stream = new SerialPort("COM3", 9600);
    public static short receivedString;
    public float Sensitivity = 1.01f;

    void Start()
    {
        data_stream.Open();
    }

    // Update is called once per frame
    void Update()
    {
        receivedString = short.Parse(data_stream.ReadLine());
    }
}
