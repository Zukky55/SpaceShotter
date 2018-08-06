using UnityEngine;
using System.Collections;

public class DestroyByTime : MonoBehaviour
{
    /// <summary></summary>
    ParticleSystem ps;
    
    IEnumerator Start()
    {
        ps = GetComponent<ParticleSystem>();
        yield return new WaitWhile(() => ps.IsAlive(true));
        Destroy(gameObject);
    }
}