using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private float m_playerHealth;
    // Start is called before the first frame update
    void Start()
    {
        m_playerHealth = 3;
    }

    // Update is called once per frame
    void Update()
    {
        if(m_playerHealth <= 0)
        {
            SceneManager.LoadScene("LoseScreen");
        }
    } 
    public void TakeDamage()
    {
        m_playerHealth--;
    }
}
