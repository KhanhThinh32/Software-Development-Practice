using System;
using System.Collections.Generic;

namespace RecipeManagement.Core;

/// <summary>
/// Implement this class using the five Part A collections as private fields:
/// Dictionary&lt;int, Recipe&gt;, List&lt;string&gt;, LinkedList&lt;int&gt;,
/// Stack&lt;int&gt; and Queue&lt;string&gt;.
/// </summary>
public sealed class RecipeManager : IRecipeManager
{
        private readonly Dictionary<int, Recipe> recipes_list = new();
        private readonly List<string> shoppingList = new();
        private readonly LinkedList<int> cookingPlan = new();
        private readonly Stack<int> recipesRemove = new();
        private readonly Queue<string> instructiontionQueue = new();

    public RecipeManager(IEnumerable<Recipe> recipes)
    {
        if(recipes == null)
        {
            throw new ArgumentException(nameof(recipes));
        }

        foreach (Recipe recipe in recipes)
        {
            if (recipe == null)
            {
                throw new ArgumentException("Must contain at least 1 recipes.",nameof(recipes));
            }

            if (recipe.Id <= 0)
            {
                throw new ArgumentException("ID must be positive value.",nameof(recipes));
            }

            if (string.IsNullOrWhiteSpace(recipe.Title))
            {
                throw new ArgumentException("Recipe title can not be emty.",nameof(recipes));
            }

            if (recipes_list.ContainsKey(recipe.Id))
            {
                throw new ArgumentException("Duplicate ID.",nameof(recipes));
            }
        }
    }

    public int RecipeCount => recipes_list.Count;
    public int ShoppingItemCount => shoppingList.Count;
    public int CookingPlanCount => cookingPlan.Count;
    public int PendingInstructionCount => instructiontionQueue.Count;
    public int RemovedRecipeCount => recipesRemove.Count;

    public bool AddRecipe(Recipe recipe)
    {
        if (recipe == null)
            {
                throw new ArgumentException(nameof(recipe));
            }

            if (recipe.Id <= 0)
            {
                return false;
            }

            if (string.IsNullOrWhiteSpace(recipe.Title))
            {
                return false;
            }

            if (recipes_list.ContainsKey(recipe.Id))
            {
                return false;
            }

            recipes_list.Add(recipe.Id, recipe);
            return true;
    }
        

    public Recipe? FindRecipe(int recipeId)
    {
        if (recipes_list.ContainsKey(recipeId))
        {
            return recipes_list[recipeId];
        }
        return null;
    }

    public bool RemoveRecipe(int recipeId)
    {
        if (!recipes_list.ContainsKey(recipeId))
        {
            return false;
        }

        if (cookingPlan.Contains(recipeId))
        {
            return false;
        }
        return recipes_list.Remove(recipeId);
    }

    public int AddIngredientsToShoppingList(int recipeId)
    {
        Recipe? recipe = FindRecipe(recipeId);

        if(recipe == null)
        {
            return 0;
        }

        foreach(string ingredient in recipe.Ingredients)
        {
            shoppingList.Add(ingredient);
        }
        return recipe.Ingredients.Count;
    }

    public IReadOnlyList<string> GetShoppingList()
    {
        return new List<string>(shoppingList);
    }

    public void ClearShoppingList()
    {
        shoppingList.Clear();
    }

    public bool AddRecipeToCookingPlan(int recipeId)
    {
        if (!recipes_list.ContainsKey(recipeId))
        {
            return false;
        }

        if (cookingPlan.Contains(recipeId))
        {
            return false;
        }

        cookingPlan.AddLast(recipeId);
        return true;
    }

    public bool RemoveRecipeFromCookingPlan(int recipeId)
    {
        bool removed = cookingPlan.Remove(recipeId);
        if (!removed)
        {
            return false;
        }

        recipesRemove.Push(recipeId);
        return true;
    }
    public bool RestoreLastRemovedRecipe()
    {
        if (recipesRemove.Count == 0)
        {
            return false;
        }

        int recipeId = recipesRemove.Pop();
        if (!recipes_list.ContainsKey(recipeId))
        {
            return false;
        }

        if (cookingPlan.Contains(recipeId))
        {
            return false;
        }

        cookingPlan.AddLast(recipeId);
        return true;
    }

    public int? PeekLastRemovedRecipe()
    {
        if (recipesRemove.Count == 0)
        {
            return null;
        }

        return recipesRemove.Peek();
    }

    public IReadOnlyList<int> GetCookingPlan()
    {
        return new List<int>(cookingPlan);
    }

    public bool StartCooking(int recipeId)
    {
        Recipe? recipe = FindRecipe(recipeId);
        if (recipe == null)
        {
            return false;
        }

        if (recipe.Instructions.Count == 0)
        {
            return false;
        }

        instructiontionQueue.Clear();

        foreach(string instruction in recipe.Instructions)
        {
            instructiontionQueue.Enqueue(instruction);
        }
        return true;
    }

    public string? PeekNextInstruction()
    {
        if (instructiontionQueue.Count == 0)
        {
            return null;
        }

        return instructiontionQueue.Peek();
    }

    public string? CompleteNextInstruction()
    {
        if(instructiontionQueue.Count == 0)
        {
            return null;
        }
        return instructiontionQueue.Dequeue();
    }

    public IReadOnlyList<Recipe> SearchByTitle(string searchText) =>
        throw new NotImplementedException("Part B: implement SearchByTitle.");

    public IReadOnlyList<Recipe> SearchByIngredient(string searchText) =>
        throw new NotImplementedException("Part B: implement SearchByIngredient.");

    public IReadOnlyList<Recipe> GetHighestProteinRecipes(int count) =>
        throw new NotImplementedException("Part B: implement GetHighestProteinRecipes.");

    public bool AddSavedRecipe(int recipeId) =>
        throw new NotImplementedException("Part B: implement AddSavedRecipe.");

    public bool RemoveSavedRecipe(int recipeId) =>
        throw new NotImplementedException("Part B: implement RemoveSavedRecipe.");

    public bool IsRecipeSaved(int recipeId) =>
        throw new NotImplementedException("Part B: implement IsRecipeSaved.");

    public IReadOnlyList<int> GetSavedRecipes() =>
        throw new NotImplementedException("Part B: implement GetSavedRecipes.");
}
