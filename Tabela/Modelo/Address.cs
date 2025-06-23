namespace Modelo 
{
    public class Address
    {
        public string Street { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }
        public string FullAddress { get; set; } 
        public object Id { get; set; }
        public string Country { get; set; }
        public string Street1 { get; set; }
        public string PostalCode { get; set; }
        public string Street2 { get; set; }
        public string AddressType { get; set; }

        public static implicit operator Address(string addressString)
        {
            return new Address { FullAddress = addressString };
        }

        public override string ToString()
        {
            return FullAddress ?? $"{Street}, {City} - {State}";
        }
    }
}