using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseMovement : MonoBehaviour
{
    Vector3 movementDirection;// 
    private Rigidbody myBody;//cuerpo
    [SerializeField]  float walk_Speed = 5f;//velocidad
    [SerializeField] float walking_Force = 50f;//fuerza
    [SerializeField] float turning_Smoothing = 0.1f;

    private Quaternion screenMovement_Space;
    private Vector3 screenMovement_Forward;
    private Vector3 screenMovement_Right;
    void Awake()
    {
        myBody = GetComponent<Rigidbody>();
        movementDirection = Vector3.zero;
    }
    private void Start()
    {
        SetScreenMovement();
    }
    void FixedUpdate()
    {
        HangleMovement();
    }
    private void Update()
    {
        MovementInput();
    }
    void MovementInput()
    {

             movementDirection = Input.GetAxis("Horizontal")
            * screenMovement_Right + Input.GetAxis("Vertical")
            * screenMovement_Forward;

        // ANIMATE CHARACTER
        if (Input.GetAxis("Horizontal") != 0 ||
        Input.GetAxis("Vertical") != 0)
        {

          //  playerAnimation.Walk(true);

        }
        else
        {

         //   playerAnimation.Walk(false);

        }

        if (movementDirection.sqrMagnitude > 1)
        {
           movementDirection.Normalize();
        }

    }

    void SetScreenMovement()
    {
        screenMovement_Space = Quaternion.Euler(0f, Camera.main.transform.eulerAngles.y, 0f);
        screenMovement_Forward = screenMovement_Space * Vector3.forward;
        screenMovement_Right = screenMovement_Space * Vector3.right;
    }
    void HangleMovement()
    {

        // target velocity is the velocity we want to reach
        Vector3 targetVelocity = movementDirection * walk_Speed;

        // delta velocity is the difference between target velocity
        // and current velocity
        Vector3 deltaVelocity = targetVelocity - myBody.velocity;

        if (myBody.useGravity)
        {
            deltaVelocity.y = 0f;
        }

        myBody.AddForce(deltaVelocity * walking_Force,
       ForceMode.Acceleration);

        Vector3 face_Direction = movementDirection;

        if (face_Direction == Vector3.zero)
        {

            myBody.angularVelocity = Vector3.zero;

        }
        else
        {

            float rotationAngle = AngleAroundAxis(transform.forward,
            face_Direction, Vector3.up);

            myBody.angularVelocity = (Vector3.up * rotationAngle * turning_Smoothing);

        }

    }

    float AngleAroundAxis(Vector3 dirA, Vector3 dirB, Vector3 axis)
    {

        float angle = Vector3.Angle(dirA, dirB);

        return angle * (Vector3.Dot(axis, Vector3.Cross(dirA, dirB)) > 0 ? 1 : -1);
    }


}
