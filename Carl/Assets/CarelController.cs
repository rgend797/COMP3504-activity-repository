using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using UnityEditor;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;

public class CarelController : MonoBehaviour
{

    // Define a delegate for functions with no parameters and void return type.
    public delegate void CarelAction(Rigidbody carelRigidbody);
    public Rigidbody carelRigidbody;

    string[] commands;// = new string[] { "FORWARD", "RIGHT", "LEFT", "LEFT", "RIGHT", "FORWARD", "RIGHT", "LEFT" };

    // Create a list to store Carel actions (functions).
    //private List<CarelAction> actionList = new List<CarelAction>();

    public GameObject carel; // Reference to Carel's GameObject.
    public GameObject alphabet;
    public ProgramHandler handler;
    private bool isWaiting = false;


    // Reference to your moveForwardScript and turnLeftCodingBlock scripts.

    private void Start()
    {
        handler = alphabet.GetComponent<ProgramHandler>();
        // Add the desired functions to the action list.
        // actionList.Add(TurnRight);
        //actionList.Add(TurnLeft);
        //actionList.Add(() => MoveCareltest()); // Example of moving Carel forward 2 steps.

        // Execute the actions in the list.
        //foreach (var action in actionList)
        //{
        //action.Invoke();

        //ex();
        carelRigidbody = GetComponent<Rigidbody>();
        UpdateMoveDirection();

    }
    void Update()
    {
        if (Input.GetKeyDown("space") && isWaiting == false)
        {
            Debug.Log(gameObject.transform.eulerAngles.y);

            StartCoroutine(ResetCarelPosition());

        }
    }

    IEnumerator ResetCarelPosition()
    {

        float  postion = 0.5f;
        // Move Carel to home position.
        Vector3 homePosition = new Vector3(postion, 0, -postion);
        Quaternion homeRotation = Quaternion.Euler(0, 0, 0);
        carelRigidbody.MovePosition(homePosition);
        carelRigidbody.rotation = homeRotation;

        // Wait for 5 seconds.
        yield return new WaitForSeconds(0.5f);

        // After waiting, execute the commands.
        StartCoroutine(ExecuteCommandsCoroutine());
    }


    public  IEnumerator  ExecuteCommandsCoroutine()
    {
        String[] c = handler.getCommand();

        isWaiting = true;
        foreach (var command in c)
        {
            switch (command)
            {
                case "Forward":
                    yield return StartCoroutine(MoveCarlTest());
                    break;
                case "Right":
                    yield return StartCoroutine(TurnRight());
                    break;
                case "Left":
                    yield return StartCoroutine(TurnLeft());
                    break;
            }
            yield return new WaitForSeconds(0.5f); // Wait for one second

        }
        isWaiting = false;


    }


    //public string[] git() => ;//alphabet.GetComponent<ProgramHandler>.getCommand();
    // Define the TurnRight function.


    private Vector3 moveDirection;
    private void UpdateMoveDirection()
    {
        // Get Carel's current rotation.
        Quaternion rotation = carel.transform.rotation;

        // Check if Carel is facing forward or backward (considering some tolerance).
        if (Mathf.Abs(rotation.eulerAngles.y - 0f) < 45f || Mathf.Abs(rotation.eulerAngles.y - 180f) < 45f)
        {
            moveDirection = Vector3.forward;
            Debug.Log(moveDirection);
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
    /* public IEnumerator MoveCarlTest()
    {
        /// the amount of steps carl will take
        int steps = 1;
        Debug.Log(moveDirection);

        UpdateMoveDirection();

        // carls new postion
        Vector3 newPosition = carel.transform.position + ( transform.forward * steps);

        // how long carl takes to walk to destination
        float timeToDestination = 1f;
        // the timer
        float currentTime = 0;

        float timeCompleted = currentTime / timeToDestination;
        Vector3 currentpostion = Vector3.Lerp(carelRigidbody.position, newPosition, timeCompleted);

        while (timeCompleted <= timeToDestination)
        {
            currentTime += Time.deltaTime;
            timeCompleted = currentTime / timeToDestination;

            carelRigidbody.MovePosition(Vector3.Lerp(currentpostion, newPosition, timeCompleted));

            yield return null;


        }

    }
    */

    public IEnumerator MoveCarlTest()
    {
        // The amount of steps Carl will take
        int steps = 1;
        Debug.Log(moveDirection);


        // Ensure that 'moveDirection' is updated based on Carl's current orientation.
        UpdateMoveDirection();

        // Carl's new position
        // Replace 'transform.forward' with 'moveDirection' to use the updated movement direction
        Vector3 newPosition = carel.transform.position + (-transform.right  * steps);

        // How long Carl takes to walk to destination
        float timeToDestination = 1f;

        // Start time of the movement
        float startTime = Time.time;

        // Initial position of Carl
        Vector3 initialPosition = carelRigidbody.position;

        while (Time.time < startTime + timeToDestination)
        {
            // Calculate the completion ratio
            float ratio = ((Time.time - startTime) / timeToDestination)*3;

            // Update Carl's position
            carelRigidbody.MovePosition(Vector3.Lerp(initialPosition, newPosition, ratio));

            yield return null;
        }

        // Ensure Carl is exactly at the new position after the movement
        carelRigidbody.MovePosition(newPosition);
    }

    public float turnAngle = 90f;
    public float turnDuration = 5f;

    public IEnumerator TurnLeft()
    {
        Quaternion startRotation = carelRigidbody.transform.rotation;
        Quaternion endRotation = startRotation * Quaternion.Euler(0, -turnAngle, 0);
        float currentTime = 0f;

        while (currentTime < turnDuration)
        {
            currentTime += Time.deltaTime*3;
            carelRigidbody.MoveRotation(Quaternion.Lerp(startRotation, endRotation, currentTime / turnDuration));
            yield return null;
        }

        carelRigidbody.MoveRotation(endRotation); // Ensure final rotation is set accurately
    }

    public IEnumerator TurnRight()
    {
        Quaternion startRotation = carelRigidbody.transform.rotation;
        Quaternion endRotation = startRotation * Quaternion.Euler(0, turnAngle, 0);
        float currentTime = 0f;

        while (currentTime < turnDuration)
        {
            currentTime += Time.deltaTime*3;
            carelRigidbody.MoveRotation(Quaternion.Lerp(startRotation, endRotation, currentTime / turnDuration));
            yield return null;
        }

        carelRigidbody.MoveRotation(endRotation); // Ensure final rotation is set accurately
    }


}