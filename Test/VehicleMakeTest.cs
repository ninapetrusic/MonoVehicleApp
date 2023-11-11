using AutoMapper;
using Model;
using Model.Common;
using Moq;
using Repository.Common;
using Service;
using Service.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Test
{
    public class VehicleMakeTest
    {
        private readonly Mock<IUnitOfWork> _unitOfWork;
        private static MapperConfiguration mapperConfig = new MapperConfiguration(
        cfg =>
        {
            cfg.AddProfile<VehicleMakeProfile>();
            cfg.AddProfile<VehicleModelProfile>();
        });
        private readonly IMapper _mapper = mapperConfig.CreateMapper();

        public VehicleMakeTest()
        {
            _unitOfWork = new Mock<IUnitOfWork>();
        }

        [Fact]
        public async Task ServiceGetAllTest()
        {
            var query = new Common.QueryParams();
            var data = GetData(); //DAL
            var dataModel = _mapper.Map<IEnumerable<DAL.VehicleMake>, IEnumerable<IVehicleMake>>(data);
            _unitOfWork.Setup(x => x.vehicleMakeRepo.GetAllAsync(query)).ReturnsAsync(data);
            var makeService = new VehicleMakeService(_unitOfWork.Object, _mapper);
            var result = await makeService.GetVehicleMakesAsync(query).ConfigureAwait(true);

            Assert.NotNull(result);
            Assert.Equal(GetData().Count(), result.Count());
            Assert.True(dataModel.GetType() == result.GetType());
        }

        [Fact]
        public async Task ServiceGetByIdAsync()
        {
            var data = GetData();
            var dataModel = _mapper.Map<IEnumerable<DAL.VehicleMake>, IEnumerable<IVehicleMake>>(data);
            _unitOfWork.Setup(x => x.vehicleMakeRepo.GetByIdAsync(2)).ReturnsAsync(data.ElementAt(1));
            var makeService = new VehicleMakeService(_unitOfWork.Object, _mapper);
            var result = await makeService.GetVehicleMakeByIdAsync(2).ConfigureAwait(true);

            Assert.NotNull(result);
            Assert.True(dataModel.ElementAt(1).Id == result.Id);
            Assert.True(dataModel.ElementAt(1).GetType() == result.GetType());
        }

        [Fact]
        public async Task ServiceGetByIdAsync_NotExisting()
        {
            _unitOfWork.Setup(x => x.vehicleMakeRepo.GetByIdAsync(1)).ReturnsAsync(new DAL.VehicleMake());
            var makeService = new VehicleMakeService(_unitOfWork.Object, _mapper);
            var result = await makeService.GetVehicleMakeByIdAsync(1).ConfigureAwait(true);

            Assert.IsAssignableFrom<IVehicleMake>(result);
            Assert.True(result.Id == 0);
            Assert.True(result.Name == null);

        }

        [Fact]
        public async Task ServiceCreateMake_Ok()
        {
            VehicleMakeCreate data = new VehicleMakeCreate { Name = "name1", Abrv = "abrv1" };
            _unitOfWork.Setup(x => x.CommitAsync()).ReturnsAsync(1);
            _unitOfWork.Setup(x => x.AddAsync(It.IsAny<DAL.VehicleMake>())).ReturnsAsync(1);
            IVehicleMakeService service = new VehicleMakeService(_unitOfWork.Object, _mapper);
            var result = await service.InsertVehicleMakeAsync(data).ConfigureAwait(true);

            Assert.IsType<bool>(result);
            Assert.True(result);
        }

        [Fact]
        public async Task ServiceCreateMake_BadReq()
        {
            VehicleMakeCreate data = new VehicleMakeCreate { Name = "name1", Abrv = "abrv1" };
            _unitOfWork.Setup(x => x.AddAsync(It.IsAny<DAL.VehicleMake>())).ReturnsAsync(0);
            IVehicleMakeService service = new VehicleMakeService(_unitOfWork.Object, _mapper);
            var result = await service.InsertVehicleMakeAsync(data).ConfigureAwait(true);

            Assert.IsType<bool>(result);
            Assert.False(result);
        }

        [Fact]
        public async Task ServiceDeleteMake_Ok()
        {
            DAL.VehicleMake data = GetData().ElementAt(1);
            _unitOfWork.Setup(x => x.vehicleMakeRepo.GetByIdAsync(2)).ReturnsAsync(data);
            _unitOfWork.Setup(x => x.DeleteAsync(data)).ReturnsAsync(1);
            _unitOfWork.Setup(x => x.CommitAsync()).ReturnsAsync(1);
            IVehicleMakeService service = new VehicleMakeService(_unitOfWork.Object, _mapper);
            var result = await service.DeleteVehicleMakeAsync(2).ConfigureAwait(true);

            Assert.IsType<bool>(result);
            Assert.True(result);

        }
        [Fact]
        public async Task ServiceDeleteMake_BadReq()
        {
            _unitOfWork.Setup(x => x.vehicleMakeRepo.GetByIdAsync(2)).ReturnsAsync(new DAL.VehicleMake());
            IVehicleMakeService service = new VehicleMakeService(_unitOfWork.Object, _mapper);
            var result = await service.DeleteVehicleMakeAsync(2).ConfigureAwait(true);

            Assert.IsType<bool>(result);
            Assert.False(result);
        }
        [Fact]
        public async Task ServiceUpdateMake_Ok()
        {
            DAL.VehicleMake data = GetData().ElementAt(1);
            _unitOfWork.Setup(x => x.vehicleMakeRepo.GetByIdAsync(2)).ReturnsAsync(data);
            _unitOfWork.Setup(x => x.UpdateAsync(It.IsAny<DAL.VehicleMake>())).ReturnsAsync(1);
            _unitOfWork.Setup(x => x.CommitAsync()).ReturnsAsync(1);
            IVehicleMakeService service = new VehicleMakeService(_unitOfWork.Object, _mapper);
            var result = await service.UpdateVehicleMakeAsync(2, new VehicleMakeCreate { Name = "name" }).ConfigureAwait(true);

            Assert.IsType<bool>(result);
            Assert.True(result);
        }
        [Fact]
        public async Task ServiceUpdateMake_BadReq()
        {
            DAL.VehicleMake data = GetData().ElementAt(1);
            _unitOfWork.Setup(x => x.vehicleMakeRepo.GetByIdAsync(2)).ReturnsAsync(data);
            _unitOfWork.Setup(x => x.UpdateAsync(It.IsAny<DAL.VehicleMake>())).ReturnsAsync(0);
            IVehicleMakeService service = new VehicleMakeService(_unitOfWork.Object, _mapper);
            var result = await service.UpdateVehicleMakeAsync(2, new VehicleMakeCreate { Name = "name" }).ConfigureAwait(true);

            Assert.IsType<bool>(result);
            Assert.False(result);
        }

        private static IEnumerable<DAL.VehicleMake> GetData()
        {
            IEnumerable<DAL.VehicleMake> data = new List<DAL.VehicleMake>
            {
                new DAL.VehicleMake { Id = 1, Name = "name1", Abrv = "abrv1" },
                new DAL.VehicleMake { Id = 2, Name = "name2", Abrv = null },
                new DAL.VehicleMake { Id = 3, Name = "name3", Abrv = "abrv3" },
            };
            return data;
        }
    }
}
