using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Holds the code that allows the flippers to function
/// </summary>
public class FlipperBehavior : MonoBehaviour
{
    /// <summary>
    /// Resting position of the flipper
    /// </summary>
    public float stillPoaition = 0.0f;

    /// <summary>
    /// Poaition to be moved to when pressed
    /// </summary>
    public float pressPosition = 45.0f;

    /// <summary>
    /// Force applied to the flipper when presssed
    /// </summary>
    public float force = 1000.0f;

    /// <summary>
    /// Stores the name of the input entered
    /// </summary>
    public string inputName;

    /// <summary>
    /// Refrence to the HingeJoint
    /// </summary>
    HingeJoint hinge;

    /// <summary>
    ///  Start is called before the first frame update
    /// </summary>
    void Start()
    {
        hinge = GetComponent<HingeJoint>();
        hinge.useSpring = true;
    }

    /// <summary>
    /// Update is called once per frame
    /// </summary>
    void Update()
    {
        JointSpring spring = new JointSpring();
        spring.spring = force * Time.deltaTime;

        if(Input.GetAxis(inputName) == 1)
        {
            spring.targetPosition = pressPosition;
        }
        else
        {
            spring.targetPosition = stillPoaition;
        }
        hinge.spring = spring;
        hinge.useLimits = true;
    }
}
