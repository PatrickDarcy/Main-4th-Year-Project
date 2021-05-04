using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemySpawnerController : MonoBehaviour
{
    public GameObject m_enemyAi;
    private float m_timer;
    public float m_delay;

    private void Update()
    {
        if (SceneManager.GetActiveScene().name != "LevelEditor")
        {
            m_timer += Time.deltaTime;

            if (m_timer >= m_delay)
            {
                Instantiate(m_enemyAi, transform.position, Quaternion.identity);
                m_timer = 0;
            }
        }
    }
}
