using API.Interfaces.Models.Primitives;
using API.Models.Create;
using API.Models.Lonely;
using API.Models.Old;
using API.Models.Shallow;
using API.Models.Shallow.Primitives;
using API.Models.Unidentified;
using AutoMapper;
using DataAccess.Entities;
using DataAccess.Models.Base;
using DataAccess.Models.Identified;
using DataAccess.Models.Interfaces.Primitives;

namespace API.Profiles;

public class AutomationProfile : Profile
{
    public AutomationProfile()
    {
        // //CreateMap<CreateClient, Client>();
        // CreateMap<NameModel, Infrastructure>();
        // CreateMap<NameModel, State>();
        // CreateMap<NameModel, Product>();

        // CreateMap<InfrastructurePut, Infrastructure>();
        // CreateMap<InstancePut, Instance>();
        // //CreateMap<ClientPut, Client>();

        // //CreateMap<Client, ShallowClient>()
        ////     .ReverseMap();
        // CreateMap<Infrastructure, InfrastructureOneNested>();
        // CreateMap<Configuration, ConfigurationOneNested>();
        // CreateMap<Instance, InstanceOneNested>();
        // CreateMap<Product, ProductOneNested>()
        //     .ReverseMap();
        // CreateMap<TypeInfrastructure, TypeInfrastructureOneNested>()
        //     .ReverseMap();
        // CreateMap<TypeInstance, TypeInstanceOneNested>()
        //     .ReverseMap();

        // //CreateMap<Client, ClientIdentified>().ReverseMap();
        // CreateMap<Configuration, ConfigurationIdentified>().ReverseMap();
        // CreateMap<Infrastructure, InfrastructureIdentified>().ReverseMap();
        // CreateMap<Instance, InstanceIdentified>().ReverseMap();
        // CreateMap<Product, ProductIdentified>().ReverseMap();
        // CreateMap<TypeInfrastructure, TypeInfrastructureIdentified>().ReverseMap();
        // CreateMap<TypeInstance, TypeInfrastructureIdentified>().ReverseMap();


        // //CreateMap<ClientBase, Client>();
        // CreateMap<InfrastructureBase, Infrastructure>();
        // CreateMap<StateBase, State>();
        // CreateMap<ConfigurationBase, Configuration>();
        // CreateMap<InstanceBase, Instance>();
        // CreateMap<ProductBase, Product>();
        // CreateMap<TypeInfrastructureBase, TypeInfrastructure>();
        // CreateMap<TypeInstanceBase, TypeInstance>();


        CreateMap<Client, ShallowClient>()
            .ReverseMap();
        CreateMap<Product, ShallowProduct>()
            .ReverseMap();
        CreateMap<Infrastructure, ShallowInfrastructure>()
            .ReverseMap();
        CreateMap<State, ShallowState>()
            .ReverseMap();

        CreateMap<CreateClient, Client>();

        //When creating for an easier way to link( Just specify name)
        CreateMap<INamed, Product>();
        CreateMap<INamed, State>();
        CreateMap<INamed, Client>();
        CreateMap<INamed, Infrastructure>();
        CreateMap<INamed, Instance>();
        CreateMap<INamed, TypeInstance>();
        CreateMap<INamed, TypeInfrastructure>();

        //When 
        CreateMap<Product, LonelyProduct>();
        CreateMap<State, LonelyState>();
        CreateMap<Client, LonelyClient>();
        CreateMap<Infrastructure, LonelyInfrastructure>();
        CreateMap<Instance, LonelyInstance>();
        CreateMap<TypeInstance, LonelyType>();
        CreateMap<TypeInfrastructure, LonelyType>();

        CreateMap<Product, ILonelyProduct>().As<LonelyProduct>();
        CreateMap<State, ILonelyState>().As<LonelyState>();
        CreateMap<Client, ILonelyClient>().As<LonelyClient>();
        CreateMap<Infrastructure, ILonelyInfrastructure>().As<LonelyInfrastructure>();
        CreateMap<Instance, ILonelyInstance>().As<LonelyInstance>();
        CreateMap<TypeInstance, IType>().As<LonelyType>();
        CreateMap<TypeInfrastructure, IType>().As<LonelyType>();
        //CreateMap<, >().As<>();
    }
}