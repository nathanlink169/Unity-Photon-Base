using UnityEngine;
using Photon;
using System.Collections;

public class RandomMatchmaker : Photon.PunBehaviour
{

	// Use this for initialization
	void Start ()
	{
		PhotonNetwork.ConnectUsingSettings ("0.1");
	}
	
	// Update is called once per frame
	void Update ()
	{
	
	}

	void OnGUI ()
	{
		GUILayout.Label (PhotonNetwork.connectionStateDetailed.ToString ());
	}

	public override void OnJoinedLobby ()
	{
		PhotonNetwork.JoinRandomRoom ();
	}

	public void OnPhotonRandomJoinFailed ()
	{
		Debug.Log ("Can't Join Random Room!");
		PhotonNetwork.CreateRoom (null);
	}

	public override void OnJoinedRoom ()
	{
		GameObject obj = PhotonNetwork.Instantiate ("TestCapsule", new Vector3 (0, 2, 0), Quaternion.identity, 0);
		obj.GetComponent<CapsuleControl> ().enabled = true;
	}
}
