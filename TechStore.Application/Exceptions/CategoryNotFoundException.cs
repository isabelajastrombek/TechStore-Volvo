namespace TechStore.Application.Exceptions;

public class CategoryNotFoundException : Exception
{
    public CategoryNotFoundException(int id) 
        : base($"A categoria com ID {id} não foi encontrada no sistema.")
    {
    }
}