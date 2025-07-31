using MediatR;

namespace MediatorCrud.Rqsts
{
    public class Expungecmnd:IRequest<Unit>
    {
        public int Id;
        public Expungecmnd(int id)
        {
            Id = id;
        }
    }
}
