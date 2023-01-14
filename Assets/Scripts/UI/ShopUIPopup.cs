using System;
using UnityEngine;
using UnityEngine.UI;

namespace ClothStore
{
    public class ShopUIPopup: MonoBehaviour
    {
        [SerializeField] private Button _closeButton;
        
        void Awake()
        {
            _closeButton.onClick.AddListener(onClosePopup);
        }

        private void onClosePopup()
        {
            gameObject.SetActive(false);
        }
    }
}