namespace batch15webAPI
{
    public class Member
    {
        public string ChandaNo { get; set; }
        public string Category { get; set; }
        public string Surname { get; set; }
        public string FirstName { get; set; }
        public string AuxillaryBodyName { get; set; }
        public string MiddleName { get; set; }
        public virtual DateTime? DateOfBirth { get; set; }
        public string Email { get; set; }
        public string PhoneNo { get; set; }
        public int JamaatId { get; set; }
        public string JamaatName { get; set; }
        public int CircuitId { get; set; }
        public string CircuitCode { get; set; }
        public string CircuitName { get; set; }
        public string Sex { get; set; }
        public string MaritalStatus { get; set; }
        public string Address { get; set; }
        public string NextOfKinPhoneNo { get; set; }
        public string NextOfKinName { get; set; }
        public string Nationality { get; set; }
        public string PhotoUrl { get; set; }
    }
}
