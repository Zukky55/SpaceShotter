using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public GameObject hazard;
    public Vector3 spawnValues;
    public int hazardCount;
    public float spawnWait;
    public float startWait;
    public float waveWait;

    [SerializeField] Text m_scoreText;
    private int score;

    [SerializeField] Test m_test;

    void Start()
    {
        score = 0;
        UpdateScore();
        StartCoroutine("SpawnWaves");


        if (m_test == null)
        {
            Debug.Log("not complete");
        }
        m_test.Call();
        
    }

    IEnumerator SpawnWaves()
    {
        while(true)
        {
            yield return new WaitForSeconds(startWait);
            for (int i = 0; i < hazardCount; i++)
            {
                Vector3 spawnPosition = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
                Quaternion spawnRotation = Quaternion.identity;
                Instantiate(hazard, spawnPosition, spawnRotation);
                yield return new WaitForSeconds(spawnWait);
            }
            yield return new WaitForSeconds(waveWait);
        }
    }
    /// <summary>scoreに引数分追加しtextにscoreを更新する</summary>
    /// <param name="newScoreValue">This is add to score</param>
    public void AddScore (int newScoreValue)
    {
        score += newScoreValue;
        UpdateScore();
    }
    /// <summary>Scoreをtextに更新する</summary>
    public void UpdateScore()
    {
        m_scoreText.text = "Score: " + score;
    }

}