﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

/// <summary>
/// Event describes the relations binding persons and occurrences referring to dictionary positions
/// </summary>
namespace ClassLibrary
{
    [DataContract()]
    [Serializable]
    public class Event
    {
        private Client client;
        private VehicleState vehicleState;
        private DateTimeOffset rentalOfDate;
        private DateTimeOffset returnOfDate;

        [DataMember()]
        public Client Client { get => client; set => client = value; }
        [DataMember()]
        public DateTimeOffset RentalOfDate { get => rentalOfDate; set => rentalOfDate = value; }
        [DataMember()]
        public DateTimeOffset ReturnOfDate { get => returnOfDate; set => returnOfDate = value; }
        [DataMember()]
        public VehicleState VehicleState { get => vehicleState; set => vehicleState = value; }

        public override bool Equals(object obj)
        {
            var @event = obj as Event;
            return @event != null &&
                   EqualityComparer<Client>.Default.Equals(client, @event.client) &&
                   EqualityComparer<VehicleState>.Default.Equals(vehicleState, @event.vehicleState) &&
                   rentalOfDate.Equals(@event.rentalOfDate) &&
                   returnOfDate.Equals(@event.returnOfDate);
        }

        public override int GetHashCode()
        {
            var hashCode = -1468429342;
            hashCode = hashCode * -1521134295 + EqualityComparer<Client>.Default.GetHashCode(client);
            hashCode = hashCode * -1521134295 + EqualityComparer<VehicleState>.Default.GetHashCode(vehicleState);
            hashCode = hashCode * -1521134295 + EqualityComparer<DateTimeOffset>.Default.GetHashCode(rentalOfDate);
            hashCode = hashCode * -1521134295 + EqualityComparer<DateTimeOffset>.Default.GetHashCode(returnOfDate);
            return hashCode;
        }

        public override string ToString()
        {
            return "Wypozyczenia dokonal: " + this.Client + "" + this.VehicleState + "Rental of date: " + this.RentalOfDate + 
                   " Return of date: " + this.ReturnOfDate + "\n"; 
        }

    }
}
