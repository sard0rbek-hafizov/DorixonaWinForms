using System.ComponentModel.DataAnnotations;

namespace Dorixona.Domain.Models.AdminModel.AdminDTO;

public class AdminPaginationDto
{
    [Range(1, int.MaxValue, ErrorMessage = "Sahifa raqami 1 yoki undan katta bo‘lishi kerak.")]
    public int PageNumber { get; set; } = 1;

    [Range(1, 100, ErrorMessage = "Har bir sahifada ko‘rsatiladigan elementlar soni 1 dan 100 gacha bo‘lishi kerak.")]
    public int PageSize { get; set; } = 10;

    [MaxLength(50, ErrorMessage = "Qidiruv qiymati 50 belgidan oshmasligi kerak.")]
    public string? Search { get; set; }

    [MaxLength(20, ErrorMessage = "Saralash maydoni nomi 20 belgidan oshmasligi kerak.")]
    public string? SortBy { get; set; }

    [RegularExpression("^(asc|desc)$", ErrorMessage = "Saralash tartibi faqat 'asc' yoki 'desc' bo‘lishi mumkin.")]
    public string? SortOrder { get; set; } = "asc";
}
