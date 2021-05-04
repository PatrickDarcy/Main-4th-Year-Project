using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.SceneManagement;

public class LevelEditorManager : MonoBehaviour
{
    public GameObject m_player;
    public GameObject m_moverRay;
    public XRNode m_inputSource;

    private Vector2 m_inputAxis;
    private bool m_isObjGrabbed;
    private GameObject m_worldObject;
    private bool m_objectSelected;
    public void SpawnWorldObject(GameObject t_worldObject)
    {
        m_objectSelected = true;
        m_worldObject = t_worldObject;
    }
    public void Update()
    {
        InputDevice device = InputDevices.GetDeviceAtXRNode(m_inputSource);
        device.TryGetFeatureValue(CommonUsages.primary2DAxis, out m_inputAxis);
        if(m_objectSelected)
        {
            SelectedObject();
        }
    }

    private void FixedUpdate()
    {
        RayLengthAdjuster(m_inputAxis.y);
    }

    public void RayLengthAdjuster(float t_adjustment)
    {
        if (m_moverRay.GetComponent<XRRayInteractor>().maxRaycastDistance > 0)
            m_moverRay.GetComponent<XRRayInteractor>().maxRaycastDistance += t_adjustment;
        else
            m_moverRay.GetComponent<XRRayInteractor>().maxRaycastDistance = 0.1f;
    }

    private void SelectedObject()
    {
        InputDevice device = InputDevices.GetDeviceAtXRNode(m_inputSource);
        device.TryGetFeatureValue(CommonUsages.triggerButton, out m_isObjGrabbed);

        if (!m_isObjGrabbed)
        {
            Instantiate<GameObject>(m_worldObject, m_moverRay.GetComponent<XRRayInteractor>().transform.position, Quaternion.identity);
            m_objectSelected = false;
        }

    }

    public void SaveNewLevel()
    {
        ShapeData[] shapes = FindObjectsOfType<ShapeData>();
        LevelSave.SaveLevel(shapes);
        SceneManager.LoadScene("MainMenu");
    }
}
