using System.Collections.Generic;
using RecipeManagement.Core;

namespace RecipeManagement.Tests;

/// <summary>
/// Example tests from the assignment specification. Add your own tests as you work.
/// </summary>
public sealed class RecipeManagerTests
{
    [Fact]
    public void Constructor_BuildsRecipeDictionary()
    {
        var manager = CreateManager();
        Assert.Equal(2, manager.RecipeCount);
        Assert.Equal("Recipe A", manager.FindRecipe(10)?.Title);
    }

    [Fact]
    public void Constructor_NullRecipeTesting()
    {
        Assert.Throws<ArgumentException>(() => new RecipeManager(null!));
    }

    [Fact]
    public void Constructor_DuplicateIdTesting()
    {
        var recipes = new[]
        {
            new Recipe
            {
                Id = 1,
                Title = "Recipe A"
            },
            new Recipe
            {
                Id = 1,
                Title = "Recipe B"
            }
        };
        Assert.Throws<ArgumentException>(() => new RecipeMager(recipes));
    }

    [Fact]
    public void Constructor_NegativeIdTesting()
    {
        var recipes = new []
        {
            new Recipe
            {
                Id = 0,
                title = "Invalid Recipe"
            }
        };
        Assert.Throws<ArgumentException>(() => new RecipeManager(recipes));
    }

    [Fact]
    public void Constructor_NonTitleTesting()
    {
        var recipes = new []
        {
            new Recipe
            {
                Id = 1,
                title = ""
            }
        };
        Assert.Throws<ArgumentException>(() => new RecipeManager(recipes));
    }

    [Fact]
    public void AddRecipe_Testing()
    {
        var manager = CreateManager();
        var recipe = new Recipe
        {
            Id = 30,
            Title = "Cooking Recipe"
        };

        bool result = manager.AddRecipe(recipe);

        Assert.True(result);
        Assert.Equal(3, manager.RecipeCount);
        Assert.Equal("Cooking Recipe", manager.FindRecipe(30)?.Title);
    }


    [Fact]
    public void AddRecipe_TestingDuplicateId()
    {
        var manager = CreateManager();
        var recipe = new Recipe
        {
            Id = 10,
            Title = "Duplicate recipe"
        };

        bool result = manager.AddRecipe(recipe);

        Assert.False(result);
        Assert.Equal(2, manager.RecipeCount);
    }


    [Fact]
    public void AddRecipe_TestingBlankTitle()
    {
        var manager = CreateManager();
        var recipe = new Recipe
        {
            Id = 30,
            Title = "   "
        };

        Assert.False(manager.AddRecipe(recipe));
    }

    [Fact]
    public void AddRecipe_TestingNullRecipe()
    {
        var manager = CreateManager();
        Assert.Throws<ArgumentException>(() => manager.AddRecipe(null!));
    }

    [Fact]
    public void FindRecipe_TestingNonId()
    {
        var manager = CreateManager();
        Recipe? result = manager.FindRecipe(1000);
        Assert.Null(result);
    }

    [Fact]
    public void RemoveRecipe_Testing()
    {
        var manager = CreateManager();

        bool result = manager.RemoveRecipe(20);

        Assert.True(result);
        Assert.Null(manager.FindRecipe(20));
        Assert.Equal(1, manager.RecipeCount);
    }


    public void RemoveRecipe_TestingNonRecipe()
    {
        var manager = CreateManager();

        Assert.False(manager.RemoveRecipe(1000));
        Assert.Equal(1, manager.RecipeCount);
    }


    public void RemoveRecipe_TestingWhenRecipeInCookingPlan()
    {
        var manager = CreateManager();

        Assert.True(manager.AddRecipeToCookingPlan(10));

        bool result = manager.RemoveRecipe(10);

        Assert.False(result);
        Assert.NotNull(manager.FindRecipe(10));
    }


    public void ShoppingList_TestingCopyIngredients()
    {
        var manager = CreateManager();

        int added = manager.AddIngredientsToShoppingList(10);

        Assert.Equal(2,added);
        Assert.Equal(2, manager.ShoppingItemCount);

        Assert.Equal(new[] {"1 apple", "2 bananas" }, manager.GetShoppingList);
    }


    [Fact]
    public void InstructionsAreCompletedInFileOrder()
    {
        var manager = CreateManager();
        Assert.True(manager.StartCooking(10));
        Assert.Equal("First step", manager.PeekNextInstruction());
        Assert.Equal("First step", manager.CompleteNextInstruction());
        Assert.Equal("Second step", manager.PeekNextInstruction());
    }

    [Fact]
    public void RemovedRecipesAreRestoredLastInFirstOut()
    {
        var manager = CreateManager();
        manager.AddRecipeToCookingPlan(10);
        manager.AddRecipeToCookingPlan(20);
        manager.RemoveRecipeFromCookingPlan(10);
        manager.RemoveRecipeFromCookingPlan(20);
        Assert.Equal(20, manager.PeekLastRemovedRecipe());
        Assert.True(manager.RestoreLastRemovedRecipe());
        Assert.Equal(new[] { 20 }, manager.GetCookingPlan());
    }

    private static RecipeManager CreateManager()
    {
        return new RecipeManager(new[]
        {
            new Recipe
            {
                Id = 10,
                Title = "Recipe A",
                Ingredients = new() { "1 apple" },
                Instructions = new() { "First step", "Second step" }
            },
            new Recipe
            {
                Id = 20,
                Title = "Recipe B"
            }
        });
    }
}
