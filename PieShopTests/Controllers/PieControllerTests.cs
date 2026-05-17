using PieShop.Controllers;
using PieShop.ViewModels;
using PieShopTests.Mocks;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace PieShopTests.Controllers
{
    public class PieControllerTests
    {
        [Fact]
        public async Task List_EmptyCategory_ReturnsAllPies()
        {
            //arrange
            var mockPieRepository = RepositoryMocks.GetPieRepository();

            var pieController = new PieController(mockPieRepository.Object);

            //act
            var result = await pieController.List("");

            //assert
            var viewResult = Assert.IsType<ViewResult>(result);
            var pieListViewModel = Assert.IsAssignableFrom<PieListViewModel>(viewResult.ViewData.Model);
            Assert.Equal(10, pieListViewModel.Pies.Count());
        }
    }
}
