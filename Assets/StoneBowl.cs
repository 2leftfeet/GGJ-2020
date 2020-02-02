using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum StoneColor
{
    Pink,
    Red,
    Blue,
    Orange
};

public class StoneBowl : MonoBehaviour
{
    public StoneColor color;

    public bool filled = false;

    void OnTriggerStay(Collider col) {
        var ball = col.gameObject.GetComponent<StoneBall>();
        if (ball)
        {
            if(ball.color == color)
            {
                filled = true;
            }
        }
    }

    void OnTriggerExit(Collider col)
    {
        var ball = col.gameObject.GetComponent<StoneBall>();
        if (ball)
        {
            if (ball.color == color)
            {
                filled = false;
            }
        }
    }
}
