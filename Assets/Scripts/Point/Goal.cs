using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Goal : MonoBehaviour
{
    bool isGoal = false;
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" && !isGoal)
        {
            isGoal = true;
            CountPlantTree.instance.CountTreeThisScene();
            SoundManager.instance.PlayGoalSound();
            GameManager.instance.FadeInBackground();
            StartCoroutine(GoalScene());
        }
    }

    IEnumerator GoalScene()
    {
        yield return new WaitForSecondsRealtime(GameManager.instance.BgFadeTime + 0.5f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
