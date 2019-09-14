using MedPark.Web.Dto;
using RestEase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedPark.Web.Services
{
    [SerializationMethods(Query = QuerySerializationMethod.Serialized)]
    public interface IMedParcticeService
    {
        [Get("api/specialist/{id}")]
        Task<SpecialistDto> GetSpecialistDetails([Path] Guid id);

        [Get("api/specialist/getpractice/{id}")]
        Task<PracticeDto> GetPracticeDetails([Path] Guid id);
    }
}
