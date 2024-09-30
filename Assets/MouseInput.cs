using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseInput : MonoBehaviour
{
    public enum RotationAxes
    {
        MouseXandY = 0,
        MouseY = 1,
        MouseX = 2,
    }
    // Start is called before the first frame update
    public RotationAxes axes = RotationAxes.MouseXandY;
    public float sensitivityHorizontal = 1.0f;
    public float sensitivityVertical = 1.0f;

    public float minVertical = -45.0f;
    public float maxVertical = 45.0f;

    private float verticalRotate = 0;

    void Start()
    {
        Rigidbody body = GetComponent<Rigidbody>();
        if (body != null)
        {
            body.freezeRotation = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (axes == RotationAxes.MouseX)
        {
            transform.Rotate(0, Input.GetAxis("Mouse X") * sensitivityHorizontal, 0);
        }
        else if (axes == RotationAxes.MouseY)
        {
            verticalRotate -= Input.GetAxis("Mouse Y") * sensitivityVertical;
            verticalRotate = Mathf.Clamp(verticalRotate, minVertical, maxVertical);
            float horizontalRotate = transform.localEulerAngles.y;

            transform.localEulerAngles = new Vector3(verticalRotate, horizontalRotate, 0);
        }
        else
        {
            verticalRotate -= Input.GetAxis("Mouse Y") * sensitivityVertical;
            verticalRotate = Mathf.Clamp(verticalRotate, minVertical, maxVertical);
            float delta = Input.GetAxis("Mouse X") * sensitivityHorizontal;
            float horizontalRotate = transform.localEulerAngles.y + delta;

            transform.localEulerAngles = new Vector3(verticalRotate, horizontalRotate, 0);
        }
    }
}

