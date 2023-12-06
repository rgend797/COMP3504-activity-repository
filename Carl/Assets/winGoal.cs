using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class winGoal : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {

        // Carel must enable collider.istrigger and rigidbody.iskinematic
        if (other.tag == "Player") // must add tag to Carel
        {
            Debug.Log("You Win!");
            SceneManager.LoadScene("SampleScene"); //resets scene

        }

    }
}
