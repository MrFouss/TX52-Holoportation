using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class NetworkAvatarController : AvatarControllerClassic
{
    public int NumberOfMovementSynchronizationsPerSecond = 60;
    public int NumberOfFaceSynchronizationsPerSecond = 1;
    public int NumberOfLineToSend = 1;
	private readonly Dictionary<KinectWrapper.NuiSkeletonPositionIndex, Transform> transforms = new Dictionary<KinectWrapper.NuiSkeletonPositionIndex, Transform>();
    private Vector3 _position = Vector3.zero;
    public Texture2D FaceTexture2D;
    private Color[] buffer;

	// Use this for initialization
	void Start ()
	{
	    InvokeRepeating("SendAvatarMessage", 1f, 1 / (float)NumberOfMovementSynchronizationsPerSecond);
        //InvokeRepeating("SendFaceMessage", 1f, 1f / (float)NumberOfFaceSynchronizationsPerSecond);
    }

    void SendFaceMessage()
    {
        if (FaceTexture2D != null)
        {
            for (int i = 0; i < FaceTexture2D.height; i += NumberOfLineToSend)
            {
                buffer = new Color[NumberOfLineToSend * FaceTexture2D.width];
                Array.Copy(FaceTexture2D.GetPixels(), i * FaceTexture2D.width, buffer, 0, NumberOfLineToSend * FaceTexture2D.width);
                NetworkServer.SendToAll(FaceMessage.Type,
                    new FaceMessage(FaceTexture2D.width, FaceTexture2D.height, 0, i, FaceTexture2D.width - 1, i, buffer));
            }

            if (FaceTexture2D.height % 2 != 0)
            {
                buffer = new Color[FaceTexture2D.width];
                Array.Copy(FaceTexture2D.GetPixels(), (FaceTexture2D.height - 1) * FaceTexture2D.width, buffer, 0, NumberOfLineToSend * FaceTexture2D.width);
                NetworkServer.SendToAll(FaceMessage.Type,
                    new FaceMessage(FaceTexture2D.width, FaceTexture2D.height, 0, (FaceTexture2D.height - 1), FaceTexture2D.width - 1, (FaceTexture2D.height - 1), buffer));

            }
            FaceTexture2D = null;
        }
    }

    void SendAvatarMessage()
    {
        if (transforms.Count != 0)
        {
            NetworkServer.SendToAll(AvatarMessage.Type, new AvatarMessage(transforms, _position));
            transforms.Clear();
        }
    }

    protected override void TransformBone(uint userId, KinectWrapper.NuiSkeletonPositionIndex joint, int boneIndex, bool flip)
    {
        Transform boneTransform = bones[boneIndex];
        base.TransformBone(userId, joint, boneIndex, flip);
        transforms[joint] = boneTransform;
    }

    protected override void MoveAvatar(uint userId)
    {
        base.MoveAvatar(userId);
        this._position = bodyRoot.localPosition;
    }
}
