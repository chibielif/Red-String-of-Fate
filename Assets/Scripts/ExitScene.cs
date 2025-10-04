using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitScene : MonoBehaviour
{
    [SerializeField] string nextScene;
    [SerializeField] float levelLoadDelay = 1f;
    
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            //when we change a scene we need to fade the string
            FindFirstObjectByType<GameSession>().ProcessStringVisibility();
            StartCoroutine(LoadNextScene());
        }
        //int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
    }

    IEnumerator LoadNextScene()
    {
        yield return new WaitForSecondsRealtime(levelLoadDelay);
        SceneManager.LoadScene(nextScene);
    }
}
