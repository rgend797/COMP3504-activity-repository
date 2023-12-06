using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class turnLeftCodingBlock : MonoBehaviour
{
    public GameObject carrel; // Reference to Carrel's GameObject.
    public float turnAngle = 90f;
    public float turnDuration = 5f; // Duration over which the turn should complete


    // Adjust the rotation angle for the turn (e.g., 90 degrees for a left turn).

    // Update is called when the user presses a button or interacts with the block.
    public IEnumerator TurnLeft(Rigidbody carelRigidbody)
    {
        Quaternion startRotation = carelRigidbody.transform.rotation;
        Quaternion endRotation = startRotation * Quaternion.Euler(0, -turnAngle, 0);
        float currentTime = 0f;

        while (currentTime < turnDuration)
        {
            currentTime += Time.deltaTime;
            carelRigidbody.MoveRotation(Quaternion.Lerp(startRotation, endRotation, currentTime / turnDuration));
            yield return null;
        }

        carelRigidbody.MoveRotation(endRotation); // Ensure final rotation is set accurately
    }


}