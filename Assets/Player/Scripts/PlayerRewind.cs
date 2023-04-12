using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using static TMPro.SpriteAssetUtilities.TexturePacker_JsonArray;

public class PlayerRewind : MonoBehaviour
{
    [SerializeField] PortalManager portalManager;

    List<RewindFrame> rewindFrames = new List<RewindFrame>();
    bool time;
    bool active = false;

    public bool GetActive()
    {
        return active;
    }


    private void Start()
    {
        if (portalManager == null)
        {
            time = false;
        }
        else
        {
            time = portalManager.time;
        }

        StartCoroutine(AddFrame());
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R) && !active)
        {
            StartRewindTimeToStart();
        }
    }

    public void StartRewindTimeToStart()
    {
        active = true;
        StopAllCoroutines();
        rewindFrames.Reverse();
        GetComponent<Collider2D>().enabled = false;
        GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;

        StartCoroutine(RewindTimeToStart());
    }

    IEnumerator RewindTimeToStart()
    {
        bool oldTime = time;
        int counter = 0;
        int RewindSpeed = 1;

        for (int i = 0; i < rewindFrames.Count; i = i + RewindSpeed)
        {
            counter++;
            yield return new WaitForEndOfFrame();

            if (oldTime != rewindFrames[i].Time)
            {
                portalManager.SwitchTime();
            }

            transform.position = new Vector2(rewindFrames[i].X, rewindFrames[i].Y);
            oldTime = rewindFrames[i].Time;

            if (counter % 20 == 0)
            {
                RewindSpeed++;
            }
        }

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    IEnumerator AddFrame()
    {
        while (true)
        {
            yield return new WaitForEndOfFrame();
            if (portalManager == null)
            {
                time = false;
            }
            else
            {
                time = portalManager.time;
            }
            rewindFrames.Add(new RewindFrame(transform.position.x, transform.position.y, time));
        }
    }
}
