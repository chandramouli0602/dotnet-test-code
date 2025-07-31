using MediatorCrud.Pdtcxt;
using MediatorCrud.Rqsts;
using MediatR;

namespace MediatorCrud.PdtHdlr
{
    public class ExpungeHdlr : IRequestHandler<Expungecmnd, Unit>
    {
        private readonly Pdtdata _pdtdata;

        public ExpungeHdlr(Pdtdata pdtdata)
        {
            _pdtdata = pdtdata;
        }

        public async Task<Unit> Handle(Expungecmnd expungecmnd,CancellationToken cancellation)
        {
            var pdt = await _pdtdata.Pdts.FindAsync(expungecmnd.Id);
            if (pdt != null)
            {
                _pdtdata.Pdts.Remove(pdt);
                await _pdtdata.SaveChangesAsync();
            }
            return Unit.Value;

        }
    }
}
