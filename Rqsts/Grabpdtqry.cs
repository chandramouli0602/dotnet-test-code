using MediatorCrud.Models;
using MediatR;

namespace MediatorCrud.Rqsts
{
    public class Grabpdtqry:IRequest<Pdt?>
    {
        public int Id;
        public Grabpdtqry(int id)
        {
            Id = id;
        }
    }
}
