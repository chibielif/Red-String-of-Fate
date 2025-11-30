using UnityEngine;

public class WinScreen : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            //display win screen
            FindFirstObjectByType<GameManager>().WinGame();
        }
    }

}
