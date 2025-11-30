using System;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class LoveRefill : MonoBehaviour
{
    private GameManager _gameManager;

    private void Awake()
    {
        _gameManager = FindFirstObjectByType<GameManager>();
    }
    
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Player")) return;
        _gameManager.LoadTangram();
    }
    
}
