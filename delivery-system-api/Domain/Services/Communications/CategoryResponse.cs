using delivery_system_api.Domain.Models;

namespace delivery_system_api.Domain.Services.Communications
{
    public class CategoryResponse : BaseResponse
    { 
     public Category Category { get; set; }
    public CategoryResponse(bool success, string message, Category category) : base(success, message)
    {
            Category = category;
    }
    public CategoryResponse(Category category) : this(true, string.Empty, category)
    {

    }
    public CategoryResponse(string message) : this(false, message, null)
    {

    }
}
    
}

