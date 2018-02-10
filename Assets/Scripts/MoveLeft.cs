using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeft : MonoBehaviour {

    [SerializeField]
    float scroll_speed;

    private void Update()
    {
        transform.Translate(scroll_speed * new Vector3(-1,0,0) * Time.deltaTime);
        
    }
}
