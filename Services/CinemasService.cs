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
    public class CinemasService : ICinemasService
    {
        private readonly CinemaTicketDbContext _context;
        public CinemasService(CinemaTicketDbContext context)
        {
            _context = context; 
        }
        public async Task<string> Add(Cinema model)
        {
            try
            {
                if (!String.IsNullOrEmpty(model.Logo))
                {
                    string imageUrl = Helpers.AddFile(model.Logo);
                    model.Logo = imageUrl;
                    Helpers.AddFile(model.Logo);
                }
                _context.Cinemas.Add(model);
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
                var cinema = await _context.Cinemas.FindAsync(Id);
                if (cinema == null) return "No record found";
                _context.Cinemas.Remove(cinema);
                await _context.SaveChangesAsync();
                return "true";
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<List<Cinema>> GetAll(string name)
        {
            try
            {
                var items = _context.Cinemas.AsQueryable();
                if (!String.IsNullOrEmpty(name))
                {
                    items = items.Where(x => x.Name.ToLower().Contains(name.ToLower()));
                }
              
                if (items.Any())
                {
                    var List = await items.ToListAsync();
                    return List;
                }
                return new List<Cinema>();

            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<Cinema> GetById(int Id)
        {
            try
            {
                if (Id < 0) return new Cinema();
                var item = await _context.Cinemas.FindAsync(Id);
                if (item == null) return new Cinema();
                return item;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<string> Update(Cinema model)
        {
            if (model == null || model.Id <= 0) return "Incomplete Information";
            var cinema = await _context.Cinemas.FindAsync(model.Id);
            if (cinema == null) return "Record does not exist";
            if (model.Logo != null)
            {
                //First Remove Existing File from Folder and then Add New One 
            }
            cinema.Name = model.Name;
            cinema.Description = model.Description;
            await _context.SaveChangesAsync();
            return "true";
        }
    }
}
