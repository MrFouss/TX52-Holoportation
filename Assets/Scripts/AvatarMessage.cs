using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.Networking;

[Serializable]
public struct Vector3Serializer
{
    public float x;
    public float y;
    public float z;

    public Vector3Serializer(Vector3 v3): this() {
        this.Fill(v3);
    }

    public Vector3 V3 {
        get {
            return new Vector3(this.x, this.y, this.z);
        }
    }

    public void Fill(Vector3 v3)
    {
        this.x = v3.x;
        this.y = v3.y;
        this.z = v3.z;
    }

}

[Serializable]
public struct QuaternionSerializer
{
    public float x;
    public float y;
    public float z;
    public float w;

    public QuaternionSerializer(Quaternion q) : this()
    {
        this.x = q.x;
        this.y = q.y;
        this.z = q.z;
        this.w = q.w;
    }

    public Quaternion Quaternion
    {
        get
        {
            return new Quaternion(x, y, z, w);
        }
    }
}

public class AvatarMessage : MessageBase
{
    public static short Type = MsgType.Highest + 1;

    public Vector3Serializer Position;
	public QuaternionSerializer[] Rotations;
	public Vector3Serializer[] Positions;
    public int[] Bones;

	public NetworkAvatarController.AvatarMotionMode avatarMotionMode;


    // For Unity
    public AvatarMessage()
    {
    }

	public AvatarMessage(Dictionary<KinectWrapper.NuiSkeletonPositionIndex, Transform> tr, Vector3 position, NetworkAvatarController.AvatarMotionMode motionMode)
    {
		Rotations = new QuaternionSerializer[tr.Count];
		Positions = new Vector3Serializer[tr.Count];
        Bones = new int[tr.Count];
        Position = new Vector3Serializer(position);
        for (var i = 0; i < tr.Count; i++)
        {
			Bones[i] = (int)tr.Keys.ElementAt(i);
			Positions[i] = new Vector3Serializer(tr[(KinectWrapper.NuiSkeletonPositionIndex)Bones[i]].position);
			Rotations[i] = new QuaternionSerializer(tr[(KinectWrapper.NuiSkeletonPositionIndex)Bones[i]].rotation);
        }

		this.avatarMotionMode = motionMode;
    }
}
