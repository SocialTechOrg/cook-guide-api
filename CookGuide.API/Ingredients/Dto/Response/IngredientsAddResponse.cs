﻿namespace CookGuide.API.Ingredients.Dto.Response;

public class IngredientsAddResponse
{
    public int id {get; set;}
    public string name { get; set; }
    public string other_names { get; set; }
    public string nutrients { get; set; }
    public string description { get; set; }
}