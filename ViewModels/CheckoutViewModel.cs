using System.ComponentModel.DataAnnotations;

namespace deskly_ui.ViewModels;

public class CheckoutViewModel
{
    public CartViewModel Cart { get; set; } = new();

    [Required(ErrorMessage = "Ad alanı zorunludur.")]
    [Display(Name = "Ad")]
    public string FirstName { get; set; } = string.Empty;

    [Required(ErrorMessage = "Soyad alanı zorunludur.")]
    [Display(Name = "Soyad")]
    public string LastName { get; set; } = string.Empty;

    [Required(ErrorMessage = "E-posta alanı zorunludur.")]
    [EmailAddress(ErrorMessage = "Geçerli bir e-posta adresi giriniz.")]
    [Display(Name = "E-posta")]
    public string Email { get; set; } = string.Empty;

    [Required(ErrorMessage = "Telefon alanı zorunludur.")]
    [Phone(ErrorMessage = "Geçerli bir telefon numarası giriniz.")]
    [Display(Name = "Telefon")]
    public string Phone { get; set; } = string.Empty;

    [Required(ErrorMessage = "Adres alanı zorunludur.")]
    [Display(Name = "Adres")]
    public string Address { get; set; } = string.Empty;

    [Required(ErrorMessage = "Şehir alanı zorunludur.")]
    [Display(Name = "Şehir")]
    public string City { get; set; } = string.Empty;

    [Required(ErrorMessage = "İlçe alanı zorunludur.")]
    [Display(Name = "İlçe")]
    public string District { get; set; } = string.Empty;

    [Display(Name = "Posta kodu")]
    public string PostalCode { get; set; } = string.Empty;

    [Display(Name = "Adres başlığı")]
    public string AddressTitle { get; set; } = string.Empty;

    [Required(ErrorMessage = "Teslimat yöntemi seçiniz.")]
    [Display(Name = "Teslimat yöntemi")]
    public string ShippingMethod { get; set; } = "standard";

    [Required(ErrorMessage = "Kart üzerindeki isim zorunludur.")]
    [Display(Name = "Kart üzerindeki isim")]
    public string CardHolder { get; set; } = string.Empty;

    [Required(ErrorMessage = "Kart numarası zorunludur.")]
    [RegularExpression(
        @"^[0-9\s]{16,19}$",
        ErrorMessage = "Geçerli bir kart numarası giriniz.")]
    [Display(Name = "Kart numarası")]
    public string CardNumber { get; set; } = string.Empty;

    [Required(ErrorMessage = "Son kullanma tarihi zorunludur.")]
    [RegularExpression(
        @"^(0[1-9]|1[0-2])\/[0-9]{2}$",
        ErrorMessage = "Tarihi AA/YY formatında giriniz.")]
    [Display(Name = "Son kullanma tarihi")]
    public string Expiry { get; set; } = string.Empty;

    [Required(ErrorMessage = "CVV alanı zorunludur.")]
    [RegularExpression(
        @"^[0-9]{3,4}$",
        ErrorMessage = "CVV 3 veya 4 rakam olmalıdır.")]
    [Display(Name = "CVV")]
    public string Cvv { get; set; } = string.Empty;
}