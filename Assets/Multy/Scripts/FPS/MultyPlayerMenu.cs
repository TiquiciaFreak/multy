using FishNet;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public sealed class MultyPlayerMenu : MonoBehaviour
{
    [SerializeField] private Button hostBtn,clientBtn;
    
    void Start()
    {
        hostBtn.onClick.AddListener(() =>
        {
            InstanceFinder.ServerManager.StartConnection();
            InstanceFinder.ClientManager.StartConnection();
        });
        clientBtn.onClick.AddListener(() =>  InstanceFinder.ClientManager.StartConnection());
        
    }

}