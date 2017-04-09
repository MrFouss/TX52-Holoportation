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
        int port = this.ServerInfoContainer.getParsedPort();

        if (port != 0) {
            this.LoadingImage.SetActive(true);
            this.NetworkManager.networkPort = port;
            this.NetworkManager.StartServer();
            Debug.Log("server port = " + port);
            SceneManager.LoadScene("KinectApp");
        }
    }
}
