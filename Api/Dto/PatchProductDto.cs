namespace Api.Dto;

public class PatchProductDto
{
    public PatchProperty<string>? Name { get; set; }

    public PatchProperty<string>? Description { get; set; }
}