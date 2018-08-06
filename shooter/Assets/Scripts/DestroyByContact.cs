using UnityEngine;
using System.Collections;

public class DestroyByContact : MonoBehaviour
{
    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Boundary")
        {
            return;
        }
        Destroy(other.gameObject);
        Destroy(gameObject);
    }
}