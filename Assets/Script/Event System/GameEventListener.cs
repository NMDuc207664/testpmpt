using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Unity.Netcode;
public class GameEventListener : NetworkBehaviour
{
    // Check if there is a event happening
    public GameEvent gameEvent;
    // Preform the unity event response to the call
    public UnityEvent response;

    public void OnEnable()
    {
        gameEvent.RegisterListener(this);
    }

    public void OnDisable()
    {
        gameEvent.UnregisterListener(this);
    }

    public virtual void OnEventCall()
    {
        response.Invoke();
    }
}
