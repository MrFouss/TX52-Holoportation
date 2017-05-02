﻿using System;
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
        string address = this.ServerInfoContainer.Address;
        int port = this.ServerInfoContainer.Port;
		
        this.LoadingImage.SetActive(true);
        this.NetworkManager.networkAddress = address;
        this.NetworkManager.networkPort = port;
        this.NetworkManager.StartClient();

        Debug.Log("Server IP: " + address);
        Debug.Log("Server port: " + port);
        SceneManager.LoadScene("MobileApp");
    }
}
