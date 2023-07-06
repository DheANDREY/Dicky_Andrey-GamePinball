using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class paddleController : MonoBehaviour
{
    public KeyCode input;
    public float springPower;

    private float targetPressed;
    private float targetRelease;

    private HingeJoint hinge;

    private void Start()
    {
        hinge = GetComponent<HingeJoint>();
        targetPressed = hinge.limits.max;
        targetRelease = hinge.limits.min;
    }

    private void Update()
    {
        ReadInput();
    }

    private void ReadInput()
    {
        JointSpring jointSpring = hinge.spring;

        if (Input.GetKey(input))
        {
            jointSpring.spring = targetPressed;
        }
        else
        {
            jointSpring.spring = targetRelease;
        }

        hinge.spring = jointSpring;
    }
}