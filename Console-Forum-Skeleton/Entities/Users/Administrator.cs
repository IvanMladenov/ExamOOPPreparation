﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleForum.Entities.Users
{
    using ConsoleForum.Contracts;

    public class Administrator:User
    {
        public Administrator(int id, string name, string password, string email)
            : base(id, name, password, email)
        {
        }
    }
}
