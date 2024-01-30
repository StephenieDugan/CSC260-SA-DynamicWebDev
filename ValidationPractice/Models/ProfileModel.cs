using System.ComponentModel.DataAnnotations;

public class ProfileModel
{
    [Required(ErrorMessage = "Name is required")]
    public string Name { get; set; }

    [Required(ErrorMessage = "Age is required")]
    [Range(5, int.MaxValue, ErrorMessage = "Age must be 5 or older")]
    public int? Age { get; set; }

    public string Street { get; set; }
    public string City { get; set; }
    public string State { get; set; }
    public string ZipCode { get; set; }

    public bool IsAddressEmpty =>
        string.IsNullOrWhiteSpace(Street) && string.IsNullOrWhiteSpace(City)
        && string.IsNullOrWhiteSpace(State) && string.IsNullOrWhiteSpace(ZipCode);
}
