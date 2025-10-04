using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    private MainScreen _mainScreen;
    private StoryScreen _storyScreen;
    private TutorialScreen _tutorialScreen;

    void Start()
    {
        _mainScreen = FindFirstObjectByType<MainScreen>();
        _storyScreen = FindFirstObjectByType<StoryScreen>();
        _tutorialScreen = FindFirstObjectByType<TutorialScreen>();
        
        _mainScreen.gameObject.SetActive(true);
        _storyScreen.gameObject.SetActive(false);
        _tutorialScreen.gameObject.SetActive(false);
    }
    public void LoadGame()
    {
        SceneManager.LoadScene("Scene1");
    }

    public void LoadStoryScreen()
    {
        _mainScreen.gameObject.SetActive(false);
        _storyScreen.gameObject.SetActive(true);
    }
    
    public void LoadTutorialScreen()
    {
        _storyScreen.gameObject.SetActive(false);
        _tutorialScreen.gameObject.SetActive(true);
    }
    
}
