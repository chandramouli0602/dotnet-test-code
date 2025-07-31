namespace MediatorCrud.Models
{
    public class Pdt
    {
        public int Id { get; set; }  
        public string PdtName { get; set; } = string.Empty;
        public int PdtStk { get; set; }
        public string PdtDescr { get; set; } = string.Empty;
        public decimal PdtPrice { get; set; }
        public int catgryId { get; set; } 
        public ctgry catgry { get; set; } = null!;
    }
}
