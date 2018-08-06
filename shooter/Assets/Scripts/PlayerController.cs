using UnityEngine;
using System.Collections;

[System.Serializable]
public class Boundary
{
    public float xMin, xMax, zMin, zMax;
}


public class PlayerController : MonoBehaviour
{
    /// <summary>機体のスピード</summary>
    public float speed;
    /// <summary>機体が動く時の角度</summary>
    public float tilt;
    /// <summary>境界</summary>
    public Boundary boundary;
    /// <summary>weapon</summary>
    public GameObject shot;
    /// <summary>weapon's spawn point</summary>
    public Transform shotSpawn;
    /// <summary>weapon's fireRate</summary>
    public float fireRate;
    private float nextFire;
    /// <summary>bullets sound</summary>
    AudioSource bs;
    

    

    void Update()
    {
        if (Input.GetKey(KeyCode.Space) && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
            bs = GetComponent<AudioSource>();
            bs.Play();
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