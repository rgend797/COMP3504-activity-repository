using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;


public class CarelController : MonoBehaviour
{

    // Define a delegate for functions with no parameters and void return type.
    public delegate void CarelAction(Rigidbody carelRigidbody);
    public Rigidbody carelRigidbody;

    string[] commands = new string[] { "FORWARD", "RIGHT", "LEFT", "LEFT", "RIGHT", "FORWARD", "RIGHT", "LEFT" };

    // Create a list to store Carel actions (functions).
    //private List<CarelAction> actionList = new List<CarelAction>();

    public GameObject carel; // Reference to Carel's GameObject.

    // Reference to your moveForwardScript and turnLeftCodingBlock scripts.
    public moveForwardScript moveScript;
    public turnLeftCodingBlock turnLeftScript;
    public turnRightBlockScript turnRightScript;


    private void Start()
    {
        // Add the desired functions to the action list.
        // actionList.Add(TurnRight);
        //actionList.Add(TurnLeft);
        //actionList.Add(() => MoveCareltest()); // Example of moving Carel forward 2 steps.

        // Execute the actions in the list.
        //foreach (var action in actionList)
        //{
        //action.Invoke();
        
        ex();
    }

    public void ex()
    {
        foreach (var action in commands)
        {
            if (action == "FORWARD")
            {
                MoveCareltest();
            }
            else if (action == "RIGHT")
            {
                TurnRight();
            }
            else if (action == "LEFT")
            {
                TurnLeft();
            }
            else
            {
                Debug.LogError(action + "is an invaild command");
            }

        }
    }
    // Define the TurnRight function.
    public void TurnRight()
    {
        turnRightBlockScript scriptForRight = turnRightScript.GetComponent<turnRightBlockScript>();

        StartCoroutine(scriptForRight.TurnRight(carelRigidbody));
    }

    // Define the TurnLeft function.
    public void TurnLeft()
    {
        turnLeftCodingBlock scriptForLeft = turnLeftScript.GetComponent<turnLeftCodingBlock>();

        StartCoroutine(scriptForLeft.TurnLeft(carelRigidbody));
    }

    // Define the MoveCareltest function.
    public void MoveCareltest()
    {
        moveForwardScript scriptForMove = moveScript.GetComponent<moveForwardScript>();

        StartCoroutine(scriptForMove.MoveCarlTest(carelRigidbody));
    }
}