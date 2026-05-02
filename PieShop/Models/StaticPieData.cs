namespace PieShop.Models
{
    public static class StaticPieData
    {
        private static readonly List<Pie> _pies = new List<Pie>()
        {
            new Pie { PieId = 1, Name = "Apple Pie", Price = 15.95M, ShortDescription = "Classic apple pie", InStock = true, IsPieOfTheWeek = false },
            new Pie { PieId = 2, Name = "Cherry Pie", Price = 18.95M, ShortDescription = "Sweet cherry pie", InStock = true, IsPieOfTheWeek = true },
            new Pie { PieId = 3, Name = "Pumpkin Pie", Price = 12.95M, ShortDescription = "Seasonal favorite", InStock = false, IsPieOfTheWeek = false }
        };

        public static IEnumerable<Pie> GetAll() => _pies.OrderBy(p => p.PieId);

        public static Pie? GetById(int id) => _pies.FirstOrDefault(p => p.PieId == id);
    }
}
