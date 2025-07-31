using MediatR;

namespace MediatorCrud.Rqsts
{
    public class Rescriptcmnd:IRequest<Unit>
    {
        public int Id{ get; set; }
        public string rescriptname { get; set; }
        public decimal rescriptprice { get; set; }
        public string rescriptdescr { get; set; }
        public int rescriptstock { get; set; }
        public int ctrId { get; set; }


    }
}
