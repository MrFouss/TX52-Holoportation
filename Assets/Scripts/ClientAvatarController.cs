using System;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.Networking;

public class ClientAvatarController : MonoBehaviour {

	// Public variables that will get matched to bones. If empty, the Kinect will simply not track it.
    public Transform HipCenter;
    public Transform Spine;
    public Transform ShoulderCenter;
    public Transform Head;
    public Transform ShoulderLeft;
    public Transform ElbowLeft;
    public Transform WristLeft;
    public Transform HandLeft;
    public Transform ShoulderRight;
    public Transform ElbowRight;
    public Transform WristRight;
    public Transform HandRight;
    public Transform HipLeft;
    public Transform KneeLeft;
    public Transform AnkleLeft;
    public Transform FootLeft;
    public Transform HipRight;
    public Transform KneeRight;
    public Transform AnkleRight;
    public Transform FootRight;
    public Transform Body;

    public GameObject Asset;
    public Texture2D FaceTexture;
    public int FaceCenterX = 512;
    public int FaceCenterY = 300;

    private Texture2D currentTexture;
	private Projector faceProjector;


    // Use this for initialization
    void Start ()
    {
        currentTexture = new Texture2D(0, 0);

        GameObject go = GameObject.Find("NetworkManager");
        NetworkManager manager = go.GetComponent<NetworkManager>();
        manager.client.RegisterHandler(AvatarMessage.Type, this.HandleAvatarMessage);
        manager.client.RegisterHandler(FaceMessage.Type, this.HandleFaceMessage);
        Debug.Log("Handlers registered");

        Texture2D tmpTexture2D = this.FaceTexture;
        this.FaceTexture = new Texture2D(tmpTexture2D.width,tmpTexture2D.height);
        this.FaceTexture.SetPixels32(tmpTexture2D.GetPixels32());
        this.FaceTexture.Apply();

        this.Asset.GetComponent<Renderer>().materials[1].mainTexture = FaceTexture;

		GameObject proj = GameObject.Find("FaceProjector");
		this.faceProjector = go.GetComponent<Projector>();
    }

    // PNG version
    /*void Update() {
        Texture2D texture2D = this.currentTexture;
        int x, y;
        for (int i = 0; i < texture2D.width; ++i)
        {
            for (int j = 0; j < texture2D.height; ++j)
            {
                x = this.FaceCenterX - (texture2D.width / 2) + i;
                y = this.FaceTexture.height - this.FaceCenterY + (texture2D.height / 2) - j;
                if (x > 0 && x < this.FaceTexture.width && y > 0 && y < this.FaceTexture.height)
                {
                    //FaceTexture.SetPixel(x, y, message.colors[(i * message.width) + j].Color);
                    FaceTexture.SetPixel(x, y, texture2D.GetPixel(i, j));
                    //Debug.Log("(i * message.width) + j = " + ((i * message.width) + j));
                }
            }
        }
        this.FaceTexture.Apply();
    }*/

    private void HandleAvatarMessage(NetworkMessage message) {
        AvatarMessage avatarMessage = message.ReadMessage<AvatarMessage>();
        if (avatarMessage != null) {
            this.OnAvatarMessage(avatarMessage);
            Debug.Log("AvatarMessage received");
        }
    }

    private void HandleFaceMessage(NetworkMessage message)
    {
        FaceMessage faceMessage = message.ReadMessage<FaceMessage>();
        if (faceMessage != null)
        {
            this.OnFaceMessage(faceMessage);
            Debug.Log("FaceMessage received");
        }
    }

