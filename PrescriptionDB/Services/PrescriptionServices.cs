using Microsoft.EntityFrameworkCore;
using PrescriptionDB.Data;
using PrescriptionDB.Models;

namespace PrescriptionDB.Services;

public class PrescriptionServices
{
    private readonly ApplicationDBContext _dbContext;

    public PrescriptionServices(ApplicationDBContext dbContext)
    {
        _dbContext = dbContext;
    }

    // Get a list of prescriptions
    public async Task<List<Prescription>> GetPrescriptions()
    {
        return await _dbContext.Prescriptions
            .Include(p => p.Patient)
            .Include(p => p.Doctor)
            .Include(p => p.Drug)
            .ToListAsync();
    }

    // Get a prescription by ID
    public async Task<Prescription> GetPrescriptionById(int id)
    {
        return await _dbContext.Prescriptions
            .Include(p => p.Patient)
            .Include(p => p.Doctor)
            .Include(p => p.Drug)
            .FirstOrDefaultAsync(p => p.PrescriptionID == id);
    }

    // Add a new prescription
    public async Task PostPrescription(Prescription prescription)
    {
        await _dbContext.Prescriptions.AddAsync(prescription);
        await _dbContext.SaveChangesAsync();
    }

    // Update an existing prescription
    public async Task UpdatePrescription(Prescription prescription)
    {
        _dbContext.Prescriptions.Update(prescription);
        await _dbContext.SaveChangesAsync();
    }

    // Delete a prescription by ID
    public async Task DeletePrescription(int id)
    {
        var prescription = await _dbContext.Prescriptions.FindAsync(id);
        if (prescription != null)
        {
            _dbContext.Prescriptions.Remove(prescription);
            await _dbContext.SaveChangesAsync();
        }
    }
}