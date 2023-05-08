﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace FitnessCenter.BD.EntitiesBD.Repositories
{
    public class Services
    {
        public Guid Id { get; set; }
        public string Title { get; set; }

        [ForeignKey("Abonements")]
        public Guid AbonementId { get; set; }

        public virtual ICollection<Abonements> Abonement { get; set; }
    }
}