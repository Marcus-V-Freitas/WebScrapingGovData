﻿using Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IExtractGovWebDataRepository
    {
        Task<bool> SaveExtractGovData(List<GovInformation> informations);
    }
}