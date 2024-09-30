using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
[AddComponentMenu("Control Script/FPS Input")]
public class FPSInput : MonoBehaviour
{
    public float speed = 6.0f;
    public float gravity = -9.0f;

    private CharacterController charController;
    // Start is called before the first frame update
    void Start()
    {
        charController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        float deltaX = Input.GetAxis("Horizontal") * speed;
        float deltaY = Input.GetAxis("Vertical") * speed;
        Vector3 forwardMovement = transform.forward;
        forwardMovement.y = 0;
        forwardMovement.Normalize(); 

        Vector3 rightMovement = transform.right;

        Vector3 movement = (forwardMovement * deltaY) + (rightMovement * deltaX);
        movement *= Time.deltaTime;

        movement.y = gravity * Time.deltaTime;

        charController.Move(movement);
    }
}   