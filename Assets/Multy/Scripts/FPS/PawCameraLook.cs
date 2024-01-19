using FishNet.Object;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PawCameraLook : NetworkBehaviour
{
    PlayerInput input;
    [SerializeField]
    Transform myCamera;
    [SerializeField]
    float xmin;
    [SerializeField]
    float   xmax;

    Vector3 rotation;
    public override void OnStartNetwork()
    {
        base.OnStartNetwork();
        input = GetComponent<PlayerInput>();

    }
    public override void OnStartClient()
    {
        base.OnStartClient();
        myCamera.GetComponent<Camera>().enabled = IsOwner;
        myCamera.GetComponent<AudioListener>().enabled = IsOwner;
    }
    void Update()
    {
        if (!IsOwner) return;
        rotation.x -= input.mouseY;
        rotation.y -= input.mouseX;
        rotation.x =Mathf.Clamp(rotation.x, xmin, xmax);

        myCamera.localEulerAngles = rotation;
        transform.Rotate(0.0f, input.mouseY, 0.0f, Space.World);
        
    }
}
