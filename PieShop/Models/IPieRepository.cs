namespace PieShop.Models
{
    public interface IPieRepository
    {
        Task<List<Pie>> GetAllAsync();
        Task<Pie?> GetByIdAsync(int id);
        Task<List<Pie>> GetByCategoryAsync(string categoryName);

        Task<List<Pie>> GetPiesOfTheWeekAsync();
    }
}
