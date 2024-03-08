namespace SurveyHub.Entities.Entity
{
    public enum Category
    {
        Technology = 1,
        Sports = 2,
        Entertainment = 3,
        Politics = 4,
        Food = 5,
        Travel = 6,
        Health = 7,
        Fashion = 8,
        Education = 9,
        Environment = 10,
        Other = 11
    }

    public static class CategoryExtensions
    {
        public static Category ToSurveyCategory(this int categoryId)
        {
            if (Enum.IsDefined(typeof(Category), categoryId))
            {
                return (Category)categoryId;
            }

            else
            {
                throw new ArgumentOutOfRangeException(nameof(categoryId), "Invalid Category ID.");
            }
        }
    }
}