using AutoMapper;
using ItemShop.Cargo.DTOs.CargoCompanyDTOs;
using ItemShop.Cargo.DTOs.CargoCustomerDTOs;
using ItemShop.Cargo.DTOs.CargoDetailDTOs;
using ItemShop.Cargo.DTOs.CargoOperationDTOs;
using ItemShop.Cargo.Entity.Concrete;

namespace ItemShop.Cargo.Business.Mapping
{
    public class GeneralMapping : Profile
    {
        public GeneralMapping()
        {
            //CargoCompany
            CreateMap<CargoCompany, ResultCargoCompanyDto>().ReverseMap();
            CreateMap<CargoCompany, CreateCargoCompanyDto>().ReverseMap();
            CreateMap<CargoCompany, GetByIdCargoCompanyDto>().ReverseMap();
            CreateMap<CargoCompany, UpdateCargoCompanyDto>().ReverseMap();

            //CargoDetail
            CreateMap<CargoDetail, ResultCargoDetailDto>().ReverseMap();
            CreateMap<CargoDetail, CreateCargoDetailDto>().ReverseMap();
            CreateMap<CargoDetail, GetByIdCargoDetailDto>().ReverseMap();
            CreateMap<CargoDetail, GetByIdCargoDetailDto>().ReverseMap();

            //CargoDetail
            CreateMap<CargoCustomer, ResultCargoCustomerDto>().ReverseMap();
            CreateMap<CargoCustomer, CreateCargoCustomerDto>().ReverseMap();
            CreateMap<CargoCustomer, GetByIdCargoCustomerDto>().ReverseMap();
            CreateMap<CargoCustomer, GetByIdCargoCustomerDto>().ReverseMap();
            //CargoDetail
            CreateMap<CargoOperation, ResultCargoOperationDto>().ReverseMap();
            CreateMap<CargoOperation, CreateCargoOperationDto>().ReverseMap();
            CreateMap<CargoOperation, GetByIdCargoOperationDto>().ReverseMap();
            CreateMap<CargoOperation, GetByIdCargoOperationDto>().ReverseMap();

        }
    }
}