using MediatorCrud.Models;
using MediatorCrud.Pdtcxt;
using MediatorCrud.Rqsts;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace MediatorCrud.PdtHdlr
{
    public class GrabAllHdlr : IRequestHandler<prdtqry, List<Pdt>>
    {
        private readonly Pdtdata _pdtcxt;

        public GrabAllHdlr(Pdtdata pdtdata)
        {
            _pdtcxt = pdtdata;
        }

        public async Task<List<Pdt>> Handle(prdtqry prdtqry, CancellationToken cancellationToken)
        {
            return await _pdtcxt.Pdts.Include(p=>p.catgry).ToListAsync();
        }
    }
}
