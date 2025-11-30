using Tangram;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class GameManager : MonoBehaviour
{
    [SerializeField] int stringVisibility = 3;
    [SerializeField] Slider stringVisibilitySlider;
    [SerializeField] Image winScreen;
    
    private TangramGameManager tangramPanel;
    
    private int maxStringVisibility = 3;
    
    bool redStringVisibility = true;
    
    
    void Awake()
    {
        int numGameSessions = FindObjectsByType<GameManager>(FindObjectsSortMode.None).Length;
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
        
    }

    void Start()
    {
        tangramPanel = FindFirstObjectByType<TangramGameManager>(FindObjectsInactive.Include);
        tangramPanel.gameObject.SetActive(false);
        
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
        var player = FindFirstObjectByType<PlayerMovement>(FindObjectsInactive.Include);
        player.SetFrozen(true);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void LoadTangram()
    {
        if (tangramPanel == null)
        {
            tangramPanel = FindFirstObjectByType<TangramGameManager>(FindObjectsInactive.Include);
            if (tangramPanel == null) return;
        }
        tangramPanel.gameObject.SetActive(true);
        var player = FindFirstObjectByType<PlayerMovement>(FindObjectsInactive.Include);
        if (player) player.SetFrozen(true);
    }

    public void CloseTangram()
    {
        RefillStringVisibility();
        FindFirstObjectByType<TangramGameManager>(FindObjectsInactive.Include).ResetTangram();
        tangramPanel.gameObject.SetActive(false);
        var player = FindFirstObjectByType<PlayerMovement>(FindObjectsInactive.Include);
        if(player) player.SetFrozen(false);
        //SetPlayer(true);
    }
    

    public string GetCurrentSceneName()
    {
        return SceneManager.GetActiveScene().name;
    }
}
