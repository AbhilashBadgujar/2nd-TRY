using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class PlayerShoot : NetworkBehaviour {


    const string player_tag = "Player";

    public PlayerWeapon playerWeapon;

    [SerializeField]
    Camera cam;

    [SerializeField]
    LayerMask layer;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        if (cam == null)
        {
            print("cam ref error");
        }
    }

    private void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }

    [Client]
   void Shoot()
   {
        RaycastHit hit;
        if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, playerWeapon.range, layer))
        {
            print("hit: " + hit.collider.name);
            if (hit.collider.tag == player_tag)
            {
                CmdPlayerShot(hit.collider.name);
            }
        }
   }

    [Command]
    void CmdPlayerShot(string ID)
    {
        print(ID + "Has been Shot");
    }
}
