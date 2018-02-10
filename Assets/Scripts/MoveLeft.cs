using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeft : MonoBehaviour {

    [SerializeField]
    float scroll_speed;

    private void Start()
    {
    }

    private void Update()
    {
        transform.Translate(scroll_speed * new Vector3(-1,0,0) * Time.deltaTime);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Bound"))
        {
            GameManager.instance.RemoveFromCount(gameObject);
            Destroy(gameObject);
        }
    }
}
