using System.Collections;
using System.Collections.Generic;
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

    // Update is called when the user presses a button or submits the input field.
    public void MoveCarel()
    {
        int steps = int.Parse(stepsInputField.text);

        // Calculate the new position based on the number of steps and the move direction.
        Vector3 newPosition = carel.transform.position + (moveDirection * steps);

        // Move Carel to the new position.
        carel.transform.position = newPosition;
    }
    public void MoveCareltest(int steps)
    {
        //int steps = int.Parse(stepsInputField.text);

        // Calculate the new position based on the number of steps and the move direction.
        Vector3 newPosition = carel.transform.position + (moveDirection * steps);

        // Move Carel to the new position.
        carel.transform.position = newPosition;
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
}
