using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Hold all the code that dictates what the plunger
/// </summary>
public class PlungerBehavior : MonoBehaviour
{
    /// <summary>
    ///  Value that holds the current force
    /// </summary>
    float force;

    /// <summary>
    ///  Minimum force that can be applied to the plunger
    /// </summary>
    float minForce = 0f;

    /// <summary>
    /// Maximum force that can be applied to the plunger
    /// </summary>
    public float maxForce = 100;

    /// <summary>
    /// Create a refrence to the slider
    /// </summary>
    public Slider slider;

    /// <summary>
    /// Create a list of rigidbodies
    /// </summary>
    List<Rigidbody> ally;

    /// <summary>
    /// Create a bool for the ball
    /// </summary>
    bool ball;

    /// <summary>
    /// Start is called before the first frame update
    /// </summary>
    void Start()
    {
        //Set the minimum and maximum slider values
        slider.minValue = 0f;
        slider.maxValue = maxForce;
        ally = new List<Rigidbody>();
    }

    /// <summary>
    /// Update is called once per frame
    /// </summary>
    void Update()
    {
        //If we have the ball
        if(ball)
        {
            //Set the slider to be active
            slider.gameObject.SetActive(true);
        }
        //If we don't have the ball
        else
        {
            //Set the slider to be disabled
            slider.gameObject.SetActive(false);
        }

        //Set the sliders value to be force
        slider.value = force;

        //If the ally count is greater than zero
        if(ally.Count > 0)
        {
            //Set the ball to be true
            ball = true;

            //If the mouse0 is pressed down
            if(Input.GetKey(KeyCode.Mouse0))
            {
                //If the force is less than or equel to the maxForce
                if(force <= maxForce)
                {
                    //force plus equels 50 multiplied by Time.deltaTime
                    force += 500 * Time.deltaTime;
                }
            }

            //If mouse0 is not pressed
            if (Input.GetKeyUp(KeyCode.Mouse0))
            {
                //Foreach rigidbody in the ally list
                foreach(Rigidbody rigi in ally)
                {
                    //Add force to the rigi
                    rigi.AddForce(force * Vector3.forward);
                }
            }
        }
        else
        {
            //Set the ball to be false and the force to zero
            ball = false;
            force = 0f;
        }
    }

    /// <summary>
    /// When something enters the trigger
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerEnter(Collider other)
    {
        //If the tag is Player
        if(other.CompareTag("Player"))
        {
            //Add the Player to the ally list
            ally.Add(other.GetComponent<Rigidbody>());
        }
    }

    /// <summary>
    ///  When something exits the trigger
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerExit(Collider other)
    {
        //If the tag is Player
        if (other.CompareTag("Player"))
        {
            //Remove the Player from the list and set force to 0
            ally.Remove(other.GetComponent<Rigidbody>());
            force = 0f;
        }
    }
}
