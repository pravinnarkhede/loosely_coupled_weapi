using AutoMapper;
using CoditasAssignment.Data;
using CoditasAssignment.Data.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CoditasAssignment.Service
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public override string ProfileName
        {
            get { return "ViewModelToDomainMappings"; }
        }

        protected override void Configure()
        {
            Mapper.CreateMap<StoreViewModel, Store>()
                .ForMember(g => g.id, map => map.MapFrom(vm => vm.Id))
                .ForMember(g => g.name, map => map.MapFrom(vm => vm.Name));

            Mapper.CreateMap<CategoryViewModel, Category>()
                .ForMember(g => g.id, map => map.MapFrom(vm => vm.Id))
                .ForMember(g => g.name, map => map.MapFrom(vm => vm.Name));


            Mapper.CreateMap<ItemViewModel, Item>()
               .ForMember(g => g.id, map => map.MapFrom(vm => vm.Id))
               .ForMember(g => g.name, map => map.MapFrom(vm => vm.Name))
               .ForMember(g => g.price, map => map.MapFrom(vm => vm.Price));

            Mapper.CreateMap<ModifireViewModel, ItemModifire>()
              .ForMember(g => g.id, map => map.MapFrom(vm => vm.Id))
              .ForMember(g => g.name, map => map.MapFrom(vm => vm.Name))
              .ForMember(g => g.price, map => map.MapFrom(vm => vm.Price));

            Mapper.CreateMap<OrderViewModel, Order>()
              .ForMember(g => g.id, map => map.MapFrom(vm => vm.Id))
              .ForMember(g => g.order_date, map => map.MapFrom(vm => vm.OrderDate))
              .ForMember(g => g.order_number, map => map.MapFrom(vm => vm.OrderNumber))
              .ForMember(g => g.tax, map => map.MapFrom(vm => vm.Tax))
              .ForMember(g => g.sub_total, map => map.MapFrom(vm => vm.SubTotal))
              .ForMember(g => g.total, map => map.MapFrom(vm => vm.Total));

            Mapper.CreateMap<OrderItemViewModel, OrderItem>()
             .ForMember(g => g.id, map => map.MapFrom(vm => vm.Id))
             .ForMember(g => g.order_id, map => map.MapFrom(vm => vm.OrderId))
             .ForMember(g => g.item_id, map => map.MapFrom(vm => vm.ItemId))
             .ForMember(g => g.quantity, map => map.MapFrom(vm => vm.Quantity))
             .ForMember(g => g.price, map => map.MapFrom(vm => vm.Price));

            Mapper.CreateMap<OrderItemModifireViewModel, OrderItemModifire>()
             .ForMember(g => g.id, map => map.MapFrom(vm => vm.Id))
             .ForMember(g => g.order_item_id, map => map.MapFrom(vm => vm.OrderItemId))
             .ForMember(g => g.modifire_id, map => map.MapFrom(vm => vm.ModifireId));
        }
    }
}