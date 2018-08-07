using UnityEngine;
using System.Collections;

public class Mover : MonoBehaviour
{
    public float speed;
    Rigidbody m_rb;

    void Start()
    {
        m_rb = GetComponent<Rigidbody>();
        m_rb.velocity = transform.forward * speed;
    }
}