using UnityEngine;
using UnityEngine.Networking;
public class PlayerSetup: NetworkBehaviour {
    
    [SerializeField] private Behaviour[] turnOffs;
    private GameObject sceneCam;
    //[SerializeField] private Canvas canvas;
    void Awake() {
        if (isLocalPlayer) {
            //sceneCam = GameObject.Find("SceneCam");
            //sceneCam.SetActive(false);
        }
    }
    void Start() {
        if(isLocalPlayer){
        Util.SetLayerRecursively(gameObject,"LocalPlayer");
        }

        if (isLocalPlayer) {
            return;
        }
        Renderer[] rends = GetComponentsInChildren<Renderer>();
        foreach (Renderer r in rends){
            r.material.color = Color.red;
        }
        turnOff();
    }

    void turnOff() {

        for (int i = 0; i < turnOffs.Length; i++) {
            turnOffs[i].enabled = false;

        }
    }
}