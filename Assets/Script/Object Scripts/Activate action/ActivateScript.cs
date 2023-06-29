using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;
public class ActivateScript : NetworkBehaviour
{
    [SerializeField] public GameEvent onActivate;
    [SerializeField] private bool isInteract = false;
    private void Update()
    {
        //Press the button to send active signal
        if (Input.GetButtonDown("Interact") && isInteract && !PauseMenu.isPause)
        {
            onActivate.Call();
        }

    }

    // If player near the panel, enable interact
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isInteract = true;
        }
            
    }

    [ServerRpc]
    private void SignalCallServerRpc(NetworkBehaviourReference eventRef, ServerRpcParams serverRpcParams)
    {
        ulong clientID = serverRpcParams.Receive.SenderClientId; 
        
        onActivate.Call();
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        isInteract = false;
    }

    [ClientRpc]
    private void ActivateClientRpc()
    {
        if (Input.GetButtonDown("Interact") && isInteract && !PauseMenu.isPause)
        {
            onActivate.Call();
        }
    }
}
