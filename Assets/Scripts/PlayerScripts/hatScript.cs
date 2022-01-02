using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;
//using Unity.Netcode.Messaging;
//using Unity.Netcode.Spawning;
//using Unity.Netcode.NetworkVariable;
using UnityEngine.UI;
using System.Text;

public class hatScript : NetworkBehaviour
{
    public NetworkVariable<bool> cowboyHat = new NetworkVariable<bool>();
    public GameObject hat;
    public GameObject cowboyPrefab;
    // Start is called before the first frame update
    void Start()
    {
        cowboyHat.Value = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (IsLocalPlayer)
        {
            if (Input.GetKeyDown(KeyCode.H))
            {
                cowboyHat.Value = true;
            }
        }

        if (Input.GetKeyDown(KeyCode.H))
        {
            hatServerRpc();
        }
    }

    [ServerRpc (RequireOwnership = false)]
    public void hatServerRpc()
    {
        print("bro");
    }
}
