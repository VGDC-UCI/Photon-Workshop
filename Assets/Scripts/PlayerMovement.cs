using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Photon.Pun;

public class PlayerMovement : MonoBehaviourPun, IPunObservable
{
	public float movementSpeed = 1f;

	private Rigidbody2D rb;
	private float lastRecieved;

	void Awake()
	{
		rb = GetComponent<Rigidbody2D>();
	}
	void Update()
	{
		if(!photonView.IsMine)
		{
			return;
		}
		float moveHorizontal = Input.GetAxisRaw("Horizontal");
		float moveVertical = Input.GetAxisRaw("Vertical");
		rb.velocity = new Vector2(moveHorizontal, moveVertical).normalized * movementSpeed;
	}

	public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
	{
		if(stream.IsWriting)
		{
			stream.SendNext(transform.position);
		}
		else
		{
			transform.position = (Vector3)stream.ReceiveNext();
			Debug.Log(Time.time - lastRecieved);
			lastRecieved = Time.time;
		}
	}
}
