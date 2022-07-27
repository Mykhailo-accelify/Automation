﻿using API.Models.Shallow;
using API.Models.Unidentified;

namespace API.Profile
{
    using API.Models.Client;
    using API.Models.Old;
    using AutoMapper;
    using DataAccess.Entities;
    using DataAccess.Models.Base;
    using DataAccess.Models.Identified;

    public class AutomatizationProfile : Profile
    {
        public AutomatizationProfile()
        {            
            CreateMap<IUnidentifiedClient, Client>();
            CreateMap<NameModel, Infrastructure>();
            CreateMap<NameModel, State>();
            CreateMap<NameModel, Product>();

            CreateMap<InfrastructurePut, Infrastructure>();
            CreateMap<InstancePut, Instance>();
            CreateMap<ClientPut, Client>();

            CreateMap<Client, IShallowClient>()
                .ReverseMap();
            CreateMap<Infrastructure, InfrastructureOneNested>();
            CreateMap<Configuration, ConfigurationOneNested>();
            CreateMap<Instance, InstanceOneNested>();
            CreateMap<Product, ProductOneNested>()
                .ReverseMap();
            CreateMap<TypeInfrastructure, TypeInfrastructureOneNested>()
                .ReverseMap();
            CreateMap<TypeInstance, TypeInstanceOneNested>()
                .ReverseMap();

            CreateMap<Client, ClientIdentified>().ReverseMap();
            CreateMap<Configuration, ConfigurationIdentified>().ReverseMap();
            CreateMap<Infrastructure, InfrastructureIdentified>().ReverseMap();
            CreateMap<Instance, InstanceIdentified>().ReverseMap();
            CreateMap<Product, ProductIdentified>().ReverseMap();
            CreateMap<TypeInfrastructure, TypeInfrastructureIdentified>().ReverseMap();
            CreateMap<TypeInstance, TypeInfrastructureIdentified>().ReverseMap();


            //CreateMap<ClientBase, Client>();
            CreateMap<InfrastructureBase, Infrastructure>();
            CreateMap<StateBase, State>();
            CreateMap<ConfigurationBase, Configuration>();
            CreateMap<InstanceBase, Instance>();
            CreateMap<ProductBase, Product>();
            CreateMap<TypeInfrastructureBase, TypeInfrastructure>();
            CreateMap<TypeInstanceBase, TypeInstance>();
        }
    }
}