    private void OnAvatarMessage(AvatarMessage msg)
    {
        this.Body.position = msg.Position.V3 / 10;

        for (var i = 0; i < msg.Bones.Length; ++i)
        {
			switch ((KinectWrapper.NuiSkeletonPositionIndex)msg.Bones[i])
			{
			case KinectWrapper.NuiSkeletonPositionIndex.HipCenter:
				this.HipCenter.position = this.transform.TransformPoint(msg.Positions [i].V3);
				this.HipCenter.rotation = msg.Rotations [i].Quaternion;
				break;
			case KinectWrapper.NuiSkeletonPositionIndex.Spine:
				this.Spine.position =this.transform.TransformPoint(msg.Positions [i].V3);
				this.Spine.rotation = msg.Rotations [i].Quaternion;
				break;
			case KinectWrapper.NuiSkeletonPositionIndex.ShoulderCenter:
				this.ShoulderCenter.position = this.transform.TransformPoint(msg.Positions [i].V3);
				this.ShoulderCenter.rotation = msg.Rotations [i].Quaternion;
				break;
			case KinectWrapper.NuiSkeletonPositionIndex.Head:
				this.Head.position = this.transform.TransformPoint(msg.Positions [i].V3);
				this.Head.rotation = msg.Rotations [i].Quaternion;
				break;
			case KinectWrapper.NuiSkeletonPositionIndex.ShoulderLeft:
				this.ShoulderLeft.position = this.transform.TransformPoint(msg.Positions [i].V3);
				this.ShoulderLeft.rotation = msg.Rotations [i].Quaternion;
				break;
			case KinectWrapper.NuiSkeletonPositionIndex.ElbowLeft:
				this.ElbowLeft.position = this.transform.TransformPoint(msg.Positions [i].V3);
				this.ElbowLeft.rotation = msg.Rotations [i].Quaternion;
				break;
			case KinectWrapper.NuiSkeletonPositionIndex.WristLeft:
				this.WristLeft.position = this.transform.TransformPoint(msg.Positions [i].V3);
				this.WristLeft.rotation = msg.Rotations [i].Quaternion;
				break;
			case KinectWrapper.NuiSkeletonPositionIndex.HandLeft:
				this.HandLeft.position = this.transform.TransformPoint(msg.Positions [i].V3);
				this.HandLeft.rotation = msg.Rotations [i].Quaternion;
				break;
			case KinectWrapper.NuiSkeletonPositionIndex.ShoulderRight:
				this.ShoulderRight.position = this.transform.TransformPoint(msg.Positions [i].V3);
				this.ShoulderRight.rotation = msg.Rotations [i].Quaternion;
				break;
			case KinectWrapper.NuiSkeletonPositionIndex.ElbowRight:
				this.ElbowRight.position = this.transform.TransformPoint(msg.Positions [i].V3);
				this.ElbowRight.rotation = msg.Rotations [i].Quaternion;
				break;
			case KinectWrapper.NuiSkeletonPositionIndex.WristRight:
				this.WristRight.position = this.transform.TransformPoint(msg.Positions [i].V3);
				this.WristRight.rotation = msg.Rotations [i].Quaternion;
				break;
			case KinectWrapper.NuiSkeletonPositionIndex.HandRight:
				this.HandRight.position = this.transform.TransformPoint(msg.Positions [i].V3);
				this.HandRight.rotation = msg.Rotations [i].Quaternion;
				break;
			case KinectWrapper.NuiSkeletonPositionIndex.HipLeft:
				this.HipLeft.position = this.transform.TransformPoint(msg.Positions [i].V3);
				this.HipLeft.rotation = msg.Rotations [i].Quaternion;
				break;
			case KinectWrapper.NuiSkeletonPositionIndex.KneeLeft:
				this.KneeLeft.position = this.transform.TransformPoint(msg.Positions [i].V3);
				this.KneeLeft.rotation = msg.Rotations [i].Quaternion;
				break;
			case KinectWrapper.NuiSkeletonPositionIndex.AnkleLeft:
				this.AnkleLeft.position = this.transform.TransformPoint(msg.Positions [i].V3);
				this.AnkleLeft.rotation = msg.Rotations [i].Quaternion;
				break;
			case KinectWrapper.NuiSkeletonPositionIndex.FootLeft:
				this.FootLeft.position = this.transform.TransformPoint(msg.Positions [i].V3);
				this.FootLeft.rotation = msg.Rotations [i].Quaternion;
				break;
			case KinectWrapper.NuiSkeletonPositionIndex.HipRight:
				this.HipRight.position = this.transform.TransformPoint(msg.Positions [i].V3);
				this.HipRight.rotation = msg.Rotations [i].Quaternion;
				break;
			case KinectWrapper.NuiSkeletonPositionIndex.KneeRight:
				this.KneeRight.position = this.transform.TransformPoint(msg.Positions [i].V3);
				this.KneeRight.rotation = msg.Rotations [i].Quaternion;
				break;
			case KinectWrapper.NuiSkeletonPositionIndex.AnkleRight:
				this.AnkleRight.position = this.transform.TransformPoint(msg.Positions [i].V3);
				this.AnkleRight.rotation = msg.Rotations [i].Quaternion;
				break;
			case KinectWrapper.NuiSkeletonPositionIndex.FootRight:
				this.FootRight.position = this.transform.TransformPoint(msg.Positions [i].V3);
				this.FootRight.rotation = msg.Rotations [i].Quaternion;
				break;
			default:
				throw new ArgumentOutOfRangeException();
			}

        }
    }

    private void OnFaceMessage(FaceMessage message) {

        // PNG version
        /*Texture2D texture2D = new Texture2D(message.width,message.height);
        texture2D.LoadImage(message.png);
        this.currentTexture = texture2D;

        this.GuiTexture.texture = texture2D;*/

        // Color[] version
        int x, y;
        for (int i = 0; i < message.width; ++i)
        {
            for (int j = 0; j < message.height; ++j)
            {
                x = this.FaceCenterX - (message.width / 2) + i;
                y = this.FaceTexture.height - this.FaceCenterY + (message.height / 2) - j;
                if (x > 0 && x < this.FaceTexture.width && y > 0 && y < this.FaceTexture.height)
                {
                    FaceTexture.SetPixel(x, y, message.colors[(i * message.width) + j].Color);
                }
            }
        }
        this.FaceTexture.Apply();


		this.faceProjector.material.SetTexture ("_ShadowTex", FaceTexture);
    }
}
