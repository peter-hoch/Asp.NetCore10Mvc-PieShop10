using PieShop.Controllers;
using PieShop.ViewModels;
using PieShopTests.Mocks;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace PieShopTests.Controllers
{
    public class HomeControllerTests
    {
        [Fact]
        public async Task Index_Use_PieOfTheWeeks_FromRepository()
        {
            var mockPieRepository = RepositoryMocks.GetPieRepository();

            var all = (await mockPieRepository.Object.GetAllAsync()).Where(p=>p.IsPieOfTheWeek);

            HomeController homeController = new HomeController(mockPieRepository.Object);

            var result = (await homeController.Index()).ViewData.Model as HomeViewModel;

            Assert.NotNull(result);

            var piesOfTheWeek = result?.PiesOfTheWeek?.ToList();
            Assert.NotNull(piesOfTheWeek);
            Assert.True(piesOfTheWeek?.Count() == 3);
            Assert.Equal("Apple Pie", piesOfTheWeek?[0].Name);
        }
    }
}
