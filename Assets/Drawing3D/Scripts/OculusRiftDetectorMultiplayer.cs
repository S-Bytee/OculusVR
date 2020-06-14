using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OculusRiftDetectorMultiplayer : MonoBehaviour
{

    [HideInInspector]
    public ProjectType ProjectType;

    [HideInInspector]
    public bool OculusHeadsetIsPresentAndConnected = false;
    [HideInInspector]
    public bool OculusSensorIsPresentAndConnected = false;
    [HideInInspector]
    public bool OculusHeadsetIsMountedOnUserHead = false;


    GameObject PhysicsPointerLaser;

    GameObject currPhysicsPointerLaserForDesktop;
    GameObject currPhysicsPointerLaserForOculus;
    GameObject CenterEyeAnchorForDesktop;

    GameObject CenterEyeAnchorForOculus;
    [System.Serializable]
    public class PhysicsPointerForDesktop
    {

        public Vector3 PhysicsPointerPosition;
        public Vector3 PhysicsPointerRotation;
        public float MaxLength;
        public float MinLength;
        public float DefaultLength;

        public float WidthStartPoint;
        public float WidthEndPoint;

    }

    [System.Serializable]
    public class PhysicsPointerForOculus
    {
        public Vector3 PhysicsPointerPosition;
        public Vector3 PhysicsPointerRotation;
        public float MaxLength;
        public float MinLength;
        public float DefaultLength;

        public float WidthStartPoint;
        public float WidthEndPoint;

    }

    public PhysicsPointerForDesktop physicsPointerConfigForDesktop;
    public PhysicsPointerForOculus physicsPointerConfigForOculus;

    // Start is called before the first frame update
    void Start()
    {
        CenterEyeAnchorForDesktop = transform.GetChild(1).GetChild(0).GetChild(0).GetChild(1).gameObject;
        CenterEyeAnchorForOculus = transform.GetChild(0).GetChild(0).GetChild(0).GetChild(1).gameObject;
        PhysicsPointerLaser = transform.GetChild(2).gameObject;

        if (ORiftDetector())
        {
            transform.GetChild(0).gameObject.SetActive(true);
            transform.GetChild(1).gameObject.SetActive(false);
            InstaciatePhysicsPointerForOculus();

            ProjectType = ProjectType.OCULUS;
        }
        else
        {
            transform.GetChild(1).gameObject.SetActive(true);
            transform.GetChild(0).gameObject.SetActive(false);
            InstaciatePhysicsPointerForDesktop();

            ProjectType = ProjectType.DESKTOP;
        }


    }
    bool ORiftDetector()
    {
        //nhotou fehom f des variables besh Ken sthaakinaa naaytoulhom men script ekher 

        OculusHeadsetIsPresentAndConnected = OVRManager.isHmdPresent;
        OculusHeadsetIsMountedOnUserHead = OVRPlugin.userPresent;
        return OculusHeadsetIsPresentAndConnected;

    }


    void InstaciatePhysicsPointerForDesktop()
    {

        if (currPhysicsPointerLaserForDesktop == null)
        {

            currPhysicsPointerLaserForDesktop = PhysicsPointerLaser;
            currPhysicsPointerLaserForDesktop.transform.parent = CenterEyeAnchorForDesktop.transform;
            currPhysicsPointerLaserForDesktop.transform.localPosition = physicsPointerConfigForDesktop.PhysicsPointerPosition;
            currPhysicsPointerLaserForDesktop.transform.localRotation = Quaternion.Euler(physicsPointerConfigForDesktop.PhysicsPointerRotation);
            currPhysicsPointerLaserForDesktop.GetComponent<PhysicsPointerMultiplayer>().maxLength = physicsPointerConfigForDesktop.MaxLength;
            currPhysicsPointerLaserForDesktop.GetComponent<PhysicsPointerMultiplayer>().defaultLength = physicsPointerConfigForDesktop.DefaultLength;
            currPhysicsPointerLaserForDesktop.GetComponent<PhysicsPointerMultiplayer>().minLength = physicsPointerConfigForDesktop.MinLength;
            currPhysicsPointerLaserForDesktop.GetComponent<LineRenderer>().widthCurve = new AnimationCurve(new Keyframe(0, physicsPointerConfigForDesktop.WidthStartPoint), new Keyframe(1, physicsPointerConfigForDesktop.WidthEndPoint));


        }

    }


    void InstaciatePhysicsPointerForOculus()
    {
        if (currPhysicsPointerLaserForOculus == null)
        {

            currPhysicsPointerLaserForOculus = PhysicsPointerLaser;
            currPhysicsPointerLaserForOculus.transform.parent = CenterEyeAnchorForOculus.transform;
            currPhysicsPointerLaserForOculus.transform.localPosition = physicsPointerConfigForOculus.PhysicsPointerPosition;
            currPhysicsPointerLaserForOculus.transform.localRotation = Quaternion.Euler(physicsPointerConfigForOculus.PhysicsPointerRotation);
            currPhysicsPointerLaserForOculus.GetComponent<PhysicsPointerMultiplayer>().maxLength = physicsPointerConfigForOculus.MaxLength;
            currPhysicsPointerLaserForOculus.GetComponent<PhysicsPointerMultiplayer>().defaultLength = physicsPointerConfigForOculus.DefaultLength;
            currPhysicsPointerLaserForOculus.GetComponent<PhysicsPointerMultiplayer>().minLength = physicsPointerConfigForOculus.MinLength;
            currPhysicsPointerLaserForOculus.GetComponent<LineRenderer>().widthCurve = new AnimationCurve(new Keyframe(0, physicsPointerConfigForOculus.WidthStartPoint), new Keyframe(1, physicsPointerConfigForOculus.WidthEndPoint));

        }

    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
