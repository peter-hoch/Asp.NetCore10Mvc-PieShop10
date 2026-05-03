namespace PieShop.Models
{
    public interface ICategoryRepository
    {
        Task<List<Category>> GetAllAsync();
    }
}
