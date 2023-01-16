using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using UnityEngine;

namespace ClothStore
{
    
    [Serializable]
    public class OutfitSetData
    {
        public OutfitConstant.OutfitSet outfitSet;
        public OutfitData shirt;
        public OutfitData pants;

        public OutfitSetData clone()
        {
            return new OutfitSetData()
            {
                outfitSet = this.outfitSet,
                shirt = this.shirt,
                pants = this.pants
            };
        }

        public bool isSameShirt(OutfitData otherShirt)
        {
            return shirt.isSame(otherShirt);
        }
        
        public bool isSamePants(OutfitData otherPants)
        {
            return pants.isSame(otherPants);
        }
    }
}
