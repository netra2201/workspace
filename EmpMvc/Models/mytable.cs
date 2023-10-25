using System.ComponentModel.DataAnnotations;
namespace EmpMvc.Models;

public class mytable{
    [Display(Name = "Product Id")]
    [Key]
    [Required(ErrorMessage = "Id is Compulsary")]

    public int id {get;set;}

    [Required(ErrorMessage =  "Name Cannot be Blank")]
    public string? name {get;set;}

    [Range(100,900,ErrorMessage = "salary should be between 100 and 900")]
     public int salary{get;set;}
}