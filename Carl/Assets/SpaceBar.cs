using UnityEngine;
using UnityEngine.UI;

public class SpaceBar : MonoBehaviour
{
    private CarelController carelController;

    void Start()
    {
        // Find the GameObject with the CarelController script
        carelController = FindObjectOfType<CarelController>();

        // Get the Button component attached to this GameObject
        Button button = GetComponent<Button>();

        // Add a listener to the button click event
        button.onClick.AddListener(OnButtonClick);
    }

    void OnButtonClick()
    {
        // This function will be called when the button is clicked
        Debug.Log("Button Clicked!");

        // Call the CheckSpaceBarInput method from the CarelController script
        carelController.CheckButtonClick();
    }
}
