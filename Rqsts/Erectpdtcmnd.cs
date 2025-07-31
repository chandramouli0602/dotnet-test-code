using MediatR;

namespace MediatorCrud.Rqsts
{
    public class Erectpdtcmnd:IRequest<Unit>
    {
        public int id { get; set; }
        public string Pdterectname{ get; set; }
        public decimal Pdterectprice{ get; set; }
        public string Pdterectdescr { get; set; }
        public int Pdterectstock { get; set; }
        public int ctgrId { get; set; }
    }
}
