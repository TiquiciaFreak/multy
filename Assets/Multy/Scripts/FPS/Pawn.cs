using FishNet.Object;
using FishNet.Object.Synchronizing;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class Pawn :NetworkBehaviour
{
    [SyncVar]
  public MyPlayerNet PlayerNet;

    [SyncVar]
    public float health;
    [SyncVar]
  public  string playerName;

}
