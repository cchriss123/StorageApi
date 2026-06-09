namespace StorageApi.Models;

public class Product(int id, string name, int price, string category, string shelf, int count, string description)
{
    int Id  { get; set; } = id;
    string Name   { get; set; } = name;
    int Price   { get; set; } = price;
    string Category   { get; set; } = category;
    string Shelf    { get; set; } = shelf;
    int Count   { get; set; } = count;
    string Description   { get; set; } = description;
}