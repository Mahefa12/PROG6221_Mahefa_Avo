using System;

// Class representing a recipe
class Recipe
{
    private int numberOfIngredients; // Number of ingredients in the recipe
    private Ingredient[] ingredients; // Array to store ingredients
    private Ingredient[] originalIngredients; // Array to store original ingredient quantities
    private int numberOfSteps; // Number of steps in the recipe
    private string[] steps; // Array to store recipe steps

    // Constructor for Recipe class
    public Recipe()
    {
        numberOfIngredients = 0;
        numberOfSteps = 0;
    }

    // Method to add ingredients to the recipe
    public void AddIngredients(int numberOfIngredients)
    {
        this.numberOfIngredients = numberOfIngredients;
        ingredients = new Ingredient[numberOfIngredients];
        originalIngredients = new Ingredient[numberOfIngredients];
        for (int i = 0; i < numberOfIngredients; i++)
        {
            Console.Write($"Enter name of ingredient {i + 1}: ");
            string name = Console.ReadLine();
            Console.Write($"Enter quantity of ingredient {i + 1}: ");
            double quantity = double.Parse(Console.ReadLine());
            Console.Write($"Enter unit of measurement of ingredient {i + 1}: ");
            string unit = Console.ReadLine();

            ingredients[i] = new Ingredient(name, quantity, unit);
            originalIngredients[i] = new Ingredient(name, quantity, unit); // Store original quantities
        }
    }

    // Method to add steps to the recipe
    public void AddSteps(int numberOfSteps)
    {
        this.numberOfSteps = numberOfSteps;
        steps = new string[numberOfSteps];
        for (int i = 0; i < numberOfSteps; i++)
        {
            Console.Write($"Enter step {i + 1}: ");
            steps[i] = Console.ReadLine();
        }
    }

    // Method to display the recipe
    public void DisplayRecipe()
    {
        if (numberOfIngredients == 0 || numberOfSteps == 0)
        {
            Console.WriteLine("No recipe currently stored, please add a new recipe.");
            return;
        }

        Console.WriteLine("Ingredients:");
        foreach (var ingredient in ingredients)
        {
            Console.WriteLine($"{ingredient.Quantity} {ingredient.Unit} of {ingredient.Name}");
        }

        Console.WriteLine("\nSteps:");
        for (int i = 0; i < numberOfSteps; i++)
        {
            Console.WriteLine($"{i + 1}. {steps[i]}");
        }
    }

    // Method to scale the recipe
    public void ScaleRecipe(double factor)
    {
        foreach (var ingredient in ingredients)
        {
            ingredient.Quantity *= factor;
        }
    }

    // Method to reset ingredient quantities to their original values
    public void ResetQuantities()
    {
        for (int i = 0; i < numberOfIngredients; i++)
        {
            ingredients[i].Quantity = originalIngredients[i].Quantity; // Reset to original quantities
        }
    }

    // Method to clear the recipe
    public void ClearRecipe()
    {
        numberOfIngredients = 0;
        numberOfSteps = 0;
        ingredients = null;
        originalIngredients = null;
        steps = null;
    }
}

// Class representing an ingredient
class Ingredient
{
    public string Name { get; } // Name of the ingredient
    public double Quantity { get; set; } // Quantity of the ingredient
    public string Unit { get; } // Unit of measurement of the ingredient

    // Constructor for Ingredient class
    public Ingredient(string name, double quantity, string unit)
    {
        Name = name;
        Quantity = quantity;
        Unit = unit;
    }
}

// Main class of the program
class Program
{
    static void Main(string[] args)
    {
        Recipe recipe = new Recipe();
        bool exit = false;

        while (!exit)
        {
            Console.WriteLine("\nOptions:");
            Console.WriteLine("1. Enter Recipe");
            Console.WriteLine("2. Display Recipe");
            Console.WriteLine("3. Scale Recipe");
            Console.WriteLine("4. Reset Quantities");
            Console.WriteLine("5. Clear Recipe and Enter New Recipe");
            Console.WriteLine("6. Exit");
            Console.Write("Enter your choice: ");
            int choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    Console.Write("Enter the number of ingredients: ");
                    int numberOfIngredients = int.Parse(Console.ReadLine());
                    recipe.AddIngredients(numberOfIngredients);

                    Console.Write("Enter the number of steps: ");
                    int numberOfSteps = int.Parse(Console.ReadLine());
                    recipe.AddSteps(numberOfSteps);
                    break;
                case 2:
                    Console.WriteLine("\nRecipe:");
                    recipe.DisplayRecipe();
                    break;
                case 3:
                    Console.Write("Enter scaling factor (0.5, 2, or 3): ");
                    double factor = double.Parse(Console.ReadLine());
                    recipe.ScaleRecipe(factor);
                    Console.WriteLine("\nRecipe scaled.");
                    break;
                case 4:
                    recipe.ResetQuantities();
                    Console.WriteLine("\nQuantities reset to original values.");
                    break;
                case 5:
                    recipe.ClearRecipe();
                    Console.WriteLine("\nRecipe cleared. Please enter a new recipe.");
                    break;
                case 6:
                    exit = true;
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please enter a valid option.");
                    break;
            }
        }
    }
}