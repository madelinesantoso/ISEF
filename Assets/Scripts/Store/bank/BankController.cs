using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Unity.Netcode;
/*using Unity.Netcode.NetworkVariable;
using Unity.Netcode.Spawning;
using Unity.Netcode.Messaging;*/

public class BankController : MonoBehaviour
{
    public GameObject bankingUI;
    public GameObject introScreen;
    public GameObject depositScreen;
    public GameObject withdrawScreen;
    public GameObject reportScreen;

    public GameObject player;

    public GameObject accountInfo;
    public GameObject nonaccountInfo;
    public bool AccountHere;
    public bool currentlyInBank = false;

    //text on report screen

    // Start is called before the first frame update
    void Start()
    {
        bankingUI.SetActive(false);
        AccountHere = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (currentlyInBank != true)
        {
            bankingUI.SetActive(false);
        }
    }

    public void MakeAccount()
    {
        AccountHere = true;
        ReturnHome();
    }

    public void DeleteAccount()
    {
        AccountHere = false;
        ExitBank();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            if (AccountHere == true)
            {
                accountInfo.SetActive(true);
                nonaccountInfo.SetActive(false);
            } else
            {
                accountInfo.SetActive(false);
                nonaccountInfo.SetActive(true);
            }
            player = collision.gameObject;
            bankingUI.SetActive(true);
            introScreen.SetActive(true);
            depositScreen.SetActive(false);
            withdrawScreen.SetActive(false);
            reportScreen.SetActive(false);
        }
        currentlyInBank = true;
    }

    public void DepositScreen()
    {
        depositScreen.SetActive(true);
        introScreen.SetActive(false);
    }

    public void WithdrawScreen()
    {
        withdrawScreen.SetActive(true);
        introScreen.SetActive(false);
    }

    public void ReportScreen()
    {
        reportScreen.SetActive(true);
        introScreen.SetActive(false);
    }

    public void ReturnHome()
    {
        if (AccountHere == true)
        {
            accountInfo.SetActive(true);
            nonaccountInfo.SetActive(false);
        }
        else
        {
            accountInfo.SetActive(false);
            nonaccountInfo.SetActive(true);
        }
        bankingUI.SetActive(true);
        introScreen.SetActive(true);
        depositScreen.SetActive(false);
        withdrawScreen.SetActive(false);
        reportScreen.SetActive(false);
    }

    public void ExitBank()
    {
        bankingUI.SetActive(false);
    }
}
