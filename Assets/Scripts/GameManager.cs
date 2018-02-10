using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Object
{
    Enemy,
    Pickup
}

public class GameManager : MonoBehaviour {

    public static GameManager instance;

    [SerializeField]
    GameObject[] pickup_prefabs,enemy_prefabs;
    [SerializeField]
    int max_pickups, max_enemies;
    [SerializeField]
    float spawn_timer,destroy_delta;

    bool spawned;
    int pickups, enemies;

    Player player;

    private void Start()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
        player = FindObjectOfType<Player>();
    }

    private void Update()
    {
        Spawn();
    }

    public void UseSwipeInput(Dir swipe)
    {
        player.DoSwipeAction(swipe);
    }

    public void Spawn()
    {
        if (spawned)
            return;
        if (enemies < max_enemies)
        {
            int idx = Random.Range(0,enemy_prefabs.Length-1);
            Instantiate(enemy_prefabs[idx]);
            enemies++;
            StartCoroutine(LockSpawn());
            return;
        }
        if (pickups < max_pickups)
        {
            int idx = Random.Range(0, pickup_prefabs.Length - 1);
            Instantiate(pickup_prefabs[idx]);
            pickups++;
            StartCoroutine(LockSpawn());
            return;
        }
    }

    IEnumerator LockSpawn()
    {
        spawned = true;
        yield return new WaitForSeconds(spawn_timer);
        spawned = false;
    }

    public bool PastPlayer(GameObject go)
    {
        if(go.transform.position.x < player.transform.position.y-destroy_delta)
        {
            if (go.CompareTag("Enemy"))
                enemies--;
            else if (go.CompareTag("Pickup"))
                pickups--;
            return true;
        }
        return false;
    }
}
