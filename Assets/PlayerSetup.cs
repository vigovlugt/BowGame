using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class PlayerSetup : NetworkBehaviour
{
    [SerializeField]
    private Behaviour[] turnOffs;

    // Use this for initialization
    void Start()
    {
        if (isLocalPlayer)
        {
            return;
        }

        turnOff();
    }

    void turnOff()
    {
        Camera.main.enabled = false;

        for (int i = 0; i < turnOffs.Length; i++)
        {
            turnOffs[i].enabled = false;

        }
    }
}
