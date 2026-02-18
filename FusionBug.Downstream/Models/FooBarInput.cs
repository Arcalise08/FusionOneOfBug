namespace FusionBug.Downstream.Models;
[OneOf]
public class FooBarInput
{
    public Foo? Foo { get; set; }
    public Bar? Bar { get; set; }
}