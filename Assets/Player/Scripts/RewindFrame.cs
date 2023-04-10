using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RewindFrame
{
    public RewindFrame(float x, float y, bool time) 
    { 
        X = x;
        Y = y;
        Time = time;
    }
    public float X;
    public float Y;
    public bool Time;
}
