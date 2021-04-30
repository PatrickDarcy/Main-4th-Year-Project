using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private float m_playerHealth;
    public GameObject m_moverRay;
    public XRNode m_inputSource;

    private bool m_aButtonPressed;
    private bool m_canShoot;
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

    private void WeaponChange()
    {
        InputDevice device = InputDevices.GetDeviceAtXRNode(m_inputSource);
        device.TryGetFeatureValue(CommonUsages.primaryTouch, out m_aButtonPressed);
        if (!m_canShoot)
        {
            if (m_aButtonPressed)
            {
                m_canShoot = true;
                gameObject.transform.GetChild(0).transform.GetChild(3).gameObject.SetActive(false);
            }
        }
        else
        {
            if (m_aButtonPressed)
            {
                m_canShoot = false;
                gameObject.transform.GetChild(0).transform.GetChild(3).gameObject.SetActive(true);
            }
        }
    }

    private void Shoot()
    {

    }
}
