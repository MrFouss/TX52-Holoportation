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
    public int[] Bones;

    // For Unity
    public AvatarMessage()
    {
    }

    public AvatarMessage(Dictionary<KinectWrapper.NuiSkeletonPositionIndex, Quaternion> rotations, Vector3 position)
    {
        Rotations = new QuaternionSerializer[rotations.Count];
        Bones = new int[rotations.Count];
        Position = new Vector3Serializer(position);
        for (var i = 0; i < rotations.Count; i++)
        {
            Bones[i] = (int)rotations.Keys.ElementAt(i);
            Rotations[i] = new QuaternionSerializer(rotations[(KinectWrapper.NuiSkeletonPositionIndex)Bones[i]]);
        }
    }
}
