using UnityEngine;
//using Windows.Kinect;

using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.IO;
using System.Text;

public class AvatarControllerClassic : AvatarController
{
	// Public variables that will get matched to bones. If empty, the Kinect will simply not track it.
	public Transform HipCenter;
	public Transform Spine;
	public Transform ShoulderCenter;
	public Transform Head;

	public Transform ShoulderLeft; // special bone
	public Transform LeftUpperArm;
	public Transform LeftElbow;
	public Transform LeftHand;
	private Transform LeftFingers = null;

	public Transform ShoulderRight; // special bone
	public Transform RightUpperArm;
	public Transform RightElbow;
	public Transform RightHand;
	private Transform RightFingers = null;

	public Transform LeftThigh;
	public Transform LeftKnee;
	public Transform LeftFoot;
	private Transform LeftToes = null;

	public Transform RightThigh;
	public Transform RightKnee;
	public Transform RightFoot;
	private Transform RightToes = null;

	public Transform BodyRoot;
	public GameObject OffsetNode;


	// If the bones to be mapped have been declared, map that bone to the model.
	protected override void MapBones()
	{
		bones[0] = HipCenter;
		bones[1] = Spine;
		bones[2] = ShoulderCenter;
		bones[3] = Head;

		bones[4] = ShoulderLeft; // special bone
		bones[5] = LeftUpperArm;
		bones[6] = LeftElbow;
		bones[7] = LeftHand;
		bones[8] = LeftFingers;

		bones[9] = ShoulderRight; // special bone
		bones[10] = RightUpperArm;
		bones[11] = RightElbow;
		bones[12] = RightHand;
		bones[13] = RightFingers;

		bones[14] = LeftThigh;
		bones[15] = LeftKnee;
		bones[16] = LeftFoot;
		bones[17] = LeftToes;

		bones[18] = RightThigh;
		bones[19] = RightKnee;
		bones[20] = RightFoot;
		bones[21] = RightToes;

		// body root and offset
		bodyRoot = BodyRoot;
		offsetNode = OffsetNode;

		if(offsetNode == null)
		{
			offsetNode = new GameObject(name + "Ctrl") { layer = transform.gameObject.layer, tag = transform.gameObject.tag };
			offsetNode.transform.position = transform.position;
			offsetNode.transform.rotation = transform.rotation;
			offsetNode.transform.parent = transform.parent;

			transform.parent = offsetNode.transform;
			transform.localPosition = Vector3.zero;
			transform.localRotation = Quaternion.identity;
		}

//		if(bodyRoot == null)
//		{
//			bodyRoot = transform;
//		}
	}

}

