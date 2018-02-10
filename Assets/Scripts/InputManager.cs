using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Dir
{
    None,
    Up,
    Down,
    Left,
    Right
}

public class InputManager : MonoBehaviour {

    bool swipe;
    Vector3 swipe_start_pos,swipe_end_pos;
    float min_swipe_length;



    private void Update()
    {
        if(Input.touchCount==1)
        {
            if (!swipe && Input.GetTouch(0).phase == TouchPhase.Began)
            {
                swipe = true;
                swipe_start_pos = Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position);
            }
            else if(swipe && Input.GetTouch(0).phase == TouchPhase.Ended)
            {
                swipe = false;
                swipe_end_pos= Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position);
                Dir dir = CalcSwipeDir();
                if (dir != Dir.None)
                    GameManager.instance.UseSwipeInput(dir);
            }
        }
    }

    Dir CalcSwipeDir()
    {
        float deltaX = swipe_end_pos.x - swipe_start_pos.x;
        float deltaY = swipe_end_pos.y - swipe_start_pos.y;
        if(Mathf.Abs(deltaX)> Mathf.Abs(deltaY))
        {
            if (Mathf.Abs(deltaX) < min_swipe_length)
                return Dir.None;
            if (deltaX > 0)
                return Dir.Right;
            return Dir.Left;
        }
        else
        {
            if (Mathf.Abs(deltaY) < min_swipe_length)
                return Dir.None;
            if (deltaY > 0)
                return Dir.Up;
            return Dir.Down;
        }
    }
}
