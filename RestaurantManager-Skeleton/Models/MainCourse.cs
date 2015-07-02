namespace RestaurantManager.Models
{
    using System;
    using System.Runtime.CompilerServices;
    using System.Text;

    using RestaurantManager.Interfaces;

    public class MainCourse : Meal, IMainCourse
    {
        public MainCourse(
            string name, 
            decimal price, 
            int calories, 
            int quantityPerServing, 
            int timeToPrepare, 
            bool isVegan, 
            string type)
            : base(name, price, calories, quantityPerServing, timeToPrepare)
        {
            this.IsVegan = isVegan;
            this.Type = (MainCourseType)Enum.Parse(typeof(MainCourseType),type);
        }

        public MainCourseType Type { get; set; }

        public override string ToString()
        {
            var sb=new StringBuilder();
            sb.Append(string.Format("{0}", this.IsVegan ? "[VEGAN] " : string.Empty));
            sb.Append(base.ToString()).AppendLine();
            sb.AppendLine(string.Format("Type: {0}",this.Type));

            return sb.ToString();
        }
    }
}