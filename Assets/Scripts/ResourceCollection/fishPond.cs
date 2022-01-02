using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;
//using Unity.Netcode.Messaging;
//using Unity.Netcode.Spawning;
//using Unity.Netcode.NetworkVariable;
using UnityEngine.UI;
using System.Text;

public class fishPond : NetworkBehaviour
{
    public NetworkVariable<int> fishAmount = new NetworkVariable<int>();
    public NetworkVariable<float> fishStuff = new NetworkVariable<float>();

    void Start()
    {
        fishStuff.Value = 20;
        fishAmount.Value = 20;
    }

    public int getFishAmount() //just learned what return stuff does, super awesome :D
    {
        return fishAmount.Value;
    }

    /*void increaseFish()
    {
        fishAmount.Value++;
    }*/

    [ServerRpc(RequireOwnership = false)]
    public void depleteFishServerRpc(int amountTaken)
    {
        fishStuff.Value -= amountTaken;
        print(fishStuff.Value);
        fishAmount.Value -= amountTaken;
    }
}
