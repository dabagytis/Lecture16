﻿using Lecture16_1.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lecture16_1.Core.Contracts.IService
{
    public interface IRentalService
    {
        void AddRental(NuomosUzsakymas nuomosUzsakymas);
        NuomosUzsakymas GetRental(int id);
        List<NuomosUzsakymas> GetAllRentals();
        void UpdateRental(NuomosUzsakymas nuomosUzsakymas);
        void DeleteRental(int id);
        List<NuomosUzsakymas> GetRentalsByCar(int id);
        List<NuomosUzsakymas> GetRentalsByClient(int id);
        List<NuomosUzsakymas> GetRentalsByWorker(int id);
        List<NuomosUzsakymas> GetRentalsInDateRange(DateTime startDate, DateTime endDate);
    }
}