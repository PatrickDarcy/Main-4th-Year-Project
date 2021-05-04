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
    public bool EnableRightTeleportation { get; set; } = true;
    public bool EnableLeftTeleportation { get; set; } = true;

    // Update is called once per frame
    void Update()
    {
        if(LeftTeleportRay && EnableLeftTeleportation)
        {
            LeftTeleportRay.gameObject.SetActive(EnableLeftTeleportation && CheckIfActivated(LeftTeleportRay));
        }        
        if(RightTeleportRay && EnableRightTeleportation)
        {
            RightTeleportRay.gameObject.SetActive(EnableRightTeleportation && CheckIfActivated(RightTeleportRay));
        }
    }

    public bool CheckIfActivated(XRController controller)
    {
        InputHelpers.IsPressed(controller.inputDevice, teleportrActivationButton, out bool isActivated, activationThreshold);
        return isActivated;
    }
}
