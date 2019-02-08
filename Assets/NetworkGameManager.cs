using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Photon.Pun;

public class NetworkGameManager : MonoBehaviourPunCallbacks
{
	public static GameObject localPlayerInstance;

	public GameObject playerPrefab;

	void Start()
	{
		if(PhotonNetwork.IsMasterClient)
		{
			localPlayerInstance = Instantiate(playerPrefab, Vector3.left, Quaternion.identity);
		}
		else
		{
			localPlayerInstance = Instantiate(playerPrefab, Vector3.right, Quaternion.identity);
		}
	}
}
