using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

[Serializable]
public struct ColorSerializer
{

    public float r;
    public float g;
    public float b;
    public float a;

    public ColorSerializer(Color color) : this()
    {
        this.Fill(color);
    }

    public Color Color
    {
        get
        {
            return new Color(this.r, this.g, this.b, this.a);
        }
    }

    public void Fill(Color color)
    {
        this.r = color.r;
        this.g = color.g;
        this.b = color.b;
        this.a = color.a;
    }

}


public class FaceMessage : MessageBase
{
    public static short Type = MsgType.Highest + 2;

    public int width;
    public int height;
    public int firstPixelX;
    public int firstPixelY;
    public int lastPixelX;
    public int lastPixelY;
    public ColorSerializer[] colors;

    // For Unity
    public FaceMessage()
    {
    }

    public FaceMessage(int width, int height, int firstPixelX, int firstPixelY, int lastPixelX, int lastPixelY, Color[] colors)
    {
        this.width = width;
        this.height = height;
        this.colors = new ColorSerializer[colors.Length];
        this.firstPixelX = firstPixelX;
        this.firstPixelY = firstPixelY;
        this.lastPixelX = lastPixelX;
        this.lastPixelY = lastPixelY;

        for (var i = 0; i < colors.Length; i++)
        {
            this.colors[i] = new ColorSerializer(colors[i]);
        }
    }
}
