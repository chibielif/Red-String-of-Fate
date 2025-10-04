using System;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class LoveRefill : MonoBehaviour
{
    private GameSession _gameSession;

    private void Awake()
    {
        _gameSession = FindFirstObjectByType<GameSession>();
    }
    


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Player") || _gameSession.GetCurrentSceneName() != "Scene6") return;
        _gameSession.LoadTangram();
    }
    
}
