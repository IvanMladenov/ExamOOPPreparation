namespace RestaurantManager.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using System.Text;

    using RestaurantManager.Interfaces;

    public class Restarurant : IRestaurant
    {
        private string location;

        private string name;

        public Restarurant(string name, string location)
        {
            this.Name = name;
            this.Location = location;
            this.Recipes = new List<IRecipe>();
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("Name cannot be null or empty");
                }
                this.name = value;
            }
        }

        public string Location
        {
            get
            {
                return this.location;
            }
            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("Location cannot be null or empty");
                }
                this.location = value;
            }
        }

        public IList<IRecipe> Recipes { get; private set; }

        public void AddRecipe(IRecipe recipe)
        {
            this.Recipes.Add(recipe);
        }

        public void RemoveRecipe(IRecipe recipe)
        {
            this.Recipes.Remove(recipe);
        }

        public string PrintMenu()
        {
            var listOfTypes = new List<List<IRecipe>>()
                                  {
                                      this.Recipes.Where(x => x is Drink).OrderBy(x => x.Name).ToList(),
                                      this.Recipes.Where(x => x is Salad).OrderBy(x => x.Name).ToList(),
                                      this.Recipes.Where(x => x is MainCourse).OrderBy(x => x.Name).ToList(),
                                      this.Recipes.Where(x => x is Dessert).OrderBy(x => x.Name).ToList()
                                  };
            bool hasValue = false;
            var sb = new StringBuilder();
            sb.AppendFormat("***** {0} - {1} *****", this.Name, this.Location).AppendLine();
            for (int i = 0; i < listOfTypes.Count; i++)
            {
                var list = listOfTypes[i];
                if (list.Any())
                {
                    switch (i)
                    {
 
                        case 3:
                            sb.AppendLine("~~~~~ DESSERTS ~~~~~");
                            sb.Append(string.Join("\n", list));
                            break;
                        case 2:
                            sb.AppendLine("~~~~~ MAIN COURSES ~~~~~");
                            sb.Append(string.Join("\n", list));
                            break;
                        case 0:
                            sb.AppendLine("~~~~~ DRINKS ~~~~~");
                            sb.Append(string.Join("\n", list));
                            break;
                        case 1:
                            sb.AppendLine("~~~~~ SALADS ~~~~~");
                            sb.Append(string.Join("\n", list));
                            break;
                    }

                    hasValue = true;
                }
            }
           if(!hasValue)
            {
                sb.Append("No recipes... yet");
            }

            return sb.ToString();
        }
    }
}