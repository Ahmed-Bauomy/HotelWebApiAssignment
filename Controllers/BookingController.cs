using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using HotelWebApi.Models;
using HotelWebApi.Repositories;
using HotelWebApi.ViewModels;

namespace HotelWebApi.Controllers
{
    public class BookingController : ApiController
    {
        private readonly IRepository<Booking> BookingRepository;
        public BookingController(IRepository<Booking> _repository)
        {
            BookingRepository = _repository;
        }

        // GET: api/Booking
        public IHttpActionResult GetBookings()
        {
            return Ok(BookingRepository.GetAllItems());
        }

        // GET: api/Booking/5
        [ResponseType(typeof(Booking))]
        public IHttpActionResult GetBooking(string id)
        {
            Booking booking = BookingRepository.GetItem(id);
            if (booking == null)
            {
                return NotFound();
            }

            return Ok(booking);
        }
         // PUT: api/Booking/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutBooking(string id, Booking booking)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != booking.BookingId)
            {
                return BadRequest();
            }


            try
            {
                BookingRepository.EditItem(booking);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (BookingExists(id)== null)
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Booking
        [ResponseType(typeof(Booking))]
        public IHttpActionResult PostBooking(Booking booking)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            BookingRepository.AddItem(booking);

            return CreatedAtRoute("DefaultApi", new { id = booking.BookingId }, booking);
        }

        // DELETE: api/Booking/5
        [ResponseType(typeof(Booking))]
        public IHttpActionResult DeleteBooking(string id)
        {
            Booking booking = BookingRepository.GetItem(id);
            if (booking == null)
            {
                return NotFound();
            }

            BookingRepository.DeleteItem(id);

            return Ok(booking);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                BookingRepository.Dispose();
            }
            base.Dispose(disposing);
        }

        private Booking BookingExists(string id)
        {
            return BookingRepository.GetItem(id);
        }
    }
}