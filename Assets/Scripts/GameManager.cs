using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CharacterController = ClothStore.Character.CharacterController;

namespace ClothStore
{
    public class GameManager : MonoBehaviour
    {
        #region Singleton

        private static GameManager s_Instance;
        public static GameManager Instance
        {
            get
            {
                if (s_Instance == null)
                {
                    s_Instance = FindObjectOfType<GameManager>();
                }

                return s_Instance;
            }
        }

        #endregion

        #region Public functions

        public Bounds getGameWorldBounds()
        {
            //TODO: Should calculate the real game world bounds later if the world larger than camera view
            var result = new Bounds();
            if (_camera == null)
            {
                return result;
            }
            
            result.center = Vector3.zero;

            var camHeight = _camera.orthographicSize;
            var camWidth = camHeight * _camera.aspect;
            result.extents = new Vector3(camWidth, camHeight, 0f);
            return result;
        }

        #endregion

        public GameUIManager UIManager => _gameUIManager;
        
        [SerializeField] private GameUIManager _gameUIManager;
        [SerializeField] private CharacterController _character;
        [SerializeField] private Camera _camera;

        void Awake()
        {
            if (s_Instance != null && s_Instance != this)
            {
                Destroy(gameObject);
                return;
            }
            
            s_Instance = this;
            DontDestroyOnLoad(gameObject);
            Application.targetFrameRate = 60;
        }
        
        void Start()
        {
            initCharacter();
            initObjects();
        }

        private void initCharacter()
        {
            _character.onHitOtherObject += onCharacterHitObject;
        }

        private void onCharacterHitObject(GameObject obj)
        {
            if (obj.CompareTag(TagConstant.TAG_SHOPKEEPER))
            {
                _gameUIManager.showShopPopup();
            }
        }

        private void initObjects()
        {
            
        }
    }
}
