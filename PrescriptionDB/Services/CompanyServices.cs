using Microsoft.EntityFrameworkCore;
using PrescriptionDB.Data;
using PrescriptionDB.Model;
using PrescriptionDB.Models;

namespace PrescriptionDB.Services;

public class CompanyServices
{
        private readonly ApplicationDBContext _dbContext;

        public CompanyServices(ApplicationDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<PharmaceuticalCompany>> Get()
        {
            return await _dbContext.PharmaceuticalCompanies.ToListAsync();
        }

        public async Task Post(PharmaceuticalCompany company)
        {
            await _dbContext.PharmaceuticalCompanies.AddAsync(company);
            await _dbContext.SaveChangesAsync();
        }

}