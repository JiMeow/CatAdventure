using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MushroomControll : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "AttackArea")
        {
            GameObject tomb = Resources.Load("TombGround") as GameObject;
            GameObject newTomb = Instantiate(tomb, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.name == "AttackArea")
        {
            GameObject tomb = Resources.Load("TombGround") as GameObject;
            GameObject newTomb = Instantiate(tomb, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
