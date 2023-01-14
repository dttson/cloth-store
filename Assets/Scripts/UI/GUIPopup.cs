using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace ClothStore
{
    public class GUIPopup: MonoBehaviour
    {
        public class GUIButtonData
        {
            public string text;
            public Action callback;

            public GUIButtonData(string text, Action callback)
            {
                this.text = text;
                this.callback = callback;
            }

            public GUIButtonData(string text)
            {
                this.text = text;
            }
        }
        
        [SerializeField] private TMP_Text _titleText;
        [SerializeField] private TMP_Text _messageText;
        [SerializeField] private RectTransform _buttonContainer;
        [SerializeField] private Button[] _actionButtons;
        
        public void show(string title, string message, List<GUIButtonData> buttonData)
        {
            gameObject.SetActive(true);
            _titleText.text = title;
            _messageText.text = message;

            var btnCount = Mathf.Min(_actionButtons.Length, buttonData.Count);
            for (int i = 0; i < btnCount; i++)
            {
                var btn = _actionButtons[i]; 
                var text = btn.GetComponentInChildren<TMP_Text>();
                text.text = buttonData[i].text;
                btn.onClick.RemoveAllListeners();
                var i1 = i;
                btn.onClick.AddListener(() => buttonData[i1].callback?.Invoke());
            }
            
            //TODO: Should add more button on UI if buttons.length > ui buttons
        }

        public void hide()
        {
            gameObject.SetActive(false);
        }

        private void Awake()
        {
            if (_actionButtons.Length == 0)
            {
                _actionButtons = _buttonContainer.GetComponentsInChildren<Button>();
            }
        }

        void Start()
        {
            
        }
    }
}