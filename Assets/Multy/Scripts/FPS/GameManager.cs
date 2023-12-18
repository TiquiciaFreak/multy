using FishNet.Demo.AdditiveScenes;
using FishNet.Object;
using FishNet.Object.Synchronizing;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public sealed class GameManager : NetworkBehaviour
{
   public static GameManager Instance { get; private set; }
    [SyncObject]
    public readonly SyncList<MyPlayerNet> _players = new SyncList<MyPlayerNet>();
    [SyncVar]
    public bool canStart;

    private void Awake()
    {
        Instance = this;
    }
    //cuando el jugado inicia conexion con el server
    private void Update()
    {
        if (!IsServer) return;

        canStart = _players.All(_players => _players.isReady);
        Debug.Log($"Can Start= {canStart}");

    }
}

