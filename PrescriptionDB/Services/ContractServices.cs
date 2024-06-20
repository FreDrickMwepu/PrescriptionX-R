using Microsoft.EntityFrameworkCore;
using PrescriptionDB.Data;
using PrescriptionDB.Model;
using PrescriptionDB.Models;

namespace PrescriptionDB.Services;

public class ContractServices
{
    private readonly ApplicationDBContext _dbContext;

    public ContractServices(ApplicationDBContext dbContext)
    {
        _dbContext = dbContext;
    }

    // Get a list of contracts
    public async Task<List<Contract>> GetContracts()
    {
        return await _dbContext.Contracts.ToListAsync();
    }

    // Get a contract by ID
    public async Task<Contract> GetContractById(int id)
    {
        return await _dbContext.Contracts.FindAsync(id);
    }

    // Add a new contract
    public async Task PostContract(Contract contract)
    {
        await _dbContext.Contracts.AddAsync(contract);
        await _dbContext.SaveChangesAsync();
    }

    // Update an existing contract
    public async Task UpdateContract(Contract contract)
    {
        _dbContext.Contracts.Update(contract);
        await _dbContext.SaveChangesAsync();
    }

    // Delete a contract by ID
    public async Task DeleteContract(int id)
    {
        var contract = await _dbContext.Contracts.FindAsync(id);
        if (contract != null)
        {
            _dbContext.Contracts.Remove(contract);
            await _dbContext.SaveChangesAsync();
        }
    }

}