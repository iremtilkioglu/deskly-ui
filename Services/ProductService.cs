using deskly_ui.Models;

namespace deskly_ui.Services;

public class ProductService
{
    public List<Product> GetAllProducts()
    {
        return new List<Product>
        {
            new Product
            {
                Id = 1,
                Name = "Aura Monitör Standı",
                Slug = "aura-monitor-standi",
                ShortDescription = "Minimal alüminyum monitör standı",
                Description = "Masa düzenini yükselten, sade ve dayanıklı monitör standı.",
                Price = 2499,
                OldPrice = 2999,
                Category = "Monitor Standı",
                ImageUrl = "/images/products/aura-monitor-stand.png",
                IsFeatured = true,
                IsBestSeller = true,

                Variants = new List<ProductVariant>
                {
                    new ProductVariant
                    {
                        ColorName = "Siyah",
                        ColorCode = "#2B313C",
                        ImageUrl = "/images/products/aura-monitor-stand.png"
                    },
                    new ProductVariant
                    {
                        ColorName = "Meşe",
                        ColorCode = "#C8A46A",
                        ImageUrl = "/images/products/aura-monitor-stand-oak.png"
                    },
                    new ProductVariant
                    {
                        ColorName = "Ceviz",
                        ColorCode = "#7A4E3A",
                        ImageUrl = "/images/products/aura-monitor-stand-walnut.png"
                    }
                }
            },

            new Product
            {
                Id = 2,
                Name = "Luna Masa Lambası",
                Slug = "luna-masa-lambasi",
                ShortDescription = "Yumuşak ışıklı modern masa lambası",
                Description = "Çalışma alanınız için dengeli ışık sağlayan premium masa lambası.",
                Price = 1299,
                Category = "Aydınlatma",
                ImageUrl = "/images/products/luna-desk-lamp.png",
                IsFeatured = true,
                IsNew = true,

                Variants = new List<ProductVariant>
                {
                    new ProductVariant
                    {
                        ColorName = "Siyah",
                        ColorCode = "#23272D",
                        ImageUrl = "/images/products/luna-desk-lamp.png"
                    },
                    new ProductVariant
                    {
                        ColorName = "Gri",
                        ColorCode = "#73777B",
                        ImageUrl = "/images/products/luna-desk-lamp-gray.png"
                    },
                    new ProductVariant
                    {
                        ColorName = "Gümüş",
                        ColorCode = "#C4C6C8",
                        ImageUrl = "/images/products/luna-desk-lamp-silver.png"
                    }
                }
            },

            new Product
            {
                Id = 3,
                Name = "ChargePad Wireless",
                Slug = "chargepad-wireless",
                ShortDescription = "Minimal kablosuz şarj pedi",
                Description = "Telefonunuzu masanızda düzenli ve erişilebilir tutan kablosuz şarj pedi.",
                Price = 999,
                OldPrice = 1199,
                Category = "Şarj",
                ImageUrl = "/images/products/chargepad-wireless.png",
                IsFeatured = true,
                IsBestSeller = true,

                Variants = new List<ProductVariant>
                {
                    new ProductVariant
                    {
                        ColorName = "Siyah",
                        ColorCode = "#22252A",
                        ImageUrl = "/images/products/chargepad-wireless.png"
                    },
                    new ProductVariant
                    {
                        ColorName = "Beyaz",
                        ColorCode = "#F1F0EC",
                        ImageUrl = "/images/products/chargepad-wireless-white.png"
                    },
                    new ProductVariant
                    {
                        ColorName = "Gri",
                        ColorCode = "#77797D",
                        ImageUrl = "/images/products/chargepad-wireless-gray.png"
                    }
                }
            },

            new Product
            {
                Id = 4,
                Name = "Deskly Felt Desk Mat",
                Slug = "deskly-felt-desk-mat",
                ShortDescription = "Geniş yüzeyli premium keçe desk mat",
                Description = "Klavyeniz ve mouse için premium keçe yüzey.",
                Price = 799,
                Category = "Mouse Pad",
                ImageUrl = "/images/products/deskly-felt-desk-mat.png",
                IsNew = true,

                Variants = new List<ProductVariant>
                {
                    new ProductVariant
                    {
                        ColorName = "Antrasit",
                        ColorCode = "#3B3D40",
                        ImageUrl = "/images/products/deskly-felt-desk-mat.png"
                    },
                    new ProductVariant
                    {
                        ColorName = "Gri",
                        ColorCode = "#B7B9BA",
                        ImageUrl = "/images/products/deskly-felt-desk-mat-gray.png"
                    },
                    new ProductVariant
                    {
                        ColorName = "Bej",
                        ColorCode = "#D5C6AF",
                        ImageUrl = "/images/products/deskly-felt-desk-mat-beige.png"
                    }
                }
            },

            new Product
            {
                Id = 5,
                Name = "Deskly Organizer",
                Slug = "deskly-organizer",
                ShortDescription = "Premium masa düzenleyici",
                Description = "Kalem ve aksesuarlar için minimalist organizer.",
                Price = 649,
                Category = "Organizer",
                ImageUrl = "/images/products/deskly-organizer.png",
                IsBestSeller = true,

                Variants = new List<ProductVariant>
                {
                    new ProductVariant
                    {
                        ColorName = "Siyah",
                        ColorCode = "#25282D",
                        ImageUrl = "/images/products/deskly-organizer.png"
                    },
                    new ProductVariant
                    {
                        ColorName = "Meşe",
                        ColorCode = "#C99D61",
                        ImageUrl = "/images/products/deskly-organizer-oak.png"
                    },
                    new ProductVariant
                    {
                        ColorName = "Ceviz",
                        ColorCode = "#714634",
                        ImageUrl = "/images/products/deskly-organizer-walnut.png"
                    }
                }
            },

            new Product
            {
                Id = 6,
                Name = "Flow Wireless Mouse",
                Slug = "flow-wireless-mouse",
                ShortDescription = "Ergonomik kablosuz mouse",
                Description = "Sessiz, hafif ve modern çalışma deneyimi.",
                Price = 1199,
                Category = "Mouse",
                ImageUrl = "/images/products/flow-wireless-mouse.png",
                IsNew = true,

                Variants = new List<ProductVariant>
                {
                    new ProductVariant
                    {
                        ColorName = "Siyah",
                        ColorCode = "#282B30",
                        ImageUrl = "/images/products/flow-wireless-mouse.png"
                    },
                    new ProductVariant
                    {
                        ColorName = "Kum",
                        ColorCode = "#D4C3AA",
                        ImageUrl = "/images/products/flow-wireless-mouse-sand.png"
                    },
                    new ProductVariant
                    {
                        ColorName = "Beyaz",
                        ColorCode = "#EFEDE8",
                        ImageUrl = "/images/products/flow-wireless-mouse-white.png"
                    }
                }
            },

            new Product
            {
                Id = 7,
                Name = "Lift Laptop Stand",
                Slug = "lift-laptop-stand",
                ShortDescription = "Ergonomik laptop standı",
                Description = "Daha iyi duruş için premium alüminyum stand.",
                Price = 1599,
                Category = "Laptop Standı",
                ImageUrl = "/images/products/lift-laptop-stand.png",
                IsFeatured = true,

                Variants = new List<ProductVariant>
                {
                    new ProductVariant
                    {
                        ColorName = "Gümüş",
                        ColorCode = "#C4C6C7",
                        ImageUrl = "/images/products/lift-laptop-stand.png"
                    },
                    new ProductVariant
                    {
                        ColorName = "Gri",
                        ColorCode = "#73767A",
                        ImageUrl = "/images/products/lift-laptop-stand-gray.png"
                    },
                    new ProductVariant
                    {
                        ColorName = "Siyah",
                        ColorCode = "#25282C",
                        ImageUrl = "/images/products/lift-laptop-stand-black.png"
                    }
                }
            },

            new Product
            {
                Id = 8,
                Name = "Deskly Headphone Stand",
                Slug = "deskly-headphone-stand",
                ShortDescription = "Minimal kulaklık standı",
                Description = "Kulaklığınızı düzenli tutan premium stand.",
                Price = 699,
                Category = "Aksesuar",
                ImageUrl = "/images/products/deskly-headphone-stand.png",

                Variants = new List<ProductVariant>
                {
                    new ProductVariant
                    {
                        ColorName = "Siyah",
                        ColorCode = "#292B30",
                        ImageUrl = "/images/products/deskly-headphone-stand.png"
                    },
                    new ProductVariant
                    {
                        ColorName = "Meşe",
                        ColorCode = "#C59A61",
                        ImageUrl = "/images/products/deskly-headphone-stand-oak.png"
                    },
                    new ProductVariant
                    {
                        ColorName = "Ceviz",
                        ColorCode = "#704534",
                        ImageUrl = "/images/products/deskly-headphone-stand-walnut.png"
                    }
                }
            }
        };
    }
}