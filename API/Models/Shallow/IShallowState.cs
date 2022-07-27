﻿using API.Models.Shallow.Primitives;
using API.Models.Shallow.Relationship.Primitives;

namespace API.Models.Shallow;

public interface IShallowState : ILonelyState, IShallowRelationshipClients
{
    
}