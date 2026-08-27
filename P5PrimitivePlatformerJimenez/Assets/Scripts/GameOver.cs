using UnityEngine;
using TMPro;

public class GameOver : MonoBehaviour
{
    public GameObject textObjectToEnable; // Assign the GameObject containing your text here in the inspector

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (textObjectToEnable != null)
        {
            textObjectToEnable.SetActive(false); // Hide the text object at the start
        }
    }


    // Update is called once per frame
    void Update()
    {

    }

    // This function is called when another object collides with this object
    private void OnCollisionEnter(Collision collision)
    {
        // Check if the object we collided with has the tag "Player"
        if (collision.gameObject.CompareTag("Player"))
        {
            if (textObjectToEnable != null)
            {
                textObjectToEnable.SetActive(true); // Enable and show the text object on screen
            }
        }
    }
}
