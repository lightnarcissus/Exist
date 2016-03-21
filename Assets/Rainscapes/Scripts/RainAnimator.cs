using UnityEngine;
using System.Collections;

//Hack by Si Borokokok

public class RainAnimator : MonoBehaviour
{
    public Texture2D[] frames;
    public float framesPerSecond = 16f;
    public static bool on;

    public void Start()
    {
        on = true;
    }

    public void Update()
    {
        if (on)
        {
            int a = (int) (Time.time * framesPerSecond);
            a = a % frames.Length;
            renderer.material.SetTexture("_BumpMap", frames[a]);
        }
    }
}

