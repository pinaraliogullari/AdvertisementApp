﻿using AdvertisementApp.Dtos.Interfaces;

namespace AdvertisementApp.Dtos.AppRoleDtos
{
    public class AppRoleListDto : IDto
    {
        public int Id { get; set; }
        public string Definition { get; set; }

    }
}
