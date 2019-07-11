using System;
using System.Collections.Generic;
using System.Text;

namespace MedPark.Common
{
    public interface IIdentifiable
    {
        Guid Id { get; }
    }
}
