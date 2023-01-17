using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using ClothStore;
using ClothStore.Character;
using UnityEngine;
using UnityEngine.U2D.Animation;

public class OutfitController : MonoBehaviour
{
    public OutfitSetData CurrentOutfit => _outfitChanger.CurrentOutfit;
    
    [SerializeField] private OutfitSetData _defaultOutfit;
    [SerializeField] private OutfitChanger _outfitChanger;
    
    private Dictionary<OutfitData, int> _ownOutfitData = new();

    public int getOutfitCount(OutfitData data)
    {
        _ownOutfitData.TryGetValue(data, out var count);
        return count;
    }

    public bool buyOutfit(OutfitData data)
    {
        if (!BalanceManager.Instance.useCoin(data.price))
        {
            Debug.LogError("Out of coin");
            return false;
        }

        int count = 0;
        if (_ownOutfitData.ContainsKey(data))
        {
            count = _ownOutfitData[data];
        }

        _ownOutfitData[data] = count + 1; 
        return true;
    }

    public bool sellOutfit(OutfitData data)
    {
        if (!_ownOutfitData.ContainsKey(data))
        {
            Debug.LogError($"Outfit not exist: {JsonUtility.ToJson(data)}");
            return false;
        }
        BalanceManager.Instance.increaseCoin(data.price);
        var count = _ownOutfitData[data];
        _ownOutfitData[data] = count - 1;
        if (_ownOutfitData[data] <= 0)
        {
            _ownOutfitData.Remove(data);
        }

        // if remove equipped outfit
        if (_outfitChanger.CurrentOutfit.isSameShirt(data) || _outfitChanger.CurrentOutfit.isSamePants(data))
        {
            var remainCount = _ownOutfitData[data];
            if (remainCount > 0)
            {
                updateOutfit(data);       
            }
            else
            {
                //there no shirt left in the inventory -> rollback
                _ownOutfitData.Add(data, 1);
                return false;
            }
        }
        return true;
    }
    
    public void updateOutfitSet(OutfitSetData data)
    {
        _outfitChanger.updateOutfitSet(data);
    }
    
    public void updateOutfit(OutfitData data)
    {
        _outfitChanger.updateOutfit(data);
    }

    void Awake()
    {
        _ownOutfitData.Add(_defaultOutfit.shirt, 1);
        _ownOutfitData.Add(_defaultOutfit.pants, 1);
    }

    void Start()
    {
        _outfitChanger.updateOutfitSet(_defaultOutfit);
    }
}
