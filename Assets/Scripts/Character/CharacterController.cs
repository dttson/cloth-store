using System;
using UnityEngine;

// ReSharper disable CheckNamespace

namespace ClothStore.Character
{
    public class CharacterController : MonoBehaviour
    {
        public event Action<GameObject> onHitOtherObject;
        
        [SerializeField] private float _moveSpeed = 1f;
        [SerializeField] private BoxCollider2D _boxCollider;

        private float xMin, xMax;
        private float yMin, yMax;

        void Start()
        {
            var characterSize = _boxCollider.size;
            var worldBounds = GameManager.Instance.getGameWorldBounds();
            xMin = worldBounds.min.x + characterSize.x / 2;
            xMax = worldBounds.max.x - characterSize.x / 2;
            
            yMin = worldBounds.min.y + characterSize.y / 2;
            yMax = worldBounds.max.y - characterSize.y / 2;
        }

        void Update()
        {
            if (GameManager.Instance.UIManager.isAnyUIOpen())
            {
                return;
            }
            
            var direction = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")).normalized;
            direction *= _moveSpeed * Time.deltaTime;

            var newPosition = transform.position;
            newPosition.x = Mathf.Clamp(newPosition.x + direction.x, xMin, xMax);
            newPosition.y = Mathf.Clamp(newPosition.y + direction.y, yMin, yMax);
            transform.position = newPosition;
        }
        
        void OnTriggerEnter2D(Collider2D col)
        {
            onHitOtherObject?.Invoke(col.gameObject);
        }
    }
}