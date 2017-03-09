using UnityEngine;
using UnityEngine.Networking;


[RequireComponent(typeof(Player))]
//If this whole script is not controller by the system we are disabling the components
public class PlayerSetup : NetworkBehaviour {

    //List of componenets to disable
    [SerializeField]
    Behaviour[] componenetsToDisable;

    [SerializeField]
    GameObject playerUIPrefab;
    private GameObject playerUIInstance;

    Camera sceneCamera;

    void Start()
    {
        if (!isLocalPlayer)
        {
            DisableComponents();
        } else
        {
            // Disables the main camera when we join the museum 
            sceneCamera = Camera.main;
            if(sceneCamera != null)
            {
                sceneCamera.gameObject.SetActive(false);
            }

            // Create PlayerUI
            playerUIInstance = Instantiate(playerUIPrefab);
            playerUIInstance.name = playerUIPrefab.name;
        }
    }

    public override void OnStartClient()
    {
        base.OnStartClient();

        string _netID = GetComponent<NetworkIdentity>().netId.ToString();
        Player _player = GetComponent<Player>();

        GameManager.RegisterPlayer(_netID, _player);
    }

    void DisableComponents()
    {
        for (int i = 0; i < componenetsToDisable.Length; i++)
        {
            componenetsToDisable[i].enabled = false;
        }
    }

    // We are using this when we disconnect from the museum sets the main camera back to true
    void OnDisable()
    {
        Destroy(playerUIInstance);

        if (sceneCamera != null)
        {
            sceneCamera.gameObject.SetActive(true);
        }

        GameManager.UnRegisterPlayer(transform.name);
    }
}
