using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ClothStore
{
    public class BalanceManager
    {
        private static BalanceManager s_Instance;

        public static BalanceManager Instance
        {
            get
            {
                if (s_Instance == null)
                {
                    s_Instance = new BalanceManager();
                }

                return s_Instance;
            }
        }

        #region Balance

        public uint CurrentCoin { get; private set; } = Constant.INIT_COIN;
        public void increaseCoin(uint amount)
        {
            CurrentCoin += amount;
        }

        public bool useCoin(uint amount)
        {
            if (CurrentCoin < amount)
            {
                return false;
            }
            CurrentCoin -= amount;
            return true;
        }
        #endregion
    }
}
