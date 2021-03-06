﻿using System;
using System.Collections.Generic;
using TrovTHA.Models;

namespace TrovTHA.Repository
{
    public interface IUserRepository
    {
        IEnumerable<ApplicationUser> FindAll();
        ApplicationUser Save(ApplicationUser user);
        ApplicationUser FindByUsername(string userName);
        ApplicationUser FindById(string id);
    }
}
