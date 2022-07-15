﻿using DataAccess.Models.Interfaces.Primitives;
using DataAccess.Models.Interfaces.Relationships;

namespace DataAccess.Models.Interfaces;

public interface IInfrastructureVariables : IKeyValue,
    IInfrastructureVariablesRelationships
{

}