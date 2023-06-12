using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CuttingCounter : BaseCounter
{

    public event EventHandler<OnProgressChangedArgs> OnProgressChanged;
    public class OnProgressChangedArgs : EventArgs
    {
        public float normalizedProgress;
    }

    [SerializeField] CuttingRecipeSO[] cuttingRecipes;
    private float cuttingProgress;


    public override void Interact(Player player)
    {
        if (!HasKitchenObject())
        {
            if (player.HasKitchenObject())
            {
                if (IsValidObjectToInteract(player.GetKitchenObject().GetKitchenObjectSO()))
                {
                    cuttingProgress = 0;

                    CuttingRecipeSO objetCuttingRecipe = GetCuttingRecipeFromInput(GetKitchenObject().GetKitchenObjectSO());

                    OnProgressChanged?.Invoke(this, new OnProgressChangedArgs
                    {
                        normalizedProgress = (float)cuttingProgress / objetCuttingRecipe.cuttingProgressMax
                    });
                    player.GetKitchenObject().SetKitchenObjectParent(this);
                }
            }
        }
        else
        {
            if (!player.HasKitchenObject())
            {
                GetKitchenObject().SetKitchenObjectParent(player);
            }
        }
    }

    public override void AltInteract(Player player)
    {
        if (HasKitchenObject() && IsValidObjectToInteract(GetKitchenObject().GetKitchenObjectSO()))
        {
            cuttingProgress++;
            CuttingRecipeSO objetCuttingRecipe = GetCuttingRecipeFromInput(GetKitchenObject().GetKitchenObjectSO());

            OnProgressChanged?.Invoke(this, new OnProgressChangedArgs
            {
                normalizedProgress = (float)cuttingProgress / objetCuttingRecipe.cuttingProgressMax
            });

            if (objetCuttingRecipe.cuttingProgressMax <= cuttingProgress)
            {
                KitchenObjectSO outputKitchenObject = GetOutputFromInput(GetKitchenObject().GetKitchenObjectSO());

                GetKitchenObject().DestroySelf();
                KitchenObject.SpawnKitchenObject(outputKitchenObject, this);
            }
        }
    }


    public KitchenObjectSO GetOutputFromInput(KitchenObjectSO input)
    {
        CuttingRecipeSO cuttingRecipeSO = GetCuttingRecipeFromInput(input);
        if (cuttingRecipeSO != null)
        {
            return cuttingRecipeSO.output;
        }
        else
        {
            return null;
        }
    }


    private bool IsValidObjectToInteract(KitchenObjectSO input)
    {
        return GetOutputFromInput(input) != null;
    }


    private CuttingRecipeSO GetCuttingRecipeFromInput(KitchenObjectSO input)
    {
        foreach (CuttingRecipeSO recipe in cuttingRecipes)
        {
            if (recipe.input == input)
            {
                return recipe;
            }
        }
        return null;
    }
}
