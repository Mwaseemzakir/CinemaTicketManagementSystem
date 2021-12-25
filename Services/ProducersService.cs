using CinemaTicketManagementSystem.Database;
using CinemaTicketManagementSystem.Interfaces;
using CinemaTicketManagementSystem.Models;
using CinemaTicketManagementSystem.Utils.Helpers;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CinemaTicketManagementSystem.Services
{
    public class ProducersService : IProducersService
    {
        private readonly CinemaTicketDbContext _context;
        public ProducersService(CinemaTicketDbContext context)
        {
            _context = context;
        }
        public async Task<string> Add(Producer model)
        {
            try
            {
                if (!String.IsNullOrEmpty(model.ProfilePictureUrl))
                {
                    string imageUrl = Helpers.AddFile(model.ProfilePictureUrl);
                    model.ProfilePictureUrl = imageUrl;
                    Helpers.AddFile(model.ProfilePictureUrl);
                }
               
                //Save Data in Table
                _context.Producers.Add(model);
                await _context.SaveChangesAsync();
                return "true";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public async Task<string> Delete(int Id)
        {
            try
            {
                if (Id <= 0) return "Invalid Id";
                var producer = await _context.Producers.FindAsync(Id);
                if (producer == null) return "No record found";
                _context.Producers.Remove(producer);
                await _context.SaveChangesAsync();
                return "true";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public async Task<List<Producer>> GetAll(string name)
        {
            try
            {
                var items = _context.Producers.AsQueryable();
                if (!String.IsNullOrEmpty(name))
                {
                    items = items.Where(x => x.FullName.ToLower().Contains(name.ToLower()));
                }

                if (items.Any())
                {
                    var List = await items.ToListAsync();
                    return List;
                }
                return new List<Producer>();

            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<Producer> GetById(int Id)
        {
            try
            {
                if (Id < 0) return new Producer();
                var item = await _context.Producers.FindAsync(Id);
                if (item == null) return new Producer();
                return item;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<string> Update(Producer model)
        {
            try
            {
                if (model == null || model.Id <= 0) return "Incomplete Information";
                var producer = await _context.Producers.FindAsync(model.Id);
                if (producer == null) return "Record does not exist";
                if (model.ProfilePictureUrl != null)
                {
                    //First Remove Existing File from Folder and then Add New One 
                }
                producer.Country = model.Country;
                producer.Bio = model.Bio;
                producer.FullName = model.FullName;
                await _context.SaveChangesAsync();
                return "true";
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
