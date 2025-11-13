using System;
using System.IO.Ports;
using UnityEngine;

public class ArduinoInput : MonoBehaviour
{
    [Header("Configuración Serial")]
    public string portName = "COM3"; // Cambia según tu PC
    public int baudRate = 9600;

    private SerialPort serialPort;
    private string lastCommand = "";

    public static event Action<Vector2> OnMovementEncoder;
    void Start()
    {
        try
        {
            serialPort = new SerialPort(portName, baudRate);
            serialPort.Open();
            serialPort.ReadTimeout = 50;
            Debug.Log("? Conectado al Arduino en " + portName);
        }
        catch (System.Exception e)
        {
            Debug.LogError("? No se pudo conectar al puerto " + portName + ": " + e.Message);
        }
    }

    void Update()
    {
        if (serialPort != null && serialPort.IsOpen)
        {
            try
            {
                string data = serialPort.ReadLine().Trim();
                if (data != lastCommand)
                {
                    lastCommand = data;
                    HandleArduinoInput(data);
                }
            }
            catch (System.TimeoutException) { }
        }
    }

    
    private void HandleArduinoInput(string data)
    {
        Vector2 movement = Vector2.zero;

        if (data.Contains("LEFT"))
            movement = new Vector2(-1, 0);
        else if (data.Contains("RIGHT"))
            movement = new Vector2(1, 0);
        else if (data.Contains("STOP"))
            movement = Vector2.zero;

       OnMovementEncoder?.Invoke(movement);
    }


    void OnApplicationQuit()
    {
        if (serialPort != null && serialPort.IsOpen)
            serialPort.Close();
    }
}
