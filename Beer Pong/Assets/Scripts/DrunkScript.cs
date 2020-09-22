﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrunkScript : MonoBehaviour
{
    // Start is called before the first frame update
    public static int s_NumMissedBalls = 100;

    private const float MAX_POSITIVE_Z_ROTATION = 15.0f;
    private const float MAX_NEGATIVE_Z_ROTATION = 345.0f;
    private const float ANGULAR_ACCELERATION_INCREMENT_PER_MISSED_SHOT = 0.1f;
    private const float ANGULAR_ACCELERATION_SCALAR = 1.0f;

    private float m_LastNonZeroAngularVelocity = 0.0f;
    private float m_AngularVelocity = 0.0f;
    private float m_LastAngularAcceleration = 0.0f;
    private bool m_IsSwayingRight = false;
    private bool m_SetLastAngularAcceleration = false;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ApplyAcceleration();
        ApplyConstraints();
    }

    private void ApplyAcceleration()
    {
        Vector3 eulerAngles = gameObject.transform.eulerAngles;

        float zValue = eulerAngles.z;

        if (zValue >= MAX_NEGATIVE_Z_ROTATION)
        {
            zValue = MAX_NEGATIVE_Z_ROTATION - zValue;
        }

        float angularAcceleration = (Mathf.Abs(zValue) / MAX_POSITIVE_Z_ROTATION) * ANGULAR_ACCELERATION_SCALAR;
        angularAcceleration += ANGULAR_ACCELERATION_INCREMENT_PER_MISSED_SHOT * s_NumMissedBalls;

        if (eulerAngles.z >= MAX_NEGATIVE_Z_ROTATION || eulerAngles.z <= 2.0f && m_IsSwayingRight)
        {
            angularAcceleration *= -1.0f;
        }

        m_AngularVelocity += angularAcceleration * Time.deltaTime;

        if (Mathf.Abs(m_AngularVelocity) <= 0.05f)
        {
            eulerAngles.z += m_LastNonZeroAngularVelocity * Time.deltaTime;
        } else
        {
            eulerAngles.z += m_AngularVelocity * Time.deltaTime;
            m_LastNonZeroAngularVelocity = m_AngularVelocity;
        }

        if (Mathf.Abs(eulerAngles.z) <= 0.1f)
        {
            m_AngularVelocity /= 1.2f;
        }

        gameObject.transform.eulerAngles = eulerAngles;

    }

    private void ApplyConstraints()
    {
        Vector3 currentEulerAngle = gameObject.transform.eulerAngles;

        if(currentEulerAngle.z <= MAX_NEGATIVE_Z_ROTATION && currentEulerAngle.z > MAX_POSITIVE_Z_ROTATION + 10.0f)
        {
            currentEulerAngle.z = MAX_NEGATIVE_Z_ROTATION;
            m_AngularVelocity *= -1.0f;
            m_IsSwayingRight = false;
        }  else if (currentEulerAngle.z >= MAX_POSITIVE_Z_ROTATION && currentEulerAngle.z < MAX_POSITIVE_Z_ROTATION + 10.0f)
        {
            currentEulerAngle.z = MAX_POSITIVE_Z_ROTATION;
            m_AngularVelocity *= -1.0f;
            m_IsSwayingRight = true;
        }

        gameObject.transform.eulerAngles = currentEulerAngle;
    }
}