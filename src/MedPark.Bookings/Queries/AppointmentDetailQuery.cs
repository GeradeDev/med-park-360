using MedPark.Bookings.Dto;
using MedPark.Common.Types;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedPark.Bookings.Queries
{
    public class AppointmentDetailQuery : IQuery<AppointmentDetailDto>
    {
        public Guid AppointmentId { get; set; }
    }
}
