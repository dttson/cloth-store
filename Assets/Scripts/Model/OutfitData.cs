using System;
using UnityEngine;

namespace ClothStore
{
    [CreateAssetMenu(fileName = "OutfitData", menuName = "Outfit Data", order = 51)]
    [Serializable]
    public class OutfitData : ScriptableObject
    {
        public OutfitConstant.OutfitPart part;
        public uint price;
        public SkinItemData[] skinData;
        public Sprite sprite;

        public bool isSame(OutfitData other)
        {
            if (other.part != part || other.price != price || other.skinData.Length != skinData.Length || other.sprite != sprite)
            {
                return false;
            }

            for (int i = 0; i < skinData.Length; i++)
            {
                if (!skinData[i].isSame(other.skinData[i]))
                {
                    return false;
                }
            }

            return true;
        }
    }
    
    [Serializable]
    public class SkinItemData
    {
        public OutfitConstant.SkinCategory category;
        public OutfitConstant.SkinLabel label;

        public bool isSame(SkinItemData other)
        {
            return other.category == category && other.label == label;
        }
    }
}