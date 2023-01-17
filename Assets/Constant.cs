namespace ClothStore
{
    public class Constant
    {
        public const int INIT_COIN = 1000;
    }

    public class OutfitConstant
    {
        public enum OutfitSet
        {
            CUSTOM,
            BUSINESS_MAN1,
            BUSINESS_MAN2,
            BUSINESS_MAN3,
        }

        public enum OutfitPart
        {
            Shirt, Pants
        }

        public enum SkinCategory
        {
            Body, LeftHand, RightHand, LeftFoot, RightFoot,
            Body_B, LeftHand_B, RightHand_B, LeftFoot_B, RightFoot_B,
        }
        
        
        public enum SkinLabel
        {
            Entry, Entry_0, Entry_1
        }
    }

    public class TagConstant
    {
        public const string TAG_SHOPKEEPER = "ShopKeeper";
    }
}