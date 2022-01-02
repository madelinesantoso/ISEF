using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;
//using Unity.Netcode.Messaging;
//using Unity.Netcode.NetworkVariable;
using UnityEngine.UI;

public class serverVariables : NetworkBehaviour
{
    public NetworkVariable<float> bankInterest = new NetworkVariable<float>();
    public NetworkVariable<float> bankCurrency = new NetworkVariable<float>();
    public NetworkVariable<int> goodFood = new NetworkVariable<int>();
    public NetworkVariable<int> ehFood = new NetworkVariable<int>();
    public NetworkVariable<int> bait = new NetworkVariable<int>();
    public NetworkVariable<int> wood = new NetworkVariable<int>();
    public NetworkVariable<int> oreInMine = new NetworkVariable<int>();
    public NetworkVariable<int> rarity = new NetworkVariable<int>();
    public NetworkVariable<int> ore = new NetworkVariable<int>();
    // Start is called before the first frame update
    void Start()
    {
        bankInterest.Value = 0;
        bankCurrency.Value = 10;
        goodFood.Value = 10;
        ehFood.Value = 10;
        wood.Value = 20;
        bait.Value = 10;
        oreInMine.Value = 25;
        rarity.Value = 30;
        ore.Value = 20;
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    [ServerRpc (RequireOwnership = false)]
    public void updateVarServerRpc(float num)
    {
        updateBankInterestClientRpc(num);
        //print("update interest called by " + num);
    }

    [ServerRpc(RequireOwnership = false)]
    public void moreCurrencyServerRpc(float num)
    {
        increaseCurrencyClientRpc(num);
        //print("serverVar script called, increase by " + num);
    }

    [ServerRpc(RequireOwnership = false)]
    public void lessCurrencyServerRpc(float num)
    {
        decreaseCurrencyClientRpc(num);
        //print("serverVar script called, decrease by " + num);
    }

    [ServerRpc(RequireOwnership = false)]
    public void roundABoutFoodServerRpc(int num)
    {
        updateFoodStoreClientRpc(num);
    }

    [ServerRpc(RequireOwnership = false)]
    public void roundABoutGoodFoodServerRpc(int num)
    {
        updateGoodFoodStoreClientRpc(num);
    }

    [ServerRpc(RequireOwnership = false)]
    public void roundABoutBaitServerRpc(int num)
    {
        updateBaitStoreClientRpc(num);
    }

    [ServerRpc(RequireOwnership = false)]
    public void roundABoutWoodServerRpc(int num)
    {
        increaseWoodClientRpc(num);
    }

    [ServerRpc(RequireOwnership = false)]
    public void roundABoutLessWoodServerRpc(int num)
    {
        decreaseWoodClientRpc(num);
    }

    [ServerRpc(RequireOwnership = false)]
    public void roundABoutMineServerRpc()
    {
        MineClientRpc();
    }

    [ServerRpc(RequireOwnership = false)]
    public void roundABoutOreServerRpc(int num)
    {
        increaseOreClientRpc(num);
    }

    /* 


CLIENT RPC STUFF


   */

    [ClientRpc]
    public void updateBankInterestClientRpc(float interest)
    {
        //print(bankInterest.Value);
        bankInterest.Value += interest;
       // print("interest: " + bankInterest.Value);
    }

    [ClientRpc]
    public void MineClientRpc()
    {
        oreInMine.Value--;
        rarity.Value += 3;
    }

    [ClientRpc]
    public void updateFoodStoreClientRpc(int food)
    {
        ehFood.Value = food;
        //print("eh food is now " + ehFood.Value);
        
    }

    [ClientRpc]
    public void updateGoodFoodStoreClientRpc(int food)
    {
        goodFood.Value = food;
        //print("eh food is now " + goodFood.Value);
    }

    [ClientRpc]
    public void updateBaitStoreClientRpc(int fish)
    {
        bait.Value = fish;
    }

    [ClientRpc]
    public void updateStoreClientRpc(int num)
    {
        //do stuff
    }

    [ClientRpc]
    public void increaseCurrencyClientRpc(float num)
    {
        bankCurrency.Value += num;
        print("Currency: " + bankCurrency.Value + ". Increased by " + num);
    }

    [ClientRpc]
    public void decreaseCurrencyClientRpc(float num)
    {
        bankCurrency.Value -= num;
        print("Currency: " + bankCurrency.Value + ". Decreased by " + num);
    }

    [ClientRpc]
    public void decreaseWoodClientRpc(int num)
    {
        wood.Value -= num;
    }

    [ClientRpc]
    public void increaseWoodClientRpc(int num)
    {
        wood.Value += num;
    }

    [ClientRpc]
    public void decreaseOreClientRpc(int num)
    {
        ore.Value -= num;
    }

    [ClientRpc]
    public void increaseOreClientRpc(int num)
    {
        ore.Value += num;
    }
}
