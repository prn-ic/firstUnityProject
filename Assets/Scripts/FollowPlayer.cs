using System.Collections;
using System.Collections.Generic;
using UnityEngine;

abstract class CameraMode
{
    public abstract void ChangeCamera(ref Vector3 offset);
}

class BehindCamera : CameraMode
{
    public override void ChangeCamera(ref Vector3 offset)
    {
        offset = new Vector3(0, 5, -9);
    }
}

class OnBonnetCamera: CameraMode
{
    public override void ChangeCamera(ref Vector3 offset)
    {
        offset = new Vector3(0, 2, 1);

    }
}

class SecondPersonCamera : CameraMode
{
    public override void ChangeCamera(ref Vector3 offset)
    {
        offset = new Vector3(0, 14, -25);

    }
}


public class FollowPlayer : MonoBehaviour
{
    private Vector3 offset = new Vector3(0, 5, -9);
    private Vector3 offset2 = new Vector3(0, 5, -9);
    private int cameraModePosition = 0;
    private int cameraModePosition2 = 0;
    List<CameraMode> cameraModes = new List<CameraMode>()
    {
        new BehindCamera(),
        new OnBonnetCamera(),
        new SecondPersonCamera()
    };
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        GameObject.Find("Main Camera 2").transform.position = GameObject.Find("Vehicle").transform.position + offset;
        GameObject.Find("Main Camera").transform.position = GameObject.Find("SecondVehicle").transform.position + offset2;
        
        if (Input.GetKeyDown(KeyCode.V))
        {
            ChangeCamera(ref offset, ref cameraModePosition);
        }
        if (Input.GetKeyDown(KeyCode.B))
        {
            ChangeCamera(ref offset2, ref cameraModePosition2);
        }
    }

    void ChangeCamera(ref Vector3 cameraOffset, ref int camModePos)
    {
        if (camModePos < cameraModes.Count-1)
        {
            camModePos += 1;
        }
        else
        {
            camModePos = 0;
        }

        cameraModes[camModePos].ChangeCamera(ref cameraOffset);
    }
}
