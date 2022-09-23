﻿using System;
using System.Collections.Generic;

namespace Starex.Domain.Entities.Base
{
    public abstract class BaseEntity
    {
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
