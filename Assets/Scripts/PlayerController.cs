using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float speed;
    private Rigidbody m_rb;

	
	void Start () {
        m_rb = GetComponent<Rigidbody>();
	}
	
	
	void Update () {

        Move();
	}

    private void Move()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        m_rb.velocity = new Vector3(x * speed, m_rb.velocity.y, z * speed);
        
    }
}
