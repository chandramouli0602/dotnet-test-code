using MediatorCrud.Models;
using MediatorCrud.Pdtcxt;
using MediatorCrud.Rqsts;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace MediatorCrud.PdtHdlr
{
    public class ErectHdlr : IRequestHandler<Erectpdtcmnd, Unit>    {
        private readonly Pdtdata _pdtdata;

        public ErectHdlr(Pdtdata pdtdata)
        {
            _pdtdata = pdtdata;
        }

        public async Task<Unit> Handle(Erectpdtcmnd erctcmnd,CancellationToken cancellation)
        {
            var pdt = new Pdt
            {
                PdtName = erctcmnd.Pdterectname,
                PdtPrice = erctcmnd.Pdterectprice,
                PdtDescr = erctcmnd.Pdterectdescr,
                PdtStk = erctcmnd.Pdterectstock,
                catgryId = erctcmnd.ctgrId
            };
            _pdtdata.Pdts.Add(pdt);
            await _pdtdata.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
