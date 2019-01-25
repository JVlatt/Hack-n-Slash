using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonCamera : MonoBehaviour {

    public Transform m_lookAt;
    private Transform m_camTransform;

    private Camera m_cam;

    public float m_distance = 10.0f;
    private float m_currentX = 0.0f;
    private float m_currentY = 0.0f;
    private float m_sensitivityX = 4.0f;
    private float m_sensitivityY = 1.0f;

    private const float Y_ANGLE_MIN = 0.0f;
    private const float Y_ANGLE_MAX = 50.0f;

    private const float DISTANCE_MIN = 5.0f;
    private const float DISTANCE_MAX = 15.0f;


    private void Start()
    {
        m_camTransform = transform;
        m_cam = Camera.main;

        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update()
    {
        m_distance += Input.GetAxis("Mouse ScrollWheel");
        m_currentX += Input.GetAxis("Mouse X") * m_sensitivityX;
        m_currentY -= Input.GetAxis("Mouse Y") * m_sensitivityY;

        m_currentY = Mathf.Clamp(m_currentY, Y_ANGLE_MIN, Y_ANGLE_MAX);
        m_distance = Mathf.Clamp(m_distance, DISTANCE_MIN, DISTANCE_MAX);
    }

    private void LateUpdate()
    {
        Vector3 dir = new Vector3(0, 0, -m_distance);
        Quaternion rotation = Quaternion.Euler(m_currentY, m_currentX, 0);
        m_camTransform.position = m_lookAt.position + rotation * dir;
        m_camTransform.LookAt(m_lookAt.position);
    }
}
