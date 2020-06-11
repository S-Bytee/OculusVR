using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
 
SCRIPT HEDHA YAAMEL HAJTIN 

            LOULA : 

IL DETECTE KEN FAMA OCULUS CONNECTé FEL PC, L PRINCIPE SIMPLE KEN FAMA OCULUS BEL MANETTE MTEEHA DONC ON ACTIVE "PlayerForOculusRiftPlatform" 
KEN MAFAMESH DONC ON ACTIVE "PlayerForDesktopPlatform" 
            

            THENYA :

YAAAMEL INSTANCE LEL PHYSICS POINTER (DESKTOP O OCULUS ZOUZ MAA BAADHHOM) BEL CONFIG MTEEEHOM 

*/


public class OculusRiftDetector : MonoBehaviour
{

    [HideInInspector]
    public bool OculusHeadsetIsPresentAndConnected = false;
    [HideInInspector]
    public bool OculusSensorIsPresentAndConnected = false;
    [HideInInspector]
    public bool OculusHeadsetIsMountedOnUserHead = false;


    public GameObject PhysicsPointerLaserForDesktop;
    public GameObject PhysicsPointerLaserForOculus;    
    
    GameObject currPhysicsPointerLaserForDesktop;
    GameObject currPhysicsPointerLaserForOculus;


    //FEL SCENE HEDHY CAMERA MTEENA LI HEYA PARENT LEL PHYSICS POINTER
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

    }

    [System.Serializable]
    public class PhysicsPointerForOculus
    {
        public Vector3 PhysicsPointerPosition;
        public Vector3 PhysicsPointerRotation;
        public float MaxLength;
        public float MinLength;
        public float DefaultLength;
    }


    public PhysicsPointerForDesktop physicsPointerConfigForDesktop;
    public PhysicsPointerForOculus physicsPointerConfigForOculus;



    private void Start()
    {

        CenterEyeAnchorForDesktop = transform.GetChild(1).GetChild(0).GetChild(0).GetChild(1).gameObject;
        CenterEyeAnchorForOculus = transform.GetChild(0).GetChild(0).GetChild(0).GetChild(1).gameObject;
        
       
    }

    void Update()
    {

        if(ORiftDetector())
        {
            transform.GetChild(0).gameObject.SetActive(true);
            transform.GetChild(1).gameObject.SetActive(false);
           InstaciatePhysicsPointerForOculus();
        }
        else
        {
            transform.GetChild(1).gameObject.SetActive(true);
            transform.GetChild(0).gameObject.SetActive(false);
            InstaciatePhysicsPointerForDesktop();
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

        if(currPhysicsPointerLaserForDesktop == null)
        {
            currPhysicsPointerLaserForDesktop = Instantiate(PhysicsPointerLaserForDesktop);
            currPhysicsPointerLaserForDesktop.transform.parent = CenterEyeAnchorForDesktop.transform;
            currPhysicsPointerLaserForDesktop.transform.localPosition = physicsPointerConfigForDesktop.PhysicsPointerPosition;
            currPhysicsPointerLaserForDesktop.transform.localRotation = Quaternion.Euler(physicsPointerConfigForDesktop.PhysicsPointerRotation);
            currPhysicsPointerLaserForDesktop.GetComponent<PhysicsPointer>().maxLength = physicsPointerConfigForDesktop.MaxLength;
            currPhysicsPointerLaserForDesktop.GetComponent<PhysicsPointer>().defaultLength = physicsPointerConfigForDesktop.DefaultLength;
            currPhysicsPointerLaserForDesktop.GetComponent<PhysicsPointer>().minLength = physicsPointerConfigForDesktop.MinLength;

        }

    }


    void InstaciatePhysicsPointerForOculus()
    {


            currPhysicsPointerLaserForOculus = Instantiate(PhysicsPointerLaserForOculus);
            currPhysicsPointerLaserForOculus.transform.parent = CenterEyeAnchorForOculus.transform;
            currPhysicsPointerLaserForOculus.transform.localPosition = physicsPointerConfigForOculus.PhysicsPointerPosition;
            currPhysicsPointerLaserForOculus.transform.localRotation = Quaternion.Euler(physicsPointerConfigForOculus.PhysicsPointerRotation);
            currPhysicsPointerLaserForOculus.GetComponent<PhysicsPointer>().maxLength = physicsPointerConfigForOculus.MaxLength;
            currPhysicsPointerLaserForOculus.GetComponent<PhysicsPointer>().defaultLength = physicsPointerConfigForOculus.DefaultLength;
            currPhysicsPointerLaserForOculus.GetComponent<PhysicsPointer>().minLength = physicsPointerConfigForOculus.MinLength;

        

    }

}
