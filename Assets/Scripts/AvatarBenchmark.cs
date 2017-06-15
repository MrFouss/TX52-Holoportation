using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AvatarBenchmark : MonoBehaviour {

	public Text avatarHeadDiff;
	public Text avatarLeftHandDiff;

	private NetworkAvatarController avatarController;


	// Use this for initialization
	void Start () {
		this.avatarHeadDiff.text = "0";
		GameObject go = GameObject.Find("LowManMeshSoft");
		this.avatarController = go.GetComponent<NetworkAvatarController>();
	}
	
	// Update is called once per frame
	void Update () {
		this.avatarHeadDiff.text = this.avatarController.AvatarBonePositionDiff(KinectWrapper.NuiSkeletonPositionIndex.Head).ToString();
		this.avatarLeftHandDiff.text = this.avatarController.AvatarBonePositionDiff(KinectWrapper.NuiSkeletonPositionIndex.HandLeft).ToString();
	}
}
