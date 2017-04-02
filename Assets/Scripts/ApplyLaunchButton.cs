using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;

public class ApplyLaunchButton : MonoBehaviour {

    public ServerInfoContainer ServerInfoContainer;

    public NetworkManager NetworkManager;

    public GameObject LoadingImage;

    public void ConnectAndLoad()
    {
        int port = 0;
        try
        {
            port = int.Parse(this.ServerInfoContainer.Port);
        }
        catch
        {
        }
        if (port != 0)
        {
            this.LoadingImage.SetActive(true);
            this.NetworkManager.networkPort = port;
            this.NetworkManager.StartServer();
            Debug.Log("server port = " + this.ServerInfoContainer.Port);
            SceneManager.LoadScene("KinectApp");
        }
    }
}
