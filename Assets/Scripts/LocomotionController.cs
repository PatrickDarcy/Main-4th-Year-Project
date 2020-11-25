using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class LocomotionController : MonoBehaviour
{
    public XRController LeftTeleportRay;
    public XRController RightTeleportRay;
    public InputHelpers.Button teleportrActivationButton;
    public float activationThreshold = 0.1f;

    // Update is called once per frame
    void Update()
    {
        if(LeftTeleportRay)
        {
            LeftTeleportRay.gameObject.SetActive(CheckIfActivated(LeftTeleportRay));
        }        
        if(RightTeleportRay)
        {
            RightTeleportRay.gameObject.SetActive(CheckIfActivated(RightTeleportRay));
        }
    }

    public bool CheckIfActivated(XRController controller)
    {
        InputHelpers.IsPressed(controller.inputDevice, teleportrActivationButton, out bool isActivated, activationThreshold);
        return isActivated;
    }
}
