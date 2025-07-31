using System.ComponentModel.DataAnnotations;

namespace MediatorCrud.Models
{
    public class ctgry
    {
        [Key]
        public int catgryId { get; set; }  
        public string catgryNmae { get; set; } = string.Empty;
        public ICollection<Pdt> Pdts { get; set; } = new List<Pdt>();
    }
}