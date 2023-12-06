using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Perspective : MonoBehaviour
{
    float rotationX = 0f;
    float rotationY = 0f;
    public float sensitivity = 1f;

    // Start is called before the first frame update

    void Start()
    {



    }

    // Update is called once per frame
    void Update()
    {

        // Camera Rotation based on mouse movement

        if (Input.GetMouseButton(1))
        {

            rotationY += Input.GetAxis("Mouse X") * sensitivity;
            rotationX += Input.GetAxis("Mouse Y") * sensitivity;

            transform.localEulerAngles = new Vector3(-rotationX, rotationY, 0);
        }



        // Camera movement based on WASD or arrow keys

        float xDirection = Input.GetAxis("Horizontal") / 50;
        float zDirection = Input.GetAxis("Vertical") / 50;


        Vector3 right = Camera.main.transform.right;
        Vector3 forward = Camera.main.transform.forward;
        // right.y = 0;
        // forward.y = 0;

        Vector3 zDir = zDirection * forward;
        Vector3 xDir = xDirection * right;

        Vector3 perspective = xDir + zDir;

        Vector3 moveDirection = new Vector3(xDirection, zDirection, 0f);

        transform.Translate(perspective, Space.World);

    }
}
