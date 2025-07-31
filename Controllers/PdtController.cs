using MediatorCrud.Models;
using MediatorCrud.Pdtcxt;
using MediatorCrud.Rqsts;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace MediatorCrud.Controllers
{
    public class PdtController : Controller
    {
        private readonly IMediator _mtr;
        private readonly Pdtdata _pdtdata;

        public PdtController(IMediator mtr,Pdtdata pdtdata)
        {
            _mtr = mtr;
            _pdtdata = pdtdata;
        }

        public async Task<IActionResult> GrabAll()
        {
            var pdts = await _mtr.Send(new prdtqry());
            return View(pdts);
        }

        public async Task<IActionResult> Erect()
        {
            ViewBag.ctgrs = new SelectList(_pdtdata.Ctgries.ToList(), "catgryId", "catgryNmae");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Erect(Erectpdtcmnd erectpdtcmnd)
        {
            if(!ModelState.IsValid)
            {
                ViewBag.ctgrs = new SelectList(_pdtdata.Ctgries.ToList(), "catgryId", "catgryNmae");
                return View(erectpdtcmnd);
            }
            await _mtr.Send(erectpdtcmnd);
            return RedirectToAction("GrabAll");
        }

        public async Task<IActionResult> Rescript(int id)
        {
            var pdt = await _mtr.Send(new Grabpdtqry(id));
            if (pdt == null) return NotFound();

            ViewBag.ctgrs = new SelectList(_pdtdata.Ctgries.ToList(), "catgryId", "catgryNmae", pdt.catgryId);

            return View(new Rescriptcmnd
            {
              Id=pdt.Id,
              rescriptname=pdt.PdtName,
              rescriptprice=pdt.PdtPrice,
              rescriptstock=pdt.PdtStk,
              rescriptdescr=pdt.PdtDescr,
              ctrId=pdt.catgryId
            }
            );
        }

        [HttpPost]
        public async Task<IActionResult> Rescript(Rescriptcmnd rescriptcmnd)
        {
            if(!ModelState.IsValid)
            {
                ViewBag.ctgrs = new SelectList(_pdtdata.Ctgries.ToList(), "Id", "Name", rescriptcmnd.ctrId);
                return View(rescriptcmnd);
            }
            await _mtr.Send(rescriptcmnd);
            return RedirectToAction("GrabAll");
        }
             
        public async Task<IActionResult> Expunge(int id)
        {
            await _mtr.Send(new Expungecmnd(id));
            return RedirectToAction("GrabAll");
        }
    }
}