using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class Race : NetworkBehaviour {

    // Use this for initialization
    public NetworkManager nw;
	void Start ()
    {

        if (Network.isServer)
        {
            while (!nw.IsClientConnected())
            {
                print(NetworkServer.objects);
            }
        }
		
	}
	
	// Update is called once per frame
	void Update ()

    {
		
	}
}
