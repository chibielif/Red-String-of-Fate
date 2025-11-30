using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoThroughGate : MonoBehaviour
{
    [SerializeField] int nextSceneIndex;
    private float _levelLoadDelay = 0.5f;
    private bool _hasPassed = false;
    
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !_hasPassed)
        {
            //when we change a scene we need to fade the string
            _hasPassed = true;
            FindFirstObjectByType<GameManager>().ProcessStringVisibility();
            StartCoroutine(LoadNextScene());
        }
    }

    IEnumerator LoadNextScene()
    {
        yield return new WaitForSecondsRealtime(_levelLoadDelay);
        SceneManager.LoadScene(nextSceneIndex);
    }
}
