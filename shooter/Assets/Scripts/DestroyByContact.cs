using UnityEngine;
using System.Collections;

public class DestroyByContact : MonoBehaviour
{
    [SerializeField] GameObject explosion;
    [SerializeField] GameObject playerExplosion;
    [SerializeField] int m_scoreValue;
    /// <summary>Class GameController</summary>
    GameController m_gc;
    GameObject m_gco;


    void OnTriggerEnter(Collider other)
    {

        if (other.tag == "Boundary")
        {
            return;
        }
        Instantiate(explosion, transform.position, transform.rotation);
        if(other.tag == "Player")
        {
            Instantiate(playerExplosion, other.transform.position, other.transform.rotation);
        }

        m_gco = GameObject.Find("GameController");
        m_gc = m_gco.GetComponent<GameController>();
        Destroy(other.gameObject);
        Destroy(gameObject);
        m_gc.AddScore(m_scoreValue);
        

    }
}