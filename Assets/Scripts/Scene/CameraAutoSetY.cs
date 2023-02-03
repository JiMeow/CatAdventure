using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraAutoSetY : MonoBehaviour
{
    float cameeraStartX;
    float playerStartX;
    GameObject player;
    void Start()
    {
        player = GameObject.Find("Player");
        playerStartX = player.transform.position.x;
        cameeraStartX = transform.position.x;
    }
    
    void Update()
    {
        float playerX = player.transform.position.x;
        float cameraX = transform.position.x;
        float diff = playerX - playerStartX;
        transform.position = new Vector3(cameeraStartX + diff, transform.position.y, transform.position.z);
    }
}
