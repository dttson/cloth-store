using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.U2D.Animation;

public class OutfitController : MonoBehaviour
{
    [SerializeField] private SpriteResolver[] _spriteResolvers;

    void Awake()
    {
        _spriteResolvers = GetComponentsInChildren<SpriteResolver>();
    }

    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.LeftShift) && Input.GetKeyUp(KeyCode.G))
        {
            foreach (var spriteResolver in _spriteResolvers)
            {
                var category = spriteResolver.GetCategory();
                var currentLabel = spriteResolver.GetLabel();
                var allLabels = spriteResolver.spriteLibrary.spriteLibraryAsset.GetCategoryLabelNames(category)
                    .ToList();

                int currentIdx = allLabels.IndexOf(currentLabel);
                int nextIdx = (currentIdx + 1) % allLabels.Count;
                spriteResolver.SetCategoryAndLabel(category, allLabels[nextIdx]);
            }
        }
    }
}
