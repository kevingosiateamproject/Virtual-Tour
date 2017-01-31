using UnityEngine;
using UnityEngine.Networking;


//If this whole script is not controller by the system we are disabling the components
public class PlayerSetup : NetworkBehaviour {

    //List of componenets to disable
    [SerializeField]
    Behaviour[] componenetsToDisable;

    Camera sceneCamera;

    void Start()
    {
        if (!isLocalPlayer)
        {
            for (int i = 0; i < componenetsToDisable.Length; i++)
            {
                componenetsToDisable[i].enabled = false;
            }
        }
        else
        {
            // Disables the main camera when we join the museum 
            sceneCamera = Camera.main;
            if(sceneCamera != null)
            {
                sceneCamera.gameObject.SetActive(false);
            }
        }
    }

    // We are using this when we disconnect from the museum sets the main camera back to true
    void OnDisable()
    {
        if (sceneCamera != null)
        {
            sceneCamera.gameObject.SetActive(true);
        }
    }
}
