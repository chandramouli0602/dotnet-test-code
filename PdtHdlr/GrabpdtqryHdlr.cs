using MediatorCrud.Models;
using MediatorCrud.Pdtcxt;
using MediatorCrud.Rqsts;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace MediatorCrud.PdtHdlr
{
    public class GrabpdtqryHdlr : IRequestHandler<Grabpdtqry, Pdt>
    {
        private readonly Pdtdata _pdtdata;

        public GrabpdtqryHdlr(Pdtdata pdtdata)
        {
            _pdtdata = pdtdata;
        }

        public async Task<Pdt?> Handle(Grabpdtqry grabpdtqry,CancellationToken cancellation)
        {
            return await _pdtdata.Pdts.Include(p => p.catgry).FirstOrDefaultAsync(p=>p.Id==grabpdtqry.Id);
        }
    }
}
