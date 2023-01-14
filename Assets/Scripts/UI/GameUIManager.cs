using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ClothStore
{
    public class GameUIManager : MonoBehaviour
    {
        [SerializeField] private GUIPopup _popup;
        [SerializeField] private ShopUIPopup _shopUIPopup;

        public bool isAnyUIOpen()
        {
            return _popup.gameObject.activeSelf || _shopUIPopup.gameObject.activeSelf;
        }

        public void showConfirmPopup(string title, string message, Action onOK, Action onCancel)
        {
            _popup.show(title, message, new List<GUIPopup.GUIButtonData>() {new ("OK", onOK), new ("Cancel")});
        }

        public void showInfoPopup(string title, string message)
        {
            _popup.show(title, message, new List<GUIPopup.GUIButtonData>() {new ("OK")});
        }

        public void showShopPopup()
        {
            _shopUIPopup.gameObject.SetActive(true);
        }
        
        void Start()
        {
            _popup.gameObject.SetActive(false);
            _shopUIPopup.gameObject.SetActive(false);
        }

        // Update is called once per frame
        void Update()
        {
        
        }
    }
}
