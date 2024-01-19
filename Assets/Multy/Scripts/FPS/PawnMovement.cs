using FishNet.Object;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class PawnMovement : NetworkBehaviour
{
    PlayerInput input;  
    CharacterController characterController;
  
    [SerializeField]
    float speed;
    [SerializeField]
    float jumpSpeed;
    [SerializeField]
    float  gravityScale;
    private Vector3 velocity;
    public override void OnStartNetwork()
    {
        base.OnStartNetwork();
        input = GetComponent<PlayerInput>();
        characterController = GetComponent<CharacterController>();

    }
    private void Update()
    {
        if (!IsOwner) return;
        Vector3 dir = Vector3.ClampMagnitude((transform.forward * input.v) + (transform.right * input.h) * speed, speed);
        velocity.x=dir.x;
        velocity.y=dir.z;
        if (characterController.isGrounded)
        {
            velocity.y = 0.0f;
            if (input.isJump)
            {
                velocity.y = jumpSpeed;
            }
        }
        else
        {
            velocity.y = Physics.gravity.y * gravityScale * Time.deltaTime;
        }
        characterController.Move(velocity * Time.deltaTime);
    }
}
