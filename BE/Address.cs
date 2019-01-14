using System;

namespace BE
{
    public struct Address
    {
        public string street_name;
        public int building_number;
        public string city;

        public Address(string street_name, int building_number, string city)
        {
            this.street_name = street_name ?? throw new ArgumentNullException(nameof(street_name));
            this.building_number = building_number;
            this.city = city ?? throw new ArgumentNullException(nameof(city));
        }

        public override string ToString()
        {
            return city + " " + street_name + (building_number != 0 ? " (" + building_number + ")" : "");
        }
        public double getDistance(Address address)
        {
            Random random = new Random();
            return random.NextDouble() * 1000;
        }
    }
}