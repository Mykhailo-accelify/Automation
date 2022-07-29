﻿using API.Converters;
using API.Models.Create.Primitives;
using DataAccess.Models.Interfaces.Primitives;
using Newtonsoft.Json;

namespace API.Interfaces.Models.Relationship.Primitives.Create;

public interface ICreateRelationshipState
{
    [JsonConverter(typeof(InterfaceConverter<Named, INamed>))]
    public INamed State { get; set; }

}