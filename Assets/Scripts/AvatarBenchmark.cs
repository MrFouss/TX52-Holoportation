using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AvatarBenchmark : MonoBehaviour {

	public Text avatarHeadDiff;
	public Text avatarLeftHandDiff;
	public Text avatarLeftKneeDiff;
	public Text avatarLeftShoulderDiff;

	private NetworkAvatarController avatarController;


	// Use this for initialization
	void Start () {
		this.avatarHeadDiff.text = "0";
		GameObject go = GameObject.Find("LowManMeshSoft");
		this.avatarController = go.GetComponent<NetworkAvatarController>();
	}
	
	// Update is called once per frame
	void Update () {
		this.avatarLeftKneeDiff.text = this.avatarController.AvatarBonePositionDiff(15).ToString();
		this.avatarHeadDiff.text = this.avatarController.AvatarBonePositionDiff(3).ToString();
		this.avatarLeftShoulderDiff.text = this.avatarController.AvatarBonePositionDiff(10).ToString();
		this.avatarLeftHandDiff.text = this.avatarController.AvatarBonePositionDiff(7).ToString();
	}
}
