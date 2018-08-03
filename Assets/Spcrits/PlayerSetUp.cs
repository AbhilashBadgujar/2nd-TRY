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
<<<<<<< HEAD
     
        RegisterPlayer();
    }

    void RegisterPlayer()
    {
        string ID = " Player " + GetComponent<NetworkIdentity>().netId;
        transform.name = ID;
<<<<<<< HEAD
    }
=======
=======
>>>>>>> parent of 435c895... player Shooting
    }

>>>>>>> b7b30cfeb624906a0f4818a0de257474ba98c0bc

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
