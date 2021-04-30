using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HVK_ZZTop.Models;

namespace HVK_ZZTop.Models {
    public class PetReservationAndReservationViewModel {
        public Reservation Reservation { get; set; }
        public PetReservation PetReservation { get; set; }
        public List<Reservation> ReservationList { get; set; }
        public List<PetReservation> PetReservationList { get; set; }
        public List<PetReservationService> PetReservationService { get; set; }

        public List<Medication> MedicationList { get; set; }
        public Medication Medication { get; set; }

        public bool Walks { get; set; }

        public bool PlayTime { get; set; }

        public PetReservationAndReservationViewModel() {
        }

        public PetReservationAndReservationViewModel(Reservation reservation, PetReservation petReservation, List<PetReservationService> petReservationService, List<Medication> medicationList) {
            Reservation = reservation;
            PetReservation = petReservation;
            PetReservationService = petReservationService;
            MedicationList = medicationList;
        }

        public PetReservationAndReservationViewModel(Reservation reservation, PetReservation petReservation, List<PetReservationService> petReservationService, Medication medication) {
            Reservation = reservation;
            PetReservation = petReservation;
            PetReservationService = petReservationService;
            Medication = medication;
        }

        public PetReservationAndReservationViewModel(List<Reservation> reservationList, List<PetReservation> petReservationList) {
            ReservationList = reservationList;
            PetReservationList = petReservationList;
        }
    }
}
