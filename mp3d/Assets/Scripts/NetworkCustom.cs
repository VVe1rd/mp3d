using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.Networking.NetworkSystem;

public class NetworkCustom : NetworkLobbyManager
{

    //public Transform spawnPosition;

    public override GameObject OnLobbyServerCreateGamePlayer(NetworkConnection conn, short playerControllerId)
    {
        //Select the prefab from the spawnable objects list
        //var _id = playerControllerId;
        var _id = conn.connectionId;
        var playerPrefab = spawnPrefabs[_id];

        // Create player object with prefab
        GameObject _temp = (GameObject)Instantiate(playerPrefab, startPositions[_id].position, Quaternion.identity);

        return _temp;
    }

}