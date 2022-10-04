using Microsoft.AspNetCore.Mvc;
using Moq;
using Starex.API.Controllers.Advantage;
using System.Collections.Generic;
using System.Linq;
using Xunit;
namespace Starex.UnitTest.AdvantageControllerTest
{
    public class AdvantageControllerTest
    {
        private readonly Mock<IAdvantageService> _mockRepo;
        private readonly AdvantagesController _controller;
        private readonly AdvantageListDto _advantageListDto;
        private readonly List<AdvantageDto> advantageDto;
        private readonly AdvantagePostDto advantagePostDto;
        public AdvantageControllerTest()
        {
            _mockRepo = new Mock<IAdvantageService>();
            _controller = new AdvantagesController(_mockRepo.Object);
            advantageDto = new List<AdvantageDto>();
            advantagePostDto = new AdvantagePostDto
            {
                Title = "gfjh",
               
            };
            advantageDto.Add(new AdvantageDto()
            {
                
                Icon = "sada",
                Title = "dasdas"
            });
            _advantageListDto = new AdvantageListDto();
            _advantageListDto.AdvantageDtos = new();
            _advantageListDto.AdvantageDtos.AddRange(advantageDto);
        }
        [Fact]
        public async void GetAdvantage_ActionExecutes_ReturnOkResultWithAdvantage()
        {
            _mockRepo.Setup(x => x.GetAll()).ReturnsAsync(_advantageListDto);
            var result = await _controller.GetAll();
            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnAdvantage = Assert.IsAssignableFrom<AdvantageListDto>(okResult.Value);
            Assert.Equal<int>(1, returnAdvantage.AdvantageDtos.ToList().Count());
        }
        [Fact]
        public async void PostAdvantage()
        {
            _mockRepo.Setup(x => x.AddAsync(advantagePostDto));
            var result = await _controller.Create(advantagePostDto);
            var okResult = Assert.IsType<CreatedResult>(result);
        }
        [Fact]
        public async void DeleteAdvantage()
        {
            _mockRepo.Setup(x => x.Remove(1));
            var result =  _controller.Delete(1);
            var okResult = Assert.IsType<OkObjectResult>(result);
        }
        [Fact]
        public async void GetAdvantage()
        {
            _mockRepo.Setup(x => x.GetByIdAsync(true,1));
            var result = await _controller.Get(1);
            var okResult = Assert.IsType<OkObjectResult>(result);
        }
        [Fact]
        public async void UpdateAdvantage()
        {
            _mockRepo.Setup(x => x.Update(advantagePostDto, 1));
            var result =  _controller.Update(advantagePostDto,1);
            var okResult = Assert.IsType<NoContentResult>(result);
        }
    }
}
