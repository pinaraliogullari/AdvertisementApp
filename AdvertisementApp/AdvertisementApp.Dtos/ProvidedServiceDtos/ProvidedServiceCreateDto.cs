﻿using AdvertisementApp.Dtos.Interfaces;

namespace AdvertisementApp.Dtos.ProvidedServiceDtos
{
    public class ProvidedServiceCreateDto:IDto
    {
        public string Title { get; set; }
        public string ImagePath { get; set; }
        public string Description { get; set; }
    }
}
