using UnityEngine;

namespace Photon.Pun.Cam{
    public class CameraWork : MonoBehaviour
    {
        /*
    #region Private Fields
    
    private float distance = 0.0f;
    private float height = 3.0f; //This is really the only parameter we care about
    private Vector3 centerOffset = Vector3.zero;
    private float smoothSpeed = 0.125f;
    private bool followOnStart = false;

    bool isFollowing;
    Transform cameraTransform;
    Vector3 cameraOffset = vector3.zero;

    #endregion

    #region MonoBehavior Callbacks
    

    void Start()
    {
        if (followOnStart)
            OnStartFollowing();
    }

    void LateUpdate(){
        if (cameraTransform == null && isFollowing){
            OnStartFollowing();
        }
        if (isFollowing){
            Follow();
        }
    }

    #endregion

    #region Public Methods
    public void OnStartFollowing(){
        CameraTransform = Camera.main.transform;
        isFollowing = true;
        Cut();
    }
    #endregion

    #region Private Methods

    void Follow(){
        cameraOffset.z = -distance;
        cameraOffset.y = height;
        cameraTransform.position = Vector3.Lerp(cameraTransform.position, 
            this.transform.position + this.transform.TransformVector(cameraOffset), 
            smoothSpeed*Time.deltaTime);
        cameraTransform.LookAt(this.transform.position + centerOffset);
    }

    void Cut(){
        cameraOffset.z = -distance;
        cameraOffset.y = height;
        cameraTransform.position = this.transform.position + this.transform.TransformVector(cameraOffset);
        cameraTransform.LookAt(this.transform.position + centerOffset);
    }
    #endregion


    // Update is called once per frame
    void Update()
    {if (cameraTransform == null && isFollowing)
        OnStartFollowing();
        
    }
    */
} 

}

