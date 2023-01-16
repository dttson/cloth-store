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
        
        void Awake()
        {
            _spriteResolvers = GetComponentsInChildren<SpriteResolver>();
            foreach (var spriteResolver in _spriteResolvers)
            {
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
                var spriteResolver = _dictSpriteResolvers[category];
                spriteResolver.SetCategoryAndLabel(category, label);
            }
        }
    }
}