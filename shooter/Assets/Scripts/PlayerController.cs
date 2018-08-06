using UnityEngine;
using System.Collections;

[System.Serializable]
public class Boundary
{
    public float xMin, xMax, zMin, zMax;
}


public class PlayerController : MonoBehaviour
{
    public float speed;
    public float tilt;
    public Boundary boundary;

    public GameObject shot;
    public Transform shotSpawn;
    public float fireRate;

    private float nextFire;

    

    

    void Update()
    {
        if (Input.GetButton("Fire1") && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
        }
    }

    void FixedUpdate()
    {
        Rigidbody m_rb = GetComponent<Rigidbody>();
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        m_rb.velocity = movement * speed;

        m_rb.position = new Vector3
        (
            Mathf.Clamp(m_rb.position.x, boundary.xMin, boundary.xMax),
            0.0f,
            Mathf.Clamp(m_rb.position.z, boundary.zMin, boundary.zMax)
        );

        m_rb.rotation = Quaternion.Euler(0.0f, 0.0f, m_rb.velocity.x * -tilt);
    }
}