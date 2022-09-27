﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SampleProject.Models;

namespace SampleProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserRegistrationsController : ControllerBase
    {
        private readonly SampleProjectContext _context;

        public UserRegistrationsController(SampleProjectContext context)
        {
            _context = context;
        }

        // GET: api/UserRegistrations
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserRegistration>>> GetUserRegistration()
        {
            return await _context.UserRegistration.ToListAsync();
        }

        // GET: api/UserRegistrations/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UserRegistration>> GetUserRegistration(Guid id)
        {
            var userRegistration = await _context.UserRegistration.FindAsync(id);

            if (userRegistration == null)
            {
                return NotFound();
            }

            return userRegistration;
        }

        // PUT: api/UserRegistrations/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUserRegistration(Guid id, UserRegistration userRegistration)
        {
            if (id != userRegistration.Id)
            {
                return BadRequest();
            }

            _context.Entry(userRegistration).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserRegistrationExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/UserRegistrations
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<UserRegistration>> PostUserRegistration(UserRegistration userRegistration)
        {
            _context.UserRegistration.Add(userRegistration);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUserRegistration", new { id = userRegistration.Id }, userRegistration);
        }

        // DELETE: api/UserRegistrations/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUserRegistration(Guid id)
        {
            var userRegistration = await _context.UserRegistration.FindAsync(id);
            if (userRegistration == null)
            {
                return NotFound();
            }

            _context.UserRegistration.Remove(userRegistration);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpGet("IsValidUser/{emailAddress}/{password}")]
        public UserRegistration IsValidUser(string emailAddress, string password)
        {
            var user =  _context.UserRegistration.FirstOrDefault(user=> user.EmailAddress == emailAddress && user.Password==password);
            return user;
        }

        private bool UserRegistrationExists(Guid id)
        {
            return _context.UserRegistration.Any(e => e.Id == id);
        }
    }
}
