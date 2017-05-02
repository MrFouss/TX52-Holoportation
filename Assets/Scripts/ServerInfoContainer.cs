using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.UI;

public class ServerInfoContainer : MonoBehaviour {

    public InputField AddressField;
    public InputField PortField;

	public string Address;
	public int Port;

    public void UpdateAddress() {
		string addressFieldContent = this.AddressField.text.ToString();

		this.Address = addressFieldContent.Length == 0
			? this.AddressField.placeholder.ToString()
			: this.AddressField.text.ToString();
	}

    public void UpdatePort(){
		string portFieldContent = this.PortField.text.ToString();
		int portFieldValue = int.Parse(portFieldContent);

		this.Port = (portFieldContent.Length == 0 && portFieldValue >= 0 && portFieldValue <= 65535)
			? int.Parse(this.PortField.placeholder.ToString())
			: int.Parse(this.PortField.text.ToString());
	}

    // Use this for initialization
    void Start () {
        MonoBehaviour.DontDestroyOnLoad(this.gameObject);
    }

}
