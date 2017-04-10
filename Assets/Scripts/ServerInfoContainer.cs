using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ServerInfoContainer : MonoBehaviour {

    public InputField AddressField;
    public InputField PortField;

	public string Address;
	public string Port;

    public string getParsedAddress() {
         return this.AddressField.text.ToString();
    }

    public int getParsedPort(){
        return int.Parse(this.PortField.text.ToString());
    }

    public void UpdateAddress() {
		this.Address = this.AddressField.text.ToString();
	}

    public void UpdatePort(){
		this.Port = this.PortField.text.ToString();
	}

    // Use this for initialization
    void Start () {
        MonoBehaviour.DontDestroyOnLoad(this.gameObject);
    }

}
