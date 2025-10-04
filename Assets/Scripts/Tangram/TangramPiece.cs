using UnityEngine;
using UnityEngine.EventSystems;

namespace Tangram
{
    public class TangramPiece : MonoBehaviour, IBeginDragHandler, IDragHandler,IEndDragHandler
    {
        private AudioPlayer _audioPlayer;
        private Vector2 _originalPosition;
        private bool _isPlaced = false;
        [SerializeField] private TangramSlot tangramSlot;

        private RectTransform _rect;
        private Transform _originalParent;

        public bool GetIsPlaced()
        {
            return _isPlaced;
        }
        
        public void SetIsPlaced(bool value)
        {
            _isPlaced = value;
        }

        private void Awake()
        {
            _rect = (RectTransform)transform;
            _audioPlayer = FindFirstObjectByType<AudioPlayer>();
            _originalPosition = transform.position;
        }

        public void OnBeginDrag(PointerEventData eventData)
        {
            if (_isPlaced) return;
            _audioPlayer.PlayPickUpClip();
        
            // parçanın en üstte durmasını sağlamak için
            _originalParent = _rect.parent;
            _rect.SetAsLastSibling();
        }

        public void OnDrag(PointerEventData eventData)
        {
            if (_isPlaced) return;
            transform.position = eventData.position;
        }

        public void OnEndDrag(PointerEventData eventData)
        {
            if (_isPlaced) return;
            if (Vector2.Distance(transform.position, tangramSlot.transform.position) < 30f)
            {
                transform.position = tangramSlot.transform.position;
                _isPlaced = true;
            }
            else
            {
                _audioPlayer.PlayDropClip();
                transform.position = _originalPosition;
            }
        
            _rect.SetParent(_originalParent, true);
        }

        public void ResetPosition()
        {
            transform.position = _originalPosition;
        }
    }
}
