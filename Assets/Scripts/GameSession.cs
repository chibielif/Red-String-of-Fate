using Tangram;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameSession : MonoBehaviour
{
    [SerializeField] int stringVisibility = 3;
    [SerializeField] Slider stringVisibilitySlider;
    [SerializeField] Image winScreen;
    [SerializeField] private RectTransform tangramPanel;
    
    private int maxStringVisibility = 3;
    
    bool redStringVisibility = true;
    
    
    void Awake()
    {
        int numGameSessions = FindObjectsByType<GameSession>(FindObjectsSortMode.None).Length;
        if (numGameSessions > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
            SceneManager.sceneLoaded += OnSceneLoaded;
        }
        winScreen.gameObject.SetActive(false);
        tangramPanel.gameObject.SetActive(false);
    }

    void Start()
    {
        stringVisibilitySlider.maxValue = maxStringVisibility;
        stringVisibilitySlider.value = maxStringVisibility;
    }
    

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        //her sahnede stringin visible olup olmadığını kontrol edip uyguluyoruz
        ApplyStringState();
    }

    //bu metodu love-refill durumunda çağırarak güncelle
    void SetRedStringVisibility(bool visible)
    {
        if(redStringVisibility == visible) return;
        redStringVisibility = visible;
        ApplyStringState();
    }
    

    // bir sahneden diğerine geçişte bu metod çağırılarak stringvisibility duruma göre güncellenir
    public void ProcessStringVisibility()
    {
        if (stringVisibility > 1)
        {
            FadeString();
        }
        else
        {
            DisableString();
        }
    }
    

    void FadeString()
    {
        //TODO:make the color of the string lighter? if possible
        
        //reduce string visibility on the slider 
        stringVisibility--;
        stringVisibilitySlider.value = stringVisibility;
    }

    void DisableString()
    {
        stringVisibility--;
        stringVisibilitySlider.value = stringVisibility;
        SetRedStringVisibility(false);
    }

    public void RefillStringVisibility()
    {
        stringVisibility = maxStringVisibility;
        stringVisibilitySlider.value = maxStringVisibility;
        SetRedStringVisibility(true);
    }

    private void ApplyStringState()
    {
        var redString = FindFirstObjectByType<RedString>(FindObjectsInactive.Include);
        if (redString != null)
        {
            redString.gameObject.SetActive(redStringVisibility);
        }
    }
    

    public void WinGame()
    {
        winScreen.gameObject.SetActive(true);

    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void LoadTangram()
    {
        tangramPanel.gameObject.SetActive(true);
        var player = FindFirstObjectByType<PlayerMovement>(FindObjectsInactive.Include);
        if (player) player.SetFrozen(true);
        //SetPlayer(false);
    }

    public void CloseTangram()
    {
        RefillStringVisibility();
        tangramPanel.gameObject.SetActive(false);
        var player = FindFirstObjectByType<PlayerMovement>(FindObjectsInactive.Include);
        if(player) player.SetFrozen(false);
        FindFirstObjectByType<TangramManager>(FindObjectsInactive.Include).ResetTangram();
        //SetPlayer(true);
    }
    

    public string GetCurrentSceneName()
    {
        return SceneManager.GetActiveScene().name;
    }
}
