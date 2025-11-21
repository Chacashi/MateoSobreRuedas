using System;
using System.IO.Ports;
using UnityEngine;

public class ArduinoInput : MonoBehaviour
{
    [Header("Serial Config")]
    public string portName = "COM3";
    public int baudRate = 9600;

    private SerialPort serialPort;


    public static event Action<Vector2> OnMovementEncoder;

    private void Start()
    {
        try
        {
            serialPort = new SerialPort(portName, baudRate);
            serialPort.ReadTimeout = 50;
            serialPort.Open();
            Debug.Log("Arduino connected.");
        }
        catch (Exception e)
        {
            Debug.LogError("No se pudo abrir el puerto: " + e.Message);
        }
    }

    private void Update()
    {
        if (serialPort == null || !serialPort.IsOpen)
            return;

        try
        {
            string data = serialPort.ReadLine().Trim();

            if (data == "R1")
            {
                
                OnMovementEncoder?.Invoke(new Vector2(1, 0));
            }
            else if (data == "R-1")
            {
               
                OnMovementEncoder?.Invoke(new Vector2(-1, 0));
            }
            else if (data == "STOP")
            {
                OnMovementEncoder?.Invoke(Vector2.zero);
            }
        }
        catch (TimeoutException)
        {
            
        }
       
    }

    private void OnApplicationQuit()
    {
        if (serialPort != null && serialPort.IsOpen)
            serialPort.Close();
    }
}
