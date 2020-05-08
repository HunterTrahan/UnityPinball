using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Holds the code that allows the mushroomBumber to give score to the player
/// </summary>
public class MushroomBumberBehavior : MonoBehaviour
{
    [SerializeField]
    // Refrence to the ValueKeepingBehavior
    private ValueKeepingBehavior scoreKeep;

    /// <summary>
    /// Detect if there is collision
    /// 
    /// <param name="collision"></param>
    private void OnCollisionEnter(Collision collision)
    {
        // If the collision is detected to be the player
        if (collision.gameObject.CompareTag("Player"))
        {
            // increase the score
            scoreKeep.score++;
        }
    }
}
