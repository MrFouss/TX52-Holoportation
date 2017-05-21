using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FaceCutting : MonoBehaviour
{
    public NetworkAvatarController Controller;
    public GUITexture GuiTexture;
    private Texture2D headTexture;
    private Texture2D tmp;
    private KinectManager manager;

	// Use this for initialization
	void Start () {
        manager = KinectManager.Instance;
        headTexture = new Texture2D(50, 50);
        tmp = new Texture2D(KinectWrapper.Constants.ColorImageWidth, KinectWrapper.Constants.ColorImageHeight);
        Controller.FaceTexture2D = headTexture;
    }

	// Update is called once per frame
    void Update()
    {
        if (!manager.IsInitialized())
        {
            return;
        }

        Texture2D kinectTexture2D = manager.GetUsersLblTex();
        tmp.SetPixels32(kinectTexture2D.GetPixels32());
        tmp.Apply();


        uint player1 = manager.GetPlayer1ID();
        if (manager.IsJointTracked(player1, (int) KinectWrapper.NuiSkeletonPositionIndex.Head))
        {
            Vector3 headPosition =
                KinectWrapper.MapSkeletonPointToDepthPoint(manager.GetRawSkeletonJointPos(player1,
                    (int) KinectWrapper.NuiSkeletonPositionIndex.Head));
            for (int x = 0, i = -((int) headTexture.width / 2);
                i < headTexture.width / 2 && x < headTexture.width;
                ++i , ++x)
            {
                for (int y = 0, j = -((int) headTexture.height / 2);
                    j < headTexture.height / 2 && y < headTexture.height;
                    ++j, ++y)
                {
                    headTexture.SetPixel(x, y, tmp.GetPixel((int) headPosition.x + i, (int) headPosition.y + j));
                }
            }

            headTexture.Apply();
            Controller.FaceTexture2D = headTexture;
            Texture2D test = new Texture2D(headTexture.width, headTexture.height);
            test.LoadImage(headTexture.EncodeToPNG());
            GuiTexture.texture = test;
        }
    }
}
