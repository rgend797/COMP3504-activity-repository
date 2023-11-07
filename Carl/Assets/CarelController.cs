using System;
using System.Collections.Generic;
using UnityEngine;

public class CarelController : MonoBehaviour
{
    // Define a delegate for functions with no parameters and void return type.
    public delegate void CarelAction();

    // Create a list to store Carel actions (functions).
    private List<CarelAction> actionList = new List<CarelAction>();

    public GameObject carel; // Reference to Carel's GameObject.

    // Reference to your moveForwardScript and turnLeftCodingBlock scripts.
    public moveForwardScript moveScript;
    public turnLeftCodingBlock turnLeftScript;
    public turnRightBlockScript turnRightScript;

    private void Start()
    {
        // Add the desired functions to the action list.
        actionList.Add(TurnRight);
        actionList.Add(TurnLeft);
        actionList.Add(() => MoveCareltest(2)); // Example of moving Carel forward 2 steps.

        // Execute the actions in the list.
        foreach (var action in actionList)
        {
            action.Invoke();
        }
    }

    // Define the TurnRight function.
    public void TurnRight()
    {
        turnRightScript.TurnRight();
    }

    // Define the TurnLeft function.
    public void TurnLeft()
    {
        turnLeftScript.TurnLeft();
    }

    // Define the MoveCareltest function.
    public void MoveCareltest(int steps)
    {
        moveScript.MoveCareltest(steps);
    }
}