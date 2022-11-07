using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using Vuforia;

public class trailerActions : MonoBehaviour
{
    public VideoPlayer v;

    // Start is called before the first frame update
    void Start()
    {
        v = this.GetComponent<VideoPlayer>();

    }

    private void OnMouseDown()
    {
        StartCoroutine(playPauseVideo());
    }

    IEnumerator playPauseVideo()
    {
        v.Prepare();
        while (!v.isPrepared)
        {
            yield return null;
        }
        if (v.isPlaying)
        {
            v.Pause();
        }
        else
        {
            v.Play();
        }
        yield return null;
    }
    // Update is called once per frame
    void Update()
    {
    }
}
