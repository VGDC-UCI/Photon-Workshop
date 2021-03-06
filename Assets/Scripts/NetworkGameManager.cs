﻿using System.Collections;
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
			localPlayerInstance = PhotonNetwork.Instantiate("Player", Vector3.left, Quaternion.identity);
		}
		else
		{
			localPlayerInstance = PhotonNetwork.Instantiate("Player", Vector3.right, Quaternion.identity);
		}
	}
}