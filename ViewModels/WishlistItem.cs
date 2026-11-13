using System;

namespace deskly_ui.Models;

public class WishlistItem
{
    public int ProductId { get; set; }
    public string? SelectedColor { get; set; }

    public Product Product { get; set; } = null!;

    public DateTime AddedAt { get; set; } = DateTime.Now;
}