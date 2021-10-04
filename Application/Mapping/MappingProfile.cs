﻿using Application.DTOs;
using AutoMapper;
using Domain.Models;

namespace Application.Mapping
{
    public class MappingProfile : Profile

    {
        public MappingProfile()
        {
            CreateMap<Root, RootDTO>();
            CreateMap<ContactPoint, ContactPointDTO>();
            CreateMap<Distribution, DistributionDTO>();
            CreateMap<DownloadUrlDocument, DownloadUrlDocumentDTO>();
            CreateMap<Publisher, PublisherDTO>();
            CreateMap<GovInformation, GovInformationDTO>();
        }
    }
}