using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

public class LevelEditorManager : MonoBehaviour
{
    public GameObject m_player;
    public GameObject m_moverRay;
    public XRNode m_inputSource;

    private Vector2 m_inputAxis;
    private bool m_isObjGrabbed;
    public void SpawnWorldObject(GameObject t_worldObject)
    {
        InputDevice device = InputDevices.GetDeviceAtXRNode(m_inputSource);
        device.TryGetFeatureValue(CommonUsages.gripButton, out m_isObjGrabbed);

        if (m_isObjGrabbed)
        {
            Instantiate<GameObject>(t_worldObject, m_moverRay.GetComponent<XRRayInteractor>()., Quaternion.identity);
        }
    }
    public void Update()
    {
        InputDevice device = InputDevices.GetDeviceAtXRNode(m_inputSource);
        device.TryGetFeatureValue(CommonUsages.primary2DAxis, out m_inputAxis);
    }

    private void FixedUpdate()
    {
        RayLengthAdjuster(m_inputAxis.y);
    }

    public void RayLengthAdjuster(float t_adjustment)
    {
        if (m_moverRay.GetComponent<XRRayInteractor>().maxRaycastDistance > 0)
            m_moverRay.GetComponent<XRRayInteractor>().maxRaycastDistance += t_adjustment;// * Time.deltaTime;
        else
            m_moverRay.GetComponent<XRRayInteractor>().maxRaycastDistance = 0.1f;
    }
}
