using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Vuforia;

public class ApplyConnectButton : MonoBehaviour {

    public ServerInfoContainer ServerInfoContainer;
    public NetworkManager NetworkManager;
	public Toggle CardboardCheckbox;
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

		if (CardboardCheckbox.isOn) {
			VuforiaConfiguration.Instance.DigitalEyewear.EyewearType = DigitalEyewearARController.EyewearType.VideoSeeThrough;
			VuforiaConfiguration.Instance.DigitalEyewear.StereoFramework = DigitalEyewearARController.StereoFramework.Vuforia;
		} else {
			VuforiaConfiguration.Instance.DigitalEyewear.EyewearType = DigitalEyewearARController.EyewearType.None;
		}
		SceneManager.LoadScene("MobileApp");
    }
}
