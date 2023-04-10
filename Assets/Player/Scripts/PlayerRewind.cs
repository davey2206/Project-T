using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerRewind : MonoBehaviour
{
    [SerializeField] PortalManager portalManager;

    List<RewindFrame> rewindFrames = new List<RewindFrame>();
    bool time;
    bool active = false;



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

    void StartRewindTimeToStart()
    {
        active = true;
        StopAllCoroutines();
        rewindFrames.Reverse();
        GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;

        StartCoroutine(RewindTimeToStart());
    }

    IEnumerator RewindTimeToStart()
    {
        bool oldTime = time;
        foreach (var frame in rewindFrames)
        {
            yield return new WaitForEndOfFrame();

            if (oldTime != frame.Time)
            {
                portalManager.SwitchTime();
            }

            transform.position = new Vector2(frame.X, frame.Y);
            oldTime = frame.Time;
        }

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    IEnumerator AddFrame()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.025f);
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
