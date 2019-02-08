using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Photon.Pun;
using Photon.Realtime;

public class NetworkConnectionHandler : MonoBehaviourPunCallbacks
{

	void Awake()
	{
		PhotonNetwork.AutomaticallySyncScene = true;
	}
	void Start()
	{
		ConnectToNetwork();
	}
	private void ConnectToNetwork()
	{
		if(!PhotonNetwork.IsConnected)
		{
			PhotonNetwork.ConnectUsingSettings();
		}
	}
	public void TryToJoinGame()
	{
		if(PhotonNetwork.IsConnected)
		{
			PhotonNetwork.JoinRandomRoom();
		}
	}

	public override void OnConnectedToMaster()
	{
		Debug.Log("Connected To Master");
	}

	public override void OnDisconnected(DisconnectCause cause)
	{
		Debug.Log("DCed because " + cause);
	}

	public override void OnJoinRandomFailed(short returnCode, string message)
	{
		Debug.Log("failed to join random room");
		PhotonNetwork.CreateRoom(null, new RoomOptions());
	}

	public override void OnJoinedRoom()
	{
		Debug.Log("succesfully joined room");
		PhotonNetwork.LoadLevel("GameScene");
	}
}
