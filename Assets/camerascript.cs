using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camerascript : MonoBehaviour
{
    public GameObject player;
    Vector3 offset;
    void Start()
    {
        offset = transform.position - player.transform.position ;
    }

    private void LateUpdate()
    {
        transform.position = player.transform.position + offset ;
    }
    void Update()
    {
        
    }
}
