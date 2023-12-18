using FishNet.Object;
using FishNet.Object.Synchronizing;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyPlayerNet : NetworkBehaviour
{
    [SyncVar] public string userName;
    [SyncVar] public bool isReady;
    public override void OnStartServer()
    {
        base.OnStartServer();
        GameManager.Instance._players.Add(this);
    }
    //cuando el jugado termina conexion con el server
   
    public override void OnStopServer()
    {
       
        base.OnStopServer();
        GameManager.Instance._players.Remove(this);
    }
    public override void OnStopClient()
    {
        base.OnStopClient();
        GameManager.Instance._players.Remove(this);
    }
    private void Update()
    {
        if (!IsOwner) return;
        if (Input.GetKeyDown(KeyCode.R))
        {
            SetServerIsReady(!isReady);
        }
    }
    [ServerRpc]
    public void SetServerIsReady(bool value)
    {
         isReady = value;
    }
}
