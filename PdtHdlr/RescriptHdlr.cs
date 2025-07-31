using MediatorCrud.Pdtcxt;
using MediatorCrud.Rqsts;
using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;

namespace MediatorCrud.PdtHdlr
{
    public class RescriptHdlr : IRequestHandler<Rescriptcmnd, Unit>
    {
        private readonly Pdtdata _pdtdata;

        public RescriptHdlr(Pdtdata pdtdata)
        {
            _pdtdata = pdtdata;
        }

        public async Task<Unit> Handle(Rescriptcmnd rescriptcmnd,CancellationToken cancellationToken)
        {
            var pdt = await _pdtdata.Pdts.FindAsync(rescriptcmnd.Id);
            if (pdt == null)
                return Unit.Value;
            pdt.PdtName = rescriptcmnd.rescriptname;
            pdt.PdtPrice = rescriptcmnd.rescriptprice;
            pdt.PdtDescr = rescriptcmnd.rescriptdescr;
            pdt.PdtStk = rescriptcmnd.rescriptstock;
            pdt.catgryId = rescriptcmnd.ctrId;

            await _pdtdata.SaveChangesAsync();
            return Unit.Value;
        }
    }
}
