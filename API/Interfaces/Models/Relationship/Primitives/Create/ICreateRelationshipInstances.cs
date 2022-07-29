﻿using API.Converters;
using DataAccess.Models.Interfaces.Primitives;
using Newtonsoft.Json;

namespace API.Interfaces.Models.Relationship.Primitives.Create;

public interface ICreateRelationshipInstances
{
    [JsonConverter(typeof(ConverterINamed))]
    public ICollection<INamed> Instances { get; set; }

}