using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace ClothStore
{
    public class OutfitItem : MonoBehaviour
    {
        [SerializeField] private Image _mainImage;
        [SerializeField] private Button _buttonSelect;
        [SerializeField] private Button _buttonBuy;
        [SerializeField] private Button _buttonSell;
        [SerializeField] private Image _selectIcon;
        [SerializeField] private TMP_Text _textPrice;
        [SerializeField] private TMP_Text _textCount;
        [SerializeField] private Image _disableOverlay;
        [SerializeField] private Image _frame;
        [SerializeField] private Color _selectColor;
        public OutfitData Data { get; private set; }
        private Action<OutfitItem> _onChoose;

        public void initItem(OutfitData data, int count, Action<OutfitItem> onSelectCallback, Action<OutfitItem> onBuy, Action<OutfitItem> onSell)
        {
            Data = data;
            _onChoose = onSelectCallback;
            
            _mainImage.sprite = data.sprite;
            _textPrice.text = data.price.ToString();
            _selectIcon.gameObject.SetActive(false);
            updateCount(count);
                
            _buttonSelect.onClick.AddListener(() =>
            {
                select();
                onSelectCallback?.Invoke(this);
            });
            _buttonBuy.onClick.AddListener(() => onBuy?.Invoke(this));
            _buttonSell.onClick.AddListener(() => onSell?.Invoke(this));
        }

        public void updateCount(int count)
        {
            _textCount.text = count.ToString();
            setEnable(count > 0);
        }
        
        public void deselect()
        {
            _selectIcon.gameObject.SetActive(false);
            _frame.color = Color.white;
        }

        public void select()
        {
            _selectIcon.gameObject.SetActive(true);
            _frame.color = _selectColor;
        }

        public void setEnable(bool isEnabled)
        {
            _disableOverlay.gameObject.SetActive(!isEnabled);
            _buttonSelect.interactable = isEnabled;
        }


        void Start()
        {
        
        }
    }
}
