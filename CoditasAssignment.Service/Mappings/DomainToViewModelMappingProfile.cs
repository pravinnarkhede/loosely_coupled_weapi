using AutoMapper;
using CoditasAssignment.Data;
using CoditasAssignment.Data.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CoditasAssignment.Service
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public override string ProfileName
        {
            get { return "DomainToViewModelMappings"; }
        }
        protected override void Configure()
        {
            Mapper.CreateMap<Store, StoreViewModel>();
            Mapper.CreateMap<Category, CategoryViewModel>();
            Mapper.CreateMap<Item, ItemViewModel>();
            Mapper.CreateMap<ItemModifire, ModifireViewModel>();
            Mapper.CreateMap<Order, OrderViewModel>();
            Mapper.CreateMap<OrderItem, OrderItemViewModel>();
            Mapper.CreateMap<OrderItemModifire, OrderItemModifireViewModel>();
        }
    }
}