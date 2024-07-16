﻿using AdvertisementApp.Dtos.ProvidedServiceDtos;
using AdvertisementApp.Entities;

namespace AdvertisementApp.Business.Interfaces
{
    public interface IProvidedServiceManager:IService<ProvidedServiceCreateDto,ProvidedServiceUpdateDto,ProvidedServiceListDto,ProvidedService>
    {
    }
}