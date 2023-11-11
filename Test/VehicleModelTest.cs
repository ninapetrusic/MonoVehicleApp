using AutoMapper;
using DAL;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Model;
using Model.Common;
using Moq;
using Repository;
using Repository.Common;
using Service;
using Service.Common;
using System.Diagnostics;
using WebAPI.Controllers;
using Xunit;
using Xunit.Sdk;

namespace Test
{
    public class VehicleModelTest
    {  
        private readonly Mock<IUnitOfWork> _unitOfWork;
        private static MapperConfiguration mapperConfig = new MapperConfiguration(
        cfg =>
        {
            cfg.AddProfile<VehicleMakeProfile>();
            cfg.AddProfile<VehicleModelProfile>();
        });
        private readonly IMapper _mapper = mapperConfig.CreateMapper();

        public VehicleModelTest() {
            _unitOfWork = new Mock<IUnitOfWork>();
        }

        [Fact]
        public async Task ServiceGetAllTest()
        {
            var query = new Common.QueryParams();
            var data = GetData(); //DAL
            var dataModel = _mapper.Map<IEnumerable<DAL.VehicleModel>, IEnumerable<IVehicleModel>>(data);
            _unitOfWork.Setup(x => x.vehicleModelRepo.GetAllAsync(query)).ReturnsAsync(data);
            var modelService = new VehicleModelService(_unitOfWork.Object, _mapper);
            var result = await modelService.GetVehicleModelsAsync(query).ConfigureAwait(true);

            Assert.NotNull(result);
            Assert.Equal(GetData().Count(), result.Count());
            Assert.True(dataModel.GetType() == result.GetType());
        }

        [Fact]
        public async Task ServiceGetByIdAsync()
        {
            var data = GetData();
            var dataModel = _mapper.Map<IEnumerable<DAL.VehicleModel>, IEnumerable<IVehicleModel>>(data);
            _unitOfWork.Setup(x => x.vehicleModelRepo.GetByIdAsync(2)).ReturnsAsync(data.ElementAt(1));
            var modelService = new VehicleModelService(_unitOfWork.Object, _mapper);
            var result = await modelService.GetVehicleModelByIdAsync(2).ConfigureAwait(true);

            Assert.NotNull(result);
            Assert.True(dataModel.ElementAt(1).Id == result.Id);
            Assert.True(dataModel.ElementAt(1).GetType() == result.GetType());
        }

        [Fact]
        public async Task ServiceGetByIdAsync_NotExisting()
        {
            _unitOfWork.Setup(x => x.vehicleModelRepo.GetByIdAsync(1)).ReturnsAsync(new DAL.VehicleModel());
            var modelService = new VehicleModelService(_unitOfWork.Object, _mapper);
            var result = await modelService.GetVehicleModelByIdAsync(1).ConfigureAwait(true);

            Assert.IsAssignableFrom<IVehicleModel>(result);
            Assert.True(result.Id == 0);
            Assert.True(result.Name == null);

        }

        [Fact]
        public async Task ServiceCreateModel_Ok()
        {
            VehicleModelCreate data = new VehicleModelCreate { Name = "name1", Abrv = "abrv1", VehicleMakeId = 1 };
            _unitOfWork.Setup(x => x.CommitAsync()).ReturnsAsync(1);
            _unitOfWork.Setup(x => x.AddAsync(It.IsAny<DAL.VehicleModel>())).ReturnsAsync(1);
            IVehicleModelService service = new VehicleModelService(_unitOfWork.Object,_mapper);
            var result = await service.InsertVehicleModelAsync(data).ConfigureAwait(true);

            Assert.IsType<bool>(result);
            Assert.True(result);
        }

        [Fact]
        public async Task ServiceCreateModel_BadReq()
        {
            VehicleModelCreate data = new VehicleModelCreate { Name = "name1", Abrv = "abrv1", VehicleMakeId = 1 };
            _unitOfWork.Setup(x => x.AddAsync(It.IsAny<DAL.VehicleModel>())).ReturnsAsync(0);
            IVehicleModelService service = new VehicleModelService(_unitOfWork.Object, _mapper);
            var result = await service.InsertVehicleModelAsync(data).ConfigureAwait(true);

            Assert.IsType<bool>(result);
            Assert.False(result);
        }

        [Fact]
        public async Task ServiceDeleteModel_Ok()
        {
            DAL.VehicleModel data = GetData().ElementAt(1);
            _unitOfWork.Setup(x => x.vehicleModelRepo.GetByIdAsync(2)).ReturnsAsync(data);
            _unitOfWork.Setup(x => x.DeleteAsync(data)).ReturnsAsync(1);
            _unitOfWork.Setup(x => x.CommitAsync()).ReturnsAsync(1);
            IVehicleModelService service = new VehicleModelService(_unitOfWork.Object, _mapper);
            var result = await service.DeleteVehicleModelAsync(2).ConfigureAwait(true);

            Assert.IsType<bool>(result);
            Assert.True(result);

        }
        [Fact]
        public async Task ServiceDeleteModel_BadReq()
        {
            _unitOfWork.Setup(x => x.vehicleModelRepo.GetByIdAsync(2)).ReturnsAsync(new DAL.VehicleModel());
            IVehicleModelService service = new VehicleModelService(_unitOfWork.Object, _mapper);
            var result = await service.DeleteVehicleModelAsync(2).ConfigureAwait(true);

            Assert.IsType<bool>(result);
            Assert.False(result);
        }
        [Fact]
        public async Task ServiceUpdateModel_Ok()
        {
            DAL.VehicleModel data = GetData().ElementAt(1);
            _unitOfWork.Setup(x => x.vehicleModelRepo.GetByIdAsync(2)).ReturnsAsync(data);
            _unitOfWork.Setup(x => x.UpdateAsync(It.IsAny<DAL.VehicleModel>())).ReturnsAsync(1);
            _unitOfWork.Setup(x => x.CommitAsync()).ReturnsAsync(1);
            IVehicleModelService service = new VehicleModelService(_unitOfWork.Object, _mapper);
            var result = await service.UpdateVehicleModelAsync(2, new VehicleModelCreate { Name = "name" }).ConfigureAwait(true);

            Assert.IsType<bool>(result);
            Assert.True(result);
        }
        [Fact]
        public async Task ServiceUpdateModel_BadReq()
        {
            DAL.VehicleModel data = GetData().ElementAt(1);
            _unitOfWork.Setup(x => x.vehicleModelRepo.GetByIdAsync(2)).ReturnsAsync(data);
            _unitOfWork.Setup(x => x.UpdateAsync(It.IsAny<DAL.VehicleModel>())).ReturnsAsync(0);
            IVehicleModelService service = new VehicleModelService(_unitOfWork.Object, _mapper);
            var result = await service.UpdateVehicleModelAsync(2, new VehicleModelCreate { Name = "name" }).ConfigureAwait(true);

            Assert.IsType<bool>(result);
            Assert.False(result);
        }

        private static IEnumerable<DAL.VehicleModel> GetData()
        {
            IEnumerable<DAL.VehicleModel> data = new List<DAL.VehicleModel>
            {
                new DAL.VehicleModel { Id = 1, Name = "name1", Abrv = "abrv1", VehicleMakeId = 1 },
                new DAL.VehicleModel { Id = 2, Name = "name2", Abrv = null, VehicleMakeId = 2 },
                new DAL.VehicleModel { Id = 3, Name = "name3", Abrv = "abrv3", VehicleMakeId = 3 },
            };
            return data;
        }
    }
}