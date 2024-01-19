using FishNet.Object;
using FishNet.Object.Synchronizing;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AddressableAssets;

public class MyPlayerNet : NetworkBehaviour
{
    [SyncVar] public string userName;
    [SyncVar] public bool isReady;
    [SyncVar] public Pawn controllerdPawn;  
    public override void OnStartServer()
    {
        base.OnStartServer();
        GameManager.Instance._players.Add(this);
        userName = "COMENTEN";
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
        if (Input.GetKeyDown(KeyCode.I))
        {
            ServerSpawnPawn();
        }
    }
    [ServerRpc]
    public void SetServerIsReady(bool value)
    {
         isReady = value;
    }
    [ServerRpc]
    void ServerSpawnPawn()
    {
        GameObject pawnGo = Addressables.LoadAssetAsync<GameObject>("Pawn").WaitForCompletion();
        GameObject pamIntance = Instantiate(pawnGo);
       Pawn pamIntanceRef = pamIntance.GetComponent<Pawn>();
        pamIntanceRef.PlayerNet = this;

        pamIntanceRef.playerName = userName;
        Spawn(pamIntance,Owner);


    }
}
