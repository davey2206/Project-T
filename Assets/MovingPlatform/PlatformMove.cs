using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMove : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] int StartingPoint;
    [SerializeField] Transform[] points;
    [SerializeField] GameObject platform;
    [SerializeField] bool moving;

    private int i;

    // Start is called before the first frame update
    void Start()
    {
        platform.transform.position = points[StartingPoint].position;
    }

    // Update is called once per frame
    void Update()
    {
        if (moving)
        {
            move();
        }
    }

    void move()
    {
        if (Vector2.Distance(platform.transform.position, points[i].position) < 0.2f)
        {
            i++;
            if (i == points.Length)
            {
                i = 0;
            }
        }

        platform.transform.position = Vector2.MoveTowards(platform.transform.position, points[i].position, speed * Time.deltaTime);
    }

    public void SwitchMoving()
    {
        moving = !moving;
    }
}
