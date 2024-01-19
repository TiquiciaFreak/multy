using FishNet.Object;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class PlayerInput : NetworkBehaviour
{
    public float h;
    public float v;
    public float mouseX;
    public float mouseY;
    public float sensitivity;
    public bool isJump;

    private Pawn pawnOwner;

 
    private void Update()
    {
        if (!IsOwner) return;

        h = Input.GetAxis("Horizontal");
        v = Input.GetAxis("Vertical");
        mouseX = Input.GetAxis("Mouse X")*sensitivity;
        mouseY = Input.GetAxis("Mouse Y") * sensitivity;
        isJump = Input.GetButton("Jump");
    }
}
