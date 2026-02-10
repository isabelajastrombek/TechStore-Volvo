public class CategoryResponseDto
{
    public int IdCategory { get; set; }
    public string NameCategory { get; set; }

    public CategoryResponseDto(int idCategory, string nameCategory)
    {
        IdCategory = idCategory;
        NameCategory = nameCategory;
    }
}