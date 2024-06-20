using Microsoft.EntityFrameworkCore;
using PrescriptionDB.Data;
using PrescriptionDB.Models;

namespace PrescriptionDB.Services;

public class DoctorServices
{
    private readonly ApplicationDBContext _dbContext;

    public DoctorServices(ApplicationDBContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<List<Doctor>> GetDoctors()
    {
        return await _dbContext.Doctors.ToListAsync();
    }

    public async Task PostDoctor(Doctor doctor)
    {
        if (string.IsNullOrEmpty(doctor.SSN))
            throw new InvalidOperationException("SSN cannot be null or empty.");

        await _dbContext.Doctors.AddAsync(doctor);
        await _dbContext.SaveChangesAsync();
    }
}