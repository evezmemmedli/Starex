//using Microsoft.AspNetCore.Mvc;
//using Moq;
//using Starex.API.Controllers.Advantage;
//using System.Collections.Generic;
//using System.Linq;
//using Xunit;

//namespace Starex.UnitTest.AdvantageControllerTest
//{
//    public class AdvantageControllerTest
//    {
//        private readonly Mock<IAdvantageService> _mockRepo;
//        private readonly AdvantagesController _controller;
//        private readonly List<Advantage> _advantages;
//        private readonly AdvantageListDto _advantageListDto;

//        public AdvantageControllerTest()
//        {
//            _mockRepo = new Mock<IAdvantageService>();
//            _controller = new AdvantagesController(_mockRepo.Object);
//            _advantageListDto = new AdvantageListDto();
//            _advantages = new List<Advantage>() { new Advantage { Id =1,Title= "Salam",Icon= "fa-fasolid"}, new Advantage { Id = 2, Title = "Sagol", Icon = "fa-fasolid1" } };
           
//        }
//        [Fact]
//        public async void GetAdvantage_ActionExecutes_ReturnOkResultWithAdvantage()
//        {
//            _mockRepo.Setup(x => x.GetByIdAsync(true,1)).Returns(_advantages);
//            var result = await _controller.Get(1);
//            var okResult = Assert.IsType<OkObjectResult>(result);
//            var returnAdvantage = Assert.IsAssignableFrom<IEnumerable<Advantage>>(okResult.Value);
//            Assert.Equal<int>(2, returnAdvantage.ToList().Count());
//        }
//    }
//}
