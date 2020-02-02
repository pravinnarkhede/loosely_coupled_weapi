using AutoMapper;
using CoditasAssignment.Data;
using CoditasAssignment.Data.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CoditasAssignemnt.Mappings
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public override string ProfileName
        {
            get { return "ViewModelToDomainMappings"; }
        }

        protected override void Configure()
        {
            Mapper.CreateMap<CategoryViewModel, Category>()
                .ForMember(g => g.id, map => map.MapFrom(vm => vm.id))
                .ForMember(g => g.name, map => map.MapFrom(vm => vm.name));


            Mapper.CreateMap<ProductViewModel, Product>()
               .ForMember(g => g.id, map => map.MapFrom(vm => vm.Id))
               .ForMember(g => g.name, map => map.MapFrom(vm => vm.Name));
        }
    }
}