using System;
using System.Collections.Generic;
using System.Linq;
using HMS.Helpers;

namespace HMS.Admin_Functionalities
{
    public class DoctorAvailabilityService
    {
        private readonly IDoctorAvailabilityRepository _repo;
        private readonly IAppointmentRepository _apptRepo;

        public DoctorAvailabilityService(IDoctorAvailabilityRepository repo, IAppointmentRepository apptRepo)
        {
            _repo = repo;
            _apptRepo = apptRepo;
        }

        public Result AddAvailability(DoctorAvailability a)
        {
            if (a.EndAt <= a.StartAt)
                return Result.Fail("End time must be after start time.");

            _repo.Add(a);
            return Result.Ok("Availability added.");
        }

        public Result RemoveAvailability(int availabilityId)
        {
            var existing = _repo.GetById(availabilityId);
            if (existing == null)
                return Result.Fail("Availability not found.");

            _repo.Remove(availabilityId);
            return Result.Ok("Availability removed.");
        }

        public IEnumerable<(DateTime start, DateTime end)> GetOpenSlots(
            int doctorId, TimeSpan slotLength)
        {
            var availabilities = _repo.GetAvailableByDoctor(doctorId).ToList();

            var appointments = _apptRepo.GetByDoctor(doctorId, DateTime.MinValue, DateTime.MaxValue)
                                        .Where(a => a.Status == "Booked")
                                        .ToList();

            var slots = new List<(DateTime start, DateTime end)>();

            foreach (var a in availabilities)
            {
                if (a.EndAt <= a.StartAt) continue;

                var cursor = a.StartAt;
                var endAvail = a.EndAt;

                while (cursor < endAvail)
                {
                    var slotStart = cursor;
                    var slotEnd = cursor + slotLength;

                    if (slotEnd > endAvail)
                        slotEnd = endAvail;

                    bool conflict = appointments.Any(ap => ap.StartAt < slotEnd && ap.EndAt > slotStart);
                    if (!conflict && slotStart < slotEnd)
                        slots.Add((slotStart, slotEnd));

                    cursor = cursor.Add(slotLength);
                }
            }

            return slots;
        }

        public IEnumerable<DoctorAvailability> GetRawAvailabilities(int doctorId)
        {
            return _repo.GetAvailableByDoctor(doctorId);
        }

        public IEnumerable<(int DoctorID, DoctorAvailability Availability)> GetAllAvailabilities()
        {
            var doctors = _repo.GetDoctorsWithAvailability();
            return doctors.Select(a => (a.DoctorID, a));
        }
    }
}
