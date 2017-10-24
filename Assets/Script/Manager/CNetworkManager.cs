using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class CNetworkManager : NetworkBehaviour {

    [SerializeField]
    private GameObject _cameraPrefab = null; // camera prefab

    public override void OnStartLocalPlayer() // this is our player
    {
        base.OnStartLocalPlayer();

        // add input handler component OR (see Update)
    }

    private void Update()
    {
        if (!base.isLocalPlayer)
            return;

        // update your input here
    }
}

// server side
public class PlayerSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject _playerPrefab = null;

    private void SpawnPlayer(NetworkConnection conn) // spawn a new player for the desired connection
    {
        GameObject playerObj = GameObject.Instantiate(_playerPrefab); // instantiate on server side
        NetworkServer.AddPlayerForConnection(conn, playerObj, 0); // spawn on the clients and set owner
    }
}