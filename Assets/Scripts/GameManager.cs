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
    int max_enemies;
    [SerializeField]
    float spawn_enemy_timer,spawn_pickup_timer,destroy_delta;

    bool spawned;
    int  enemies;

    Player player;

    private void Start()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
        player = FindObjectOfType<Player>();
        StartCoroutine(SpawnPickup());
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
            int idx = Random.Range(0,enemy_prefabs.Length);
            Instantiate(enemy_prefabs[idx]);
            enemies++;
            StartCoroutine(LockSpawn());
        }
    }

    IEnumerator SpawnPickup()
    {
        while (true)
        {
            int idx = Random.Range(0, pickup_prefabs.Length);
            Instantiate(pickup_prefabs[idx]);
            yield return new WaitForSeconds(spawn_pickup_timer);
        }
        
    }

    IEnumerator LockSpawn()
    {
        spawned = true;
        yield return new WaitForSeconds(spawn_enemy_timer);
        spawned = false;
    }

    public bool PastPlayer(GameObject go)
    {
        if(go.transform.position.x < player.transform.position.x-destroy_delta)
        {
            if (go.CompareTag("Enemy"))
                enemies--;
            return true;
        }
        return false;
    }
}
