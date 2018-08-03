using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class PlayerSetUp : NetworkBehaviour {

    [SerializeField] Behaviour[] componentsToDesiable;

    [SerializeField] string remoteLayerName = "RemotePlayer";

    Camera SceneCam;

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
        }
    }


    void DisableComponents()
    {
        for (int i = 0; i < componentsToDesiable.Length; i++)
        {
            componentsToDesiable[i].enabled = false;
        }
    }

    void AssignRemotePlayer()
    {
        gameObject.layer = LayerMask.NameToLayer(remoteLayerName);
    }

    private void OnDisable()
    {
        if (SceneCam != null)
        {
            SceneCam.gameObject.SetActive(true);
        }
    }
}
