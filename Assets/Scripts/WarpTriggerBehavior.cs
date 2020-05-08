using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Holds the code that allows the player to warp back inside the plunger
/// decrement the players lives when the trigger activated
/// end the game when the players lives is equel to 0
/// </summary>
public class WarpTriggerBehavior : MonoBehaviour
{
    [SerializeField]
    // Postion of the warp point
    private Vector3 warpPos;

    [SerializeField]
    // Get refrence to the valueKeepingBehavior
    private ValueKeepingBehavior liveValue;

    private void OnTriggerEnter(Collider other)
    {
        // If the tag is Player
        if (other.CompareTag("Player"))
        {
            // Create reference to get the players rigidbody
            Rigidbody playerRigi;
            playerRigi = other.GetComponent<Rigidbody>();

            // Reset the players momentum
            playerRigi.velocity = Vector3.zero;
            playerRigi.angularVelocity = Vector3.zero;

            // Move the player to the warp position
            playerRigi.position = warpPos;

            // Decrease the players lice count
            liveValue.lives--;
        }

        // If the player runs out of lives
        if (liveValue.lives == 0)
        {
            // Load the Game Over scene
            SceneManager.LoadScene(3);
        }
    }
}
