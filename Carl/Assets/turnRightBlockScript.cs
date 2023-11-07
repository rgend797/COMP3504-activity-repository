using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class turnRightBlockScript : MonoBehaviour
{
    public GameObject carel; // Reference to Carel's GameObject.

    // Adjust the rotation angle for the turn (e.g., 90 degrees for a right turn).
    public float turnAngle = 90f;

    // Update is called when the user presses a button or interacts with the block.
    public void TurnRight()
    {
        // Rotate Carel's GameObject by the specified turnAngle.
        carel.transform.Rotate(Vector3.up, turnAngle);
    }
}
