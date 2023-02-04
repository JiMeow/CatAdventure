using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraAutoSetY : MonoBehaviour
{
    public bool followX;
    public bool followY;

    float cameraStartX;
    float cameraStartY;
    float playerStartX;
    float playerStartY;
    GameObject player;
    void Start()
    {
        player = GameObject.Find("Player");
        playerStartX = player.transform.position.x;
        cameraStartX = transform.position.x;
        playerStartY = player.transform.position.y;
        cameraStartY = transform.position.y;
    }
    
    void Update()
    {
        if (followX)
            FollowX();
        if (followY)
            FollowY();
    }

    void FollowX()
    {
        float playerX = player.transform.position.x;
        float cameraX = transform.position.x;
        float diff = playerX - playerStartX;
        transform.position = new Vector3(cameraStartX + diff, transform.position.y, transform.position.z);
    }

    void FollowY()
    {
        float playerY = player.transform.position.y;
        float cameraY = transform.position.y;
        float diff = playerY - playerStartY;
        transform.position = new Vector3(transform.position.x, cameraStartY + diff, transform.position.z);
    }
}
