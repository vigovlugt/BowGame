using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class PlayerSetup : NetworkBehaviour
{
    [SerializeField]
    private Behaviour[] turnOffs;
    private GameObject sceneCam;
    void Awake()
    {
        if (isLocalPlayer)
        {
            //sceneCam = GameObject.Find("SceneCam");
            //sceneCam.SetActive(false);
        }
    }
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

        for (int i = 0; i < turnOffs.Length; i++)
        {
            turnOffs[i].enabled = false;

        }
    }
}
