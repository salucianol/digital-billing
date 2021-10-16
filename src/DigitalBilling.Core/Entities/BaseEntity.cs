﻿using System;

namespace DigitalBilling.Core.Entities {
    public class BaseEntity {
        public Guid Id { get; set; }
        public DateTime Created { get; set; }
        public DateTime Modified { get; set; }
    }
}
