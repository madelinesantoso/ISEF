using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Unity.Netcode;
//using Unity.Netcode.NetworkVariable;
//using Unity.Netcode.Messaging;


public class DisplayName : MonoBehaviour
{
    public Text name;
    string EnteredName;
    //public NetworkVariable<string> name = new NetworkVariable<string>();
    public InputField textBox;
    public GameObject texttext;
    // Start is called before the first frame update
    void Start()
    {
        //displayName = transform.Find("Name").Text;
        //OnEnteredText();
    }

   /* public void OnEnteredText()
    {
        texttext = GameObject.Find("InputField");
        //textBox = texttext.GetComponent<intialInput>().sendNameField();
        name = textBox.text.ToString();
        if (name.ToString == "" &&)
        {
            name = textBox.text;
            roundAboutServerRpc();
        }
        EnteredName = textBox.text;
    }

    [ServerRpc(RequireOwnership = false)]
    public void roundAboutServerRpc()
    {
        updateNameClientRpc(name);
    }

    [ClientRpc]
    public void updateNameClientRpc(Text nameDisplay)
    {
        print("update name called");
        nameDisplay.text = name.ToString();
    }*/
}
