using AutoMapper;
using MedPark.Common;
using MedPark.Common.Handlers;
using MedPark.MedicalPractice.Domain;
using MedPark.MedicalPractice.Dto;
using MedPark.MedicalPractice.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedPark.MedicalPractice.Handlers.MedicalPractice
{
    public class InstituteQueryHandler : IQueryHandler<InstituteQuery, InstituteDTO>
    {
        private IMedParkRepository<Institute> _instituteRepo { get; }
        private IMapper _mapper { get; }

        public InstituteQueryHandler(IMedParkRepository<Institute> instituteRepo, IMapper mapper)
        {
            _instituteRepo = instituteRepo;
            _mapper = mapper;
        }

        public async Task<InstituteDTO> HandleAsync(InstituteQuery query)
        {
            Institute i = await _instituteRepo.GetAsync(query.Id);

            return _mapper.Map<InstituteDTO>(i);
        }
    }
}
