using FishNet.Object.Synchronizing;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyPlayerNet : MonoBehaviour
{
    [SyncVar] public string userName;
    [SyncVar] public bool isReady;
}
