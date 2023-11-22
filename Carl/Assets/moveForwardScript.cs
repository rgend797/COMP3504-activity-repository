
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;
using UnityEngine.UI;


public class moveForwardScript : MonoBehaviour
{
    public InputField stepsInputField; // Reference to the InputField where users enter the number of steps.
    public GameObject carel; // Reference to Carel's GameObject.
    private Vector3 moveDirection;

    private void Start()
    {
        // Ensure Carel's initial move direction is set based on its rotation.
        UpdateMoveDirection();
    }

    private void Update()
    {
        // You can keep this method empty for now.
        // MoveCareltest will be called from CarelController's Update.
    }

    

    // Update the moveDirection based on Carel's rotation.
    private void UpdateMoveDirection()
    {
        // Get Carel's current rotation.
        Quaternion rotation = carel.transform.rotation;

        // Check if Carel is facing forward or backward (considering some tolerance).
        if (Mathf.Abs(rotation.eulerAngles.y - 0f) < 45f || Mathf.Abs(rotation.eulerAngles.y - 180f) < 45f)
        {
            moveDirection = Vector3.forward;
        }
        // Check if Carel is facing right or left (considering some tolerance).
        else if (Mathf.Abs(rotation.eulerAngles.y - 90f) < 45f || Mathf.Abs(rotation.eulerAngles.y - 270f) < 45f)
        {
            moveDirection = Vector3.right;
        }
        else
        {
            // If none of the above conditions match, you can handle it as needed.
            Debug.LogWarning("Carel is not facing a valid direction.");
        }
    }
    public IEnumerator MoveCarlTest(Rigidbody carelRigidbody)
    {
        /// the amount of steps carl will take
        int steps = 1;

        // carls new postion
        Vector3 newPosition = carel.transform.position + (moveDirection * steps);

        // how long carl takes to walk to destination
        float timeToDestination = 1f;
        // the timer
        float currentTime = 0;
       
        float timeCompleted = currentTime / timeToDestination;
        Vector3 currentpostion = Vector3.Lerp(carelRigidbody.position, newPosition,  timeCompleted);

        while (timeCompleted <= timeToDestination)
        {
            currentTime += Time.deltaTime;
            timeCompleted = currentTime / timeToDestination;

            carelRigidbody.MovePosition( Vector3.Lerp(currentpostion, newPosition,  timeCompleted ));

        yield return null;


        }

    }
}

