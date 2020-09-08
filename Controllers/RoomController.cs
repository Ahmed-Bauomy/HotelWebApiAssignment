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
    public class RoomController : ApiController
    {
        private readonly IRepository<Room> RoomRepository;
        public RoomController(IRepository<Room> _repository)
        {
            RoomRepository = _repository;
        }

        // GET: api/Room
        public IHttpActionResult GetRooms()
        {
            return Ok(RoomRepository.GetAllItems());
        }

        // GET: api/Room/5
        [ResponseType(typeof(Room))]
        public IHttpActionResult GetRoom(int id)
        {
            Room room = RoomRepository.GetItem(id.ToString());
            if (room == null)
            {
                return NotFound();
            }

            return Ok(room);
        }
        [Route("api/AvailableRooms")]
        public IHttpActionResult PostBookingAvailableRooms(BookingAvailabilityViewModel model)
        {
            var rooms = RoomRepository.GetAllItems().AsEnumerable().Where(R => R.BranchId == model.BranchId)
                                                    .Select(R => R.Bookings.All(b => (b.StartDate != model.StartDate) && (b.EndDate != model.EndDate) &&
                                                                                     (b.StartDate > model.EndDate) && 
                                                                                     (b.EndDate < model.StartDate) ));
            if(rooms == null)
            {
                return NotFound();
            }
            return Ok(rooms);
        }
        // PUT: api/Room/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutRoom(int id, Room room)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != room.RoomId)
            {
                return BadRequest();
            }
            try
            {
                RoomRepository.EditItem(room);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (RoomExists(id)== null)
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

        // POST: api/Room
        [ResponseType(typeof(Room))]
        public IHttpActionResult PostRoom(Room room)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            RoomRepository.AddItem(room);
            return CreatedAtRoute("DefaultApi", new { id = room.RoomId }, room);
        }

        // DELETE: api/Room/5
        [ResponseType(typeof(Room))]
        public IHttpActionResult DeleteRoom(int id)
        {
            Room room = RoomRepository.GetItem(id.ToString());
            if (room == null)
            {
                return NotFound();
            }

            RoomRepository.DeleteItem(id.ToString());

            return Ok(room);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                RoomRepository.Dispose();
            }
            base.Dispose(disposing);
        }

        private Room RoomExists(int id)
        {
            return RoomRepository.GetItem(id.ToString());
        }
    }
}