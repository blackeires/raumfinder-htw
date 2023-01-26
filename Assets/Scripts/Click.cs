using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class Click : MonoBehaviour
{
    public VideoPlayer MyVideoPlayer;
    int IdleTimeSetting = 30;
    float LastIdleTime;
    public Canvas canvas;

    private void Start()
    {
        MyVideoPlayer.enabled = true;
        MyVideoPlayer.isLooping = true;

    }

    void Awake()
    {

        LastIdleTime = Time.time;
    }

    private void Update()
    {

        if (Input.anyKey)
        {
            LastIdleTime = Time.time;
            MyVideoPlayer.enabled = false;
            canvas.enabled = true;
        }

        if (IdleCheck())
        {
            canvas.enabled = false;
            MyVideoPlayer.enabled = true;
        }
    }

    public bool IdleCheck()
    {
        return Time.time - LastIdleTime > IdleTimeSetting;
    }

}
