namespace deskly_ui.Models.Session;

public sealed class WishlistSessionItem
{
    public int ProductId { get; set; }
    public string? SelectedColor { get; set; }
    public DateTime AddedAt { get; set; }
}
