using UnityEditor.PackageManager;
using UnityEngine;
using ViconDataStreamSDK.DotNET;

public class ViconConnect : MonoBehaviour
{
    Client client;

    void Start()
    {
        client = new Client();

        Output_Connect result = client.Connect("192.168.1.133:801");

        if (result.Result == Result.Success)
        {
            Debug.Log("Conectado a Vicon");
        }
        else
        {
            Debug.Log("Error al conectar");
        }
    }

    void Update()
    {
        if (client.IsConnected().Connected)
        {
            client.GetFrame();
            Debug.Log("Recibiendo frame");
        }
    }
}

