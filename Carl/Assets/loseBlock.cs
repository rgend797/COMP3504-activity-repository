using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class loseBlock : MonoBehaviour
{
    private void OnTriggerEnter(Collider other) // script used on example level
    {

        // Carel must enable collider.istrigger and rigidbody.iskinematic
        if (other.tag == "Player") // must add tag to Karel
        {
            Debug.Log("You Lose!");
            SceneManager.LoadScene("SampleScene"); //resets scene

        }

    }
}
