using System;
using UnityEngine;

public class AudioPlayer : MonoBehaviour
{
    [Header("Pick Up")]
    [SerializeField] AudioClip pickUpClip;
    //Range sayesinde inspectorda sliderla sesi ayarlayabiliyoruz
    [SerializeField] [Range(0f, 1f)]float pickUpVolume = 1f;
    
    [Header("Drop")]
    [SerializeField] AudioClip dropClip;
    [SerializeField] [Range(0f, 1f)]float dropVolume = 1f;
    
    private void Awake()
    {
        ManageSingleton();
    }

    private void ManageSingleton()
    {
        int instanceCount = FindObjectsByType<AudioPlayer>(FindObjectsSortMode.None).Length;
        if (instanceCount > 1)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    //oyuncu tangram parçasını aldığında oynayacak olan ses
    public void PlayPickUpClip()
    {
        if (pickUpClip != null)
        {
            //sesi sahnede bi yere yerleştiricez, düzgün olması için kameranın positionına yerleştiriyoruz
            AudioSource.PlayClipAtPoint(pickUpClip, Camera.main.transform.position, pickUpVolume);
        }
    }
    
    //oyuncu tangram parçasını bir yere koyduğunda oynayacak olan ses
    public void PlayDropClip()
    {
        if (dropClip != null)
        {
            AudioSource.PlayClipAtPoint(dropClip, Camera.main.transform.position, dropVolume);
        }
    }
}
