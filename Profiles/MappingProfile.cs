using AutoMapper;
using TransactionAssessment.Models;

namespace TransactionAssessment.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<TransactionViewModel, Transaction>();
        }
    }
}
