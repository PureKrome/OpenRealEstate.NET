﻿using System;
using System.Collections.Generic;

namespace OpenRealEstate.Core.Models
{
    public class Franchise : AggregateRoot
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; }
        public Dictionary<string, string> WebSites { get; set; }
        public IList<Media> Logos { get; set; }
        public IList<Media> Images { get; set; }
        public IList<Media> Videos { get; set; }

        public void Validate(Dictionary<string, string> errors)
        {
            if (errors == null)
            {
                throw new ArgumentNullException("errors");
            }

            base.Validate(errors);

            if (string.IsNullOrWhiteSpace(Name))
            {
                errors.Add("Name", "A name is required.");
            }
        }
    }
}