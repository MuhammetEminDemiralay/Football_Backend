using Entities.Exceptions.Abstract;

namespace Entities.Exceptions.Concrete
{
    public class PriceOutOfRangeBadRequestException : BadRequestException
    {
        public PriceOutOfRangeBadRequestException() : base("Maximum price should be lass than 1000 and greater than 10")
        {
        }
    }
}
