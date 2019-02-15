using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Photon.Pun;

public class PlayerRender : MonoBehaviourPun
{
	private SpriteRenderer sprite;
	
	void Awake()
	{
		sprite = GetComponent<SpriteRenderer>();
	}

	void Start()
	{
		if(photonView.IsMine)
		{
			sprite.color = Color.green;
		}
		else
		{
			sprite.color = Color.red;
		}
	}
}
