using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ApplyConnectButton : MonoBehaviour {

    public ServerInfoContainer ServerInfoContainer;

    public NetworkManager NetworkManager;

    public GameObject LoadingImage;

    public void ConnectAndLoad() {
        int port = 0;
        try {
            port = int.Parse(this.ServerInfoContainer.Port);
        }
        catch {
        }
        if (port != 0) {
            this.LoadingImage.SetActive(true);
            this.NetworkManager.networkAddress = this.ServerInfoContainer.Address;
            this.NetworkManager.networkPort = port;
            this.NetworkManager.StartClient();
            Debug.Log("server ip = " + this.ServerInfoContainer.Address);
            Debug.Log("server port = " + this.ServerInfoContainer.Port);
            SceneManager.LoadScene("MobileApp");
        }
    }
}
