using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public static GameManager instance;

    Player player;

    private void Start()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
        player = FindObjectOfType<Player>();
    }

    public void UseSwipeInput(Dir swipe)
    {
        player.DoSwipeAction(swipe);
    }
}
