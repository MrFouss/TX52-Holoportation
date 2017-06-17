using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class ClientsNumberUpdater : MonoBehaviour {

    public Text ClientNumberText;

    private CustomNetworkManager customNetworkManager;

	// Use this for initialization
	void Start () {
	    this.ClientNumberText.text = "0";
        GameObject go = GameObject.Find("NetworkManager");
//        this.customNetworkManager = go.GetComponent<CustomNetworkManager>();
	}

	// Update is called once per frame
	void Update () {
//	    this.ClientNumberText.text = this.customNetworkManager.NumberOfClients.ToString();
	}
}
