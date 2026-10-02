using System;
using System.Linq;
using PharmaInventory.Models;

namespace PharmaInventory.Data
{
    public static class DbInitializer
    {
        public static void Initialize(PharmaContext context)
        {
          
            context.Database.EnsureCreated();

          
            if (context.Drugs.Any())
            {
                return;
            }

            var drugs = new Drug[]
            {
                new Drug
                {
                    DrugName = "Amoxicillin 500mg",
                    BatchNumber = "AMX-2025-001",
                    ManufactureDate = DateTime.Now.AddMonths(-12),
                    ExpiryDate = DateTime.Now.AddMonths(18),
                    Quantity = 250,
                    Supplier = "MediHealth Pharma"
                },
                new Drug
                {
                    DrugName = "Paracetamol 650mg",
                    BatchNumber = "PAR-2026-042",
                    ManufactureDate = DateTime.Now.AddMonths(-6),
                    ExpiryDate = DateTime.Now.AddDays(30), 
                    Quantity = 120,
                    Supplier = "Global BioCare"
                },
                new Drug
                {
                    DrugName = "Ibuprofen 400mg",
                    BatchNumber = "IBU-2024-109",
                    ManufactureDate = DateTime.Now.AddMonths(-24),
                    ExpiryDate = DateTime.Now.AddDays(-15), 
                    Quantity = 45,
                    Supplier = "Apex LifeSciences"
                },
                new Drug
                {
                    DrugName = "Cetirizine 10mg",
                    BatchNumber = "CET-2026-088",
                    ManufactureDate = DateTime.Now.AddMonths(-4),
                    ExpiryDate = DateTime.Now.AddMonths(12), 
                    Quantity = 300,
                    Supplier = "MediHealth Pharma"
                },
                new Drug
                {
                    DrugName = "Azithromycin 250mg",
                    BatchNumber = "AZI-2025-303",
                    ManufactureDate = DateTime.Now.AddMonths(-8),
                    ExpiryDate = DateTime.Now.AddDays(10), 
                    Quantity = 80,
                    Supplier = "Global BioCare"
                }
            };

            context.Drugs.AddRange(drugs);
            context.SaveChanges();
        }
    }
}