using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D.Animation;

namespace ClothStore.Character
{
    public class OutfitChanger: MonoBehaviour
    {
        [SerializeField] private SpriteResolver[] _spriteResolvers;
        [field: SerializeField] public OutfitSetData CurrentOutfit { get; private set; }
        private readonly Dictionary<string, SpriteResolver> _dictSpriteResolvers = new();

        private Dictionary<string, SpriteResolver> DictSpriteResolvers
        {
            get
            {
                if (_dictSpriteResolvers.Count == 0)
                {
                    initSpriteResolvers();
                }

                return _dictSpriteResolvers;
            }
        }
        
        void Start()
        {
            initSpriteResolvers();
        }

        void OnValidate()
        {
            _spriteResolvers = GetComponentsInChildren<SpriteResolver>(true);
        }

        private void initSpriteResolvers()
        {
            if (_dictSpriteResolvers.Count > 0)
            {
                return;
            }
            
            foreach (var spriteResolver in _spriteResolvers)
            {
                Debug.Log($"===== Init sprite resolver {spriteResolver.gameObject.name} | {spriteResolver.GetCategory()}");
                _dictSpriteResolvers.Add(spriteResolver.GetCategory(), spriteResolver);
            }
        }
        
        public void updateOutfitSet(OutfitSetData data)
        {
            CurrentOutfit = data.clone();
            updateOutfit(CurrentOutfit.shirt);
            updateOutfit(CurrentOutfit.pants);
        }
    
        public void updateOutfit(OutfitData data)
        {
            if (data.part == OutfitConstant.OutfitPart.Shirt)
            {
                CurrentOutfit.shirt = data;
            }
            else
            {
                CurrentOutfit.pants = data;
            }
            foreach (var skinItemData in data.skinData)
            {
                var category = skinItemData.category.ToString();
                var label = skinItemData.label.ToString();
                if (DictSpriteResolvers.TryGetValue(category, out var spriteResolver))
                {
                    spriteResolver.SetCategoryAndLabel(category, label);
                }
            }
        }
    }
}