﻿using API.Models.Shallow.Primitives;

namespace API.Models.Lonely;

public class LonelyProduct : ILonelyProduct
{
    public int Id { get; set; }

    public string Name { get; set; }
}