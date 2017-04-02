using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class CustomNetworkManager : NetworkManager {
    public int NumberOfClients
    {
        get { return numberOfClients; }
    }

    private int numberOfClients;

    public override void OnServerConnect(NetworkConnection conn)
    {
        base.OnServerConnect(conn);
        numberOfClients += 1;
    }

    public override void OnServerDisconnect(NetworkConnection conn)
    {
        base.OnServerDisconnect(conn);
        numberOfClients -= 1;
    }
}
