
namespace Modelo 
{
    public class Customer
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public required Address HomeAddress { get; set; } 
        public required Address WorkAddress { get; set; } 
    }
}