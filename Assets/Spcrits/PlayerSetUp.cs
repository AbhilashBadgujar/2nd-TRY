using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class PlayerSetUp : NetworkBehaviour {

    [SerializeField] Behaviour[] componentsToDesiable;

    [SerializeField] string remoteLayerName = "RemotePlayer";

    Camera SceneCam;

    [SerializeField] GameObject PlayerUIPrefab;
    private GameObject playerUIInstance;

    void Start()
    {
        if (!isLocalPlayer)
        {
            DisableComponents();
            AssignRemotePlayer();
        }
        else
        {
            SceneCam = Camera.main;
            SceneCam.gameObject.SetActive(false);

            playerUIInstance = Instantiate(PlayerUIPrefab);
            playerUIInstance.name = PlayerUIPrefab.name;

        }

        GetComponent<Player>().Setup();
    }

    public override void OnStartClient()
    {
        base.OnStartClient();

        string _netID = GetComponent<NetworkIdentity>().netId.ToString();
        Player player = GetComponent<Player>();

        GM.RegisterPlayer(_netID, player);
    }
    void DisableComponents()
    {
        for (int i = 0; i < componentsToDesiable.Length; i++)
        {
            componentsToDesiable[i].enabled = false;
            GM.UnRegisterPlayer(transform.name);
        }
    }

    void AssignRemotePlayer()
    {
        gameObject.layer = LayerMask.NameToLayer(remoteLayerName);
    }

    private void OnDisable()
    {

        Destroy(playerUIInstance);
        if (SceneCam != null)
        {
            SceneCam.gameObject.SetActive(true);
        }
    }
}
