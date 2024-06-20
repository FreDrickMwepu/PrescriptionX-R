using Microsoft.EntityFrameworkCore;
using PrescriptionDB.Data;
using PrescriptionDB.Models;

namespace PrescriptionDB.Services;

public class PatientServices
{
    private readonly ApplicationDBContext _dbContext;

    public PatientServices(ApplicationDBContext dbContext)
    {
        _dbContext = dbContext;
    }

    // Get a list of patients
    public async Task<List<Patient>> GetPatients()
    {
        return await _dbContext.Patients.ToListAsync();
    }

    // Get a patient by SSN
    public async Task<Patient> GetPatientBySsn(string ssn)
    {
        return await _dbContext.Patients.FindAsync(ssn);
    }

    // Add a new patient
    public async Task PostPatient(Patient patient)
    {
        await _dbContext.Patients.AddAsync(patient);
        await _dbContext.SaveChangesAsync();
    }

    // Update an existing patient
    public async Task UpdatePatient(Patient patient)
    {
        _dbContext.Patients.Update(patient);
        await _dbContext.SaveChangesAsync();
    }

    // Delete a patient by SSN
    public async Task DeletePatient(string ssn)
    {
        var patient = await _dbContext.Patients.FindAsync(ssn);
        if (patient != null)
        {
            _dbContext.Patients.Remove(patient);
            await _dbContext.SaveChangesAsync();
        }
    }
}