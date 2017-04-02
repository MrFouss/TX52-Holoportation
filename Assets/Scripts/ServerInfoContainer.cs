using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ServerInfoContainer : MonoBehaviour {

    public InputField AddressField;
    public string Address;

    public InputField PortField;
    public string Port;

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
