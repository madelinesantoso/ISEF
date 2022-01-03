using UnityEngine;
using Unity.Netcode;

public class PlayerComponent : NetworkBehaviour
{
    public override void OnNetworkSpawn()
    {
        if (IsServer && !IsLocalPlayer && NetworkObject.IsPlayerObject)
        {
            transform.position += new Vector3(-2, 0, 0);
        }
        base.OnNetworkSpawn();
    }
}
