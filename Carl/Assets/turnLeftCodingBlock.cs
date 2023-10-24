using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class turnLeftCodingBlock : MonoBehaviour
{
    public GameObject carrel; // Reference to Carrel's GameObject.

    // Adjust the rotation angle for the turn (e.g., 90 degrees for a left turn).
    public float turnAngle = 90f;

    // Update is called when the user presses a button or interacts with the block.
    public void TurnLeft()
    {
        // Rotate Carrel's GameObject by the negative of the specified turnAngle.
        carrel.transform.Rotate(Vector3.up, -turnAngle);
    }
}
