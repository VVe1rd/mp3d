using UnityEngine;
using UnityEngine.Networking;

[RequireComponent(typeof(Player))]
public class PlayerSetup : NetworkBehaviour {

    [SerializeField]
    private string remoteLayer = "RemotePlayer";
    private Camera sceneCamera;

    [SerializeField]
    Behaviour[] componentsToDisable;

    void Start()
    {
        if (!isLocalPlayer)
        {
            componentsToDisable[2].enabled = true;
            for (int i = 0; i < componentsToDisable.Length; i++)
                if (i != 2)
                    componentsToDisable[i].enabled = false;
            gameObject.layer = LayerMask.NameToLayer(remoteLayer);
        }
        else
        {
            sceneCamera = Camera.main;
            if (sceneCamera != null)
                sceneCamera.gameObject.SetActive(false);
            componentsToDisable[2].enabled = false;
        }
    }

    public override void OnStartClient()
    {
        base.OnStartClient();

        string _netID = GetComponent<NetworkIdentity>().netId.ToString();
        Player _player = GetComponent<Player>();

        Game_Manager.RegisterPlayer(_netID, _player);
    }

    void OnDisable()
    {
        if (sceneCamera != null)
            sceneCamera.gameObject.SetActive(true);
    }
}
