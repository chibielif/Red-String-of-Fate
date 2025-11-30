using UnityEngine;

namespace Tangram
{
    public class TangramGameManager : MonoBehaviour
    {
        [SerializeField] TangramDraggable [] pieces = new TangramDraggable[9];
        GameManager _gameManager;

        private void Awake()
        {
            _gameManager = FindFirstObjectByType<GameManager>();
        }

        private void Update()
        {
            CheckTangramWin();
        }

        //if all tangram pieces are placed returns true, else false
        private void CheckTangramWin()
        {
            int allPiecesPlaced = 0;
            for (int i = 0; i < pieces.Length; i++)
            {
                if (pieces[i].GetIsPlaced())
                {
                    allPiecesPlaced++;
                }
            }

            if (allPiecesPlaced == pieces.Length)
            {
                _gameManager.CloseTangram();
            }
            else return;
        }

        public void ResetTangram()
        {
            for (int i = 0; i < pieces.Length; i++)
            {
                pieces[i].SetIsPlaced(false);
                pieces[i].ResetPosition();
            }
        }
    } 
}

