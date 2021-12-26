using CinemaTicketManagementSystem.Database;
using CinemaTicketManagementSystem.Interfaces;
using CinemaTicketManagementSystem.Interfaces.Base;
using CinemaTicketManagementSystem.Models;
using CinemaTicketManagementSystem.Utils.Helpers;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace CinemaTicketManagementSystem.Services
{
    public class ActorsService : IActorsService
    {
        private readonly CinemaTicketDbContext _context;
        public ActorsService(CinemaTicketDbContext context)
        {
            _context = context;
        }
        public async Task<string> AddAsync(Actor model)
        {
            try
            {
                if(!String.IsNullOrEmpty(model.ProfilePictureUrl))
                {
                    string imageUrl = Helpers.AddFile(model.ProfilePictureUrl);
                    model.ProfilePictureUrl = imageUrl;
                    Helpers.AddFile(model.ProfilePictureUrl);
                }
                _context.Actors.Add(model);
                await _context.SaveChangesAsync();
                return "true";
            }
            catch (Exception)
            {
                throw;
            }   
        }

        public async Task<string> DeleteAsync(int Id)
        {
            try
            {
                if(Id <= 0) return "Invalid Id";
                var actor =await _context.Actors.FindAsync(Id);
                if(actor == null) return "No record found";
                _context.Actors.Remove(actor);
                await _context.SaveChangesAsync();
                return "true";
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<List<Actor>> GetAll(string name, string country)
        {
            try
            {
                var items = _context.Actors.AsQueryable();
                if (!String.IsNullOrEmpty(name))
                {
                    items = items.Where(x => x.FullName.ToLower().Contains(name.ToLower()));
                }
                if (!String.IsNullOrEmpty(country))
                {
                    items = items.Where(x => x.Country.ToLower().Contains(country.ToLower()));
                }
                if (items.Any())
                {
                    var List = await items.ToListAsync();
                    return List;
                }
                return new List<Actor>();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Actor> GetByIdAsync(int Id)
        {
            try
            {
                if(Id < 0) return new Actor();
                var item = await _context.Actors.FindAsync(Id); 
                if(item == null)  return new Actor();
                return item;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<string> UpdateAsync(Actor model)
        {
            try
            {
                if (model == null || model.Id <= 0) return "Incomplete Information";
                var actor = await _context.Actors.FindAsync(model.Id);
                if (actor == null) return "Record does not exist";
                if (model.ProfilePictureUrl != null)
                {
                    //First Remove Existing File from Folder and then Add New One 
                }
                actor.Country = model.Country;
                actor.Bio = model.Bio;
                actor.FullName = model.FullName;
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
