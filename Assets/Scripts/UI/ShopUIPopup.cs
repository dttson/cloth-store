using System;
using System.Collections.Generic;
using System.Linq;
using ClothStore.Character;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace ClothStore
{
    public class ShopUIPopup: MonoBehaviour
    {
        [SerializeField] private OutfitChanger _outfitChanger;
        [SerializeField] private Button _closeButton;
        [SerializeField] private Button _saveButton;
        [SerializeField] private TMP_Text _balanceText;
        [SerializeField] private OutfitItem _outfitItem;
        [SerializeField] private RectTransform[] _containers;
        [SerializeField] private Toggle[] _tabButtons;
        [Header("Data")]
        [SerializeField] private OutfitData[] _shirtData;
        [SerializeField] private OutfitData[] _pantsData;


        private List<OutfitItem> _shirtOutfitItems = new();
        private List<OutfitItem> _pantsOutfitItems = new();
        void Start()
        {
            _closeButton.onClick.AddListener(onClosePopup);
            _saveButton.onClick.AddListener(onSave);
            updateBalance();
            initShirtItems();
            initPantsItems();
            initTabButtons();
            initOutfit();
        }

        private void updateBalance()
        {
            _balanceText.text = BalanceManager.Instance.CurrentCoin.ToString();
        }

        private void initOutfit()
        {
            _outfitChanger.updateOutfitSet(GameManager.Instance.OutfitControl.CurrentOutfit);
        }

        private void initShirtItems()
        {
            var container = _containers[0];
            var outfitController = GameManager.Instance.OutfitControl;
            var currentShirt = outfitController.CurrentOutfit.shirt;
            foreach (var shirtData in _shirtData)
            {
                var item = Instantiate(_outfitItem, container);
                var count = outfitController.getOutfitCount(shirtData);
                item.initItem(shirtData, count, onChooseOutfit, onBuyOutfit, onSellOutfit);
                if (shirtData == currentShirt)
                {
                    item.select();
                }
                _shirtOutfitItems.Add(item);
            }
        }

        private void initPantsItems()
        {
            var container = _containers[1];
            var outfitController = GameManager.Instance.OutfitControl;
            var currentPants = outfitController.CurrentOutfit.pants;
            foreach (var pantsData in _pantsData)
            {
                var item = Instantiate(_outfitItem, container);
                var count = outfitController.getOutfitCount(pantsData);
                item.initItem(pantsData, count, onChooseOutfit, onBuyOutfit, onSellOutfit);
                if (pantsData == currentPants)
                {
                    item.select();
                }
                _pantsOutfitItems.Add(item);
            }
        }
        
        private void onChooseOutfit(OutfitItem outfitItem)
        {
            var data = outfitItem.Data;
            _outfitChanger.updateOutfit(data);

            var items = data.part == OutfitConstant.OutfitPart.Shirt ? _shirtOutfitItems : _pantsOutfitItems;
            foreach (var item in items)
            {
                if (item.Data != data)
                {
                    item.deselect();    
                }
            }
        }
        
        private void onSellOutfit(OutfitItem outfitItem)
        {
            var data = outfitItem.Data;
            if (!GameManager.Instance.OutfitControl.sellOutfit(data))
            {
                Debug.LogError($"Cannot sell outfit {JsonUtility.ToJson(data)}");
                //TODO: Show notification
                return;
            }
            updateBalance();

            var count = GameManager.Instance.OutfitControl.getOutfitCount(data);
            outfitItem.updateCount(count);
        }

        private void onBuyOutfit(OutfitItem outfitItem)
        {
            var data = outfitItem.Data;
            if (!GameManager.Instance.OutfitControl.buyOutfit(data))
            {
                Debug.LogError($"Cannot buy outfit {JsonUtility.ToJson(data)}");
                //TODO: Show notification
                return;
            }
            updateBalance();
            
            var count = GameManager.Instance.OutfitControl.getOutfitCount(data);
            outfitItem.updateCount(count);
        }

        private void initTabButtons()
        {
            for (int i = 0; i < _tabButtons.Length; i++)
            {
                var button = _tabButtons[i];
                var i1 = i;
                button.onValueChanged.AddListener((isOn) =>
                {
                    if (isOn)
                    {
                        loadContainer(i1);     
                    }
                });
            }
        }

        private void loadContainer(int index)
        {
            for (int i = 0; i < _containers.Length; i++)
            {
                _containers[i].gameObject.SetActive(i == index);
            }
        }
        
        private void onSave()
        {
            gameObject.SetActive(false);
            GameManager.Instance.OutfitControl.updateOutfitSet(_outfitChanger.CurrentOutfit);
        }

        private void onClosePopup()
        {
            gameObject.SetActive(false);
        }
    }
}